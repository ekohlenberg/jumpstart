@echo off
psql --host=localhost --port=5433 --dbname=postgres --username=postgres --file=.\defarge.database.create.generated.sql


            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\audit.schema.create.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\app.schema.create.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\core.schema.create.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\sec.schema.create.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Category.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Category.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Category.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Category.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Uom.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Uom.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Uom.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Uom.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\ResourceType.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\ResourceType.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\ResourceType.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\ResourceType.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Org.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Org.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Org.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Org.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\User.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\User.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\User.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\User.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Script.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Script.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Script.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Script.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Operation.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Operation.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Operation.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Operation.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\OpRole.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\OpRole.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\OpRole.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\OpRole.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Schedule.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Schedule.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Schedule.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Schedule.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Workflow.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Workflow.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Workflow.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Workflow.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Server.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Server.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Server.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Server.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Metric.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Metric.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Metric.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Metric.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Resource.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Resource.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Resource.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Resource.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\UserOrg.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\UserOrg.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\UserOrg.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\UserOrg.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\UserPassword.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\UserPassword.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\UserPassword.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\UserPassword.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\EventService.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\EventService.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\EventService.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\EventService.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Process.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Process.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Process.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Process.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\OpRoleMap.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\OpRoleMap.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\OpRoleMap.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\OpRoleMap.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\OpRoleMember.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\OpRoleMember.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\OpRoleMember.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\OpRoleMember.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\ScheduleWorkflow.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\ScheduleWorkflow.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\ScheduleWorkflow.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\ScheduleWorkflow.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\MetricEvent.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\MetricEvent.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\MetricEvent.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\MetricEvent.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\AlertRule.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\AlertRule.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\AlertRule.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\AlertRule.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\MetricResourceMap.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\MetricResourceMap.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\MetricResourceMap.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\MetricResourceMap.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Execution.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Execution.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Execution.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Execution.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\WorkflowProcess.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\WorkflowProcess.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\WorkflowProcess.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\WorkflowProcess.rwkindex.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Alert.table.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Alert.audit.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Alert.sequence.generated.sql
        
            psql --host=localhost --port=5433 --dbname=defarge --username=postgres --file=.\Alert.rwkindex.generated.sql
        