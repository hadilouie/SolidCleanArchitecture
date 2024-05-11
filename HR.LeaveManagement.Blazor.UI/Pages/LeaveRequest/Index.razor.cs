using HR.LeaveManagement.Blazor.UI.Contracts;
using HR.LeaveManagement.Blazor.UI.Models.LeaveRequests;
using Microsoft.AspNetCore.Components;

namespace HR.LeaveManagement.Blazor.UI.Pages.LeaveRequest;

public partial class Index
{
    [Inject] ILeaveRequestService leaveRequestService { get; set; }
    [Inject] NavigationManager NavigationManager { get; set; }
    public AdminLeaveRequestViewVM Model { get; set; } = new();

    protected async override Task OnInitializedAsync()
    {
        Model = await leaveRequestService.GetAdminLeaveRequestList();
    }

    void GoToDetails(int id)
    {
        NavigationManager.NavigateTo($"/leaverequests/details/{id}");
    }
}