

CREATE TABLE core.principal (
		id BIGINT ,
		first_name VARCHAR(50) ,
		last_name VARCHAR(50) ,
		username VARCHAR(50) ,
		email VARCHAR(100) ,
		status INTEGER ,
		created_date TIMESTAMP ,
		last_login_date TIMESTAMP ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		txn_id bigint PRIMARY KEY
);
CREATE INDEX ON core.principal (id, is_active);
