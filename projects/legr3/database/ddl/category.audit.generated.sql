
create table audit.app_category (
    id BIGINT PRIMARY KEY,
		category_id BIGINT ,
		org_id BIGINT  not null,
		category_name VARCHAR(100)  not null,
		category_type VARCHAR(50) ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);