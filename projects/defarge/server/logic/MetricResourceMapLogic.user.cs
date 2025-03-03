
using System;


namespace defarge
{
    public interface IMetricResourceMapLogic
    {  
        // Generated methods
        List<MetricResourceMap> select();
        MetricResourceMap get(long id);
        void insert(MetricResourceMap metricresourcemap);
        void update(long id, MetricResourceMap metricresourcemap);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class MetricResourceMapLogic
    {
        public MetricResourceMapLogic()
        {
           
        }
        
    }
}

