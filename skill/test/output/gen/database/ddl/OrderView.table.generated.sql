
CREATE VIEW app.order_view AS
SELECT 
    customer.id AS id,
    customer.name AS customer_name,
    customer.email AS customer_email,
    customer_type.name AS customer_customer_type_name
FROM app.customer customer
LEFT OUTER JOIN app.customer_type customer_type ON customer.customer_type_id = customer_type.id;
