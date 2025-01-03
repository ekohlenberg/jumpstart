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

                OrgTest.testInsert();            
                OrgTest.testUpdate();            
                
                UserTest.testInsert();            
                UserTest.testUpdate();            
                
                UserOrgTest.testInsert();            
                UserOrgTest.testUpdate();            
                
                AccountTest.testInsert();            
                AccountTest.testUpdate();            
                
                CustomerTest.testInsert();            
                CustomerTest.testUpdate();            
                
                VendorTest.testInsert();            
                VendorTest.testUpdate();            
                
                InvoiceTest.testInsert();            
                InvoiceTest.testUpdate();            
                
                InvoiceItemTest.testInsert();            
                InvoiceItemTest.testUpdate();            
                
                BillTest.testInsert();            
                BillTest.testUpdate();            
                
                BillItemTest.testInsert();            
                BillItemTest.testUpdate();            
                
                PaymentTest.testInsert();            
                PaymentTest.testUpdate();            
                
                TransactionTest.testInsert();            
                TransactionTest.testUpdate();            
                
                CategoryTest.testInsert();            
                CategoryTest.testUpdate();            
                
                TransactionCategoryTest.testInsert();            
                TransactionCategoryTest.testUpdate();            
                
                BudgetTest.testInsert();            
                BudgetTest.testUpdate();            
                            }
            catch( Exception x)
            {
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
