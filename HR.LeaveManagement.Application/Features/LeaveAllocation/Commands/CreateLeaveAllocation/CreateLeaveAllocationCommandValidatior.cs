using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;

public class CreateLeaveAllocationCommandValidatior : AbstractValidator<CreateLeaveAllocationCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveAllocationCommandValidatior(ILeaveTypeRepository leaveTypeRepository)
    {
        RuleFor(p => p.LeaveTypeId).GreaterThan(0).MustAsync(LeaveTypeExists).WithMessage("{PropertyName} does not exist.");
        _leaveTypeRepository = leaveTypeRepository;
    }

    private async Task<bool> LeaveTypeExists(int id, CancellationToken token)
    {
        var leaveType = await _leaveTypeRepository.GetByIdAsync(id);

        return leaveType != null;
    }
}
