
public partial class ListEventService
{
	protected  EventService[]? eventserviceList;

    protected override async Task OnInitializedAsync()
    {
        var remoteClient = ClientFactory.CreateClient("RemoteAPI");

        eventserviceList = await remoteClient.GetFromJsonAsync<EventService[]>("api/eventservice");
    }

    void AddEventService()
    {
        
        Navigation.NavigateTo("edit-eventservice");
    }

    void EditEventService(long id)
    {
        Navigation.NavigateTo($"edit-eventservice/{id}");
    }


	
}