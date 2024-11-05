/*
select
OBJECT_SCHEMA_NAME(o.id) as schema_name,
o.name as table_name,
o.type as table_type,
c.name as column_name,
ascii(t.name) a_type_name,
c.length as column_length,
c.colid as column_order,
c.prec as column_prec,
c.scale as column_scale
from 
    sysobjects o
left outer join syscolumns c 
    on c.id=o.id
left outer join systypes t
    on t.xtype=c.xtype and t.name <> 'sysname'
where o.type='U'
*/
select 
TABLE_CATALOG,TABLE_SCHEMA,TABLE_NAME,COLUMN_NAME,DATA_TYPE, ORDINAL_POSITION
from information_schema.columns