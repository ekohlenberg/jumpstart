using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using Microsoft.AspNetCore.Authentication;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace jumpstart {

    public static class TypeMapping
    {
        /// <summary>
        /// Extracts the base data type by splitting on punctuation (particularly parentheses)
        /// and returns the left portion as the key for dictionary lookups
        /// </summary>
        /// <param name="dataType">The full data type string (e.g., "numeric(18,4)", "varchar(255)")</param>
        /// <returns>The base data type without parameters (e.g., "numeric", "varchar")</returns>
        public static string GetBaseDataType(string dataType)
        {
            if (string.IsNullOrEmpty(dataType))
                return dataType;

            // Split by common punctuation that indicates parameters
            var punctuationChars = new[] { '(', '[', '<', ' ' };
            int index = dataType.IndexOfAny(punctuationChars);
            
            if (index > 0)
            {
                return dataType.Substring(0, index).ToLower().Trim();
            }
            
            return dataType.ToLower().Trim();
        }

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
            {"numeric" , "ToDecimal"},	
            {"numeric(18,4)" , "ToDecimal"},	
            {"decimal" , "ToDecimal"},	
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
        public static readonly Dictionary<string, string> InputMap = new()
        {
            {"integer", "Number"},
            {"bigint", "Number"},
            {"smallint", "Number"},
            {"serial", "Number"},
            {"bigserial", "Number"},
            {"boolean", "Radio"},
            {"char", "Text"},
            {"varchar", "Text"},
            {"text", "TextArea"},
            {"date", "Date"},
            {"timestamp", "Date"},
            {"timestamptz", "Date"},
            {"real", "Number"},
            {"double precision", "Number"},
            {"numeric", "Number"},
            {"numeric(18,4)", "Number"},
            {"json", "TextArea"},
            {"uuid", "Text"},
            {"bytea", "Text"},
            {"xml", "Text"}
        };

        public static readonly Dictionary<string, string> PostgreSQLToMSSQLMap = new()
        {
            // Integer types
            { "smallint", "SMALLINT" },
            { "integer", "INT" },
            { "bigint", "BIGINT" },
            { "serial", "INT IDENTITY(1,1)" },
            { "bigserial", "BIGINT IDENTITY(1,1)" },
            
            // Character types
            { "character", "CHAR" },
            { "character varying", "VARCHAR" },
            { "varchar", "VARCHAR" },
            { "char", "CHAR" },
            { "text", "TEXT" },
            { "nchar", "NCHAR" },
            { "nvarchar", "NVARCHAR" },
            { "ntext", "NTEXT" },
            
            // Numeric types
            { "numeric", "DECIMAL" },
            { "decimal", "DECIMAL" },
            { "real", "REAL" },
            { "double precision", "FLOAT" },
            { "float", "FLOAT" },
            { "money", "MONEY" },
            { "smallmoney", "SMALLMONEY" },
            
            // Date/Time types
            { "date", "DATE" },
            { "time", "TIME" },
            { "timestamp", "DATETIME2" },
            { "timestamp without time zone", "DATETIME2" },
            { "timestamp with time zone", "DATETIME2" },
            { "timestamptz", "DATETIME2" },
            { "time without time zone", "TIME" },
            { "time with time zone", "TIME" },
            { "timetz", "TIME" },
            { "interval", "VARCHAR(50)" }, // SQL Server doesn't have direct interval type
            
            // Boolean type
            { "boolean", "BIT" },
            
            // Binary types
            { "bytea", "VARBINARY(MAX)" },
            { "binary", "BINARY" },
            { "varbinary", "VARBINARY" },
            
            // Other types
            { "uuid", "UNIQUEIDENTIFIER" },
            { "xml", "XML" },
            { "json", "NVARCHAR(MAX)" },
            { "jsonb", "NVARCHAR(MAX)" },
            
            // Network types (PostgreSQL specific - map to string equivalents)
            { "inet", "VARCHAR(45)" },
            { "cidr", "VARCHAR(43)" },
            { "macaddr", "VARCHAR(17)" },
            { "macaddr8", "VARCHAR(23)" },
            
            // Geometric types (PostgreSQL specific - map to string equivalents)
            { "point", "VARCHAR(50)" },
            { "line", "VARCHAR(100)" },
            { "lseg", "VARCHAR(100)" },
            { "box", "VARCHAR(100)" },
            { "path", "VARCHAR(MAX)" },
            { "polygon", "VARCHAR(MAX)" },
            { "circle", "VARCHAR(100)" },
            
            // Array types (PostgreSQL specific - map to string equivalents)
            { "integer[]", "NVARCHAR(MAX)" },
            { "text[]", "NVARCHAR(MAX)" },
            { "varchar[]", "NVARCHAR(MAX)" }
        };
    }

    public class MetaBaseElement
    {
        public string Name{get;set;}
        protected string _filename = string.Empty;

        public string FileName 
        {
            get 
            {
                if (string.IsNullOrEmpty(_filename)) 
                {
                    return Name;

                }
                else
                {
                    return _filename;
                }
            }
            set 
            {
                _filename = value;
            
            }
        }

        public readonly string  CR = "\n";
    }
    public class MetaAttribute : MetaBaseElement
    {
        private string _pascalName = null; 
        public string SqlDataType { get; set; }
        public string MSSQLDataType { get; set; }
        public string DotNetType {get;set;}

        public string InputType {get;set;}

        public string PascalName {
            get {
                if (_pascalName == null) _pascalName =  Utils.ConvertToPascalCase(Name);
                return _pascalName;
            }
        }
        public string ConvertMethod {get;set;}
        public string Length { get; set; }
        public string Label { get; set; }
        public string RWK { get; set; }
        public string FkType {get;set;}
        public string FkTable {get;set;}
        public string FkObject {get;set;}
        public string FkVar {get;set;}


        public bool IsNullable{get;set;} = false;

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
        private List<MetaAttribute> _globalAttributes = null;
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
        public string NavMenu {get; set;}

        public MetaModel Model {get;set;}
        
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
        public List<MetaAttribute> GlobalAttributes {
            get 
            {
                if (_globalAttributes == null)
                {
                    _globalAttributes = new List<MetaAttribute>();
                    foreach(MetaAttribute a in Attributes)
                    {
                        if (a.IsGlobal()) _globalAttributes.Add(a);
                    }
                }
                return _globalAttributes;
            }
        }
        public MetaObject(string _namespace, string tableName, string schemaName, string label, string navMenu)
        {
            Namespace = _namespace;
            TableName = tableName;
            DomainObj = Utils.ConvertToPascalCase(tableName);
            DomainVar = DomainObj.ToLower();
            Name = tableName;
            Label = label;
            NavMenu = navMenu;
            SchemaName = schemaName;
            FileName = DomainObj;
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
        
        public List<MetaObject> Objects { get;  set; } = new();
        public Dictionary<string, MetaObject> ObjectMap { get;  set; } = new();

        public string Namespace {get; set;}
        public MetaSchema(string name, string _namespace)
        {
            Name = name;
            Namespace = _namespace;
        }

        public override string ToString()
        {
            string result = $"Schema: {Name}\n";
            foreach (var obj in Objects)
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
        public Dictionary<string, List<MetaObject>> NavMenus { get; private set; } = new();

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

            foreach(var schema in this.Schemas.Values)
            {
                schema.Objects = SortMetaObjectsByReference( schema.Objects );
            }
        }
        
        protected  List<MetaObject> SortMetaObjectsByReference_1(List<MetaObject> metaObjects)
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

        protected List<MetaObject> SortMetaObjectsByReference(List<MetaObject> metaObjects)
        {
            // 1. Build the adjacency list: for each MetaObject, which MetaObjects depend on it?
            //    Because if B has an FK to A, then A should come before B.
            var adjacency = new Dictionary<MetaObject, List<MetaObject>>();
            foreach (var metaObject in metaObjects)
            {
                adjacency[metaObject] = new List<MetaObject>();
            }

            foreach (var metaObject in metaObjects)
            {
                foreach (var attribute in metaObject.Attributes)
                {
                    if (!string.IsNullOrEmpty(attribute.FkObject))
                    {
                        var fkObject = metaObjects.FirstOrDefault(mo => mo.Name == attribute.FkTable);
                        if (fkObject != null)
                        {
                            // fkObject -> metaObject
                            adjacency[fkObject].Add(metaObject);
                        }
                    }
                }
            }

            // 2. Find Strongly Connected Components (SCCs) in this directed graph
            var sccs = TarjanScc(metaObjects, adjacency);

            // 3. Build a graph of SCC "super-nodes" and topologically sort the super-nodes
            //    Each SCC is treated as a single node in the "condensed" graph.
            var sortedSccs = TopologicalSortSccs(sccs, adjacency);

            // 4. Flatten the SCCs in topological order into a single list of MetaObject
            var result = new List<MetaObject>();
            foreach (var scc in sortedSccs)
            {
                // You can order objects within an SCC however you like.
                // Usually the input or alphabetical order is fine.
                result.AddRange(scc);
            }

            return result;
        }

        /// <summary>
        /// Uses Tarjan's algorithm to find strongly connected components in the given graph.
        /// Returns a List of SCCs, where each SCC is a list of MetaObjects.
        /// </summary>
        private List<List<MetaObject>> TarjanScc(
            List<MetaObject> nodes, 
            Dictionary<MetaObject, List<MetaObject>> adjacency)
        {
            var sccResult = new List<List<MetaObject>>();

            var indexMap   = new Dictionary<MetaObject, int>();   // Map: Node -> Tarjan index
            var lowLinkMap = new Dictionary<MetaObject, int>();   // Map: Node -> low-link value
            var onStack    = new HashSet<MetaObject>();
            var stack      = new Stack<MetaObject>();

            int currentIndex = 0;

            // StrongConnect function (recursive DFS)
            void StrongConnect(MetaObject v)
            {
                // Set the depth index for v to the smallest unused index
                indexMap[v] = currentIndex;
                lowLinkMap[v] = currentIndex;
                currentIndex++;
                stack.Push(v);
                onStack.Add(v);

                // Consider successors of v
                foreach (var w in adjacency[v])
                {
                    if (!indexMap.ContainsKey(w))
                    {
                        // Successor w has not yet been visited; recurse on it
                        StrongConnect(w);
                        lowLinkMap[v] = Math.Min(lowLinkMap[v], lowLinkMap[w]);
                    }
                    else if (onStack.Contains(w))
                    {
                        // Successor w is in the stack and hence in the current SCC
                        lowLinkMap[v] = Math.Min(lowLinkMap[v], indexMap[w]);
                    }
                }

                // If v is a root node, pop the stack and generate an SCC
                if (lowLinkMap[v] == indexMap[v])
                {
                    var scc = new List<MetaObject>();
                    MetaObject nodeInScc;
                    do
                    {
                        nodeInScc = stack.Pop();
                        onStack.Remove(nodeInScc);
                        scc.Add(nodeInScc);
                    }
                    while (!nodeInScc.Equals(v));

                    sccResult.Add(scc);
                }
            }

            // Run StrongConnect for all nodes that haven't been visited
            foreach (var node in nodes)
            {
                if (!indexMap.ContainsKey(node))
                {
                    StrongConnect(node);
                }
            }

            return sccResult;
        }

        /// <summary>
        /// Given the list of SCCs, build a "condensed" graph of SCC super-nodes
        /// and perform a topological sort on it. Returns the list of SCCs in topological order.
        /// </summary>
        private List<List<MetaObject>> TopologicalSortSccs(
            List<List<MetaObject>> sccs,
            Dictionary<MetaObject, List<MetaObject>> adjacency)
        {
            // First, build an SCC lookup: which SCC does each node belong to?
            var sccLookup = new Dictionary<MetaObject, int>();
            for (int i = 0; i < sccs.Count; i++)
            {
                foreach (var mo in sccs[i])
                {
                    sccLookup[mo] = i;
                }
            }

            // Build adjacency among the SCCs (condensed graph)
            var sccGraph = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < sccs.Count; i++)
            {
                sccGraph[i] = new HashSet<int>();
            }

            for (int i = 0; i < sccs.Count; i++)
            {
                foreach (var metaObject in sccs[i])
                {
                    // look at the adjacency from metaObject to other nodes
                    foreach (var neighbor in adjacency[metaObject])
                    {
                        int neighborScc = sccLookup[neighbor];
                        if (neighborScc != i)
                        {
                            sccGraph[i].Add(neighborScc);
                        }
                    }
                }
            }

            // Now we topologically sort the condensed graph of SCC indices
            // Kahn's Algorithm or DFS-based approach can be used here.
            // We'll use a Kahn's algorithm style for SCC indices:
            var inDegree = new Dictionary<int, int>();
            for (int i = 0; i < sccs.Count; i++)
            {
                inDegree[i] = 0;
            }

            foreach (var kvp in sccGraph)
            {
                var fromScc = kvp.Key;
                foreach (var toScc in kvp.Value)
                {
                    inDegree[toScc]++;
                }
            }

            var queue = new Queue<int>();
            for (int i = 0; i < sccs.Count; i++)
            {
                if (inDegree[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

            var sortedSccIndices = new List<int>();
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                sortedSccIndices.Add(current);

                foreach (var neighbor in sccGraph[current])
                {
                    inDegree[neighbor]--;
                    if (inDegree[neighbor] == 0)
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }

            // If not all SCCs are sorted, there's a problem, but strictly speaking
            // strongly connected components can still be sorted as a condensed graph.
            // If there's somehow a cycle among the SCC "super-nodes" (which shouldn't happen),
            // you'd detect it here. Typically, it won't happen since each SCC is collapsed.
            if (sortedSccIndices.Count != sccs.Count)
            {
                // This would be unusual with correct Tarjan's usage,
                // but you could handle or throw if you want.
                throw new InvalidOperationException("Unable to topologically sort the SCCs.");
            }

            // Return the SCCs in topological order
            return sortedSccIndices.Select(sccIndex => sccs[sccIndex]).ToList();
        }



    }


}
