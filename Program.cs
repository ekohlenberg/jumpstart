﻿using System;
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

                /* database templates */
                g.AddTemplate( typeof(MetaModel), new TemplateDef("database/pgsql/template.database.create.generated.sql.cshtml", "./database", true));
                g.AddTemplate( typeof(MetaModel), new TemplateDef("database/pgsql/audit.schema.create.generated.sql.cshtml", "./database", true));

                g.AddTemplate( typeof(MetaSchema), new TemplateDef("database/pgsql/template.schema.create.generated.sql.cshtml", "./database", true));

                g.AddTemplate( typeof(MetaObject), new TemplateDef("database/pgsql/template.table.generated.sql.cshtml", "./database", true));
                g.AddTemplate( typeof(MetaObject), new TemplateDef("database/pgsql/template.audit.generated.sql.cshtml", "./database", true));
                g.AddTemplate( typeof(MetaObject), new TemplateDef("database/pgsql/template.sequence.generated.sql.cshtml", "./database", true));
                g.AddTemplate( typeof(MetaObject), new TemplateDef("database/pgsql/template.rwkindex.generated.sql.cshtml", "./database", true));

                g.AddTemplate( typeof(MetaBuild), new TemplateDef( "database/pgsql/build.sh.cshtml", "./database", true));


                /* dotnet server templates */
                /* common */
                g.AddTemplate( typeof(MetaModel), new TemplateDef("server/dotnet/common/Config.generated.cs.cshtml", "./server/common", true));
                g.AddTemplate( typeof(MetaModel), new TemplateDef("server/dotnet/common/Util.generated.cs.cshtml", "./server/common", true));
                g.AddTemplate( typeof(MetaModel), new TemplateDef("server/dotnet/common/BaseObject.generated.cs.cshtml", "./server/common", true));
                g.AddTemplate( typeof(MetaModel), new TemplateDef("server/dotnet/common/BaseLogic.generated.cs.cshtml", "./server/common", true));
                g.AddTemplate( typeof(MetaModel), new TemplateDef("server/dotnet/common/common.csproj.cshtml", "./server/common", true));
              
                /* persist */
                g.AddTemplate( typeof(MetaModel), new TemplateDef("server/dotnet/persist/DBPersist.generated.cs.cshtml", "./server/persist", true));
                g.AddTemplate( typeof(MetaModel), new TemplateDef("server/dotnet/persist/persist.csproj.cshtml", "./server/persist", true));
             
                /* domain */
                g.AddTemplate( typeof(MetaObject), new TemplateDef("server/dotnet/domain/template.generated.cs.cshtml", "./server/domain", true));
                g.AddTemplate( typeof(MetaObject), new TemplateDef("server/dotnet/domain/template.user.cs.cshtml", "./server/domain", false));
                g.AddTemplate( typeof(MetaModel), new TemplateDef("server/dotnet/domain/domain.csproj.cshtml", "./server/domain", true));

                /* logic */
                g.AddTemplate( typeof(MetaObject), new TemplateDef("server/dotnet/logic/templateLogic.generated.cs.cshtml", "./server/logic", true));
                g.AddTemplate( typeof(MetaObject), new TemplateDef("server/dotnet/logic/templateLogic.user.cs.cshtml", "./server/logic", false));
                g.AddTemplate( typeof(MetaModel), new TemplateDef("server/dotnet/logic/logic.csproj.cshtml", "./server/logic", true));
            
                /* api */
                g.AddTemplate( typeof(MetaObject), new TemplateDef("server/dotnet/api/template.api.generated.cs.cshtml", "./server/api", true));
                g.AddTemplate( typeof(MetaModel), new TemplateDef("server/dotnet/api/Program.cs.cshtml", "./server/api", false));
                g.AddTemplate( typeof(MetaModel), new TemplateDef("server/dotnet/api/appsettings.json.cshtml", "./server/api", false));
                g.AddTemplate( typeof(MetaModel), new TemplateDef("server/dotnet/api/appsettings.Development.json.cshtml", "./server/api", false));
                g.AddTemplate( typeof(MetaModel), new TemplateDef("server/dotnet/api/Properties/launchSettings.json.cshtml", "./server/api/Properties", false));

                g.AddTemplate( typeof(MetaModel), new TemplateDef("server/dotnet/api/api.csproj.cshtml", "./server/api", true));

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