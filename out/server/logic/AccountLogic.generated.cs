using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr;


namespace legr
{
    public partial class AccountLogic : Logic
    {
    
        public static List<Account> select()
        {
            Console.WriteLine("Processing AccountLogic select List" );

            List<Account> accounts = [];

            void accountCallback(System.Data.Common.DbDataReader rdr) 
            {
                Account account = [];

                DBPersist.autoAssign(rdr, account);

                accounts.Add(account);
            };

            DBPersist.select(accountCallback, "select * from app.account");

            return accounts;
        }

        
        public static Account get(long id)
        {
            Console.WriteLine("Processing AccountLogic get ID=" + id.ToString());

            Account account = [];
            account.id = id;

            DBPersist.get(account);

            return account;
        }

        
        public static void insert( Account account)
        {
            Console.WriteLine("Processing AccountLogic insert: " + account.ToString()  );

            account.is_active = "Y";

            DBPersist.insert(account);
        }

       
        public static void update(long id,  Account account)
        {
            Console.WriteLine("Processing AccountLogic update: ID = " + id.ToString() + "\n" + account.ToString()  );

            account.id = id;
            DBPersist.update(account);
        }

        
        public static void delete(long id)
        {
            Account account = get(id);
            account.is_active = "N";
             DBPersist.update(account);
        }
    }
}
