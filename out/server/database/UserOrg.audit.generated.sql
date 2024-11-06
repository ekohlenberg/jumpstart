create table audit.sec_user_org (

id BIGINT PRIMARY KEY,
 user_org_id BIGINT ,
 org_id BIGINT  not null,
 user_id BIGINT  not null


);
