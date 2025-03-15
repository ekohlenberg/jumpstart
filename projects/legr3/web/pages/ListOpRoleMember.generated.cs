
public partial class ListOpRoleMember
{
	protected  OpRoleMember[]? oprolememberList;

    protected override async Task OnInitializedAsync()
    {
        var remoteClient = ClientFactory.CreateClient("RemoteAPI");

        oprolememberList = await remoteClient.GetFromJsonAsync<OpRoleMember[]>("api/oprolemember");
    }

    void AddOpRoleMember()
    {
        
        Navigation.NavigateTo("edit-oprolemember");
    }

    void EditOpRoleMember(long id)
    {
        Navigation.NavigateTo($"edit-oprolemember/{id}");
    }


	
}