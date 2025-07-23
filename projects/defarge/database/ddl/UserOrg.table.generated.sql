
create table app.user_org (
		id BIGINT PRIMARY KEY,
		org_id BIGINT ,
		user_id BIGINT ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);
