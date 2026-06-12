"""
Python port of jumpstart's MetaModel core (src/metamodel.cs, csvloader.cs,
coreloader.cs, globalcsvloader.cs, Utils.cs).

This module is a faithful, line-by-line port intended to be a drop-in
replacement for the C# MetaModel pipeline, so that templates can be rendered
with a portable templating engine (e.g. Jinja2) without requiring the .NET
toolchain to run the generator itself.

Each class/function below is annotated with the C# source it corresponds to.
"""

from __future__ import annotations

import csv
import json
import os
from dataclasses import dataclass, field
from typing import Optional


# ---------------------------------------------------------------------------
# Utils.cs -> Utils.ConvertToPascalCase
# ---------------------------------------------------------------------------

def convert_to_pascal_case(input_str: Optional[str]) -> str:
    if not input_str:
        return input_str or ""
    parts = input_str.split("_")
    return "".join((p[0].upper() + p[1:].lower()) if p else "" for p in parts)


# ---------------------------------------------------------------------------
# metamodel.cs -> TypeMapping
# ---------------------------------------------------------------------------

class TypeMapping:
    @staticmethod
    def get_base_data_type(data_type: Optional[str]) -> str:
        if not data_type:
            return data_type or ""
        punctuation = "([< "
        index = -1
        for i, ch in enumerate(data_type):
            if ch in punctuation:
                index = i
                break
        if index > 0:
            return data_type[:index].lower().strip()
        return data_type.lower().strip()

    DataTypeMap = {
        "integer": "int",
        "bigint": "long",
        "smallint": "short",
        "serial": "int",
        "bigserial": "long",
        "boolean": "bool",
        "char": "string",
        "varchar": "string",
        "text": "string",
        "date": "DateTime",
        "timestamp": "DateTime",
        "timestamptz": "DateTime",
        "real": "float",
        "double precision": "double",
        "numeric": "decimal",
        "json": "string",
        "uuid": "Guid",
        "bytea": "byte[]",
        "xml": "string",
    }

    ConvertMap = {
        "integer": "ToInt32",
        "bigint": "ToInt64",
        "smallint": "ToInt16",
        "serial": "ToInt32",
        "bigserial": "ToInt64",
        "boolean": "ToBoolean",
        "char": "ToString",
        "varchar": "ToString",
        "text": "ToString",
        "date": "ToDateTime",
        "timestamp": "ToDateTime",
        "timestamptz": "ToDateTime",
        "time": "ToDateTime",
        "timetz": "ToDateTime",
        "real": "ToSingle",
        "double precision": "ToDouble",
        "numeric": "ToDecimal",
        "numeric(18,4)": "ToDecimal",
        "decimal": "ToDecimal",
        "bytea": "ToByte[]",
        "uuid": "Guid.Parse",
        "json": "ToString",
        "jsonb": "ToString",
        "xml": "ToString",
        "money": "ToDecimal",
        "inet": "ToString",
        "cidr": "ToString",
        "macaddr": "ToString",
    }

    InputMap = {
        "integer": "Number",
        "bigint": "Number",
        "smallint": "Number",
        "serial": "Number",
        "bigserial": "Number",
        "boolean": "Radio",
        "char": "Text",
        "varchar": "Text",
        "text": "TextArea",
        "date": "Date",
        "timestamp": "Date",
        "timestamptz": "Date",
        "real": "Number",
        "double precision": "Number",
        "numeric": "Number",
        "numeric(18,4)": "Number",
        "json": "TextArea",
        "uuid": "Text",
        "bytea": "Text",
        "xml": "Text",
    }

    PostgreSQLToMSSQLMap = {
        "smallint": "SMALLINT",
        "integer": "INT",
        "bigint": "BIGINT",
        "serial": "INT IDENTITY(1,1)",
        "bigserial": "BIGINT IDENTITY(1,1)",
        "character": "CHAR",
        "character varying": "VARCHAR",
        "varchar": "VARCHAR",
        "char": "CHAR",
        "text": "TEXT",
        "nchar": "NCHAR",
        "nvarchar": "NVARCHAR",
        "ntext": "NTEXT",
        "numeric": "DECIMAL",
        "decimal": "DECIMAL",
        "real": "REAL",
        "double precision": "FLOAT",
        "float": "FLOAT",
        "money": "MONEY",
        "smallmoney": "SMALLMONEY",
        "date": "DATE",
        "time": "TIME",
        "timestamp": "DATETIME2",
        "timestamp without time zone": "DATETIME2",
        "timestamp with time zone": "DATETIME2",
        "timestamptz": "DATETIME2",
        "time without time zone": "TIME",
        "time with time zone": "TIME",
        "timetz": "TIME",
        "interval": "VARCHAR(50)",
        "boolean": "BIT",
        "bytea": "VARBINARY(MAX)",
        "binary": "BINARY",
        "varbinary": "VARBINARY",
        "uuid": "UNIQUEIDENTIFIER",
        "xml": "XML",
        "json": "NVARCHAR(MAX)",
        "jsonb": "NVARCHAR(MAX)",
        "inet": "VARCHAR(45)",
        "cidr": "VARCHAR(43)",
        "macaddr": "VARCHAR(17)",
        "macaddr8": "VARCHAR(23)",
        "point": "VARCHAR(50)",
        "line": "VARCHAR(100)",
        "lseg": "VARCHAR(100)",
        "box": "VARCHAR(100)",
        "path": "VARCHAR(MAX)",
        "polygon": "VARCHAR(MAX)",
        "circle": "VARCHAR(100)",
        "integer[]": "NVARCHAR(MAX)",
        "text[]": "NVARCHAR(MAX)",
        "varchar[]": "NVARCHAR(MAX)",
    }


