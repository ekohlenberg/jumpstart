
CREATE TABLE core.cron_hour (
		id BIGINT ,
		name VARCHAR(10) ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		txn_id bigint PRIMARY KEY
);
CREATE INDEX ON core.cron_hour (id, is_active);
