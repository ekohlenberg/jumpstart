select
TABLE_CATALOG, 			-- Database name based on the input filename.

TABLE_SCHEMA, 			-- Schema Name

TABLE_NAME,				-- Table name using "snake" naming style.  
						-- Table name will be converted to PascalCase for domain object generation.
						
'' as TABLE_LABEL, 		-- A TitleCase representation of the table name.  
						-- Appears on the first row of the table.
						
'' as NAV_MENU, 		-- Navigation menu name for grouping tables.  
						-- Tables with the same NAV_MENU value will be grouped together in the navigation menu.
						
COLUMN_NAME,			-- A column name in "snake" style.  
						-- The first column of every table is "id", the primary key.  
						-- The primary key is BIGINT type.   
						-- Foreign keys are named as <table_name>_id and are also BIGINT.
						
'' as COLUMN_LABEL,		-- Similar to table lable, a TitleCase, user-friendly column name.
'' as FK_TYPE,			-- Can be enum, parent, map, or rwk:  
						-- 	Enum refers to a databased list of specific values.  
						-- 	Parent refers to the master record in a 1:many master-detail relationship.  
						-- 	Map refers to a column that is one part of a many:many relationship.  
						-- 	Rwk indicates that a foreign key is actually part of a table real-world key and 
						--	the RWK colums of the referenced table should be displayed.
						
'' as FK_OBJECT,		-- Refers to the table name of the foreign table.  
						-- Used as the basis for the COLUMN_NAME.
						
'' as TEST_DATA_SET,	-- Can be "addresses", "companies", "emailAddresses", "firstnames", "lastnames", or "phoneNumbers".  
						-- Used to determine the test data used for test case generation.
						
ORDINAL_POSITION,		-- Integer number that indicates column order.

COLUMN_DEFAULT,			-- A default value or function that returns a value.  Must be database specific.

'' as RWK,				-- A 1 or a 0 indicating whether or not a non-primary key column comprises a real-world key.  
						-- The generator will produce a unique index based on the real-world key columns.
						
IS_NULLABLE,			-- Can be "YES" or "NO".

DATA_TYPE,				-- The POSTGRES data type.  Current supported types are 
						--	BIGINT, 
						--	VARCHAR, 
						--	NUMERIC(18,4), 
						--	TIMESTAMP, 
						--	INTEGER, 
						-- 	DATE
						
'' as MSSQL_DATA_TYPE,		-- The MS SQL Server data type

CHARACTER_MAXIMUM_LENGTH	-- The length of a varchar column.

from information_schema.columns
where table_schema='public'
order by table_name, ordinal_position