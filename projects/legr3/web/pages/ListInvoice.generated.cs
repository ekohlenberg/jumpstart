
public partial class ListInvoice
{
	protected  Invoice[]? invoiceList;

    protected override async Task OnInitializedAsync()
    {
        var remoteClient = ClientFactory.CreateClient("RemoteAPI");

        invoiceList = await remoteClient.GetFromJsonAsync<Invoice[]>("api/invoice");
    }

    void AddInvoice()
    {
        
        Navigation.NavigateTo("edit-invoice");
    }

    void EditInvoice(long id)
    {
        Navigation.NavigateTo($"edit-invoice/{id}");
    }


	
}