using System.IO;
using System.Globalization;
using CsvHelper;

namespace jumpstart {


    public class CoreLoader : CSVLoader
    {
        public override void Load(string moduleCsv, MetaModel metaModel)
        {
            string modelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "core", moduleCsv);

            base.Load( modelPath, metaModel );
        
        }

        protected override void SetNamespace( MetaModel metaModel, string tableCatalog)
        {
            // do nothing
        }

    }

}