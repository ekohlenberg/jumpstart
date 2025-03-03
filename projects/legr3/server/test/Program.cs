using System;
using System.Collections.Generic;



namespace legr3
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
                


                Logger.Info("Testing Org");
                OrgTest.testInsert();            
                OrgTest.testUpdate();            
                
                Logger.Info("Testing Account");
                AccountTest.testInsert();            
                AccountTest.testUpdate();            
                
                Logger.Info("Testing Customer");
                CustomerTest.testInsert();            
                CustomerTest.testUpdate();            
                
                Logger.Info("Testing Vendor");
                VendorTest.testInsert();            
                VendorTest.testUpdate();            
                
                Logger.Info("Testing Category");
                CategoryTest.testInsert();            
                CategoryTest.testUpdate();            
                
                Logger.Info("Testing UserOrg");
                UserOrgTest.testInsert();            
                UserOrgTest.testUpdate();            
                
                Logger.Info("Testing Transaction");
                TransactionTest.testInsert();            
                TransactionTest.testUpdate();            
                
                Logger.Info("Testing Invoice");
                InvoiceTest.testInsert();            
                InvoiceTest.testUpdate();            
                
                Logger.Info("Testing Bill");
                BillTest.testInsert();            
                BillTest.testUpdate();            
                
                Logger.Info("Testing Budget");
                BudgetTest.testInsert();            
                BudgetTest.testUpdate();            
                
                Logger.Info("Testing TransactionCategory");
                TransactionCategoryTest.testInsert();            
                TransactionCategoryTest.testUpdate();            
                
                Logger.Info("Testing InvoiceItem");
                InvoiceItemTest.testInsert();            
                InvoiceItemTest.testUpdate();            
                
                Logger.Info("Testing Payment");
                PaymentTest.testInsert();            
                PaymentTest.testUpdate();            
                
                Logger.Info("Testing BillItem");
                BillItemTest.testInsert();            
                BillItemTest.testUpdate();            
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
