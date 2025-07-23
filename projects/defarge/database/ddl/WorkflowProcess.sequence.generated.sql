CREATE SEQUENCE core.workflow_process_identity AS BIGINT START WITH 1 INCREMENT BY 1;
GRANT USAGE, SELECT ON SEQUENCE core.workflow_process_identity TO defarge;
