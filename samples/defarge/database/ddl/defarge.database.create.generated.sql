

DROP DATABASE IF EXISTS defarge WITH ( FORCE );

CREATE DATABASE defarge
    WITH
    OWNER = defarge
    ENCODING = 'UTF8'
    LOCALE_PROVIDER = 'libc'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;
    
GRANT CONNECT ON DATABASE defarge TO defarge;
