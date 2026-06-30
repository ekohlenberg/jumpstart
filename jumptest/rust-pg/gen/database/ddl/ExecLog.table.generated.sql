

CREATE TABLE core.exec_log (
		id BIGINT ,
		token VARCHAR(255) ,
		workflow_id BIGINT ,
		start_time TIMESTAMP ,
		end_time TIMESTAMP ,
		exec_status_id BIGINT ,
		stdout VARCHAR(4096) ,
		stderr VARCHAR(4096) ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		txn_id bigint PRIMARY KEY
);
CREATE INDEX ON core.exec_log (id, is_active);
