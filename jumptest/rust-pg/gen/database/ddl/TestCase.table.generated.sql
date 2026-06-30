

CREATE TABLE app.test_case (
		id BIGINT ,
		test_plan_id BIGINT ,
		code VARCHAR(50) ,
		area VARCHAR(100) ,
		title VARCHAR(255) ,
		preconditions TEXT ,
		steps TEXT ,
		expected_result TEXT ,
		priority VARCHAR(10) ,
		component VARCHAR(100) ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		txn_id bigint PRIMARY KEY
);
CREATE INDEX ON app.test_case (id, is_active);
