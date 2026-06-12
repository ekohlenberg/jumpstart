
CREATE TABLE core.principal_password (
		id BIGINT ,
		principal_id BIGINT ,
		password_hash VARCHAR(255) ,
		expiry TIMESTAMP ,
		needs_reset INTEGER ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		txn_id bigint PRIMARY KEY
);
CREATE INDEX ON core.principal_password (id, is_active);
