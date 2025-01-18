
using System;


namespace 
{
    public interface IActionLogic
    {
        List<Action> select();
        Action get(long id);
        void insert(Action action);
        void update(long id, Action action);
        void delete( long id );
    }


    public partial class ActionLogic
    {
        public ActionLogic()
        {
           
        }
        
    }
}

