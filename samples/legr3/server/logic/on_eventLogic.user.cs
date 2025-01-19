
using System;


namespace legr3
{
    public interface IOnEventLogic
    {
        List<OnEvent> select();
        OnEvent get(long id);
        void insert(OnEvent onevent);
        void update(long id, OnEvent onevent);
        void delete( long id );
    }


    public partial class OnEventLogic
    {
        public OnEventLogic()
        {
           
        }
        
    }
}

