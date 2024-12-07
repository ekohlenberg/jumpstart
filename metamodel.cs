using System;
using System.Collections.Generic;

namespace jumpstart {
public static class TypeMapping
{
    public static readonly Dictionary<string, string> DataTypeMap = new()
    {
        { "integer", "int" },
        { "bigint", "long" },
        { "smallint", "short" },
        { "serial", "int" },
        { "bigserial", "long" },
        { "boolean", "bool" },
        { "char", "string" },
        { "varchar", "string" },
        { "text", "string" },
        { "date", "DateTime" },
        { "timestamp", "DateTime" },
        { "timestamptz", "DateTime" },
        { "real", "float" },
        { "double precision", "double" },
        { "numeric", "decimal" },
        { "json", "string" },
        { "uuid", "Guid" },
        { "bytea", "byte[]" },
        { "xml", "string" }
    };
}

public class MetaAttribute
{
    public string Name { get; set; }
    public string DataType { get; set; }
    public string Length { get; set; }
    public string Label { get; set; }
    public string RWK { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}\nDataType: {DataType}\nLength: {Length}\nLabel: {Label}\nRWK: {RWK}\n";
    }
}

public class MetaObject
{
    public string DomainObj { get; private set; }
    public string DomainVar { get; private set; }
    public string TableName { get; private set; }
    public SortedDictionary<string, MetaAttribute> Attributes { get; private set; } = new();

    public MetaObject(string tableName)
    {
        TableName = tableName;
        DomainObj = ConvertToPascalCase(tableName);
        DomainVar = DomainObj.ToLower();
    }

    public override string ToString()
    {
        string result = $"Domain Obj: {DomainObj}\nDomain Var: {DomainVar}\nTable Name: {TableName}\n";
        foreach (var attribute in Attributes.Values)
        {
            result += attribute.ToString();
        }
        return result;
    }

    private static string ConvertToPascalCase(string input)
    {
        string[] parts = input.Split('_');
        return string.Concat(Array.ConvertAll(parts, part => char.ToUpper(part[0]) + part.Substring(1).ToLower()));
    }
}

public class MetaSchema
{
    public string Name { get; set; }
    public SortedDictionary<string, MetaObject> Objects { get; private set; } = new();

    public MetaSchema(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        string result = $"Schema: {Name}\n";
        foreach (var obj in Objects.Values)
        {
            result += obj.ToString();
        }
        return result;
    }
}

public class MetaModel
{
    public string Namespace { get; set; }
    public Dictionary<string, MetaSchema> Schemas { get; private set; } = new();

    public override string ToString()
    {
        string result = $"Namespace: {Namespace}\n";
        foreach (var schema in Schemas.Values)
        {
            result += schema.ToString();
        }
        return result;
    }
}

}