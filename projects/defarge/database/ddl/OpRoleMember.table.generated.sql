
create table sec.op_role_member (
		id BIGINT PRIMARY KEY,
		user_id BIGINT ,
		op_role_id BIGINT ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);
