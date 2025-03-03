
create table audit.app_alert (
    id BIGINT PRIMARY KEY,
		alert_id BIGINT ,
		alert_rule_id BIGINT ,
		metric_event_id BIGINT ,
		triggered_at TIMESTAMP ,
		resolved_at TIMESTAMP ,
		status VARCHAR ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);