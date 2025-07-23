
create table app.alert_rule (
		id BIGINT PRIMARY KEY,
		metric_id BIGINT ,
		name VARCHAR(255) ,
		condition VARCHAR(255) ,
		threshold NUMERIC(18,4) ,
		recipients VARCHAR(255) ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);
