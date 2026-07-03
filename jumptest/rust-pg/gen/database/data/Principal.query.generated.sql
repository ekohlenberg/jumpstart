-- =====================================
-- Generate SELECT queries for all objects
-- =====================================


-- =====================================
-- Query for Principal (core.principal)
-- =====================================


INSERT INTO core.sql (id, txn_id, name, sql_text, description, last_updated, last_updated_by, is_active, data_source_id)
SELECT n, n,
    'core.principal-select',
    'SELECT
        core.principal.id,
            principal.first_name,
            principal.last_name,
            principal.username,
            principal.email,
            principal.enabled,
            principal.created_date,
            principal.last_login_date,
            principal.is_active,
            principal.created_by,
            principal.last_updated,
            principal.last_updated_by,
            principal.txn_id
    FROM core.principal
    WHERE core.principal.is_active = 1
    ORDER BY core.principal.id;',
    'Select all Principal records with related  information',
    NOW(),
    CURRENT_USER,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default' AND is_active = 1)
FROM (SELECT nextval('core.sql_identity') n) t;

INSERT INTO core.sql (id, txn_id, name, sql_text, description, last_updated, last_updated_by, is_active, data_source_id)
SELECT n, n,
    'core.principal-get',
    'SELECT
        core.principal.id,
            principal.first_name,
            principal.last_name,
            principal.username,
            principal.email,
            principal.enabled,
            principal.created_date,
            principal.last_login_date,
            principal.is_active,
            principal.created_by,
            principal.last_updated,
            principal.last_updated_by,
            principal.txn_id
    FROM core.principal
    WHERE core.principal.id = ^(id) AND core.principal.is_active = 1;',
    'Select single Principal record by ID with related  information',
    NOW(),
    CURRENT_USER,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default' AND is_active = 1)
FROM (SELECT nextval('core.sql_identity') n) t;

INSERT INTO core.sql (id, txn_id, name, sql_text, description, last_updated, last_updated_by, is_active, data_source_id)
SELECT n, n,
    'core.principal-get-by-rwk',
    'SELECT
        core.principal.id,
            principal.first_name,
            principal.last_name,
            principal.username,
            principal.email,
            principal.enabled,
            principal.created_date,
            principal.last_login_date,
            principal.is_active,
            principal.created_by,
            principal.last_updated,
            principal.last_updated_by,
            principal.txn_id
    FROM core.principal
    WHERE principal.email = ^(email) AND principal.enabled = ^(enabled) AND core.principal.is_active = 1;',
    'Select single Principal record by RWK columns with related  information',
    NOW(),
    CURRENT_USER,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default' AND is_active = 1)
FROM (SELECT nextval('core.sql_identity') n) t;

INSERT INTO core.sql (id, txn_id, name, sql_text, description, last_updated, last_updated_by, is_active, data_source_id)
SELECT n, n,
    'core.principal-get-history',
    'SELECT
        core.principal.*
    FROM core.principal
    WHERE core.principal.id = ^(id)
    ORDER BY core.principal.txn_id DESC;',
    'Select all history records for Principal by id, ordered newest first',
    NOW(),
    CURRENT_USER,
    1,
    (SELECT id FROM core.data_source WHERE name = 'default' AND is_active = 1)
FROM (SELECT nextval('core.sql_identity') n) t;


        