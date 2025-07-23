
create table audit.core_workflow (
    id BIGINT PRIMARY KEY,
		workflow_id BIGINT ,
		parent_workflow_id BIGINT  not null,
		name VARCHAR(255)  not null,
		description VARCHAR(255) ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);