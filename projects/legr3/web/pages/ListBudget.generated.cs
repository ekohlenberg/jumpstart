
public partial class ListBudget
{
	protected  Budget[]? budgetList;

    protected override async Task OnInitializedAsync()
    {
        var remoteClient = ClientFactory.CreateClient("RemoteAPI");

        budgetList = await remoteClient.GetFromJsonAsync<Budget[]>("api/budget");
    }

    void AddBudget()
    {
        
        Navigation.NavigateTo("edit-budget");
    }

    void EditBudget(long id)
    {
        Navigation.NavigateTo($"edit-budget/{id}");
    }


	
}