

CREATE TABLE app.test_plan (
		id BIGINT ,
		name VARCHAR(255) ,
		description TEXT ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		txn_id bigint PRIMARY KEY
);
CREATE INDEX ON app.test_plan (id, is_active);
