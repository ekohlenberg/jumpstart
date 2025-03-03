
public partial class ListOpRoleMember
{
	public MarkupString GetTableHeader(OpRoleMember oprolemember)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<th>Member ID</th>\n");
		
		sb.Append("<th>Username</th>\n");
		
		sb.Append("<th>Role</th>\n");
		
		sb.Append("<th>Active</th>\n");
		
		sb.Append("<th>Created By</th>\n");
		
		sb.Append("<th>Last Updated</th>\n");
		
		sb.Append("<th>Last Updated By</th>\n");
		
		sb.Append("<th>Version</th>\n");
			}

	public MarkupString GetTableDetail(OpRoleMember oprolemember)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<td>@oprolemember.id</td>\n");
		
		sb.Append("<td>@oprolemember.user_id</td>\n");
		
		sb.Append("<td>@oprolemember.op_role_id</td>\n");
		
		sb.Append("<td>@oprolemember.is_active</td>\n");
		
		sb.Append("<td>@oprolemember.created_by</td>\n");
		
		sb.Append("<td>@oprolemember.last_updated</td>\n");
		
		sb.Append("<td>@oprolemember.last_updated_by</td>\n");
		
		sb.Append("<td>@oprolemember.version</td>\n");
			}
}