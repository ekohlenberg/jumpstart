
public partial class ListOperation
{
	protected  Operation[]? operationList;

    protected override async Task OnInitializedAsync()
    {
        var remoteClient = ClientFactory.CreateClient("RemoteAPI");

        operationList = await remoteClient.GetFromJsonAsync<Operation[]>("api/operation");
    }

    void AddOperation()
    {
        
        Navigation.NavigateTo("edit-operation");
    }

    void EditOperation(long id)
    {
        Navigation.NavigateTo($"edit-operation/{id}");
    }


	
}