@"
CREATE SEQUENCE $($schemaName)_$($tableName)_identity AS BIGINT START WITH 1 INCREMENT BY 1;
"@