
using System;


namespace legr3
{
    public interface IActionGroupMapLogic
    {
        List<ActionGroupMap> select();
        ActionGroupMap get(long id);
        void insert(ActionGroupMap actiongroupmap);
        void update(long id, ActionGroupMap actiongroupmap);
        void delete( long id );
    }


    public partial class ActionGroupMapLogic
    {
        public ActionGroupMapLogic()
        {
           
        }
        
    }
}