# ---------------------------------------------------------------------------
# metamodel.cs -> ChildRelationship / EnumRelationship / ViewRelationship
# ---------------------------------------------------------------------------

@dataclass
class ChildRelationship:
    role: str
    label: str
    obj: "MetaObject"


@dataclass
class EnumRelationship:
    id_column: str
    name_column: str
    enum_attribute: "MetaAttribute"


@dataclass
class ViewRelationship:
    fk_attribute: "MetaAttribute"
    fk_object: "MetaObject"
    table_alias: str
    column_prefix: str
    nested_relationships: list = field(default_factory=list)
    rwk_attributes: list = field(default_factory=list)


# ---------------------------------------------------------------------------
# metamodel.cs -> MetaAttribute
# ---------------------------------------------------------------------------

@dataclass
class MetaAttribute:
    name: str = ""
    file_name: str = ""
    sql_data_type: str = ""
    mssql_data_type: str = ""
    dot_net_type: str = ""
    input_type: str = ""
    convert_method: str = ""
    length: str = ""
    label: str = ""
    rwk: str = "0"
    fk_type: str = ""
    fk_table: str = ""
    fk_object: str = ""
    fk_var: str = ""
    is_nullable: bool = False
    test_data_set: str = ""
    table_alias: str = ""
    _is_global: bool = False

    @property
    def pascal_name(self) -> str:
        return convert_to_pascal_case(self.name)

    def is_global(self) -> bool:
        return self._is_global

    def set_global(self) -> None:
        self._is_global = True

    def to_dict(self) -> dict:
        return {
            "Name": self.name,
            "PascalName": self.pascal_name,
            "SqlDataType": self.sql_data_type,
            "MSSQLDataType": self.mssql_data_type,
            "DotNetType": self.dot_net_type,
            "InputType": self.input_type,
            "ConvertMethod": self.convert_method,
            "Length": self.length,
            "Label": self.label,
            "RWK": self.rwk,
            "FkType": self.fk_type,
            "FkTable": self.fk_table,
            "FkObject": self.fk_object,
            "FkVar": self.fk_var,
            "IsNullable": self.is_nullable,
            "TestDataSet": self.test_data_set,
            "TableAlias": self.table_alias,
            "IsGlobal": self._is_global,
        }


# ---------------------------------------------------------------------------
# metamodel.cs -> MetaObject
# ---------------------------------------------------------------------------

