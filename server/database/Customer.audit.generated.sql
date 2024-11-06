create table audit.app_customer (

id BIGINT PRIMARY KEY,
 customer_id BIGINT ,
 org_id BIGINT  not null,
 customer_name VARCHAR(100)  not null,
 first_name VARCHAR(50) ,
 last_name VARCHAR(50) ,
 email VARCHAR(100) ,
 phone VARCHAR(20) ,
 billing_address VARCHAR(255) ,
 shipping_address VARCHAR(255) ,
 created_date TIMESTAMP 


);
