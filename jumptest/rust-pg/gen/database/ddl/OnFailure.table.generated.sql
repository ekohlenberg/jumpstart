

CREATE TABLE core.on_failure (
		id BIGINT ,
		action VARCHAR(255) ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		txn_id bigint PRIMARY KEY
);
CREATE INDEX ON core.on_failure (id, is_active);
