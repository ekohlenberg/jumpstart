
using System;


namespace defarge
{
    public interface IAlertLogic
    {  
        // Generated methods
        List<Alert> select();
        Alert get(long id);
        void insert(Alert alert);
        void update(long id, Alert alert);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class AlertLogic
    {
        public AlertLogic()
        {
           
        }
        
    }
}

