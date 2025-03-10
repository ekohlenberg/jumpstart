
public partial class ListOpRole
{
	public MarkupString GetTableHeader(OpRole oprole)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<th>Role ID</th>\n");
		
		sb.Append("<th>Role Name</th>\n");
		
		sb.Append("<th>Active</th>\n");
		
		sb.Append("<th>Created By</th>\n");
		
		sb.Append("<th>Last Updated</th>\n");
		
		sb.Append("<th>Last Updated By</th>\n");
		
		sb.Append("<th>Version</th>\n");
			}

	public MarkupString GetTableDetail(OpRole oprole)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<td>@oprole.id</td>\n");
		
		sb.Append("<td>@oprole.name</td>\n");
		
		sb.Append("<td>@oprole.is_active</td>\n");
		
		sb.Append("<td>@oprole.created_by</td>\n");
		
		sb.Append("<td>@oprole.last_updated</td>\n");
		
		sb.Append("<td>@oprole.last_updated_by</td>\n");
		
		sb.Append("<td>@oprole.version</td>\n");
			}
}