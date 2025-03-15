
public partial class ListOpRoleMap
{
	protected  OpRoleMap[]? oprolemapList;

    protected override async Task OnInitializedAsync()
    {
        var remoteClient = ClientFactory.CreateClient("RemoteAPI");

        oprolemapList = await remoteClient.GetFromJsonAsync<OpRoleMap[]>("api/oprolemap");
    }

    void AddOpRoleMap()
    {
        
        Navigation.NavigateTo("edit-oprolemap");
    }

    void EditOpRoleMap(long id)
    {
        Navigation.NavigateTo($"edit-oprolemap/{id}");
    }


	
}