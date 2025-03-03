
create table audit.app_resource (
    id BIGINT PRIMARY KEY,
		resource_id BIGINT ,
		name VARCHAR(255)  not null,
		resource_type_id BIGINT ,
		ip_address VARCHAR(255) ,
		description VARCHAR(255) ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);