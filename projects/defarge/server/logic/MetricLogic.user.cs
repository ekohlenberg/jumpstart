
using System;


namespace defarge
{
    public interface IMetricLogic
    {  
        // Generated methods
        List<Metric> select();
        Metric get(long id);
        void insert(Metric metric);
        void update(long id, Metric metric);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class MetricLogic
    {
        public MetricLogic()
        {
           
        }
        
    }
}

