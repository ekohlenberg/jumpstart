CREATE SEQUENCE app.invoice_item_identity AS BIGINT START WITH 1 INCREMENT BY 1;
GRANT USAGE, SELECT ON SEQUENCE app.invoice_item_identity TO legr3;
