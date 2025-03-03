
public partial class ListOperation
{
	public MarkupString GetTableHeader(Operation operation)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<th>Action ID</th>\n");
		
		sb.Append("<th>Object</th>\n");
		
		sb.Append("<th>Method</th>\n");
		
		sb.Append("<th>Active</th>\n");
		
		sb.Append("<th>Created By</th>\n");
		
		sb.Append("<th>Last Updated</th>\n");
		
		sb.Append("<th>Last Updated By</th>\n");
		
		sb.Append("<th>Version</th>\n");
			}

	public MarkupString GetTableDetail(Operation operation)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<td>@operation.id</td>\n");
		
		sb.Append("<td>@operation.objectname</td>\n");
		
		sb.Append("<td>@operation.methodname</td>\n");
		
		sb.Append("<td>@operation.is_active</td>\n");
		
		sb.Append("<td>@operation.created_by</td>\n");
		
		sb.Append("<td>@operation.last_updated</td>\n");
		
		sb.Append("<td>@operation.last_updated_by</td>\n");
		
		sb.Append("<td>@operation.version</td>\n");
			}
}