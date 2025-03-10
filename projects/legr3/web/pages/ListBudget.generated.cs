
public partial class ListBudget
{
	public MarkupString GetTableHeader(Budget budget)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<th>Budget ID</th>\n");
		
		sb.Append("<th>Organization ID</th>\n");
		
		sb.Append("<th>Category ID</th>\n");
		
		sb.Append("<th>Amount</th>\n");
		
		sb.Append("<th>Start Date</th>\n");
		
		sb.Append("<th>End Date</th>\n");
		
		sb.Append("<th>Active</th>\n");
		
		sb.Append("<th>Created By</th>\n");
		
		sb.Append("<th>Last Updated</th>\n");
		
		sb.Append("<th>Last Updated By</th>\n");
		
		sb.Append("<th>Version</th>\n");
			}

	public MarkupString GetTableDetail(Budget budget)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<td>@budget.id</td>\n");
		
		sb.Append("<td>@budget.org_id</td>\n");
		
		sb.Append("<td>@budget.category_id</td>\n");
		
		sb.Append("<td>@budget.amount</td>\n");
		
		sb.Append("<td>@budget.start_date</td>\n");
		
		sb.Append("<td>@budget.end_date</td>\n");
		
		sb.Append("<td>@budget.is_active</td>\n");
		
		sb.Append("<td>@budget.created_by</td>\n");
		
		sb.Append("<td>@budget.last_updated</td>\n");
		
		sb.Append("<td>@budget.last_updated_by</td>\n");
		
		sb.Append("<td>@budget.version</td>\n");
			}
}