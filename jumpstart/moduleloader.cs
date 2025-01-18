using System.IO;
using System.Globalization;
using CsvHelper;

namespace jumpstart {


    public class ModuleLoader : CSVLoader
    {
        public override void Load(string moduleCsv, MetaModel metaModel)
        {
            string modelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "modules", moduleCsv);

            base.Load( modelPath, metaModel );
        
        }

    }

}