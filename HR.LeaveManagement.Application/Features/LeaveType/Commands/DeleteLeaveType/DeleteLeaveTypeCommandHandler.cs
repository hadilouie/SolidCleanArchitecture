﻿
using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var leaveTypeDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);

            // Verify that record exist

            if(leaveTypeDelete == null)
            {
                throw new NotFoundException(nameof(leaveTypeDelete), request.Id);
            }

            await _leaveTypeRepository.DeleteAsync(leaveTypeDelete);

            return Unit.Value;
            
        }
    }
}
