
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr3;

namespace legr3
{
    public partial class AccountLogic : BaseLogic
    {
        public static List<Account> select()
        {
            Console.WriteLine("Processing AccountLogic select List");

            List<Account> accounts = new List<Account>();

            void accountCallback(System.Data.Common.DbDataReader rdr)
            {
                Account account = new Account();

                DBPersist.autoAssign(rdr, account);

                accounts.Add(account);
            };

            DBPersist.select(accountCallback, $"select * from app.account");

            return accounts;
        }

        public static Account get(long id)
        {
            Console.WriteLine($"Processing AccountLogic get ID={id}");

            Account account = new Account();
            account.id = id;

            DBPersist.get(account);

            return account;
        }

        public static void insert(Account account)
        {
            Console.WriteLine($"Processing AccountLogic insert: {account}");

            account.is_active = 1;

            DBPersist.insert(account);
        }

        public static void update(long id, Account account)
        {
            Console.WriteLine($"Processing AccountLogic update: ID = {id}\n{account}");

            account.id = id;
            DBPersist.update(account);
        }

        public static void delete(long id)
        {
            Account account = get(id);
            account.is_active = 0;
            DBPersist.update(account);
        }
    }
}