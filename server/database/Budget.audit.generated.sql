create table audit.app_budget (

id BIGINT PRIMARY KEY,
 budget_id BIGINT ,
 org_id BIGINT  not null,
 category_id BIGINT  not null,
 amount NUMERIC(18,4) ,
 start_date DATE ,
 end_date DATE 


);
