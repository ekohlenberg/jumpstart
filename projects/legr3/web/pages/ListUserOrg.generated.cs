
public partial class ListUserOrg
{
	public MarkupString GetTableHeader(UserOrg userorg)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<th>User Org ID</th>\n");
		
		sb.Append("<th>Organization ID</th>\n");
		
		sb.Append("<th>User ID</th>\n");
		
		sb.Append("<th>Active</th>\n");
		
		sb.Append("<th>Created By</th>\n");
		
		sb.Append("<th>Last Updated</th>\n");
		
		sb.Append("<th>Last Updated By</th>\n");
		
		sb.Append("<th>Version</th>\n");
			}

	public MarkupString GetTableDetail(UserOrg userorg)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<td>@userorg.id</td>\n");
		
		sb.Append("<td>@userorg.org_id</td>\n");
		
		sb.Append("<td>@userorg.user_id</td>\n");
		
		sb.Append("<td>@userorg.is_active</td>\n");
		
		sb.Append("<td>@userorg.created_by</td>\n");
		
		sb.Append("<td>@userorg.last_updated</td>\n");
		
		sb.Append("<td>@userorg.last_updated_by</td>\n");
		
		sb.Append("<td>@userorg.version</td>\n");
			}
}