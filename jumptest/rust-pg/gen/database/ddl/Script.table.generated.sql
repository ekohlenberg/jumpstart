

CREATE TABLE core.script (
		id BIGINT ,
		name VARCHAR(255) ,
		source VARCHAR(4096) ,
		script_type_id BIGINT ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		txn_id bigint PRIMARY KEY
);
CREATE INDEX ON core.script (id, is_active);
