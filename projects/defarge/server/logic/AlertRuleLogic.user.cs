
using System;


namespace defarge
{
    public interface IAlertRuleLogic
    {  
        // Generated methods
        List<AlertRule> select();
        AlertRule get(long id);
        void insert(AlertRule alertrule);
        void update(long id, AlertRule alertrule);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class AlertRuleLogic
    {
        public AlertRuleLogic()
        {
           
        }
        
    }
}

