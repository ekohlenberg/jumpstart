
public partial class ListScript
{
	protected  Script[]? scriptList;

    protected override async Task OnInitializedAsync()
    {
        var remoteClient = ClientFactory.CreateClient("RemoteAPI");

        scriptList = await remoteClient.GetFromJsonAsync<Script[]>("api/script");
    }

    void AddScript()
    {
        
        Navigation.NavigateTo("edit-script");
    }

    void EditScript(long id)
    {
        Navigation.NavigateTo($"edit-script/{id}");
    }


	
}