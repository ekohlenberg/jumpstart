-- =====================================
-- 1) Create Admin Principal
-- =====================================
INSERT INTO app."principal"(
    id,
    first_name,
    last_name,
    username,
    email,
    created_date,
    last_login_date,
    is_active,
    created_by,
    last_updated,
    last_updated_by,
    version
)
VALUES (
    nextval('app.principal_identity'),          -- Use next value from principal_identity sequence
    'Admin',
    'Principal',
    'admin',                               -- Unique principalname
    'admin@mydomain.com',
    now(),
    now(),
    1,
    'system',
    now(),
    'system',
    1
);
WITH admin_principal_id AS (
    SELECT id
    FROM app."principal"
    WHERE username = 'admin'
)
INSERT INTO sec.principal_password(
    id, principal_id, password_hash, expiry, needs_reset, is_active, created_by, last_updated, last_updated_by, version)
SELECT  nextval('sec.principal_password_identity'),
    admin_principal_id.id,
     (floor(random() * 100000 + 1))::int::varchar,  
     current_timestamp,
     1,
     1,
     current_user,
     current_timestamp,
     current_user,
     1
FROM
    admin_principal_id;

-- =====================================
-- 2) Create Admin Role
-- =====================================
INSERT INTO sec.op_role(
    id,
    name,
    is_active,
    created_by,
    last_updated,
    last_updated_by,
    version
)
VALUES (
    nextval('sec.op_role_identity'),       -- Use next value from op_role_identity sequence
    'Administrator',                       -- Unique role name
    1,
    'system',
    now(),
    'system',
    1
);

-- =====================================
-- 3) Grant All Operations to Admin Role
--    (Map every operation in sec.operation to the admin role)
--    Using a sub-select on sec.op_role to fetch the ID by "name"
-- =====================================
WITH admin_role_id AS (
    SELECT id
    FROM sec.op_role
    WHERE name = 'Administrator'
)
INSERT INTO sec.op_role_map(
    id,
    op_id,
    op_role_id,
    is_active,
    created_by,
    last_updated,
    last_updated_by,
    version
)
SELECT
    nextval('sec.op_role_map_identity'),  -- PK for op_role_map
    op.id,
    admin_role_id.id,
    1,
    'system',
    now(),
    'system',
    1
FROM sec.operation op
CROSS JOIN admin_role_id;

-- =====================================
-- 4) Map Admin Principal to Admin Role
--    Using sub-selects on sec."principal" (by username)
--    and sec.op_role (by name)
-- =====================================
WITH admin_principal_id AS (
    SELECT id
    FROM app."principal"
    WHERE username = 'admin'
),
admin_role_id AS (
    SELECT id
    FROM sec.op_role
    WHERE name = 'Administrator'
)
INSERT INTO sec.op_role_member(
    id,
    principal_id,
    op_role_id,
    is_active,
    created_by,
    last_updated,
    last_updated_by,
    version
)
SELECT
    nextval('sec.op_role_member_identity'),  -- PK for op_role_member
    admin_principal_id.id,
    admin_role_id.id,
    1,
    'system',
    now(),
    'system',
    1
FROM admin_principal_id
CROSS JOIN admin_role_id;

-- =====================================
-- Done!
-- =====================================
