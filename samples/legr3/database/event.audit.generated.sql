
create table audit.core_event (
    id BIGINT PRIMARY KEY,
		event_id BIGINT ,
		object VARCHAR(50)  not null,
		method VARCHAR(50)  not null,
		script_id BIGINT  not null,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);