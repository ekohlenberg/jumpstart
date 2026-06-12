
CREATE TABLE app.order (
		id BIGINT ,
		customer_id BIGINT ,
		order_date TIMESTAMP ,
		amount NUMERIC ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		txn_id bigint PRIMARY KEY
);
CREATE INDEX ON app.order (id, is_active);
