
public partial class ListOpRoleMap
{
	public MarkupString GetTableHeader(OpRoleMap oprolemap)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<th>Operation Role Map ID</th>\n");
		
		sb.Append("<th>Operation ID</th>\n");
		
		sb.Append("<th>Role ID</th>\n");
		
		sb.Append("<th>Active</th>\n");
		
		sb.Append("<th>Created By</th>\n");
		
		sb.Append("<th>Last Updated</th>\n");
		
		sb.Append("<th>Last Updated By</th>\n");
		
		sb.Append("<th>Version</th>\n");
			}

	public MarkupString GetTableDetail(OpRoleMap oprolemap)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<td>@oprolemap.id</td>\n");
		
		sb.Append("<td>@oprolemap.op_id</td>\n");
		
		sb.Append("<td>@oprolemap.op_role_id</td>\n");
		
		sb.Append("<td>@oprolemap.is_active</td>\n");
		
		sb.Append("<td>@oprolemap.created_by</td>\n");
		
		sb.Append("<td>@oprolemap.last_updated</td>\n");
		
		sb.Append("<td>@oprolemap.last_updated_by</td>\n");
		
		sb.Append("<td>@oprolemap.version</td>\n");
			}
}