
create table audit.sec_user_action_group (
    id BIGINT PRIMARY KEY,
		user_action_group_id BIGINT ,
		user_id BIGINT  not null,
		action_group_id BIGINT  not null,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);