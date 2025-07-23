
create table core.process (
		id BIGINT PRIMARY KEY,
		name VARCHAR(255) ,
		script_id BIGINT ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);