class MetaObject:
    def __init__(self, namespace: str, table_name: str, schema_name: str,
                 label: str, nav_menu: str, uri: str = "", is_audited: bool = True):
        self.namespace = namespace
        self.table_name = table_name
        self.domain_obj = convert_to_pascal_case(table_name)
        self.domain_var = self.domain_obj.lower()
        self.name = table_name
        self.label = label
        self.nav_menu = nav_menu
        self._uri = uri or ""
        self.schema_name = schema_name
        self.file_name = self.domain_obj
        self.is_audited = is_audited

        self.model: Optional["MetaModel"] = None
        self.attributes: list[MetaAttribute] = []
        self.children: list[ChildRelationship] = []
        self.enum_attributes: list[EnumRelationship] = []
        self.view_relationships: list[ViewRelationship] = []

        self._user_attributes: Optional[list[MetaAttribute]] = None
        self._global_attributes: Optional[list[MetaAttribute]] = None

    @property
    def is_view(self) -> bool:
        return self.table_name.lower().endswith("_view")

    @property
    def domain_obj_view(self) -> str:
        return self.domain_obj if self.is_view else self.domain_obj + "View"

    @property
    def domain_const(self) -> str:
        return self.domain_obj.upper()

    @property
    def uri(self) -> str:
        return self._uri if self._uri else self.domain_var

    @property
    def user_attributes(self) -> list[MetaAttribute]:
        if self._user_attributes is None:
            self._user_attributes = [a for a in self.attributes if not a.is_global()]
        return self._user_attributes

    @property
    def global_attributes(self) -> list[MetaAttribute]:
        if self._global_attributes is None:
            self._global_attributes = [a for a in self.attributes if a.is_global()]
        return self._global_attributes

    # -- ProcessChildren -----------------------------------------------
    def process_children(self, all_objects: list["MetaObject"]) -> None:
        for attribute in self.attributes:
            if attribute.fk_type and attribute.fk_type.lower() == "parent" and attribute.fk_table:
                parent_object = next((mo for mo in all_objects if mo.table_name == attribute.fk_table), None)
                if parent_object is not None:
                    role = attribute.name.replace("_id", "")
                    label = attribute.label or attribute.name
                    already_exists = any(
                        c.role == role and c.obj is self for c in parent_object.children
                    )
                    if not already_exists:
                        parent_object.children.append(ChildRelationship(role, label, self))

    # -- ProcessEnumObjects ----------------------------------------------
    def process_enum_objects(self, all_objects: list["MetaObject"]) -> None:
        for attribute in self.attributes:
            if attribute.fk_type and attribute.fk_type.lower() == "enum" and attribute.fk_table:
                enum_object = next((mo for mo in all_objects if mo.table_name == attribute.fk_table), None)
                if enum_object is not None:
                    alias_base = attribute.name
                    if alias_base.endswith("_id"):
                        alias_base = alias_base[:-3]
                    alias = alias_base

                    rwk_attribute = next((a for a in enum_object.attributes if a.rwk == "1"), None)
                    if rwk_attribute is not None:
                        name_column = alias + "_" + rwk_attribute.name
                        if not name_column.lower().endswith("_id"):
                            self.enum_attributes.append(
                                EnumRelationship(attribute.name, name_column, attribute)
                            )

    # -- ProcessView -------------------------------------------------------
    def process_view(self, all_objects: list["MetaObject"]) -> None:
        if not self.is_view:
            return

        foreign_keys = [a for a in self.attributes if a.fk_table and a.name != "id"]
        if not foreign_keys:
            return

        used_aliases: set[str] = set()

        def process_rwk_attributes(fk_object: "MetaObject", column_prefix: str, table_alias: str,
                                    parent_relationship: ViewRelationship, aliases: set[str],
                                    original_view_table_name: str) -> None:
            for attr in fk_object.attributes:
                if attr.rwk == "1":
                    if attr.fk_table:
                        is_self_referential = attr.fk_table == fk_object.table_name
                        if is_self_referential:
                            column_name = column_prefix + "_" + attr.name
                            synthesized = MetaAttribute(
                                name=column_name,
                                sql_data_type=attr.sql_data_type,
                                mssql_data_type=attr.mssql_data_type,
                                dot_net_type=attr.dot_net_type,
                                convert_method=attr.convert_method,
                                input_type=attr.input_type,
                                length=attr.length,
                                label=column_prefix + " " + (attr.label or attr.name),
                                rwk=attr.rwk,
                                fk_type=attr.fk_type,
                                fk_table=attr.fk_table,
                                fk_object=attr.fk_object,
                                fk_var=attr.fk_var,
                                is_nullable=attr.is_nullable,
                                test_data_set=attr.test_data_set,
                                table_alias=table_alias,
                            )
                            self.attributes.append(synthesized)
                            parent_relationship.rwk_attributes.append(synthesized)
                        else:
                            nested_fk_object = next((o for o in all_objects if o.table_name == attr.fk_table), None)
                            if nested_fk_object is not None:
                                nested_alias_base = attr.name
                                if nested_alias_base.endswith("_id"):
                                    nested_alias_base = nested_alias_base[:-3]
                                nested_alias = nested_alias_base
                                counter = 1
                                while nested_alias in aliases:
                                    nested_alias = nested_alias_base + "_" + str(counter)
                                    counter += 1
                                aliases.add(nested_alias)

                                nested_prefix = column_prefix + "_" + nested_alias_base
                                nested_relationship = ViewRelationship(attr, nested_fk_object, nested_alias, nested_prefix)
                                parent_relationship.nested_relationships.append(nested_relationship)

                                process_rwk_attributes(nested_fk_object, nested_prefix, nested_alias,
                                                        nested_relationship, aliases, original_view_table_name)
                    else:
                        column_name = column_prefix + "_" + attr.name
                        synthesized = MetaAttribute(
                            name=column_name,
                            sql_data_type=attr.sql_data_type,
                            mssql_data_type=attr.mssql_data_type,
                            dot_net_type=attr.dot_net_type,
                            convert_method=attr.convert_method,
                            input_type=attr.input_type,
                            length=attr.length,
                            label=column_prefix + " " + (attr.label or attr.name),
                            rwk=attr.rwk,
                            fk_type=attr.fk_type,
                            fk_table=attr.fk_table,
                            fk_object=attr.fk_object,
                            fk_var=attr.fk_var,
                            is_nullable=attr.is_nullable,
                            test_data_set=attr.test_data_set,
                            table_alias=table_alias,
                        )
                        self.attributes.append(synthesized)
                        parent_relationship.rwk_attributes.append(synthesized)

        # First FK as anchor
        first_fk = foreign_keys[0]
        first_fk_object = next((o for o in all_objects if o.table_name == first_fk.fk_table), None)
        counter = 0

        if first_fk_object is not None:
            first_alias_base = first_fk.name
            if first_alias_base.endswith("_id"):
                first_alias_base = first_alias_base[:-3]
            first_alias = first_alias_base
            while first_alias in used_aliases:
                first_alias = first_alias_base + "_" + str(counter)
                counter += 1
            used_aliases.add(first_alias)

            first_relationship = ViewRelationship(first_fk, first_fk_object, first_alias, first_alias_base)
            self.view_relationships.append(first_relationship)

            process_rwk_attributes(first_fk_object, first_alias_base, first_alias,
                                    first_relationship, used_aliases, self.table_name)

        # Remaining FKs
        for fk in foreign_keys[1:]:
            fk_object = next((o for o in all_objects if o.table_name == fk.fk_table), None)
            if fk_object is not None:
                alias_base = fk.name
                if alias_base.endswith("_id"):
                    alias_base = alias_base[:-3]
                alias = alias_base
                counter = 1
                while alias in used_aliases:
                    alias = alias_base + "_" + str(counter)
                    counter += 1
                used_aliases.add(alias)

                relationship = ViewRelationship(fk, fk_object, alias, alias_base)
                self.view_relationships.append(relationship)

                process_rwk_attributes(fk_object, alias_base, alias, relationship, used_aliases, self.table_name)

    def to_dict(self) -> dict:
        return {
            "Namespace": self.namespace,
            "TableName": self.table_name,
            "DomainObj": self.domain_obj,
            "DomainVar": self.domain_var,
            "DomainConst": self.domain_const,
            "DomainObjView": self.domain_obj_view,
            "SchemaName": self.schema_name,
            "Label": self.label,
            "NavMenu": self.nav_menu,
            "Uri": self.uri,
            "IsView": self.is_view,
            "IsAudited": self.is_audited,
            "Attributes": [a.to_dict() for a in self.attributes],
            "UserAttributes": [a.name for a in self.user_attributes],
            "GlobalAttributes": [a.name for a in self.global_attributes],
            "Children": [
                {"Role": c.role, "Label": c.label, "Object": c.obj.table_name}
                for c in self.children
            ],
            "EnumAttributes": [
                {"IdColumn": e.id_column, "NameColumn": e.name_column,
                 "EnumAttribute": e.enum_attribute.name}
                for e in self.enum_attributes
            ],
            "ViewRelationships": [_view_relationship_to_dict(v) for v in self.view_relationships],
        }


