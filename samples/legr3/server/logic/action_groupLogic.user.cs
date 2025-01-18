
using System;


namespace 
{
    public interface IActionGroupLogic
    {
        List<ActionGroup> select();
        ActionGroup get(long id);
        void insert(ActionGroup actiongroup);
        void update(long id, ActionGroup actiongroup);
        void delete( long id );
    }


    public partial class ActionGroupLogic
    {
        public ActionGroupLogic()
        {
           
        }
        
    }
}

