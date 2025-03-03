
public partial class ListBill
{
	public MarkupString GetTableHeader(Bill bill)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<th>Bill ID</th>\n");
		
		sb.Append("<th>Vendor </th>\n");
		
		sb.Append("<th>Organization</th>\n");
		
		sb.Append("<th>Number</th>\n");
		
		sb.Append("<th>Bill Date</th>\n");
		
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

	public MarkupString GetTableDetail(Bill bill)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<td>@bill.id</td>\n");
		
		sb.Append("<td>@bill.vendor_id</td>\n");
		
		sb.Append("<td>@bill.org_id</td>\n");
		
		sb.Append("<td>@bill.bill_number</td>\n");
		
		sb.Append("<td>@bill.bill_date</td>\n");
		
		sb.Append("<td>@bill.due_date</td>\n");
		
		sb.Append("<td>@bill.total_amount</td>\n");
		
		sb.Append("<td>@bill.status</td>\n");
		
		sb.Append("<td>@bill.created_date</td>\n");
		
		sb.Append("<td>@bill.is_active</td>\n");
		
		sb.Append("<td>@bill.created_by</td>\n");
		
		sb.Append("<td>@bill.last_updated</td>\n");
		
		sb.Append("<td>@bill.last_updated_by</td>\n");
		
		sb.Append("<td>@bill.version</td>\n");
			}
}