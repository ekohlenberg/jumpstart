
public partial class ListInvoiceItem
{
	protected  InvoiceItem[]? invoiceitemList;

    protected override async Task OnInitializedAsync()
    {
        var remoteClient = ClientFactory.CreateClient("RemoteAPI");

        invoiceitemList = await remoteClient.GetFromJsonAsync<InvoiceItem[]>("api/invoiceitem");
    }

    void AddInvoiceItem()
    {
        
        Navigation.NavigateTo("edit-invoiceitem");
    }

    void EditInvoiceItem(long id)
    {
        Navigation.NavigateTo($"edit-invoiceitem/{id}");
    }


	
}