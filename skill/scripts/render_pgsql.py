"""
Port of templates/database/pgsql/ddl/template.table.generated.sql.cshtml

This template's logic (especially the CREATE VIEW branch, which walks
ViewRelationships with a work queue) is awkward to express cleanly in Jinja2
control-flow, so it's ported directly to Python and exposed as a single
function. The other pgsql templates (database/schema/sequence/rwkindex) are
simple enough to live as .j2 files.
"""

from __future__ import annotations

from metamodel import MetaObject, ViewRelationship


def render_table(meta_object: MetaObject) -> str:
    if meta_object.is_view:
        return _render_view(meta_object)
    return _render_create_table(meta_object)


def _render_view(meta_object: MetaObject) -> str:
    if not meta_object.view_relationships:
        return ""

    select_columns: list[str] = []
    join_clauses: list[str] = []

    first_relationship = meta_object.view_relationships[0]
    first_alias = first_relationship.table_alias

    select_columns.append(first_alias + ".id AS id")

    # RWK attributes from all relationships (BFS over nested relationships)
    work_queue: list[ViewRelationship] = list(meta_object.view_relationships)
    work_index = 0
    while work_index < len(work_queue):
        relationship = work_queue[work_index]
        work_index += 1

        for attr in relationship.rwk_attributes:
            original_column_name = attr.name[len(relationship.column_prefix) + 1:]
            select_expr = f"{attr.table_alias}.{original_column_name} AS {attr.name}"
            select_columns.append(select_expr)

        work_queue.extend(relationship.nested_relationships)

    # JOIN clauses for nested relationships of the first FK
    work_queue = [first_relationship]
    work_index = 0
    while work_index < len(work_queue):
        relationship = work_queue[work_index]
        work_index += 1
        parent_alias = first_alias if relationship is first_relationship else relationship.table_alias

        for nested in relationship.nested_relationships:
            join_condition = f"{parent_alias}.{nested.fk_attribute.name} = {nested.table_alias}.id"
            join_clauses.append(
                f"LEFT OUTER JOIN {nested.fk_object.schema_name}.{nested.fk_object.table_name} "
                f"{nested.table_alias} ON {join_condition}"
            )
            work_queue.append(nested)

    # Remaining FK tables
    for relationship in meta_object.view_relationships[1:]:
        anchor_table_name = first_relationship.fk_object.table_name
        fk_column_in_joined_table = next(
            (a for a in relationship.fk_object.attributes
             if a.fk_table and a.fk_table == anchor_table_name),
            None,
        )

        if fk_column_in_joined_table is not None:
            join_condition = f"{relationship.table_alias}.{fk_column_in_joined_table.name} = {first_alias}.id"
            join_clauses.append(
                f"LEFT OUTER JOIN {relationship.fk_object.schema_name}.{relationship.fk_object.table_name} "
                f"{relationship.table_alias} ON {join_condition}"
            )

        work_queue = [relationship]
        work_index = 0
        while work_index < len(work_queue):
            rel = work_queue[work_index]
            work_index += 1
            parent_alias = relationship.table_alias if rel is relationship else rel.table_alias

            for nested in rel.nested_relationships:
                nested_join_condition = f"{parent_alias}.{nested.fk_attribute.name} = {nested.table_alias}.id"
                join_clauses.append(
                    f"LEFT OUTER JOIN {nested.fk_object.schema_name}.{nested.fk_object.table_name} "
                    f"{nested.table_alias} ON {nested_join_condition}"
                )
                work_queue.append(nested)

    select_clause = ",\n    ".join(select_columns)
    from_clause = f"{first_relationship.fk_object.schema_name}.{first_relationship.fk_object.table_name} {first_alias}"
    join_clause = ("\n" + "\n".join(join_clauses)) if join_clauses else ""

    return (
        f"\nCREATE VIEW {meta_object.schema_name}.{meta_object.table_name} AS\n"
        f"SELECT \n"
        f"    {select_clause}\n"
        f"FROM {from_clause}{join_clause};\n"
    )


def _render_create_table(meta_object: MetaObject) -> str:
    lines: list[str] = []
    lines.append(f"\nCREATE TABLE {meta_object.schema_name}.{meta_object.table_name} (")

    n = len(meta_object.attributes)
    for i, column in enumerate(meta_object.attributes):
        pk = "PRIMARY KEY" if column.name == "txn_id" else ""

        length = ""
        if column.length and column.length != "NULL":
            length = f"({column.length})"
        if column.sql_data_type == "numeric":
            length = "(18,4)"

        nullable = ""
        comma = "" if i == n - 1 else ","

        lines.append(f"\t\t{column.name} {column.sql_data_type}{length} {pk}{nullable}{comma}")

    lines.append(");")
    lines.append(f"CREATE INDEX ON {meta_object.schema_name}.{meta_object.table_name} (id, is_active);")
    return "\n".join(lines) + "\n"
