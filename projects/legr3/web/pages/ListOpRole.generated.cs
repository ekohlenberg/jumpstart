
public partial class ListOpRole
{
	protected  OpRole[]? oproleList;

    protected override async Task OnInitializedAsync()
    {
        var remoteClient = ClientFactory.CreateClient("RemoteAPI");

        oproleList = await remoteClient.GetFromJsonAsync<OpRole[]>("api/oprole");
    }

    void AddOpRole()
    {
        
        Navigation.NavigateTo("edit-oprole");
    }

    void EditOpRole(long id)
    {
        Navigation.NavigateTo($"edit-oprole/{id}");
    }


	
}