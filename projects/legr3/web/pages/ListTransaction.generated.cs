
public partial class ListTransaction
{
	protected  Transaction[]? transactionList;

    protected override async Task OnInitializedAsync()
    {
        var remoteClient = ClientFactory.CreateClient("RemoteAPI");

        transactionList = await remoteClient.GetFromJsonAsync<Transaction[]>("api/transaction");
    }

    void AddTransaction()
    {
        
        Navigation.NavigateTo("edit-transaction");
    }

    void EditTransaction(long id)
    {
        Navigation.NavigateTo($"edit-transaction/{id}");
    }


	
}