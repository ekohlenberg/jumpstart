CREATE SEQUENCE app.payment_identity AS BIGINT START WITH 1 INCREMENT BY 1;
GRANT USAGE, SELECT ON SEQUENCE app.payment_identity TO legr3;
