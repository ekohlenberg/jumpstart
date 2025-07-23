
create table core.schedule (
		id BIGINT PRIMARY KEY,
		cron_expression VARCHAR(255) ,
		next_run_time TIMESTAMP ,
		last_run_time TIMESTAMP ,
		status VARCHAR(50) ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);
