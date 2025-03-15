
public partial class ListOrg
{
	protected  Org[]? orgList;

    protected override async Task OnInitializedAsync()
    {
        var remoteClient = ClientFactory.CreateClient("RemoteAPI");

        orgList = await remoteClient.GetFromJsonAsync<Org[]>("api/org");
    }

    void AddOrg()
    {
        
        Navigation.NavigateTo("edit-org");
    }

    void EditOrg(long id)
    {
        Navigation.NavigateTo($"edit-org/{id}");
    }


	
}