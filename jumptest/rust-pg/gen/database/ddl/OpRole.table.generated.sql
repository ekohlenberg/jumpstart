

CREATE TABLE core.op_role (
		id BIGINT ,
		name VARCHAR(255) ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		txn_id bigint PRIMARY KEY
);
CREATE INDEX ON core.op_role (id, is_active);
