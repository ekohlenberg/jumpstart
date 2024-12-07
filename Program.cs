using System;
using System.IO;
using System.Threading.Tasks;
using jumpstart;

class Program
{
    static int Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: jumpstart <modelPath>");
            return 1;
        }

        string modelPath = args[0];

        if (!File.Exists(modelPath))
        {
            Console.WriteLine($"Error: File not found at path {modelPath}");
            return 1;
        }

        try
        {
            // Create an instance of the CSVLoader
            var csvLoader = new CSVLoader();
            var metaModel = new MetaModel();

            // Load the model from the specified path
             csvLoader.Load(modelPath, metaModel);

            // Output the string representation of the metaModel
            Console.WriteLine(metaModel.ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

			  return 0;
    }
}
