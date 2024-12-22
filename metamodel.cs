using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;

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

        public static readonly Dictionary<string, string> ConvertMap = new()
        {
            {"integer" , "ToInt32"},	
            {"bigint" , "ToInt64"},	
            {"smallint" , "ToInt16"},	
            {"serial" , "ToInt32"},	
            {"bigserial" , "ToInt64"},	
            {"boolean" , "ToBoolean"},	
            {"char" , "ToString"},	
            {"varchar" , "ToString"},	
            {"text" , "ToString"},	
            {"date" , "ToDateTime"},	
            {"timestamp" , "ToDateTime"},	
            {"timestamptz" , "ToDateTime"},	
            {"time" , "ToDateTime"},	 // Convert to DateTime, then use .TimeOfDay for TimeSpan
            {"timetz" , "ToDateTime" },	//  Convert to DateTime, then use .TimeOfDay for TimeSpan
            {"real" , "ToSingle"},	
            {"double precision" , "ToDouble"},	
            {"numeric" , "ToDouble"},	
            {"numeric(18,4)" , "ToDouble"},	
            {"decimal" , "ToDouble"},	
            {"bytea" , "ToByte[]"},	
            {"uuid" , "Guid.Parse" },	// Guid.Parse is used instead of Convert for UUIDs
            {"json" , "ToString"},	
            {"jsonb" , "ToString"},	
            {"xml" , "ToString"},	
            {"money" , "ToDecimal"},	
            {"inet" , "ToString"},	
            {"cidr" , "ToString"},	
            {"macaddr" , "ToString"}	
        };
    }


    public class MetaBaseElement
    {
        public string Name{get;set;}
        public readonly string  CR = "\n";
    }
    public class MetaAttribute : MetaBaseElement
    {
        
        public string SqlDataType { get; set; }
        public string NetDataType {get;set;}

        public string ConvertMethod {get;set;}
        public string Length { get; set; }
        public string Label { get; set; }
        public string RWK { get; set; }
        public string FkType {get;set;}
        public string FkObject {get;set;}

        public override string ToString()
        {
            return $"Name: {Name}\nDataType: {SqlDataType}\nLength: {Length}\nLabel: {Label}\nRWK: {RWK}\n";
        }
    }

    public class MetaObject : MetaBaseElement
    {
        public string DomainObj { get; private set; }
        public string DomainVar { get; private set; }
        public string TableName { get; private set; }

        public string Label {get; private set;}
        public string SchemaName {get; set;}

        public string Primary {get;set;}
        public List<MetaAttribute> Attributes { get; private set; } = new();

        public MetaObject(string tableName, string schemaName, string label, string primary)
        {
            TableName = tableName;
            DomainObj = ConvertToPascalCase(tableName);
            DomainVar = DomainObj.ToLower();
            Name = tableName;
            Label = label;
            Primary = primary;
            SchemaName = schemaName;
        }

        public override string ToString()
        {
            string result = $"Domain Obj: {DomainObj}\nDomain Var: {DomainVar}\nTable Name: {TableName}\n";
            foreach (var attribute in Attributes)
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

    public class MetaSchema : MetaBaseElement
    {
    
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

    public class MetaBuild : MetaBaseElement
    {
        public Dictionary<string,List<string>> outputFolderMap = [];
        public List<string> sourceFiles = new();


        public void AddToOutputFolderMap(string outputFolder, string outputFile)
        {
            if (!outputFolderMap.ContainsKey(outputFolder))
            {
                outputFolderMap[outputFolder] = new List<string>();
            }

            List<string> sourceFiles = outputFolderMap[outputFolder];

            string sourceFile = Path.GetFileName(outputFile);

            if (!sourceFiles.Any(f => f == sourceFile))
            {
                sourceFiles.Add(sourceFile);
            }
        }

        public void SetOutputFolder( string outputDir )
        {
            if (outputFolderMap.ContainsKey(outputDir))
            {
                sourceFiles = outputFolderMap[outputDir];
                
            }
        }
    }

    public class MetaModel : MetaBaseElement
    {
        public string Namespace { get; set; }
    

        public Dictionary<string, MetaSchema> Schemas { get; private set; } = new();
        public List<MetaObject> Objects { get; private set; } = new();

        
        public MetaBuild build = new MetaBuild();
        
        public MetaModel(string _namespace)
        {
            Name = _namespace;
            Namespace = _namespace;
            build.Name = Name;
        }

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