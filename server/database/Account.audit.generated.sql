create table audit.app_account (

id BIGINT PRIMARY KEY,
 account_id BIGINT ,
 org_id BIGINT  not null,
 account_name VARCHAR(100)  not null,
 account_type VARCHAR(50) ,
 balance NUMERIC(18,4) ,
 created_date TIMESTAMP 


);
