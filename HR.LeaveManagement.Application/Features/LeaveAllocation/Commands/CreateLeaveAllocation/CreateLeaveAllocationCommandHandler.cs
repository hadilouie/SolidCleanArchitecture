using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;

public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, Unit>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepostiory;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IUserService _userService;

    public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocation,
        ILeaveTypeRepository leaveTypeRepository,
        IUserService userService)
    {
        _leaveAllocationRepostiory = leaveAllocation;
        _leaveTypeRepository = leaveTypeRepository;
        _userService = userService;
    }
    public async Task<Unit> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateLeaveAllocationCommandValidatior(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid Leave allocation Request", validationResult);


        var leaveType = await _leaveTypeRepository.GetByIdAsync(request.LeaveTypeId);

        //Get Employee
        var employees = await _userService.GetEmployees();

        //Get Period
        var period = DateTime.Now.Year;

        // Assign Allocation If an allocation doesn't exist for period and leave type
        //Assign Allocations IF an allocation doesn't already exist for period and leave type
        var allocations = new List<Domain.LeaveAllocation>();
        foreach (var emp in employees)
        {
            var allocationExists = await _leaveAllocationRepostiory.AllocationExist
                (emp.Id, request.LeaveTypeId, period);

            if (allocationExists == false)
            {
                allocations.Add(new Domain.LeaveAllocation
                {
                    EmployeeId = emp.Id,
                    LeaveTypeId = leaveType.Id,
                    NumberOfDays = leaveType.DefaultDays,
                    Period = period,
                });
            }
        }

        if (allocations.Any())
        {
            await _leaveAllocationRepostiory.AddAllocations(allocations);
        }

        return Unit.Value;
    }
}
