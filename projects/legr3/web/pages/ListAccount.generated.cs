
public partial class ListAccount
{
	protected  Account[]? accountList;

    protected override async Task OnInitializedAsync()
    {
        var remoteClient = ClientFactory.CreateClient("RemoteAPI");

        accountList = await remoteClient.GetFromJsonAsync<Account[]>("api/account");
    }

    void AddAccount()
    {
        
        Navigation.NavigateTo("edit-account");
    }

    void EditAccount(long id)
    {
        Navigation.NavigateTo($"edit-account/{id}");
    }


	
}