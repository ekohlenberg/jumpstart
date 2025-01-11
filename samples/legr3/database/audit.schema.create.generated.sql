CREATE SCHEMA audit; 
GRANT USAGE ON SCHEMA audit TO legr3; 
GRANT SELECT, UPDATE, INSERT, DELETE ON ALL TABLES IN SCHEMA audit TO legr3;

CREATE TABLE IF NOT EXISTS audit.log (
    id BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    level TEXT NOT NULL,
    message TEXT NOT NULL,
    timestamp TIMESTAMPTZ NOT NULL,
    username TEXT NOT NULL,
    program TEXT NOT NULL
);