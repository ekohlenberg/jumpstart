
create table audit.sec_action (
    id BIGINT PRIMARY KEY,
		action_id BIGINT ,
		object VARCHAR(50) ,
		method VARCHAR(50) ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);