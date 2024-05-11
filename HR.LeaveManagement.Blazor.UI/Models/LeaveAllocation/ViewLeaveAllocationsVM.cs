namespace HR.LeaveManagement.Blazor.UI.Models.LeaveAllocation;

public class ViewLeaveAllocationsVM
{
    public string EmployeeId { get; set; }
    public List<LeaveAllocationVM> LeaveAllocations { get; set; }
}
