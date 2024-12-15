using System;
using System.IO;
using System.Threading.Tasks;
using jumpstart;

namespace jumpstart {


    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: jumpstart <modelPath>");
                return;
            }

            string modelPath = args[0];

            if (!File.Exists(modelPath))
            {
                Console.WriteLine($"Error: File not found at path {modelPath}");
                return;
            }

            try
            {
                // Create an instance of the CSVLoader
                var csvLoader = new CSVLoader();

                string _namespace = Path.GetFileNameWithoutExtension(modelPath);
                var metaModel = new MetaModel(_namespace);

                // Load the model from the specified path
                csvLoader.Load(modelPath, metaModel);

                Generator g = new Generator();

                g.OnFileWriteEvent += metaModel.build.AddToOutputFolderMap;

                g.AddTemplate( typeof(MetaObject), new TemplateDef("database/pgsql/template.table.generated.sql.cshtml", "./database", true));

                await g.GenerateObjects(metaModel);

                // Output the string representation of the metaModel
                Console.WriteLine(metaModel.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

                return;
        }
    }
}