def _view_relationship_to_dict(v: ViewRelationship) -> dict:
    return {
        "FkAttribute": v.fk_attribute.name,
        "FkObject": v.fk_object.table_name,
        "TableAlias": v.table_alias,
        "ColumnPrefix": v.column_prefix,
        "RwkAttributes": [a.name for a in v.rwk_attributes],
        "NestedRelationships": [_view_relationship_to_dict(n) for n in v.nested_relationships],
    }


# ---------------------------------------------------------------------------
# metamodel.cs -> MetaSchema
# ---------------------------------------------------------------------------

class MetaSchema:
    def __init__(self, name: str, namespace: str):
        self.name = name
        self.namespace = namespace
        self.objects: list[MetaObject] = []
        self.object_map: dict[str, MetaObject] = {}


# ---------------------------------------------------------------------------
# metamodel.cs -> MetaModel
# ---------------------------------------------------------------------------

class MetaModel:
    def __init__(self, namespace: str):
        self.name = namespace
        self.namespace = namespace
        self.schemas: dict[str, MetaSchema] = {}
        self.objects: list[MetaObject] = []
        self.nav_menus: dict[str, list[MetaObject]] = {}
        self.global_attributes: list[MetaAttribute] = []

    def contains_global_attribute(self, name: str) -> bool:
        return any(a.name == name for a in self.global_attributes)

    # -- Process -------------------------------------------------------
    def process(self) -> None:
        for obj in self.objects:
            obj.process_children(self.objects)
            obj.process_enum_objects(self.objects)
            obj.process_view(self.objects)

    # -- SortMetaObjectsByReference (Tarjan SCC + topo sort) -----------
    def sort_meta_objects_by_reference(self) -> None:
        self.objects = self._sort_meta_objects_by_reference(self.objects)
        for schema in self.schemas.values():
            schema.objects = self._sort_meta_objects_by_reference(schema.objects)

    def _sort_meta_objects_by_reference(self, meta_objects: list[MetaObject]) -> list[MetaObject]:
        adjacency: dict[int, list[int]] = {id(mo): [] for mo in meta_objects}
        by_name = {mo.name: mo for mo in meta_objects}

        for meta_object in meta_objects:
            for attribute in meta_object.attributes:
                if attribute.fk_object:
                    fk_object = by_name.get(attribute.fk_table)
                    if fk_object is not None:
                        adjacency[id(fk_object)].append(id(meta_object))

        sccs = self._tarjan_scc(meta_objects, adjacency)
        sorted_sccs = self._topological_sort_sccs(sccs, adjacency)

        result: list[MetaObject] = []
        for scc in sorted_sccs:
            result.extend(scc)
        return result

    def _tarjan_scc(self, nodes: list[MetaObject], adjacency: dict[int, list[int]]) -> list[list[MetaObject]]:
        by_id = {id(mo): mo for mo in nodes}
        scc_result: list[list[MetaObject]] = []
        index_map: dict[int, int] = {}
        low_link_map: dict[int, int] = {}
        on_stack: set[int] = set()
        stack: list[int] = []
        current_index = [0]

        def strong_connect(v_id: int) -> None:
            index_map[v_id] = current_index[0]
            low_link_map[v_id] = current_index[0]
            current_index[0] += 1
            stack.append(v_id)
            on_stack.add(v_id)

            for w_id in adjacency[v_id]:
                if w_id not in index_map:
                    strong_connect(w_id)
                    low_link_map[v_id] = min(low_link_map[v_id], low_link_map[w_id])
                elif w_id in on_stack:
                    low_link_map[v_id] = min(low_link_map[v_id], index_map[w_id])

            if low_link_map[v_id] == index_map[v_id]:
                scc: list[MetaObject] = []
                while True:
                    node_id = stack.pop()
                    on_stack.discard(node_id)
                    scc.append(by_id[node_id])
                    if node_id == v_id:
                        break
                scc_result.append(scc)

        for node in nodes:
            if id(node) not in index_map:
                strong_connect(id(node))

        return scc_result

    def _topological_sort_sccs(self, sccs: list[list[MetaObject]],
                                adjacency: dict[int, list[int]]) -> list[list[MetaObject]]:
        scc_lookup: dict[int, int] = {}
        for i, scc in enumerate(sccs):
            for mo in scc:
                scc_lookup[id(mo)] = i

        scc_graph: dict[int, set[int]] = {i: set() for i in range(len(sccs))}
        for i, scc in enumerate(sccs):
            for mo in scc:
                for neighbor_id in adjacency[id(mo)]:
                    neighbor_scc = scc_lookup[neighbor_id]
                    if neighbor_scc != i:
                        scc_graph[i].add(neighbor_scc)

        in_degree = {i: 0 for i in range(len(sccs))}
        for from_scc, targets in scc_graph.items():
            for to_scc in targets:
                in_degree[to_scc] += 1

        queue = [i for i in range(len(sccs)) if in_degree[i] == 0]
        sorted_indices: list[int] = []
        qi = 0
        while qi < len(queue):
            current = queue[qi]
            qi += 1
            sorted_indices.append(current)
            for neighbor in scc_graph[current]:
                in_degree[neighbor] -= 1
                if in_degree[neighbor] == 0:
                    queue.append(neighbor)

        if len(sorted_indices) != len(sccs):
            raise RuntimeError("Unable to topologically sort the SCCs.")

        return [sccs[i] for i in sorted_indices]

    def to_dict(self) -> dict:
        return {
            "Namespace": self.namespace,
            "Schemas": {
                name: {
                    "Name": schema.name,
                    "Objects": [o.table_name for o in schema.objects],
                }
                for name, schema in self.schemas.items()
            },
            "Objects": [o.to_dict() for o in self.objects],
            "ObjectOrder": [o.table_name for o in self.objects],
            "NavMenus": {
                menu: [o.table_name for o in objs]
                for menu, objs in self.nav_menus.items()
            },
            "GlobalAttributes": [a.name for a in self.global_attributes],
        }


