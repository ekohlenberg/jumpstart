using System;
using System.IO;
using System.Threading.Tasks;
using jumpstart;

namespace jumpstart {


    class Program
    {
        static async Task Main(string[] args)
        {
            /*
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: jumpstart <modelPath>");
                return;
            }
            */
            string modelPath = "./test.csv";

            if (args.Length > 0)
            {
                modelPath = args[0];

                if (!File.Exists(modelPath))
                {
                Console.WriteLine($"Error: File not found at path {modelPath}");

                return;
                }

            }

            Console.WriteLine($"Using model path {modelPath}");
           
            try
            {
                // Create an instance of the CSVLoader
                var csvLoader = new CSVLoader();

                string _namespace = Path.GetFileNameWithoutExtension(modelPath);
                var metaModel = new MetaModel(_namespace);

                // Load the model from the specified path
                csvLoader.Load(modelPath, metaModel);

                GlobalCSVLoader gloader = new GlobalCSVLoader();
                gloader.Load( "global.csv", metaModel);

                Generator g = new Generator();

                g.OnFileWriteEvent += metaModel.build.AddToOutputFolderMap;

                g.AddTemplate( typeof(MetaModel), new TemplateDef("database/pgsql/template.database.create.generated.sql.cshtml", "./database", true));
                g.AddTemplate( typeof(MetaModel), new TemplateDef("database/pgsql/audit.schema.create.generated.sql.cshtml", "./database", true));


                g.AddTemplate( typeof(MetaSchema), new TemplateDef("database/pgsql/template.schema.create.generated.sql.cshtml", "./database", true));

                g.AddTemplate( typeof(MetaObject), new TemplateDef("database/pgsql/template.table.generated.sql.cshtml", "./database", true));
                g.AddTemplate( typeof(MetaObject), new TemplateDef("database/pgsql/template.audit.generated.sql.cshtml", "./database", true));
                g.AddTemplate( typeof(MetaObject), new TemplateDef("database/pgsql/template.sequence.generated.sql.cshtml", "./database", true));


                g.AddTemplate( typeof(MetaBuild), new TemplateDef( "database/pgsql/template.build.generated.sh.cshtml", "./database", true));

                await g.GenerateApp(metaModel);
                await g.GenerateSchemas(metaModel);
                await g.GenerateObjects(metaModel);
                await g.GenerateBuild(metaModel);

                // Output the string representation of the metaModel
                Console.WriteLine(metaModel.ToString());
            }
            catch (Exception ex)
            {
                
                Exception x = ex;
                while(x != null)
                {
                    Console.WriteLine($"Error: {x.Message}\n{x.StackTrace}");

                    x = x.InnerException;
                }
            }

                return;
        }
    }
}