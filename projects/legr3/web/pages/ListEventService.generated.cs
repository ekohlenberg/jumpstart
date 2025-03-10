
public partial class ListEventService
{
	public MarkupString GetTableHeader(EventService eventservice)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<th>Event ID</th>\n");
		
		sb.Append("<th>Event Type</th>\n");
		
		sb.Append("<th>Object Filter</th>\n");
		
		sb.Append("<th>Method Filter</th>\n");
		
		sb.Append("<th>Script ID</th>\n");
		
		sb.Append("<th>Active</th>\n");
		
		sb.Append("<th>Created By</th>\n");
		
		sb.Append("<th>Last Updated</th>\n");
		
		sb.Append("<th>Last Updated By</th>\n");
		
		sb.Append("<th>Version</th>\n");
			}

	public MarkupString GetTableDetail(EventService eventservice)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<td>@eventservice.id</td>\n");
		
		sb.Append("<td>@eventservice.event_type</td>\n");
		
		sb.Append("<td>@eventservice.objectname_filter</td>\n");
		
		sb.Append("<td>@eventservice.methodname_filter</td>\n");
		
		sb.Append("<td>@eventservice.script_id</td>\n");
		
		sb.Append("<td>@eventservice.is_active</td>\n");
		
		sb.Append("<td>@eventservice.created_by</td>\n");
		
		sb.Append("<td>@eventservice.last_updated</td>\n");
		
		sb.Append("<td>@eventservice.last_updated_by</td>\n");
		
		sb.Append("<td>@eventservice.version</td>\n");
			}
}