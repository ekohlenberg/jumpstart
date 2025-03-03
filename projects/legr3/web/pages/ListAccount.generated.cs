
public partial class ListAccount
{
	public MarkupString GetTableHeader(Account account)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<th>Account ID</th>\n");
		
		sb.Append("<th>Organization</th>\n");
		
		sb.Append("<th>Name</th>\n");
		
		sb.Append("<th>Type</th>\n");
		
		sb.Append("<th>Balance</th>\n");
		
		sb.Append("<th>Created</th>\n");
		
		sb.Append("<th>Active</th>\n");
		
		sb.Append("<th>Created By</th>\n");
		
		sb.Append("<th>Last Updated</th>\n");
		
		sb.Append("<th>Last Updated By</th>\n");
		
		sb.Append("<th>Version</th>\n");
			}

	public MarkupString GetTableDetail(Account account)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<td>@account.id</td>\n");
		
		sb.Append("<td>@account.org_id</td>\n");
		
		sb.Append("<td>@account.account_name</td>\n");
		
		sb.Append("<td>@account.account_type</td>\n");
		
		sb.Append("<td>@account.balance</td>\n");
		
		sb.Append("<td>@account.created_date</td>\n");
		
		sb.Append("<td>@account.is_active</td>\n");
		
		sb.Append("<td>@account.created_by</td>\n");
		
		sb.Append("<td>@account.last_updated</td>\n");
		
		sb.Append("<td>@account.last_updated_by</td>\n");
		
		sb.Append("<td>@account.version</td>\n");
			}
}