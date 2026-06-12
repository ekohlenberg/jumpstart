
CREATE TABLE core.schedule (
		id BIGINT ,
		name VARCHAR(255) ,
		cron_every_id BIGINT ,
		cron_minute_id BIGINT ,
		cron_hour_id BIGINT ,
		cron_dom_id BIGINT ,
		cron_month_id BIGINT ,
		cron_dow_id BIGINT ,
		schedule_label VARCHAR(255) ,
		next_run_time TIMESTAMP ,
		last_run_time TIMESTAMP ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		txn_id bigint PRIMARY KEY
);
CREATE INDEX ON core.schedule (id, is_active);
