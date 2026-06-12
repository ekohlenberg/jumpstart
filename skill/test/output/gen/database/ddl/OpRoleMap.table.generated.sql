
CREATE TABLE core.op_role_map (
		id BIGINT ,
		op_id BIGINT ,
		op_role_id BIGINT ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		txn_id bigint PRIMARY KEY
);
CREATE INDEX ON core.op_role_map (id, is_active);
