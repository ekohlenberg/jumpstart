
using System;


namespace defarge
{
    public interface IMetricEventLogic
    {  
        // Generated methods
        List<MetricEvent> select();
        MetricEvent get(long id);
        void insert(MetricEvent metricevent);
        void update(long id, MetricEvent metricevent);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class MetricEventLogic
    {
        public MetricEventLogic()
        {
           
        }
        
    }
}

