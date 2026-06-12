
CREATE TABLE core.workflow (
		id BIGINT ,
		workflow_type_id BIGINT ,
		parent_id BIGINT ,
		name VARCHAR(255) ,
		seq INTEGER ,
		server_node_id BIGINT ,
		process_id BIGINT ,
		exec_status_id BIGINT ,
		last_start_time TIMESTAMP ,
		last_end_time TIMESTAMP ,
		schedule_id BIGINT ,
		on_failure_action_id BIGINT ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		txn_id bigint PRIMARY KEY
);
CREATE INDEX ON core.workflow (id, is_active);
