
public partial class ListCategory
{
	public MarkupString GetTableHeader(Category category)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<th>Category ID</th>\n");
		
		sb.Append("<th>Organization ID</th>\n");
		
		sb.Append("<th>Name</th>\n");
		
		sb.Append("<th>Category Type</th>\n");
		
		sb.Append("<th>Active</th>\n");
		
		sb.Append("<th>Created By</th>\n");
		
		sb.Append("<th>Last Updated</th>\n");
		
		sb.Append("<th>Last Updated By</th>\n");
		
		sb.Append("<th>Version</th>\n");
			}

	public MarkupString GetTableDetail(Category category)
	{
		StringBuilder sb = new StringBuilder();

		sb.Append("<td>@category.id</td>\n");
		
		sb.Append("<td>@category.org_id</td>\n");
		
		sb.Append("<td>@category.category_name</td>\n");
		
		sb.Append("<td>@category.category_type</td>\n");
		
		sb.Append("<td>@category.is_active</td>\n");
		
		sb.Append("<td>@category.created_by</td>\n");
		
		sb.Append("<td>@category.last_updated</td>\n");
		
		sb.Append("<td>@category.last_updated_by</td>\n");
		
		sb.Append("<td>@category.version</td>\n");
			}
}