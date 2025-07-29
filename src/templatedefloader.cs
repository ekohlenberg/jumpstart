using System.IO;
using System.Globalization;
using CsvHelper;


namespace jumpstart 
{


	public class TemplateDefRecord
	{
		public string COMMENT {get; set;}
		public string TEMPLATE_TYPE {get; set;}
		public string TEMPLATE_PATH {get; set;}
		public string OUTPUT_DIR {get; set;}
		public string FORCE {get; set;}
	}


	public class TemplateDefLoader
	{
	    public static List<TemplateDef> Load(string templateDefName )
	    {
	    	List<TemplateDef> templateDefs = new();

	        string templateDefPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "templates", templateDefName + ".csv");

	        using (var reader = new StreamReader(templateDefPath))
	        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
	        {
	            var records = csv.GetRecords<TemplateDefRecord>();
	            foreach (TemplateDefRecord tdr in records)
	            {
	            	TemplateDef td = new TemplateDef( tdr.TEMPLATE_TYPE.Trim(), tdr.TEMPLATE_PATH.Trim(), tdr.OUTPUT_DIR.Trim(), tdr.FORCE.Trim().ToLower());

	            	templateDefs.Add(td);
	            }
	        }
	        
	        return templateDefs;
	    }
	 }
}
