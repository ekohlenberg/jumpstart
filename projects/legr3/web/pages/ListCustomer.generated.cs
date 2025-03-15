
public partial class ListCustomer
{
	protected  Customer[]? customerList;

    protected override async Task OnInitializedAsync()
    {
        var remoteClient = ClientFactory.CreateClient("RemoteAPI");

        customerList = await remoteClient.GetFromJsonAsync<Customer[]>("api/customer");
    }

    void AddCustomer()
    {
        
        Navigation.NavigateTo("edit-customer");
    }

    void EditCustomer(long id)
    {
        Navigation.NavigateTo($"edit-customer/{id}");
    }


	
}