
public partial class ListVendor
{
	public MarkupString GetTableHeader(Vendor vendor)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<th>Vendor </th>\n");
		
		sb.Append("<th>Organization</th>\n");
		
		sb.Append("<th>Name</th>\n");
		
		sb.Append("<th>First</th>\n");
		
		sb.Append("<th>Last</th>\n");
		
		sb.Append("<th>Email</th>\n");
		
		sb.Append("<th>Phone</th>\n");
		
		sb.Append("<th>Billing Address</th>\n");
		
		sb.Append("<th>Created</th>\n");
		
		sb.Append("<th>Active</th>\n");
		
		sb.Append("<th>Created By</th>\n");
		
		sb.Append("<th>Last Updated</th>\n");
		
		sb.Append("<th>Last Updated By</th>\n");
		
		sb.Append("<th>Version</th>\n");
			}

	public MarkupString GetTableDetail(Vendor vendor)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<td>@vendor.id</td>\n");
		
		sb.Append("<td>@vendor.org_id</td>\n");
		
		sb.Append("<td>@vendor.vendor_name</td>\n");
		
		sb.Append("<td>@vendor.first_name</td>\n");
		
		sb.Append("<td>@vendor.last_name</td>\n");
		
		sb.Append("<td>@vendor.email</td>\n");
		
		sb.Append("<td>@vendor.phone</td>\n");
		
		sb.Append("<td>@vendor.billing_address</td>\n");
		
		sb.Append("<td>@vendor.created_date</td>\n");
		
		sb.Append("<td>@vendor.is_active</td>\n");
		
		sb.Append("<td>@vendor.created_by</td>\n");
		
		sb.Append("<td>@vendor.last_updated</td>\n");
		
		sb.Append("<td>@vendor.last_updated_by</td>\n");
		
		sb.Append("<td>@vendor.version</td>\n");
			}
}