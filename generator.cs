using RazorLight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace jumpstart {
public class Generator
{
    private readonly RazorLightEngine razorEngine;
    private Dictionary<string, List<Dictionary<string, string>>> metadataMap = new();
    private Dictionary<string, List<string>> outputFolderMap = new();

    public Generator()
    {
        razorEngine = new RazorLightEngineBuilder()
            .UseEmbeddedResourcesProject(typeof(Generator))
            .SetOperatingAssembly(typeof(Generator).Assembly)
            .UseMemoryCachingProvider()
            .Build();
    }

    public void AddToMetadataMap(string tableName, Dictionary<string, string> columnData)
    {
        if (!metadataMap.ContainsKey(tableName))
        {
            metadataMap[tableName] = new List<Dictionary<string, string>>();
        }
        metadataMap[tableName].Add(columnData);
    }

    public void AddToOutputFolderMap(string outputFolder, string outputFile)
    {
        if (!outputFolderMap.ContainsKey(outputFolder))
        {
            outputFolderMap[outputFolder] = new List<string>();
        }
        outputFolderMap[outputFolder].Add(Path.GetFileName(outputFile));
    }

    public string ConvertToPascalCase(string input)
    {
        var parts = input.Split('_');
        for (int i = 0; i < parts.Length; i++)
        {
            parts[i] = char.ToUpper(parts[i][0]) + parts[i].Substring(1).ToLower();
        }
        return string.Join(string.Empty, parts);
    }

    public async Task GenerateObjectAsync(List<Dictionary<string, string>> columns, string templateFile, string outputFolder, bool force = false)
    {
        string tableName = columns[0]["table_name"];
        string schemaName = columns[0]["table_schema"];
        string namespaceName = columns[0]["table_catalog"];
        string domainObj = ConvertToPascalCase(tableName);
        string domainVar = domainObj.ToLower();

        string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "templates", templateFile);

        if (!File.Exists(templatePath))
        {
            throw new FileNotFoundException($"Template not found: {templatePath}");
        }

        string template = File.ReadAllText(templatePath);

        var model = new
        {
            TableName = tableName,
            SchemaName = schemaName,
            Namespace = namespaceName,
            DomainObj = domainObj,
            DomainVar = domainVar,
        };

        string generatedCode = await razorEngine.CompileRenderStringAsync(templateFile, template, model);

        if (generatedCode.Length > 0)
        {
            string targetFile = templateFile.Replace("template", domainObj).Replace(".ps1", ".cs");
            string outputPath = Path.Combine(outputFolder, targetFile);

            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            if (!File.Exists(outputPath) || force)
            {
                File.WriteAllText(outputPath, generatedCode);
            }

            AddToOutputFolderMap(outputFolder, outputPath);
        }
    }

    public async Task GenerateSchemaLevelAsync(string schemaName, string namespaceName, string templateFile, string outputFolder)
    {
        string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "templates", templateFile);

        if (!File.Exists(templatePath))
        {
            throw new FileNotFoundException($"Template not found: {templatePath}");
        }

        string template = File.ReadAllText(templatePath);

        var model = new
        {
            SchemaName = schemaName,
            Namespace = namespaceName,
        };

        string generatedCode = await razorEngine.CompileRenderStringAsync(templateFile, template, model);

        string targetFile = templateFile.Replace("template", schemaName).Replace(".ps1", ".cs");
        string outputPath = Path.Combine(outputFolder, targetFile);

        if (!Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
        }

        if (!File.Exists(outputPath))
        {
            File.WriteAllText(outputPath, generatedCode);
        }

        AddToOutputFolderMap(outputFolder, outputPath);
    }

    public async Task GenerateAppLevelAsync(Dictionary<string, string> metadata, string templateFile, string outputFolder, bool force = false)
    {
        string namespaceName = metadata["table_catalog"];
        string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "templates", templateFile);

        if (!File.Exists(templatePath))
        {
            throw new FileNotFoundException($"Template not found: {templatePath}");
        }

        string template = File.ReadAllText(templatePath);

        var model = new
        {
            Namespace = namespaceName,
        };

        string generatedCode = await razorEngine.CompileRenderStringAsync(templateFile, template, model);

        string targetFile = templateFile.Replace("template", namespaceName).Replace(".ps1", "");
        string outputPath = Path.Combine(outputFolder, targetFile);

        if (!Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
        }

        if (!File.Exists(outputPath) || force)
        {
            File.WriteAllText(outputPath, generatedCode);
        }

        AddToOutputFolderMap(outputFolder, outputPath);
    }
}
}