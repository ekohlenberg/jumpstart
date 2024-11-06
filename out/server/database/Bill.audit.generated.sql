create table audit.app_bill (

id BIGINT PRIMARY KEY,
 bill_id BIGINT ,
 vendor_id BIGINT ,
 org_id BIGINT ,
 bill_number BIGINT ,
 bill_date TIMESTAMP ,
 due_date TIMESTAMP ,
 total_amount NUMERIC(18,4) ,
 status VARCHAR(50) ,
 created_date TIMESTAMP 


);
