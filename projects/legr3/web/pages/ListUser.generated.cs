
public partial class ListUser
{
	public MarkupString GetTableHeader(User user)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<th>User ID</th>\n");
		
		sb.Append("<th>First</th>\n");
		
		sb.Append("<th>Last</th>\n");
		
		sb.Append("<th>Username</th>\n");
		
		sb.Append("<th>Email</th>\n");
		
		sb.Append("<th>Created</th>\n");
		
		sb.Append("<th>Last Login</th>\n");
		
		sb.Append("<th>Active</th>\n");
		
		sb.Append("<th>Created By</th>\n");
		
		sb.Append("<th>Last Updated</th>\n");
		
		sb.Append("<th>Last Updated By</th>\n");
		
		sb.Append("<th>Version</th>\n");
			}

	public MarkupString GetTableDetail(User user)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<td>@user.id</td>\n");
		
		sb.Append("<td>@user.first_name</td>\n");
		
		sb.Append("<td>@user.last_name</td>\n");
		
		sb.Append("<td>@user.username</td>\n");
		
		sb.Append("<td>@user.email</td>\n");
		
		sb.Append("<td>@user.created_date</td>\n");
		
		sb.Append("<td>@user.last_login_date</td>\n");
		
		sb.Append("<td>@user.is_active</td>\n");
		
		sb.Append("<td>@user.created_by</td>\n");
		
		sb.Append("<td>@user.last_updated</td>\n");
		
		sb.Append("<td>@user.last_updated_by</td>\n");
		
		sb.Append("<td>@user.version</td>\n");
			}
}