
create table core.workflow (
		id BIGINT PRIMARY KEY,
		parent_workflow_id BIGINT ,
		name VARCHAR(255) ,
		description VARCHAR(255) ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);