# ---------------------------------------------------------------------------
# csvloader.cs -> CSVLoader
# ---------------------------------------------------------------------------

class CSVLoader:
    def load(self, model_path: str, meta_model: MetaModel) -> None:
        with open(model_path, newline="", encoding="utf-8-sig") as f:
            reader = csv.DictReader(f)
            for row in reader:
                self._set_namespace(meta_model, row.get("TABLE_CATALOG", "") or "")
                self._add_schema(meta_model, row)

    def _set_namespace(self, meta_model: MetaModel, table_catalog: str) -> None:
        if not meta_model.namespace:
            meta_model.namespace = table_catalog

    def _add_schema(self, meta_model: MetaModel, row: dict) -> None:
        schema_name = row.get("TABLE_SCHEMA") or ""
        schema = meta_model.schemas.get(schema_name)
        if schema is None:
            schema = MetaSchema(schema_name, meta_model.namespace)
            meta_model.schemas[schema_name] = schema
        self._add_object(meta_model, schema, row)

    def _add_object(self, meta_model: MetaModel, schema: MetaSchema, row: dict) -> None:
        table_name = row.get("TABLE_NAME") or ""
        meta_object = schema.object_map.get(table_name)
        if meta_object is None:
            audit_val = (row.get("IS_AUDITED") or "").strip()
            is_audited = (
                audit_val == ""
                or not (audit_val == "0" or audit_val.lower() == "false" or audit_val.lower() == "no")
            )
            meta_object = MetaObject(
                meta_model.namespace,
                table_name,
                row.get("TABLE_SCHEMA") or "",
                row.get("TABLE_LABEL") or "",
                row.get("NAV_MENU") or "",
                row.get("URI") or "",
                is_audited,
            )
            schema.objects.append(meta_object)
            schema.object_map[table_name] = meta_object

        if not any(o.name == table_name for o in meta_model.objects):
            meta_model.objects.append(meta_object)

        if meta_object.nav_menu:
            menu_list = meta_model.nav_menus.setdefault(meta_object.nav_menu, [])
            if not any(o.name == table_name for o in menu_list):
                menu_list.append(meta_object)

        meta_object.model = meta_model
        self._add_attributes(meta_object, row)

    def _add_attributes(self, meta_object: MetaObject, row: dict) -> None:
        column_name = row.get("COLUMN_NAME")
        if column_name is None:
            raise ValueError("metadata record COLUMN_NAME is null")

        if any(a.name == column_name for a in meta_object.attributes):
            return

        data_type = row.get("DATA_TYPE") or ""
        fk_table = (row.get("FK_TABLE") or "")
        is_nullable_raw = (row.get("IS_NULLABLE") or "").strip()

        attribute = MetaAttribute(
            name=column_name,
            sql_data_type=data_type,
            mssql_data_type=TypeMapping.PostgreSQLToMSSQLMap.get(data_type.lower().strip(), data_type),
            length=(row.get("CHARACTER_MAXIMUM_LENGTH") or "").strip(),
            dot_net_type=TypeMapping.DataTypeMap.get(TypeMapping.get_base_data_type(data_type), "object"),
            convert_method=TypeMapping.ConvertMap.get(TypeMapping.get_base_data_type(data_type), ""),
            input_type=TypeMapping.InputMap.get(data_type.lower().strip(), "Text"),
            label=row.get("COLUMN_LABEL") or "",
            rwk=row.get("RWK") or "",
            is_nullable=(is_nullable_raw == "1" or is_nullable_raw.lower() == "yes"),
            fk_table=fk_table.lower(),
            fk_object=convert_to_pascal_case(fk_table.lower()),
            fk_var=convert_to_pascal_case(fk_table.lower()).lower(),
            fk_type=row.get("FK_TYPE") or "",
            test_data_set=row.get("TEST_DATA_SET") or "",
        )
        meta_object.attributes.append(attribute)


