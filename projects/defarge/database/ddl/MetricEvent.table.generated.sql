
create table app.metric_event (
		id BIGINT PRIMARY KEY,
		metric_id BIGINT ,
		event_time TIMESTAMP ,
		value NUMERIC(18,4) ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);
