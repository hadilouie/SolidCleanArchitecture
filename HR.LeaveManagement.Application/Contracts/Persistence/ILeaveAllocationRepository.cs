﻿using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
{
    Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
    Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails();
    Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId);
    Task<bool> AllocationExist(string userId , int leaveTypeId, int period);
    Task AddAllocations(List<LeaveAllocation> allocations);
    Task<LeaveAllocation> GetUserAllocation(string userId, int leaveTypeId);
}
