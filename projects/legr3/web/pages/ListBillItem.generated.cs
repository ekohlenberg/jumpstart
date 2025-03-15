
public partial class ListBillItem
{
	protected  BillItem[]? billitemList;

    protected override async Task OnInitializedAsync()
    {
        var remoteClient = ClientFactory.CreateClient("RemoteAPI");

        billitemList = await remoteClient.GetFromJsonAsync<BillItem[]>("api/billitem");
    }

    void AddBillItem()
    {
        
        Navigation.NavigateTo("edit-billitem");
    }

    void EditBillItem(long id)
    {
        Navigation.NavigateTo($"edit-billitem/{id}");
    }


	
}