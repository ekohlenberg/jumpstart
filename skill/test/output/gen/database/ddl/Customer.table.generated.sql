
CREATE TABLE app.customer (
		id BIGINT ,
		name VARCHAR(255) ,
		email VARCHAR(100) ,
		customer_type_id BIGINT ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		txn_id bigint PRIMARY KEY
);
CREATE INDEX ON app.customer (id, is_active);
