

CREATE TABLE app.test_run (
		id BIGINT ,
		name VARCHAR(255) ,
		test_plan_id BIGINT ,
		run_at TIMESTAMP ,
		run_by VARCHAR(50) ,
		notes TEXT ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		txn_id bigint PRIMARY KEY
);
CREATE INDEX ON app.test_run (id, is_active);
