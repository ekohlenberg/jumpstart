
create table audit.sec_op_role (
    id BIGINT PRIMARY KEY,
		op_role_id BIGINT ,
		name VARCHAR(255)  not null,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);