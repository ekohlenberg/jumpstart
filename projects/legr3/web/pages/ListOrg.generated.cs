
public partial class ListOrg
{
	public MarkupString GetTableHeader(Org org)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<th>Organization ID</th>\n");
		
		sb.Append("<th>Name</th>\n");
		
		sb.Append("<th>Active</th>\n");
		
		sb.Append("<th>Created By</th>\n");
		
		sb.Append("<th>Last Updated</th>\n");
		
		sb.Append("<th>Last Updated By</th>\n");
		
		sb.Append("<th>Version</th>\n");
			}

	public MarkupString GetTableDetail(Org org)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<td>@org.id</td>\n");
		
		sb.Append("<td>@org.name</td>\n");
		
		sb.Append("<td>@org.is_active</td>\n");
		
		sb.Append("<td>@org.created_by</td>\n");
		
		sb.Append("<td>@org.last_updated</td>\n");
		
		sb.Append("<td>@org.last_updated_by</td>\n");
		
		sb.Append("<td>@org.version</td>\n");
			}
}