
create table audit.app_uom (
    id BIGINT PRIMARY KEY,
		uom_id BIGINT ,
		Name VARCHAR(255)  not null,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		version integer 
);