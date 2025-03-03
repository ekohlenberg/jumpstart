
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class MetricResourceMapLogic : IMetricResourceMapLogic
    {


        public static IMetricResourceMapLogic Create()
        {
            var metricresourcemap = new MetricResourceMapLogic();

            var proxy = DispatchProxy.Create<IMetricResourceMapLogic, Proxy<IMetricResourceMapLogic>>();
            ((Proxy<IMetricResourceMapLogic>)proxy).Initialize();
            ((Proxy<IMetricResourceMapLogic>)proxy).Target = metricresourcemap;
            ((Proxy<IMetricResourceMapLogic>)proxy).DomainObj = "MetricResourceMap";

            return proxy;
        }



        public  List<MetricResourceMap> select()
        {
            Console.WriteLine("Processing MetricResourceMapLogic select List");

            List<MetricResourceMap> metricresourcemaps = new List<MetricResourceMap>();

            void metricresourcemapCallback(System.Data.Common.DbDataReader rdr)
            {
                MetricResourceMap metricresourcemap = new MetricResourceMap();

                DBPersist.autoAssign(rdr, metricresourcemap);

                metricresourcemaps.Add(metricresourcemap);
            };

            DBPersist.select(metricresourcemapCallback, $"select * from app.metric_resource_map");

            return metricresourcemaps;
        }

        public  MetricResourceMap get(long id)
        {
            Console.WriteLine($"Processing MetricResourceMapLogic get ID={id}");

            MetricResourceMap metricresourcemap = new MetricResourceMap();
            metricresourcemap.id = id;

            DBPersist.get(metricresourcemap);

            return metricresourcemap;
        }

        public  void insert(MetricResourceMap metricresourcemap)
        {
            Console.WriteLine($"Processing MetricResourceMapLogic insert: {metricresourcemap}");

            metricresourcemap.is_active = 1;

            DBPersist.insert(metricresourcemap);
        }

        public  void update(long id, MetricResourceMap metricresourcemap)
        {
            Console.WriteLine($"Processing MetricResourceMapLogic update: ID = {id}\n{metricresourcemap}");

            metricresourcemap.id = id;
            DBPersist.update(metricresourcemap);
        }

        public  void delete(long id)
        {
            MetricResourceMap metricresourcemap = get(id);
            metricresourcemap.is_active = 0;
            DBPersist.update(metricresourcemap);
        }
    }
}
