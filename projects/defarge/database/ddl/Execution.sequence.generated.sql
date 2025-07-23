CREATE SEQUENCE core.execution_identity AS BIGINT START WITH 1 INCREMENT BY 1;
GRANT USAGE, SELECT ON SEQUENCE core.execution_identity TO defarge;
