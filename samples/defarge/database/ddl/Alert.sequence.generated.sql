CREATE SEQUENCE app.alert_identity AS BIGINT START WITH 1 INCREMENT BY 1;
GRANT USAGE, SELECT ON SEQUENCE app.alert_identity TO defarge;
