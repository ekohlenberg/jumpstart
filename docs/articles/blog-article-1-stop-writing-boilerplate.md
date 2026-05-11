# Jumpstart and AI: A Foundation for the Modern Development Stack

AI coding tools have changed the economics of software development. Tools like Claude Code, GitHub Copilot, and ChatGPT can generate working code from a natural language description, explain a complex codebase in plain English, and implement a feature in minutes that might have taken hours to write by hand. The question for development teams is no longer whether to use AI — it's how to use it well.

Used without structure, AI code generation creates a new class of problem. Every generation is probabilistic. Naming conventions drift. Architectural patterns diverge. A codebase built by prompting an AI across dozens of sessions by multiple developers tends toward inconsistency in ways that are subtle at first and expensive later. And when the data model changes — a new column, a new relationship, a new table — there is no reliable way to propagate that change through every affected layer without introducing gaps.

Jumpstart is designed to solve exactly this problem. It's not a competitor to AI tools. It's the layer of discipline underneath them.

## The Division of Labor

Jumpstart's core insight is that a business application has two fundamentally different kinds of code.

The first kind is **structural code**: the database schema, the data access layer, the domain classes, the REST API endpoints, the CRUD screens, the test scaffolding. This code is mechanical. Given a data model, an experienced developer would write it the same way every time. It has no interesting decisions in it. It is, in the precise sense of the word, boilerplate.

The second kind is **logic code**: business rules, validation, workflows, integrations, computed values, custom queries, access policies, edge case handling. This is where your application's actual value lives. It requires reasoning about the problem domain. It benefits from human judgment — and increasingly, from AI assistance.

Jumpstart generates the first kind automatically and completely, from a CSV metadata specification. It then creates clearly demarcated, explicitly named extension points — `*.user.cs` files, partial classes, controller extensions — where the second kind of code lives. Those extension points are yours to fill in however you choose, including by using AI tools to help write them.

The result is a clean separation: a generated foundation that is perfectly consistent across every entity, and a set of well-defined surfaces where custom logic — human or AI-written — plugs in without disturbing the foundation.

## Why Consistency at the Foundation Matters

When an AI tool generates the entire application, each entity tends to be slightly different from the others. The `Customer` controller might use one error-handling pattern; the `Invoice` controller might use another. One data class might be a record type; another might be a traditional class. These are not bugs — they're the natural result of non-deterministic generation across multiple sessions.

Jumpstart produces identical patterns across every entity in your model because every entity is rendered from the same templates. The `Customer` controller and the `Invoice` controller have exactly the same shape. The same endpoint conventions, the same audit behavior, the same AOP-injected logging and authorization. A developer who understands how one entity works understands how all of them work.

This consistency is what makes the codebase legible to AI tools. When you ask Claude Code to implement a custom endpoint on the `InvoiceController`, it can correctly infer the patterns in use — the partial class convention, the dependency injection style, the response types — from any other controller in the codebase, because they are all identical. A codebase with consistent, predictable structure is a codebase that AI tools can reason about reliably.

## Regeneration: The Problem AI Cannot Easily Solve

Here is a scenario that every team with a data-driven application will eventually face: the data model changes. A new column is added to `customer`. A new lookup table is introduced. A foreign key is reworked.

In a hand-written or AI-generated codebase, propagating this change means finding every affected file — the migration script, the domain class, the data reader, the API response type, the Blazor form, the test fixtures — and updating each one. Miss one, and you have a runtime error or a silent data loss bug. With AI assistance you can do this faster, but the AI still needs to find every affected file and update each correctly, without knowing which files it might have missed.

In a Jumpstart codebase, the answer is: update the metadata CSV and regenerate. Every `*.generated.cs` file, every DDL script, every Blazor page, every test fixture is overwritten with the correct, up-to-date version in seconds. The `*.user.cs` files — where your custom logic lives — are untouched. The FORCE flag, applied to every template individually, is what makes this safe: generated files are always overwritten; hand-edited files are never touched.

This regeneration story is Jumpstart's strongest argument in an AI-assisted world. AI tools are excellent at writing new logic. They are not yet reliable at tracking which of a hundred files need to change when a data model evolves, and making all of those changes consistently. Jumpstart makes that problem disappear entirely for the foundational layer.

## AI in the User Layer

The extension points Jumpstart creates are natural targets for AI assistance. Once the generated foundation is in place, you can bring an AI tool to a specific `user` file and ask it to implement a specific piece of business logic — knowing exactly what patterns it is working within, what the generated layer provides, and what it should not touch.

For example: the `CustomerLogic.user.cs` file is an empty partial class that extends the generated `CustomerLogic`. Ask Claude Code to implement a method that validates a customer's tax ID against an external service before insert, and it has a clear, well-scoped task. It knows the method signature (matching the generated override point), the dependency injection pattern already in use, and the layer it's operating in. The generated code provides the context; the AI provides the reasoning.

This is a more productive use of an AI tool than asking it to generate an entire application from scratch. The AI is working within a known structure rather than inventing one, which reduces the surface area for inconsistency and makes its output easier to review and trust.

## Metadata as an AI-Friendly Interface

The metadata CSV that drives Jumpstart generation is itself a natural target for AI assistance. Describing a data model in structured tabular form — tables, columns, types, relationships — is a task that maps well onto AI capabilities. Given a description of a business domain in plain English, an AI tool can produce a draft metadata CSV that a developer then reviews and refines.

This positions AI at the front of the Jumpstart pipeline, not in competition with it: AI helps articulate the model; Jumpstart generates the code from it. The metadata CSV becomes the reviewed, version-controlled specification that the team maintains, and the generated code is always derivable from it.

## A Stack, Not a Replacement

The most useful way to think about Jumpstart in an AI-assisted development workflow is as the foundational layer of a stack:

**Jumpstart** handles everything derivable from the data model — DDL, persistence, domain classes, APIs, UI pages, tests — with complete consistency and safe regeneration.

**AI tools** operate in the extension points: implementing business logic in `user` partial classes, building integrations, writing custom queries, generating documentation, and helping developers understand and navigate the codebase.

**Developers** review, guide, and own the whole system — the metadata specification, the custom logic, and the architectural decisions encoded in the templates.

This division of labor is more productive than any of the three alone. Jumpstart provides the discipline and consistency that makes AI output trustworthy. AI tools provide the reasoning and creativity that Jumpstart cannot supply. Developers provide the judgment that ties it together.

## Getting Started

Clone the repository, install the .NET 9 SDK, and run:

```bash
git clone https://github.com/your-org/jumpstart.git
cd jumpstart/src
dotnet build
dotnet run --project jumpstart.csproj -- model.csv
```

The [Getting Started guide](docs/getting-started.md) walks through your first metadata file and the full generation pipeline. The [Metadata Specification](docs/metadata.md) is the complete reference for the CSV format, column definitions, and relationship types.

The foundational layer should be consistent, correct, and invisible. Jumpstart makes it so — and leaves the rest of the application open for AI tools, and the people who use them, to make something worth building.
