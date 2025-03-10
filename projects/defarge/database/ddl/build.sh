export PSQLCMD="psql --host=localhost --port=5432 --dbname=defarge --username=postgres"
psql --host=localhost --port=5432 --dbname=postgres --username=postgres --file=./defarge.database.create.generated.sql

$PSQLCMD --file=./audit.schema.create.generated.sql
$PSQLCMD --file=./app.schema.create.generated.sql
$PSQLCMD --file=./core.schema.create.generated.sql
$PSQLCMD --file=./sec.schema.create.generated.sql
$PSQLCMD --file=./Category.table.generated.sql
$PSQLCMD --file=./Category.audit.generated.sql
$PSQLCMD --file=./Category.sequence.generated.sql
$PSQLCMD --file=./Category.rwkindex.generated.sql
$PSQLCMD --file=./Uom.table.generated.sql
$PSQLCMD --file=./Uom.audit.generated.sql
$PSQLCMD --file=./Uom.sequence.generated.sql
$PSQLCMD --file=./Uom.rwkindex.generated.sql
$PSQLCMD --file=./ResourceType.table.generated.sql
$PSQLCMD --file=./ResourceType.audit.generated.sql
$PSQLCMD --file=./ResourceType.sequence.generated.sql
$PSQLCMD --file=./ResourceType.rwkindex.generated.sql
$PSQLCMD --file=./Org.table.generated.sql
$PSQLCMD --file=./Org.audit.generated.sql
$PSQLCMD --file=./Org.sequence.generated.sql
$PSQLCMD --file=./Org.rwkindex.generated.sql
$PSQLCMD --file=./User.table.generated.sql
$PSQLCMD --file=./User.audit.generated.sql
$PSQLCMD --file=./User.sequence.generated.sql
$PSQLCMD --file=./User.rwkindex.generated.sql
$PSQLCMD --file=./Script.table.generated.sql
$PSQLCMD --file=./Script.audit.generated.sql
$PSQLCMD --file=./Script.sequence.generated.sql
$PSQLCMD --file=./Script.rwkindex.generated.sql
$PSQLCMD --file=./Operation.table.generated.sql
$PSQLCMD --file=./Operation.audit.generated.sql
$PSQLCMD --file=./Operation.sequence.generated.sql
$PSQLCMD --file=./Operation.rwkindex.generated.sql
$PSQLCMD --file=./OpRole.table.generated.sql
$PSQLCMD --file=./OpRole.audit.generated.sql
$PSQLCMD --file=./OpRole.sequence.generated.sql
$PSQLCMD --file=./OpRole.rwkindex.generated.sql
$PSQLCMD --file=./Metric.table.generated.sql
$PSQLCMD --file=./Metric.audit.generated.sql
$PSQLCMD --file=./Metric.sequence.generated.sql
$PSQLCMD --file=./Metric.rwkindex.generated.sql
$PSQLCMD --file=./Resource.table.generated.sql
$PSQLCMD --file=./Resource.audit.generated.sql
$PSQLCMD --file=./Resource.sequence.generated.sql
$PSQLCMD --file=./Resource.rwkindex.generated.sql
$PSQLCMD --file=./UserOrg.table.generated.sql
$PSQLCMD --file=./UserOrg.audit.generated.sql
$PSQLCMD --file=./UserOrg.sequence.generated.sql
$PSQLCMD --file=./UserOrg.rwkindex.generated.sql
$PSQLCMD --file=./UserPassword.table.generated.sql
$PSQLCMD --file=./UserPassword.audit.generated.sql
$PSQLCMD --file=./UserPassword.sequence.generated.sql
$PSQLCMD --file=./UserPassword.rwkindex.generated.sql
$PSQLCMD --file=./EventService.table.generated.sql
$PSQLCMD --file=./EventService.audit.generated.sql
$PSQLCMD --file=./EventService.sequence.generated.sql
$PSQLCMD --file=./EventService.rwkindex.generated.sql
$PSQLCMD --file=./OpRoleMap.table.generated.sql
$PSQLCMD --file=./OpRoleMap.audit.generated.sql
$PSQLCMD --file=./OpRoleMap.sequence.generated.sql
$PSQLCMD --file=./OpRoleMap.rwkindex.generated.sql
$PSQLCMD --file=./OpRoleMember.table.generated.sql
$PSQLCMD --file=./OpRoleMember.audit.generated.sql
$PSQLCMD --file=./OpRoleMember.sequence.generated.sql
$PSQLCMD --file=./OpRoleMember.rwkindex.generated.sql
$PSQLCMD --file=./MetricEvent.table.generated.sql
$PSQLCMD --file=./MetricEvent.audit.generated.sql
$PSQLCMD --file=./MetricEvent.sequence.generated.sql
$PSQLCMD --file=./MetricEvent.rwkindex.generated.sql
$PSQLCMD --file=./AlertRule.table.generated.sql
$PSQLCMD --file=./AlertRule.audit.generated.sql
$PSQLCMD --file=./AlertRule.sequence.generated.sql
$PSQLCMD --file=./AlertRule.rwkindex.generated.sql
$PSQLCMD --file=./MetricResourceMap.table.generated.sql
$PSQLCMD --file=./MetricResourceMap.audit.generated.sql
$PSQLCMD --file=./MetricResourceMap.sequence.generated.sql
$PSQLCMD --file=./MetricResourceMap.rwkindex.generated.sql
$PSQLCMD --file=./Alert.table.generated.sql
$PSQLCMD --file=./Alert.audit.generated.sql
$PSQLCMD --file=./Alert.sequence.generated.sql
$PSQLCMD --file=./Alert.rwkindex.generated.sql
