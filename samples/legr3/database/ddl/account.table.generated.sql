
create table app.account (
		id BIGINT PRIMARY KEY,
		org_id BIGINT  not null,
		account_name VARCHAR(100)  not null,
		account_type VARCHAR(50) ,
		balance NUMERIC(18,4) ,
		created_date TIMESTAMP ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);