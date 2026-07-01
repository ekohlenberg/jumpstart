

CREATE TABLE core.sql (
		id BIGINT ,
		name VARCHAR(255) ,
		data_source_id BIGINT ,
		sql_text VARCHAR(4096) ,
		description VARCHAR(1000) ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		txn_id bigint PRIMARY KEY
);
CREATE INDEX ON core.sql (id, is_active);
