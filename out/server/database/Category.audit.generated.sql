create table audit.app_category (

id BIGINT PRIMARY KEY,
 category_id BIGINT ,
 org_id BIGINT  not null,
 category_name VARCHAR(100)  not null,
 category_type VARCHAR(50) 


);
