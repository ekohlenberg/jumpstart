using System.IO;
using System.Globalization;
using CsvHelper;

namespace jumpstart {


public class GlobalMetaRecord {
    public string COLUMN_NAME {get;set;}
    
    public string COLUMN_DEFAULT {get;set;}

    public string IS_NULLABLE {get;set;}
    public string DATA_TYPE {get;set;}
    public string CHARACTER_MAXIMUM_LENGTH {get;set;}

    public string COLUMN_LABEL {get;set;}
   
}

public class GlobalCSVLoader
{
    public void Load(string globalCsv, MetaModel metaModel)
    {

        string modelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "global", globalCsv);

        using (var reader = new StreamReader(modelPath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<GlobalMetaRecord>();
            foreach (GlobalMetaRecord mr in records)
                    {
                        // Assuming the fields contain attributes like schema, table, column, etc

                        foreach(MetaObject metaObject in metaModel.Objects)
                        {
                            AddAttributes(metaObject, mr);
                        }
                        
                    }

        }
        
    }

    private void AddAttributes(MetaObject metaObject, GlobalMetaRecord mr)
    {
        if (!metaObject.Attributes.Any(attr => attr.Name == mr.COLUMN_NAME))
        {
            var attribute = new MetaAttribute
            {
                Name = mr.COLUMN_NAME,
                SqlDataType = mr.DATA_TYPE,
                Length = mr.CHARACTER_MAXIMUM_LENGTH,
                DotNetType = TypeMapping.DataTypeMap.GetValueOrDefault(mr.DATA_TYPE.ToLower(), "object"),
                ConvertMethod = TypeMapping.ConvertMap.GetValueOrDefault(mr.DATA_TYPE.ToLower(), ""),
                Label = mr.COLUMN_LABEL,
            };
            metaObject.Attributes.Add( attribute );
        }
    }

   
}
}
