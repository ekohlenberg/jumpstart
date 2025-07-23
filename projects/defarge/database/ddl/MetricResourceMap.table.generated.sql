
create table app.metric_resource_map (
		id BIGINT PRIMARY KEY,
		resource_id BIGINT ,
		metric_id BIGINT ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);
