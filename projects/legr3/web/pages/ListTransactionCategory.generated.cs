
public partial class ListTransactionCategory
{
	protected  TransactionCategory[]? transactioncategoryList;

    protected override async Task OnInitializedAsync()
    {
        var remoteClient = ClientFactory.CreateClient("RemoteAPI");

        transactioncategoryList = await remoteClient.GetFromJsonAsync<TransactionCategory[]>("api/transactioncategory");
    }

    void AddTransactionCategory()
    {
        
        Navigation.NavigateTo("edit-transactioncategory");
    }

    void EditTransactionCategory(long id)
    {
        Navigation.NavigateTo($"edit-transactioncategory/{id}");
    }


	
}