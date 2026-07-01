

CREATE TABLE core.principal_org (
		id BIGINT ,
		org_id BIGINT ,
		principal_id BIGINT ,
		is_active integer ,
		created_by varchar(50) ,
		last_updated timestamp ,
		last_updated_by varchar(50) ,
		txn_id bigint PRIMARY KEY
);
CREATE INDEX ON core.principal_org (id, is_active);
