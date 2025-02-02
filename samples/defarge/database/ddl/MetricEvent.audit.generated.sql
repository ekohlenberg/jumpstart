
create table audit.app_metric_event (
    id BIGINT PRIMARY KEY,
		metric_event_id BIGINT ,
		metric_id BIGINT  not null,
		event_time TIMESTAMP  not null,
		value NUMERIC(18,4) ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);