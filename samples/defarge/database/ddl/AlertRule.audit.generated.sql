
create table audit.app_alert_rule (
    id BIGINT PRIMARY KEY,
		alert_rule_id BIGINT ,
		metric_id BIGINT  not null,
		name VARCHAR(255)  not null,
		condition VARCHAR(255)  not null,
		threshold NUMERIC(18,4) ,
		recipients VARCHAR(255) ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);