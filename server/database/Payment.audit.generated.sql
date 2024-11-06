create table audit.app_payment (

id BIGINT PRIMARY KEY,
 payment_id BIGINT ,
 invoice_id BIGINT ,
 org_id BIGINT ,
 payment_date TIMESTAMP ,
 amount NUMERIC(18,4) ,
 payment_method VARCHAR(50) ,
 created_date TIMESTAMP 


);
