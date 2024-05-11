
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.DatabseContext.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    public LeaveRequestRepository(HrDatabaseContext _context) : base(_context)
    {
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
    {
        var leaveRequests = await _context.LeaveRequests
            .Include(t => t.LeaveType)
            .ToListAsync();

        return leaveRequests;
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(string userId)
    {
        var leaveRequests = await _context.LeaveRequests
            .Where(q => !string.IsNullOrEmpty(q.RequestingEmployeeId))
            .Include(t => t.LeaveType)
            .ToListAsync();

        return leaveRequests;
    }

    public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
    {
        var leaveRequests = await _context.LeaveRequests
    .Where(t => t.Id == id)
    .Include(t => t.LeaveType)
    .FirstOrDefaultAsync();

        return leaveRequests;
    }
}
