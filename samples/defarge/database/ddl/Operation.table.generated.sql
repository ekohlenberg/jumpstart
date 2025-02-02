
create table sec.operation (
		id BIGINT PRIMARY KEY,
		objectname VARCHAR(50) ,
		methodname VARCHAR(50) ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);