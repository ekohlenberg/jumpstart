create table app.invoice (

id BIGINT PRIMARY KEY,
 customer_id BIGINT ,
 org_id BIGINT ,
 invoice_number BIGINT ,
 invoice_date TIMESTAMP ,
 due_date TIMESTAMP ,
 total_amount NUMERIC(18,4) ,
 status VARCHAR(50) ,
 created_date TIMESTAMP 


);
