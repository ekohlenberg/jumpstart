
public partial class ListBillItem
{
	public MarkupString GetTableHeader(BillItem billitem)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<th>Bill Item ID</th>\n");
		
		sb.Append("<th>Bill ID</th>\n");
		
		sb.Append("<th>Description</th>\n");
		
		sb.Append("<th>Quantity</th>\n");
		
		sb.Append("<th>Unit Price</th>\n");
		
		sb.Append("<th>Total Amount</th>\n");
		
		sb.Append("<th>Active</th>\n");
		
		sb.Append("<th>Created By</th>\n");
		
		sb.Append("<th>Last Updated</th>\n");
		
		sb.Append("<th>Last Updated By</th>\n");
		
		sb.Append("<th>Version</th>\n");
			}

	public MarkupString GetTableDetail(BillItem billitem)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<td>@billitem.id</td>\n");
		
		sb.Append("<td>@billitem.bill_id</td>\n");
		
		sb.Append("<td>@billitem.description</td>\n");
		
		sb.Append("<td>@billitem.quantity</td>\n");
		
		sb.Append("<td>@billitem.unit_price</td>\n");
		
		sb.Append("<td>@billitem.total_amount</td>\n");
		
		sb.Append("<td>@billitem.is_active</td>\n");
		
		sb.Append("<td>@billitem.created_by</td>\n");
		
		sb.Append("<td>@billitem.last_updated</td>\n");
		
		sb.Append("<td>@billitem.last_updated_by</td>\n");
		
		sb.Append("<td>@billitem.version</td>\n");
			}
}