@echo off
psql --host=localhost --port=5433 --dbname=postgres --username=postgres --file=.\legr3.database.create.generated.sql


            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\audit.schema.create.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\sec.schema.create.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\app.schema.create.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\core.schema.create.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\org.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\org.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\org.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\org.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\user.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\user.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\user.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\user.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\user_org.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\user_org.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\user_org.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\user_org.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\account.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\account.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\account.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\account.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\customer.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\customer.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\customer.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\customer.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\vendor.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\vendor.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\vendor.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\vendor.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\invoice.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\invoice.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\invoice.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\invoice.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\invoice_item.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\invoice_item.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\invoice_item.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\invoice_item.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\bill.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\bill.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\bill.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\bill.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\bill_item.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\bill_item.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\bill_item.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\bill_item.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\payment.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\payment.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\payment.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\payment.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\transaction.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\transaction.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\transaction.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\transaction.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\category.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\category.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\category.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\category.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\transaction_category.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\transaction_category.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\transaction_category.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\transaction_category.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\budget.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\budget.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\budget.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\budget.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\script.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\script.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\script.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\script.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\action.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\action.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\action.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\action.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\action_group.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\action_group.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\action_group.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\action_group.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\on_event.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\on_event.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\on_event.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\on_event.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\action_group_map.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\action_group_map.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\action_group_map.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\action_group_map.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\user_action_group.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\user_action_group.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\user_action_group.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=legr3 --username=postgres --file=.\user_action_group.rwkindex.generated.sql
        