
create table audit.app_monitored_resource (
    id BIGINT PRIMARY KEY,
		monitored_resource_id () ,
		name () ,
		resource_type () ,
		ip_address () ,
		description () ,
		created_at () ,
		updated_at () ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);