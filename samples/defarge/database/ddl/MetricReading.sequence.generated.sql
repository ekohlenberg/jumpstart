CREATE SEQUENCE app.metric_reading_identity AS BIGINT START WITH 1 INCREMENT BY 1;
GRANT USAGE, SELECT ON SEQUENCE app.metric_reading_identity TO defarge;
