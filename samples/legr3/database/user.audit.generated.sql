
create table audit.sec_user (
    id BIGINT PRIMARY KEY,
		user_id BIGINT ,
		password_hash VARCHAR(255) ,
		first_name VARCHAR(50) ,
		last_name VARCHAR(50) ,
		username VARCHAR(50) ,
		email VARCHAR(100)  not null,
		created_date TIMESTAMP ,
		last_login_date TIMESTAMP ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);