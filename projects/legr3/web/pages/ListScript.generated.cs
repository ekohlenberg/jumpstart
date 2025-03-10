
public partial class ListScript
{
	public MarkupString GetTableHeader(Script script)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<th>Script ID</th>\n");
		
		sb.Append("<th>Name</th>\n");
		
		sb.Append("<th>Source Code</th>\n");
		
		sb.Append("<th>Active</th>\n");
		
		sb.Append("<th>Created By</th>\n");
		
		sb.Append("<th>Last Updated</th>\n");
		
		sb.Append("<th>Last Updated By</th>\n");
		
		sb.Append("<th>Version</th>\n");
			}

	public MarkupString GetTableDetail(Script script)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<td>@script.id</td>\n");
		
		sb.Append("<td>@script.name</td>\n");
		
		sb.Append("<td>@script.source</td>\n");
		
		sb.Append("<td>@script.is_active</td>\n");
		
		sb.Append("<td>@script.created_by</td>\n");
		
		sb.Append("<td>@script.last_updated</td>\n");
		
		sb.Append("<td>@script.last_updated_by</td>\n");
		
		sb.Append("<td>@script.version</td>\n");
			}
}