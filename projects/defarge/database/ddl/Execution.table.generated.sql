
create table core.execution (
		id BIGINT PRIMARY KEY,
		token VARCHAR(255) ,
		process_id BIGINT ,
		start_time TIMESTAMP ,
		end_time TIMESTAMP ,
		status VARCHAR(50) ,
		log_output VARCHAR(4096) ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);