# ---------------------------------------------------------------------------
# coreloader.cs -> CoreLoader
# ---------------------------------------------------------------------------

class CoreLoader(CSVLoader):
    def __init__(self, templates_dir: str):
        self.templates_dir = templates_dir

    def load(self, module_csv: str, meta_model: MetaModel) -> None:
        model_path = os.path.join(self.templates_dir, "core", module_csv)
        super().load(model_path, meta_model)

    def _set_namespace(self, meta_model: MetaModel, table_catalog: str) -> None:
        # do nothing -- core.csv must not override the app namespace
        pass


# ---------------------------------------------------------------------------
# globalcsvloader.cs -> GlobalCSVLoader
# ---------------------------------------------------------------------------

class GlobalCSVLoader:
    def __init__(self, templates_dir: str):
        self.templates_dir = templates_dir

    def load(self, global_csv: str, meta_model: MetaModel) -> None:
        model_path = os.path.join(self.templates_dir, "core", global_csv)
        with open(model_path, newline="", encoding="utf-8-sig") as f:
            reader = csv.DictReader(f)
            for row in reader:
                data_type = row.get("DATA_TYPE") or ""
                a = MetaAttribute(
                    name=row.get("COLUMN_NAME") or "",
                    sql_data_type=data_type,
                    mssql_data_type=TypeMapping.PostgreSQLToMSSQLMap.get(data_type.lower(), data_type),
                    length=row.get("CHARACTER_MAXIMUM_LENGTH") or "",
                    dot_net_type=TypeMapping.DataTypeMap.get(data_type.lower(), "object"),
                    convert_method=TypeMapping.ConvertMap.get(data_type.lower(), ""),
                    label=row.get("COLUMN_LABEL") or "",
                )
                a.set_global()

                for meta_object in meta_model.objects:
                    if not meta_object.is_view:
                        if not any(attr.name == a.name for attr in meta_object.attributes):
                            meta_object.attributes.append(a)

                if not any(attr.name == a.name for attr in meta_model.global_attributes):
                    meta_model.global_attributes.append(a)


# ---------------------------------------------------------------------------
# Convenience: full pipeline matching Program.cs
# ---------------------------------------------------------------------------

def build_model(model_path: str, templates_dir: str) -> MetaModel:
    namespace = os.path.splitext(os.path.basename(model_path))[0]
    meta_model = MetaModel(namespace)

    CSVLoader().load(model_path, meta_model)
    CoreLoader(templates_dir).load("core.csv", meta_model)
    GlobalCSVLoader(templates_dir).load("global.csv", meta_model)

    meta_model.process()
    meta_model.sort_meta_objects_by_reference()

    return meta_model


if __name__ == "__main__":
    import sys

    model_path = sys.argv[1]
    templates_dir = sys.argv[2]
    model = build_model(model_path, templates_dir)
    print(json.dumps(model.to_dict(), indent=2))
