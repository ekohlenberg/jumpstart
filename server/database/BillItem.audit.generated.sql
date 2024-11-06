create table audit.app_bill_item (

id BIGINT PRIMARY KEY,
 bill_item_id BIGINT ,
 bill_id BIGINT ,
 description VARCHAR(255) ,
 quantity INTEGER ,
 unit_price NUMERIC(18,4) ,
 total_amount NUMERIC(18,4) 


);
