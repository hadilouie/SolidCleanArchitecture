using HR.LeaveManagement.Blazor.UI.Services.Base;

namespace HR.LeaveManagement.Blazor.UI.Contracts;

public interface ILeaveAllocationService
{
    Task<Response<Guid>> CreateLeaveAllocations(int leaveTypeId);
}

