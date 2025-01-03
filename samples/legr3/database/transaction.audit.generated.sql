
create table audit.app_transaction (
    id BIGINT PRIMARY KEY,
		transaction_id BIGINT ,
		account_id BIGINT ,
		org_id BIGINT ,
		transaction_date TIMESTAMP ,
		amount NUMERIC(18,4) ,
		transaction_type VARCHAR(50) ,
		description VARCHAR(255) ,
		created_date TIMESTAMP ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);