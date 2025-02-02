
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class MetricEventLogic : IMetricEventLogic
    {


        public static IMetricEventLogic Create()
        {
            var metricevent = new MetricEventLogic();

            var proxy = DispatchProxy.Create<IMetricEventLogic, Proxy<IMetricEventLogic>>();
            ((Proxy<IMetricEventLogic>)proxy).Initialize();
            ((Proxy<IMetricEventLogic>)proxy).Target = metricevent;
            ((Proxy<IMetricEventLogic>)proxy).DomainObj = "MetricEvent";

            return proxy;
        }



        public  List<MetricEvent> select()
        {
            Console.WriteLine("Processing MetricEventLogic select List");

            List<MetricEvent> metricevents = new List<MetricEvent>();

            void metriceventCallback(System.Data.Common.DbDataReader rdr)
            {
                MetricEvent metricevent = new MetricEvent();

                DBPersist.autoAssign(rdr, metricevent);

                metricevents.Add(metricevent);
            };

            DBPersist.select(metriceventCallback, $"select * from app.metric_event");

            return metricevents;
        }

        public  MetricEvent get(long id)
        {
            Console.WriteLine($"Processing MetricEventLogic get ID={id}");

            MetricEvent metricevent = new MetricEvent();
            metricevent.id = id;

            DBPersist.get(metricevent);

            return metricevent;
        }

        public  void insert(MetricEvent metricevent)
        {
            Console.WriteLine($"Processing MetricEventLogic insert: {metricevent}");

            metricevent.is_active = 1;

            DBPersist.insert(metricevent);
        }

        public  void update(long id, MetricEvent metricevent)
        {
            Console.WriteLine($"Processing MetricEventLogic update: ID = {id}\n{metricevent}");

            metricevent.id = id;
            DBPersist.update(metricevent);
        }

        public  void delete(long id)
        {
            MetricEvent metricevent = get(id);
            metricevent.is_active = 0;
            DBPersist.update(metricevent);
        }
    }
}
