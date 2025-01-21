
create table app.transaction_category (
		id BIGINT PRIMARY KEY,
		transaction_id BIGINT ,
		category_id BIGINT ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);