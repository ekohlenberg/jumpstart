
public partial class ListUserPassword
{
	public MarkupString GetTableHeader(UserPassword userpassword)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<th>User ID</th>\n");
		
		sb.Append("<th>User ID</th>\n");
		
		sb.Append("<th>Password</th>\n");
		
		sb.Append("<th>Expiry</th>\n");
		
		sb.Append("<th>Needs Reset</th>\n");
		
		sb.Append("<th>Active</th>\n");
		
		sb.Append("<th>Created By</th>\n");
		
		sb.Append("<th>Last Updated</th>\n");
		
		sb.Append("<th>Last Updated By</th>\n");
		
		sb.Append("<th>Version</th>\n");
			}

	public MarkupString GetTableDetail(UserPassword userpassword)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<td>@userpassword.id</td>\n");
		
		sb.Append("<td>@userpassword.user_id</td>\n");
		
		sb.Append("<td>@userpassword.password_hash</td>\n");
		
		sb.Append("<td>@userpassword.expiry</td>\n");
		
		sb.Append("<td>@userpassword.needs_reset</td>\n");
		
		sb.Append("<td>@userpassword.is_active</td>\n");
		
		sb.Append("<td>@userpassword.created_by</td>\n");
		
		sb.Append("<td>@userpassword.last_updated</td>\n");
		
		sb.Append("<td>@userpassword.last_updated_by</td>\n");
		
		sb.Append("<td>@userpassword.version</td>\n");
			}
}