
create table audit.core_on_event (
    id BIGINT PRIMARY KEY,
		on_event_id BIGINT ,
		objectname VARCHAR(50)  not null,
		methodname VARCHAR(50)  not null,
		script_id BIGINT  not null,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);