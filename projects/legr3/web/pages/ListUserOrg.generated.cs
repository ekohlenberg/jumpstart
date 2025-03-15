
public partial class ListUserOrg
{
	protected  UserOrg[]? userorgList;

    protected override async Task OnInitializedAsync()
    {
        var remoteClient = ClientFactory.CreateClient("RemoteAPI");

        userorgList = await remoteClient.GetFromJsonAsync<UserOrg[]>("api/userorg");
    }

    void AddUserOrg()
    {
        
        Navigation.NavigateTo("edit-userorg");
    }

    void EditUserOrg(long id)
    {
        Navigation.NavigateTo($"edit-userorg/{id}");
    }


	
}