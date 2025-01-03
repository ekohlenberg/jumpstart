using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
        protected static string ConvertToPascalCase(string input)
        {
            string[] parts = input.Split('_');
            return string.Concat(Array.ConvertAll(parts, part => char.ToUpper(part[0]) + part.Substring(1).ToLower()));
        }
    }
    public class MetaAttribute : MetaBaseElement
    {
        private string _pascalName = null; 
        public string SqlDataType { get; set; }
        public string DotNetType {get;set;}

        public string PascalName {
            get {
                if (_pascalName == null) _pascalName =  ConvertToPascalCase(Name);
                return _pascalName;
            }
        }
        public string ConvertMethod {get;set;}
        public string Length { get; set; }
        public string Label { get; set; }
        public string RWK { get; set; }
        public string FkType {get;set;}
        public string FkObject {get;set;}

        public string TestDataSet{get;set;}

         bool _IsGlobal{get;set;} = false;

        public bool IsGlobal() { return _IsGlobal;}
        public void SetGlobal() { _IsGlobal = true;}

        public override string ToString()
        {
            return $"Name: {Name}\nDataType: {SqlDataType}\nLength: {Length}\nLabel: {Label}\nRWK: {RWK}\n";
        }
    }

    public class MetaObject : MetaBaseElement
    {
        private List<MetaAttribute> _userAttributes = null;
        public string Namespace {get; private set;}
        public string DomainObj { get; private set; }

        public string DomainConst {
            get {
                return DomainObj.ToUpper();
            }
        }
        public string DomainVar { get; private set; }
        public string TableName { get; private set; }

        public string Label {get; private set;}
        public string SchemaName {get; set;}

        public string Primary {get;set;}
        public List<MetaAttribute> Attributes { get; private set; } = new();

        public List<MetaAttribute> UserAttributes {
            get 
            {
                if (_userAttributes == null)
                {
                    _userAttributes = new List<MetaAttribute>();
                    foreach(MetaAttribute a in Attributes)
                    {
                        if (!a.IsGlobal()) _userAttributes.Add(a);
                    }
                }
                return _userAttributes;
            }
        }
        public MetaObject(string _namespace, string tableName, string schemaName, string label, string primary)
        {
            Namespace = _namespace;
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

        
    }

    public class MetaSchema : MetaBaseElement
    {
        
        public SortedDictionary<string, MetaObject> Objects { get; private set; } = new();
        public string Namespace {get; set;}
        public MetaSchema(string name, string _namespace)
        {
            Name = name;
            Namespace = _namespace;
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

        public List<MetaAttribute> GlobalAttributes {get; private set;} = new();

        public bool ContainsGlobalAttribute(string name)
        {
            return GlobalAttributes.Any(attr => attr.Name == name);
        }
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

        public void SortMetaObjectsByReference()
        {
            this.Objects = SortMetaObjectsByReference( this.Objects );
        }
        protected  List<MetaObject> SortMetaObjectsByReference(List<MetaObject> metaObjects)
        {
            // Build a dependency graph
            var graph = new Dictionary<MetaObject, List<MetaObject>>();
            var inDegree = new Dictionary<MetaObject, int>();
            
            // Initialize graph and in-degree map
            foreach (var metaObject in metaObjects)
            {
                graph[metaObject] = new List<MetaObject>();
                inDegree[metaObject] = 0;
            }

            // Populate the graph based on foreign key dependencies
            foreach (var metaObject in metaObjects)
            {
                foreach (var attribute in metaObject.Attributes)
                {
                    if (!string.IsNullOrEmpty(attribute.FkObject))
                    {
                        var fkObject = metaObjects.FirstOrDefault(mo => mo.Name == attribute.FkObject);
                        if (fkObject != null)
                        {
                            graph[fkObject].Add(metaObject);
                            inDegree[metaObject]++;
                        }
                    }
                }
            }

            // Perform topological sort using Kahn's algorithm
            var sorted = new List<MetaObject>();
            var queue = new Queue<MetaObject>();

            // Add all nodes with in-degree 0 to the queue
            foreach (var kvp in inDegree)
            {
                if (kvp.Value == 0)
                {
                    queue.Enqueue(kvp.Key);
                }
            }

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                sorted.Add(current);

                // Reduce the in-degree of neighbors
                foreach (var neighbor in graph[current])
                {
                    inDegree[neighbor]--;
                    if (inDegree[neighbor] == 0)
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }

            // Check for circular dependencies
            if (sorted.Count != metaObjects.Count)
            {
                throw new InvalidOperationException("Circular dependency detected among MetaObjects.");
            }

            return sorted;
        }



    }


}