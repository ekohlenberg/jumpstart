-- =====================================
-- 1) Create Admin User
-- =====================================
INSERT INTO app."user"(
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
    nextval('app.user_identity'),          -- Use next value from user_identity sequence
    'Admin',
    'User',
    'admin',                               -- Unique username
    'admin@mydomain.com',
    now(),
    null,
    1,
    'system',
    now(),
    'system',
    1
);

WITH admin_user_id AS (
    SELECT id
    FROM app."user"
    WHERE username = 'admin'
)
INSERT INTO sec.user_password(
    id, user_id, password_hash, expiry, needs_reset, is_active, created_by, last_updated, last_updated_by, version)
SELECT  nextval('sec.user_password_identity'),
    admin_user_id.id,
     (floor(random() * 100000 + 1))::int::varchar,  
     current_timestamp,
     1,
     1,
     current_user,
     current_timestamp,
     current_user,
     1
FROM
    admin_user_id;

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
-- 4) Map Admin User to Admin Role
--    Using sub-selects on sec."user" (by username)
--    and sec.op_role (by name)
-- =====================================
WITH admin_user_id AS (
    SELECT id
    FROM app."user"
    WHERE username = 'admin'
),
admin_role_id AS (
    SELECT id
    FROM sec.op_role
    WHERE name = 'Administrator'
)
INSERT INTO sec.op_role_member(
    id,
    user_id,
    op_role_id,
    is_active,
    created_by,
    last_updated,
    last_updated_by,
    version
)
SELECT
    nextval('sec.op_role_member_identity'),  -- PK for op_role_member
    admin_user_id.id,
    admin_role_id.id,
    1,
    'system',
    now(),
    'system',
    1
FROM admin_user_id
CROSS JOIN admin_role_id;

-- =====================================
-- Done!
-- =====================================
