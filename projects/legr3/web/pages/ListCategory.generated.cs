
public partial class ListCategory
{
	protected  Category[]? categoryList;

    protected override async Task OnInitializedAsync()
    {
        var remoteClient = ClientFactory.CreateClient("RemoteAPI");

        categoryList = await remoteClient.GetFromJsonAsync<Category[]>("api/category");
    }

    void AddCategory()
    {
        
        Navigation.NavigateTo("edit-category");
    }

    void EditCategory(long id)
    {
        Navigation.NavigateTo($"edit-category/{id}");
    }


	
}