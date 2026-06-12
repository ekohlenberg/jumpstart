
CREATE TABLE core.event_service (
		id BIGINT ,
		event_type VARCHAR(255) ,
		objectname_filter VARCHAR(255) ,
		methodname_filter VARCHAR(255) ,
		script_id BIGINT ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		txn_id bigint PRIMARY KEY
);
CREATE INDEX ON core.event_service (id, is_active);
