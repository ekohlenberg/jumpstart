CREATE SEQUENCE app.monitored_resource_identity AS BIGINT START WITH 1 INCREMENT BY 1;
GRANT USAGE, SELECT ON SEQUENCE app.monitored_resource_identity TO defarge;
