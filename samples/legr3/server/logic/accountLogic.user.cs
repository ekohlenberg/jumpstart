
using System;


namespace legr3
{
    public interface IAccountLogic
    {  
        // Generated methods
        List<Account> select();
        Account get(long id);
        void insert(Account account);
        void update(long id, Account account);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class AccountLogic
    {
        public AccountLogic()
        {
           
        }
        
    }
}

