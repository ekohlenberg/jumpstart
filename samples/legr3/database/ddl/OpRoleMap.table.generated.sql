
create table sec.op_role_map (
		id BIGINT PRIMARY KEY,
		op_id BIGINT  not null,
		op_role_id BIGINT  not null,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);