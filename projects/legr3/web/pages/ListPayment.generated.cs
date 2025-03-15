
public partial class ListPayment
{
	protected  Payment[]? paymentList;

    protected override async Task OnInitializedAsync()
    {
        var remoteClient = ClientFactory.CreateClient("RemoteAPI");

        paymentList = await remoteClient.GetFromJsonAsync<Payment[]>("api/payment");
    }

    void AddPayment()
    {
        
        Navigation.NavigateTo("edit-payment");
    }

    void EditPayment(long id)
    {
        Navigation.NavigateTo($"edit-payment/{id}");
    }


	
}