
public partial class ListUserPassword
{
	protected  UserPassword[]? userpasswordList;

    protected override async Task OnInitializedAsync()
    {
        var remoteClient = ClientFactory.CreateClient("RemoteAPI");

        userpasswordList = await remoteClient.GetFromJsonAsync<UserPassword[]>("api/userpassword");
    }

    void AddUserPassword()
    {
        
        Navigation.NavigateTo("edit-userpassword");
    }

    void EditUserPassword(long id)
    {
        Navigation.NavigateTo($"edit-userpassword/{id}");
    }


	
}