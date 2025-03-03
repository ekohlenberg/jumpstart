
public partial class ListTransactionCategory
{
	public MarkupString GetTableHeader(TransactionCategory transactioncategory)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<th>Transaction-Category ID</th>\n");
		
		sb.Append("<th>Transaction ID</th>\n");
		
		sb.Append("<th>Category ID</th>\n");
		
		sb.Append("<th>Active</th>\n");
		
		sb.Append("<th>Created By</th>\n");
		
		sb.Append("<th>Last Updated</th>\n");
		
		sb.Append("<th>Last Updated By</th>\n");
		
		sb.Append("<th>Version</th>\n");
			}

	public MarkupString GetTableDetail(TransactionCategory transactioncategory)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<td>@transactioncategory.id</td>\n");
		
		sb.Append("<td>@transactioncategory.transaction_id</td>\n");
		
		sb.Append("<td>@transactioncategory.category_id</td>\n");
		
		sb.Append("<td>@transactioncategory.is_active</td>\n");
		
		sb.Append("<td>@transactioncategory.created_by</td>\n");
		
		sb.Append("<td>@transactioncategory.last_updated</td>\n");
		
		sb.Append("<td>@transactioncategory.last_updated_by</td>\n");
		
		sb.Append("<td>@transactioncategory.version</td>\n");
			}
}