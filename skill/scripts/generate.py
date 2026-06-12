"""
Proof-of-concept generator driver.

Loads a model.csv via metamodel.build_model(), reads a template-definition
CSV (same format as templates/database-pgsql.csv etc.), and renders the
subset of templates that have been ported to skill/scripts/templates/.

Unported template rows are skipped with a note -- this is a PoC covering the
database-pgsql registry only, to validate the templating approach before
porting the full ~100-template suite.

Usage:
    python3 generate.py <model.csv> <jumpstart-templates-dir> <registry.csv> <output-dir>
"""

from __future__ import annotations

import csv
import os
import sys

from jinja2 import Environment, FileSystemLoader

from metamodel import build_model
from render_pgsql import render_table

SCRIPT_DIR = os.path.dirname(os.path.abspath(__file__))
PORTED_TEMPLATES_DIR = os.path.join(SCRIPT_DIR, "templates", "database-pgsql")

# Templates rendered directly in Python rather than via Jinja2 (complex
# control flow -- see render_pgsql.py).
PYTHON_RENDERED = {"template.table.generated.sql.cshtml": render_table}


def filename_for(template_basename: str, file_name: str) -> str:
    """Port of: targetFile = templateFile.Replace("template", model.FileName).Replace(".cshtml", "")"""
    base = template_basename
    for ext in (".cshtml", ".j2"):
        if base.endswith(ext):
            base = base[: -len(ext)]
            break
    return base.replace("template", file_name)


def write(out_dir: str, filename: str, content: str) -> None:
    os.makedirs(out_dir, exist_ok=True)
    path = os.path.join(out_dir, filename)
    with open(path, "w") as f:
        f.write(content)
    print(f"wrote {path}")


def generate(model_csv: str, templates_dir: str, registry_csv: str, output_root: str) -> None:
    model = build_model(model_csv, templates_dir)
    env = Environment(loader=FileSystemLoader(PORTED_TEMPLATES_DIR), keep_trailing_newline=True)

    with open(registry_csv, newline="") as f:
        rows = list(csv.DictReader(f))

    for row in rows:
        ttype = (row.get("TEMPLATE_TYPE") or "").strip()
        template_path = (row.get("TEMPLATE_PATH") or "").strip()
        output_dir = (row.get("OUTPUT_DIR") or "").strip().lstrip("./")
        template_basename = os.path.basename(template_path)
        j2_name = template_basename.replace(".cshtml", ".j2")
        out_dir = os.path.join(output_root, output_dir)

        if template_basename in PYTHON_RENDERED:
            renderer = PYTHON_RENDERED[template_basename]
            for obj in model.objects:
                content = renderer(obj)
                if not content:
                    continue
                write(out_dir, filename_for(template_basename, obj.domain_obj), content)
            continue

        if not os.path.exists(os.path.join(PORTED_TEMPLATES_DIR, j2_name)):
            print(f"skip (not ported): {template_path}")
            continue

        template = env.get_template(j2_name)

        if ttype == "model":
            content = template.render(model=model)
            write(out_dir, filename_for(template_basename, model.name), content)
        elif ttype == "schema":
            for schema in model.schemas.values():
                content = template.render(schema=schema)
                write(out_dir, filename_for(template_basename, schema.name), content)
        elif ttype == "object":
            for obj in model.objects:
                if obj.is_view:
                    continue
                content = template.render(obj=obj)
                write(out_dir, filename_for(template_basename, obj.domain_obj), content)
        else:
            print(f"skip (unsupported template type '{ttype}'): {template_path}")


if __name__ == "__main__":
    model_csv, templates_dir, registry_csv, output_root = sys.argv[1:5]
    generate(model_csv, templates_dir, registry_csv, output_root)
