-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for PrincipalPassword (core.principal_password)
-- =====================================


INSERT INTO core.sql (id, txn_id, name, sql_text, description, last_updated, last_updated_by, is_active, data_source_id)
SELECT n, n,
    'core.principal_password-select',
    'SELECT
        core.principal_password.id,
            principal_password.principal_id,
            principal_password.password_hash,
            principal_password.expiry,
            principal_password.needs_reset,
            principal_password.is_active,
            principal_password.created_by,
            principal_password.last_updated,
            principal_password.last_updated_by,
            principal_password.txn_id,
            principal.email AS principal_email
    FROM core.principal_password
        LEFT JOIN core.principal principal ON principal_password.principal_id = principal.id AND principal.is_active = 1
    WHERE core.principal_password.is_active = 1
    ORDER BY core.principal_password.id;',
    'Select all PrincipalPassword records with related Principal information',
    NOW(),
    CURRENT_USER,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default' AND is_active = 1)
FROM (SELECT nextval('core.sql_identity') n) t;

INSERT INTO core.sql (id, txn_id, name, sql_text, description, last_updated, last_updated_by, is_active, data_source_id)
SELECT n, n,
    'core.principal_password-get',
    'SELECT
        core.principal_password.id,
            principal_password.principal_id,
            principal_password.password_hash,
            principal_password.expiry,
            principal_password.needs_reset,
            principal_password.is_active,
            principal_password.created_by,
            principal_password.last_updated,
            principal_password.last_updated_by,
            principal_password.txn_id,
            principal.email AS principal_email
    FROM core.principal_password
        LEFT JOIN core.principal principal ON principal_password.principal_id = principal.id AND principal.is_active = 1
    WHERE core.principal_password.id = ^(id) AND core.principal_password.is_active = 1;',
    'Select single PrincipalPassword record by ID with related Principal information',
    NOW(),
    CURRENT_USER,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default' AND is_active = 1)
FROM (SELECT nextval('core.sql_identity') n) t;

INSERT INTO core.sql (id, txn_id, name, sql_text, description, last_updated, last_updated_by, is_active, data_source_id)
SELECT n, n,
    'core.principal_password-get-by-rwk',
    'SELECT
        core.principal_password.id,
            principal_password.principal_id,
            principal_password.password_hash,
            principal_password.expiry,
            principal_password.needs_reset,
            principal_password.is_active,
            principal_password.created_by,
            principal_password.last_updated,
            principal_password.last_updated_by,
            principal_password.txn_id,
            principal.email AS principal_email
    FROM core.principal_password
        LEFT JOIN core.principal principal ON principal_password.principal_id = principal.id AND principal.is_active = 1
    WHERE principal_password.principal_id = ^(principal_id) AND core.principal_password.is_active = 1;',
    'Select single PrincipalPassword record by RWK columns with related Principal information',
    NOW(),
    CURRENT_USER,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default' AND is_active = 1)
FROM (SELECT nextval('core.sql_identity') n) t;

INSERT INTO core.sql (id, txn_id, name, sql_text, description, last_updated, last_updated_by, is_active, data_source_id)
SELECT n, n,
    'core.principal_password-get-history',
    'SELECT
        core.principal_password.*
    FROM core.principal_password
    WHERE core.principal_password.id = ^(id)
    ORDER BY core.principal_password.txn_id DESC;',
    'Select all history records for PrincipalPassword by id, ordered newest first',
    NOW(),
    CURRENT_USER,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default' AND is_active = 1)
FROM (SELECT nextval('core.sql_identity') n) t;


        