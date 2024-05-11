using HR.LeaveManagement.Blazor.UI.Models.LeaveAllocation;

namespace HR.LeaveManagement.Blazor.UI.Models.LeaveRequests;

public class EmployeeLeaveRequestViewVM
{
    public List<LeaveAllocationVM> LeaveAllocations { get; set; } = new List<LeaveAllocationVM>();
    public List<LeaveRequestVM> LeaveRequests { get; set; } = new List<LeaveRequestVM>();
}
