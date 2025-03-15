
public partial class ListBill
{
	protected  Bill[]? billList;

    protected override async Task OnInitializedAsync()
    {
        var remoteClient = ClientFactory.CreateClient("RemoteAPI");

        billList = await remoteClient.GetFromJsonAsync<Bill[]>("api/bill");
    }

    void AddBill()
    {
        
        Navigation.NavigateTo("edit-bill");
    }

    void EditBill(long id)
    {
        Navigation.NavigateTo($"edit-bill/{id}");
    }


	
}