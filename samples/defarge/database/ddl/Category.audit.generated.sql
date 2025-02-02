
create table audit.app_category (
    id BIGINT PRIMARY KEY,
		category_id BIGINT ,
		parent_id BIGINT  not null,
		name VARCHAR(255)  not null,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);