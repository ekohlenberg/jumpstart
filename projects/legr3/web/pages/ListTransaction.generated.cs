
public partial class ListTransaction
{
	public MarkupString GetTableHeader(Transaction transaction)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<th>Transaction ID</th>\n");
		
		sb.Append("<th>Account ID</th>\n");
		
		sb.Append("<th>Organization ID</th>\n");
		
		sb.Append("<th>Transaction Date</th>\n");
		
		sb.Append("<th>Amount</th>\n");
		
		sb.Append("<th>Transaction Type</th>\n");
		
		sb.Append("<th>Description</th>\n");
		
		sb.Append("<th>Created Date</th>\n");
		
		sb.Append("<th>Active</th>\n");
		
		sb.Append("<th>Created By</th>\n");
		
		sb.Append("<th>Last Updated</th>\n");
		
		sb.Append("<th>Last Updated By</th>\n");
		
		sb.Append("<th>Version</th>\n");
			}

	public MarkupString GetTableDetail(Transaction transaction)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<td>@transaction.id</td>\n");
		
		sb.Append("<td>@transaction.account_id</td>\n");
		
		sb.Append("<td>@transaction.org_id</td>\n");
		
		sb.Append("<td>@transaction.transaction_date</td>\n");
		
		sb.Append("<td>@transaction.amount</td>\n");
		
		sb.Append("<td>@transaction.transaction_type</td>\n");
		
		sb.Append("<td>@transaction.description</td>\n");
		
		sb.Append("<td>@transaction.created_date</td>\n");
		
		sb.Append("<td>@transaction.is_active</td>\n");
		
		sb.Append("<td>@transaction.created_by</td>\n");
		
		sb.Append("<td>@transaction.last_updated</td>\n");
		
		sb.Append("<td>@transaction.last_updated_by</td>\n");
		
		sb.Append("<td>@transaction.version</td>\n");
			}
}