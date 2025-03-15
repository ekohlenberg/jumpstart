
public partial class ListUser
{
	protected  User[]? userList;

    protected override async Task OnInitializedAsync()
    {
        var remoteClient = ClientFactory.CreateClient("RemoteAPI");

        userList = await remoteClient.GetFromJsonAsync<User[]>("api/user");
    }

    void AddUser()
    {
        
        Navigation.NavigateTo("edit-user");
    }

    void EditUser(long id)
    {
        Navigation.NavigateTo($"edit-user/{id}");
    }


	
}