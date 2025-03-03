
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class MetricLogic : IMetricLogic
    {


        public static IMetricLogic Create()
        {
            var metric = new MetricLogic();

            var proxy = DispatchProxy.Create<IMetricLogic, Proxy<IMetricLogic>>();
            ((Proxy<IMetricLogic>)proxy).Initialize();
            ((Proxy<IMetricLogic>)proxy).Target = metric;
            ((Proxy<IMetricLogic>)proxy).DomainObj = "Metric";

            return proxy;
        }



        public  List<Metric> select()
        {
            Console.WriteLine("Processing MetricLogic select List");

            List<Metric> metrics = new List<Metric>();

            void metricCallback(System.Data.Common.DbDataReader rdr)
            {
                Metric metric = new Metric();

                DBPersist.autoAssign(rdr, metric);

                metrics.Add(metric);
            };

            DBPersist.select(metricCallback, $"select * from app.metric");

            return metrics;
        }

        public  Metric get(long id)
        {
            Console.WriteLine($"Processing MetricLogic get ID={id}");

            Metric metric = new Metric();
            metric.id = id;

            DBPersist.get(metric);

            return metric;
        }

        public  void insert(Metric metric)
        {
            Console.WriteLine($"Processing MetricLogic insert: {metric}");

            metric.is_active = 1;

            DBPersist.insert(metric);
        }

        public  void update(long id, Metric metric)
        {
            Console.WriteLine($"Processing MetricLogic update: ID = {id}\n{metric}");

            metric.id = id;
            DBPersist.update(metric);
        }

        public  void delete(long id)
        {
            Metric metric = get(id);
            metric.is_active = 0;
            DBPersist.update(metric);
        }
    }
}
