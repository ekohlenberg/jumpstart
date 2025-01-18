
create table audit.sec_action_group_map (
    id BIGINT PRIMARY KEY,
		action_group_map_id BIGINT ,
		action_id BIGINT  not null,
		action_group_id BIGINT  not null,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);