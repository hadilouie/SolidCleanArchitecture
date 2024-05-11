using HR.LeaveManagement.Blazor.UI.Contracts;
using HR.LeaveManagement.Blazor.UI.Models.LeaveTypes;
using Microsoft.AspNetCore.Components;

namespace HR.LeaveManagement.Blazor.UI.Pages.LeaveTypes
{
    public partial class Details
    {
        [Inject]
        ILeaveTypeService _client { get; set; }

        [Parameter]
        public int id { get; set; }

        LeaveTypeVM leaveType = new LeaveTypeVM();

        protected async override Task OnParametersSetAsync()
        {
            leaveType = await _client.GetLeaveTypeDetails(id);
        }
    }
}