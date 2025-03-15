
public partial class ListVendor
{
	protected  Vendor[]? vendorList;

    protected override async Task OnInitializedAsync()
    {
        var remoteClient = ClientFactory.CreateClient("RemoteAPI");

        vendorList = await remoteClient.GetFromJsonAsync<Vendor[]>("api/vendor");
    }

    void AddVendor()
    {
        
        Navigation.NavigateTo("edit-vendor");
    }

    void EditVendor(long id)
    {
        Navigation.NavigateTo($"edit-vendor/{id}");
    }


	
}