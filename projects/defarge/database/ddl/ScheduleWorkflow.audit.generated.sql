
create table audit.core_schedule_workflow (
    id BIGINT PRIMARY KEY,
		schedule_workflow_id BIGINT ,
		schedule_id BIGINT ,
		workflow_id BIGINT ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);