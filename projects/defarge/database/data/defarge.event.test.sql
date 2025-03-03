INSERT INTO core.script(
	id, name, source, is_active, created_by, last_updated, last_updated_by, version)
	VALUES (nextval('core.script_identity'), 'all-object insert event', '@using System; @using System.IO; Console.WriteLine("all-object insert event");', 1, current_user, current_timestamp, current_user, 1);

INSERT INTO core.script(
	id, name, source, is_active, created_by, last_updated, last_updated_by, version)
	VALUES (nextval('core.script_identity'), 'all-object update event', '@using System; @using System.IO; Console.WriteLine("all-object update event");', 1, current_user, current_timestamp, current_user, 1);


WITH all_object_insert_script AS (
    SELECT id
    FROM core."script"
    WHERE name = 'all-object insert event'
)
INSERT INTO core.event_service(
	id, event_type, objectname_filter, methodname_filter, script_id, is_active, created_by, last_updated, last_updated_by, version)
SELECT nextval('core.event_service_identity'), 'pre', '%', 'insert', all_object_insert_script.id, 1, current_user, current_timestamp, current_user, 1
FROM all_object_insert_script;

WITH all_object_update_script AS (
    SELECT id
    FROM core."script"
    WHERE name = 'all-object update event'
)
INSERT INTO core.event_service(
	id, event_type, objectname_filter, methodname_filter, script_id, is_active, created_by, last_updated, last_updated_by, version)
SELECT nextval('core.event_service_identity'), 'post', '%', 'update', all_object_update_script.id, 1, current_user, current_timestamp, current_user, 1
FROM all_object_update_script;