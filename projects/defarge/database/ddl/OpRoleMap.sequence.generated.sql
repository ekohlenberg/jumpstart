CREATE SEQUENCE sec.op_role_map_identity AS BIGINT START WITH 1 INCREMENT BY 1;
GRANT USAGE, SELECT ON SEQUENCE sec.op_role_map_identity TO defarge;
