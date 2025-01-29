@echo off
psql --host=localhost --port=5433 --dbname=postgres --username=postgres --file=.\legr3.database.create.generated.sql


            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\audit.schema.create.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\app.schema.create.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\core.schema.create.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\sec.schema.create.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Org.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Org.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Org.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Org.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\User.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\User.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\User.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\User.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Script.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Script.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Script.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Script.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Operation.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Operation.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Operation.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Operation.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\OpRole.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\OpRole.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\OpRole.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\OpRole.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Account.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Account.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Account.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Account.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Customer.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Customer.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Customer.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Customer.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Vendor.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Vendor.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Vendor.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Vendor.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Category.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Category.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Category.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Category.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\UserOrg.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\UserOrg.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\UserOrg.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\UserOrg.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\UserPassword.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\UserPassword.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\UserPassword.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\UserPassword.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\EventService.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\EventService.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\EventService.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\EventService.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\OpRoleMap.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\OpRoleMap.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\OpRoleMap.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\OpRoleMap.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\OpRoleMember.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\OpRoleMember.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\OpRoleMember.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\OpRoleMember.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Transaction.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Transaction.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Transaction.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Transaction.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Invoice.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Invoice.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Invoice.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Invoice.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Bill.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Bill.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Bill.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Bill.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Budget.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Budget.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Budget.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Budget.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\TransactionCategory.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\TransactionCategory.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\TransactionCategory.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\TransactionCategory.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\InvoiceItem.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\InvoiceItem.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\InvoiceItem.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\InvoiceItem.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Payment.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Payment.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Payment.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\Payment.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\BillItem.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\BillItem.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\BillItem.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\BillItem.rwkindex.generated.sql
        