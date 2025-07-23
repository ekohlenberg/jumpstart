
create table audit.core_server (
    id BIGINT PRIMARY KEY,
		server_id BIGINT ,
		name VARCHAR(50)  not null,
		type VARCHAR(50)  not null,
		address VARCHAR(255)  not null,
		port INTEGER  not null,
		is_default INTEGER ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);