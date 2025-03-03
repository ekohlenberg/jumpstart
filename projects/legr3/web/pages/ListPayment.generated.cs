
public partial class ListPayment
{
	public MarkupString GetTableHeader(Payment payment)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<th>Payment ID</th>\n");
		
		sb.Append("<th>Invoice ID</th>\n");
		
		sb.Append("<th>Organization ID</th>\n");
		
		sb.Append("<th>Payment Date</th>\n");
		
		sb.Append("<th>Amount</th>\n");
		
		sb.Append("<th>Payment Method</th>\n");
		
		sb.Append("<th>Created Date</th>\n");
		
		sb.Append("<th>Active</th>\n");
		
		sb.Append("<th>Created By</th>\n");
		
		sb.Append("<th>Last Updated</th>\n");
		
		sb.Append("<th>Last Updated By</th>\n");
		
		sb.Append("<th>Version</th>\n");
			}

	public MarkupString GetTableDetail(Payment payment)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<td>@payment.id</td>\n");
		
		sb.Append("<td>@payment.invoice_id</td>\n");
		
		sb.Append("<td>@payment.org_id</td>\n");
		
		sb.Append("<td>@payment.payment_date</td>\n");
		
		sb.Append("<td>@payment.amount</td>\n");
		
		sb.Append("<td>@payment.payment_method</td>\n");
		
		sb.Append("<td>@payment.created_date</td>\n");
		
		sb.Append("<td>@payment.is_active</td>\n");
		
		sb.Append("<td>@payment.created_by</td>\n");
		
		sb.Append("<td>@payment.last_updated</td>\n");
		
		sb.Append("<td>@payment.last_updated_by</td>\n");
		
		sb.Append("<td>@payment.version</td>\n");
			}
}