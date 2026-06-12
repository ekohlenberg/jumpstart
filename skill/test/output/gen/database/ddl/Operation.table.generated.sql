
CREATE TABLE core.operation (
		id BIGINT ,
		objectname VARCHAR(50) ,
		methodname VARCHAR(50) ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		txn_id bigint PRIMARY KEY
);
CREATE INDEX ON core.operation (id, is_active);
