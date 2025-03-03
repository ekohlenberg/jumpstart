
create table app.metric_reading (
		id () PRIMARY KEY,
		metric_id BIGINT() ,
		reading_timestamp () ,
		value () ,
		created_at () ,
		updated_at () ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);