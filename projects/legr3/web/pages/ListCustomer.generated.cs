
public partial class ListCustomer
{
	public MarkupString GetTableHeader(Customer customer)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<th>Customer ID</th>\n");
		
		sb.Append("<th>Organization ID</th>\n");
		
		sb.Append("<th>Name</th>\n");
		
		sb.Append("<th>First</th>\n");
		
		sb.Append("<th>Last</th>\n");
		
		sb.Append("<th>Email</th>\n");
		
		sb.Append("<th>Phone</th>\n");
		
		sb.Append("<th>Billing Address</th>\n");
		
		sb.Append("<th>Shipping Address</th>\n");
		
		sb.Append("<th>Created</th>\n");
		
		sb.Append("<th>Active</th>\n");
		
		sb.Append("<th>Created By</th>\n");
		
		sb.Append("<th>Last Updated</th>\n");
		
		sb.Append("<th>Last Updated By</th>\n");
		
		sb.Append("<th>Version</th>\n");
			}

	public MarkupString GetTableDetail(Customer customer)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<td>@customer.id</td>\n");
		
		sb.Append("<td>@customer.org_id</td>\n");
		
		sb.Append("<td>@customer.customer_name</td>\n");
		
		sb.Append("<td>@customer.first_name</td>\n");
		
		sb.Append("<td>@customer.last_name</td>\n");
		
		sb.Append("<td>@customer.email</td>\n");
		
		sb.Append("<td>@customer.phone</td>\n");
		
		sb.Append("<td>@customer.billing_address</td>\n");
		
		sb.Append("<td>@customer.shipping_address</td>\n");
		
		sb.Append("<td>@customer.created_date</td>\n");
		
		sb.Append("<td>@customer.is_active</td>\n");
		
		sb.Append("<td>@customer.created_by</td>\n");
		
		sb.Append("<td>@customer.last_updated</td>\n");
		
		sb.Append("<td>@customer.last_updated_by</td>\n");
		
		sb.Append("<td>@customer.version</td>\n");
			}
}