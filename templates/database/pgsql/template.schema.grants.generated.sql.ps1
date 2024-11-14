@"
GRANT USAGE ON SCHEMA $($schemaName) TO $($namespace); 
GRANT SELECT, UPDATE, INSERT, DELETE ON ALL TABLES IN SCHEMA $($schemaName) TO $($namespace);
"@
