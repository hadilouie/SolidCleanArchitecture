
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.DatabseContext.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(HrDatabaseContext _context) : base(_context)
        {
        }

        public async Task AddAllocations(List<LeaveAllocation> allocations)
        {
            await _context.AddRangeAsync(allocations);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AllocationExist(string userId, int leaveTypeId, int period)
        {
            return await _context.LeaveAllocations.AnyAsync(t => t.EmployeeId == userId
            && t.LeaveTypeId == leaveTypeId
            && t.Period == period);
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            var leaveAlllocations = await _context.LeaveAllocations
                .Include(t => t.LeaveType)
                .ToListAsync();

            return leaveAlllocations;
        }
        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId)
        {
            var leaveAlllocations = await _context.LeaveAllocations.Where(t => t.EmployeeId == userId)
                .Include(t => t.LeaveType)
                .ToListAsync();

            return leaveAlllocations;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leaveAlllocation = await _context.LeaveAllocations
               .Include(t => t.LeaveType)
               .FirstOrDefaultAsync(t => t.Id == id);

            return leaveAlllocation;
        }      

        public async Task<LeaveAllocation> GetUserAllocation(string userId, int leaveTypeId)
        {
            var leaveAlllocation = await _context.LeaveAllocations
                .FirstOrDefaultAsync(t => t.EmployeeId == userId && t.LeaveTypeId == leaveTypeId);

            return leaveAlllocation;
        }
    }
}
