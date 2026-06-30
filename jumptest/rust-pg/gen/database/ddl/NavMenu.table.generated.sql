

CREATE TABLE core.nav_menu (
		id BIGINT ,
		parent_id BIGINT ,
		ordinal INTEGER ,
		name VARCHAR(1000) ,
		link VARCHAR(1000) ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		txn_id bigint PRIMARY KEY
);
CREATE INDEX ON core.nav_menu (id, is_active);
