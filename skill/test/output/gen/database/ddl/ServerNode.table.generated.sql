
CREATE TABLE core.server_node (
		id BIGINT ,
		server_node_type_id BIGINT ,
		hostname VARCHAR(255) ,
		ip_address VARCHAR(255) ,
		port INTEGER ,
		username VARCHAR(255) ,
		url VARCHAR(255) ,
		user_domain VARCHAR(255) ,
		os_name VARCHAR(255) ,
		os_version VARCHAR(255) ,
		architecture VARCHAR(255) ,
		registered_at TIMESTAMP ,
		server_node_status_id BIGINT ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		txn_id bigint PRIMARY KEY
);
CREATE INDEX ON core.server_node (id, is_active);
