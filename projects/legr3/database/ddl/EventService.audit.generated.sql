
create table audit.core_event_service (
    id BIGINT PRIMARY KEY,
		event_service_id BIGINT ,
		event_type VARCHAR(255)  not null,
		objectname_filter VARCHAR(255)  not null,
		methodname_filter VARCHAR(255)  not null,
		script_id BIGINT  not null,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);