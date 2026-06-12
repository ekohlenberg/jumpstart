
CREATE TABLE core.process (
		id BIGINT ,
		name VARCHAR(255) ,
		script_id BIGINT ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		txn_id bigint PRIMARY KEY
);
CREATE INDEX ON core.process (id, is_active);
