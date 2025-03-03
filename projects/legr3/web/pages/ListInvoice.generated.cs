
public partial class ListInvoice
{
	public MarkupString GetTableHeader(Invoice invoice)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<th>Invoice ID</th>\n");
		
		sb.Append("<th>Customer</th>\n");
		
		sb.Append("<th>Organization</th>\n");
		
		sb.Append("<th>Number</th>\n");
		
		sb.Append("<th>Invoice Date</th>\n");
		
		sb.Append("<th>Due Date</th>\n");
		
		sb.Append("<th>Total Amount</th>\n");
		
		sb.Append("<th>Status</th>\n");
		
		sb.Append("<th>Created</th>\n");
		
		sb.Append("<th>Active</th>\n");
		
		sb.Append("<th>Created By</th>\n");
		
		sb.Append("<th>Last Updated</th>\n");
		
		sb.Append("<th>Last Updated By</th>\n");
		
		sb.Append("<th>Version</th>\n");
			}

	public MarkupString GetTableDetail(Invoice invoice)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<td>@invoice.id</td>\n");
		
		sb.Append("<td>@invoice.customer_id</td>\n");
		
		sb.Append("<td>@invoice.org_id</td>\n");
		
		sb.Append("<td>@invoice.invoice_number</td>\n");
		
		sb.Append("<td>@invoice.invoice_date</td>\n");
		
		sb.Append("<td>@invoice.due_date</td>\n");
		
		sb.Append("<td>@invoice.total_amount</td>\n");
		
		sb.Append("<td>@invoice.status</td>\n");
		
		sb.Append("<td>@invoice.created_date</td>\n");
		
		sb.Append("<td>@invoice.is_active</td>\n");
		
		sb.Append("<td>@invoice.created_by</td>\n");
		
		sb.Append("<td>@invoice.last_updated</td>\n");
		
		sb.Append("<td>@invoice.last_updated_by</td>\n");
		
		sb.Append("<td>@invoice.version</td>\n");
			}
}