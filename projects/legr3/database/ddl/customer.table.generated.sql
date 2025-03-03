
create table app.customer (
		id BIGINT PRIMARY KEY,
		org_id BIGINT  not null,
		customer_name VARCHAR(100)  not null,
		first_name VARCHAR(50) ,
		last_name VARCHAR(50) ,
		email VARCHAR(100) ,
		phone VARCHAR(20) ,
		billing_address VARCHAR(255) ,
		shipping_address VARCHAR(255) ,
		created_date TIMESTAMP ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);