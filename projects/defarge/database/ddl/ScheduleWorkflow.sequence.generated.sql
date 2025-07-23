CREATE SEQUENCE core.schedule_workflow_identity AS BIGINT START WITH 1 INCREMENT BY 1;
GRANT USAGE, SELECT ON SEQUENCE core.schedule_workflow_identity TO defarge;
