using System;
using System.Collections.Generic;



namespace defarge
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
                List<OpRole> opRoles = OpRoleLogic.Create().select();
                var adminRole = opRoles.Find(role => role.name == "Administrator");

                BaseTest.addLastId("op_role", adminRole.id);

                List<User> users = UserLogic.Create().select();
                var currentUser = users.Find(user => user.username == Environment.UserName);

                if (currentUser == null)
                {
                    UserTest.testInsert();  
                    long userId = BaseTest.getLastId("User");
                    OpRoleMemberTest.testInsert();
                }
                else
                {
                    BaseTest.addLastId("user", currentUser.id);

                    List<OpRoleMember> opRoleMembers = OpRoleMemberLogic.Create().select();
                    var adminRoleMembership = opRoleMembers.Find(membership => membership.user_id == currentUser.id && membership.op_role_id == adminRole.id);

                    if (adminRoleMembership == null)
                    {
                        OpRoleMemberTest.testInsert();
                    }
                }
                


                Logger.Info("Testing Category");
                CategoryTest.testInsert();            
                CategoryTest.testUpdate();            
                
                Logger.Info("Testing Uom");
                UomTest.testInsert();            
                UomTest.testUpdate();            
                
                Logger.Info("Testing ResourceType");
                ResourceTypeTest.testInsert();            
                ResourceTypeTest.testUpdate();            
                
                Logger.Info("Testing Org");
                OrgTest.testInsert();            
                OrgTest.testUpdate();            
                
                Logger.Info("Testing Metric");
                MetricTest.testInsert();            
                MetricTest.testUpdate();            
                
                Logger.Info("Testing Resource");
                ResourceTest.testInsert();            
                ResourceTest.testUpdate();            
                
                Logger.Info("Testing UserOrg");
                UserOrgTest.testInsert();            
                UserOrgTest.testUpdate();            
                
                Logger.Info("Testing MetricEvent");
                MetricEventTest.testInsert();            
                MetricEventTest.testUpdate();            
                
                Logger.Info("Testing AlertRule");
                AlertRuleTest.testInsert();            
                AlertRuleTest.testUpdate();            
                
                Logger.Info("Testing MetricResourceMap");
                MetricResourceMapTest.testInsert();            
                MetricResourceMapTest.testUpdate();            
                
                Logger.Info("Testing Alert");
                AlertTest.testInsert();            
                AlertTest.testUpdate();            
                            }
            catch( Exception x)
            {
                Logger.Error("Error executing test: ", x);
                Console.WriteLine(x.Message);
                Console.WriteLine(x.StackTrace);

                if (x.InnerException != null)
                {
                    x = x.InnerException;
                    Console.WriteLine(x.Message);
                    Console.WriteLine(x.StackTrace);
                }	
            }
		}
    }
}
