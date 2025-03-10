
public partial class ListInvoiceItem
{
	public MarkupString GetTableHeader(InvoiceItem invoiceitem)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<th>Invoice Item ID</th>\n");
		
		sb.Append("<th>Invoice ID</th>\n");
		
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

	public MarkupString GetTableDetail(InvoiceItem invoiceitem)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<td>@invoiceitem.id</td>\n");
		
		sb.Append("<td>@invoiceitem.invoice_id</td>\n");
		
		sb.Append("<td>@invoiceitem.description</td>\n");
		
		sb.Append("<td>@invoiceitem.quantity</td>\n");
		
		sb.Append("<td>@invoiceitem.unit_price</td>\n");
		
		sb.Append("<td>@invoiceitem.total_amount</td>\n");
		
		sb.Append("<td>@invoiceitem.is_active</td>\n");
		
		sb.Append("<td>@invoiceitem.created_by</td>\n");
		
		sb.Append("<td>@invoiceitem.last_updated</td>\n");
		
		sb.Append("<td>@invoiceitem.last_updated_by</td>\n");
		
		sb.Append("<td>@invoiceitem.version</td>\n");
			}
}