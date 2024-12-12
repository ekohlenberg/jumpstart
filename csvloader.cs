using System.IO;
using System.Globalization;
using CsvHelper;

namespace jumpstart {


public class MetadataRecord {
    public string TABLE_CATALOG {get;set;}
    public string TABLE_SCHEMA {get;set;}
    public string TABLE_NAME {get;set;}
    public string TABLE_LABEL {get;set;}
    public string PRIMARY_TABLE {get;set;}
    public string COLUMN_NAME {get;set;}
    public string COLUMN_LABEL {get;set;}
    public string FK_TYPE {get;set;}
    public string FK_OBJECT {get;set;}
    public string TEST_DATA_SET {get;set;}
    public string ORDINAL_POSITION {get;set;}
    public string COLUMN_DEFAULT {get;set;}
    public string RWK {get;set;}
    public string IS_NULLABLE {get;set;}
    public string DATA_TYPE {get;set;}
    public string MSSQL_DATA_TYPE {get;set;}
    public string CHARACTER_MAXIMUM_LENGTH {get;set;}
    public string CHARACTER_OCTET_LENGTH {get;set;}
    public string NUMERIC_PRECISION {get;set;}
    public string NUMERIC_PRECISION_RADIX {get;set;}
    public string NUMERIC_SCALE {get;set;}
    public string DATETIME_PRECISION {get;set;}
    public string CHARACTER_SET_CATALOG {get;set;}
    public string CHARACTER_SET_SCHEMA {get;set;}
    public string CHARACTER_SET_NAME {get;set;}
    public string COLLATION_CATALOG {get;set;}
    public string COLLATION_SCHEMA {get;set;}
    public string COLLATION_NAME {get;set;}
    public string DOMAIN_CATALOG {get;set;}
    public string DOMAIN_SCHEMA {get;set;}
    public string DOMAIN_NAME {get;set;}
}

public class CSVLoader
{
    public void Load(string modelPath, MetaModel metaModel)
    {
        
        using (var reader = new StreamReader(modelPath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<MetadataRecord>();
            foreach (MetadataRecord mr in records)
                    {
                       
                        // Assuming the fields contain attributes like schema, table, column, etc

                        SetNamespace(metaModel, mr.TABLE_CATALOG);
                        AddSchema(metaModel, mr);
                    }

        }
        
    }

    private void SetNamespace(MetaModel metaModel, string tableCatalog)
    {
        if (string.IsNullOrEmpty(metaModel.Namespace))
        {
            metaModel.Namespace = tableCatalog;
        }
    }

    private void AddSchema(MetaModel metaModel, MetadataRecord mr)
    {
        MetaSchema schema=null;

        if (!metaModel.Schemas.TryGetValue(mr.TABLE_SCHEMA, out schema))
        {
            schema = new MetaSchema(mr.TABLE_SCHEMA);
            metaModel.Schemas[mr.TABLE_SCHEMA] = schema;
        }

        AddObject(metaModel, schema, mr);
    }

    private void AddObject(MetaModel metaModel, MetaSchema schema, MetadataRecord mr)
    {
        if (!schema.Objects.TryGetValue(mr.TABLE_NAME, out var metaObject))
        {
            metaObject = new MetaObject(mr.TABLE_NAME, mr.TABLE_SCHEMA);
            schema.Objects[mr.TABLE_NAME] = metaObject;
        }

        if (!metaModel.Objects.ContainsKey(mr.TABLE_NAME))
        {
            metaModel.Objects[mr.TABLE_NAME] = metaObject;
        }

        AddAttributes(metaObject, mr);
    }

    private void AddAttributes(MetaObject metaObject, MetadataRecord mr)
    {
        if (!metaObject.Attributes.Any(attr => attr.Name == mr.COLUMN_NAME))
        {
            var attribute = new MetaAttribute
            {
                Name = mr.COLUMN_NAME,
                DataType = TypeMapping.DataTypeMap.GetValueOrDefault(mr.DATA_TYPE.ToLower(), "object"),
                Length = mr.CHARACTER_MAXIMUM_LENGTH,
                Label = mr.COLUMN_LABEL,
                RWK = mr.RWK,
            };
            metaObject.Attributes.Add( attribute );
        }
    }
}
}
