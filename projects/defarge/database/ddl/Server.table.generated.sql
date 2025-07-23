
create table core.server (
		id BIGINT PRIMARY KEY,
		name VARCHAR(50) ,
		type VARCHAR(50) ,
		address VARCHAR(255) ,
		port INTEGER ,
		is_default INTEGER ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);
