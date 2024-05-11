using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;

public class GetLeaveAllocationHandler : IRequestHandler<GetLeaveAllocationQuery, List<LeaveAllocationDto>>
{
    private readonly ILeaveAllocationRepository _leaveAllocation;
    private readonly IMapper _mapper;

    public GetLeaveAllocationHandler(ILeaveAllocationRepository leaveAllocation, IMapper mapper)
    {
        _leaveAllocation = leaveAllocation;
        _mapper = mapper;
    }
    public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationQuery request, CancellationToken cancellationToken)
    {
        var leaveAllocations = await _leaveAllocation.GetLeaveAllocationsWithDetails();

        var allocations = _mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);

        return allocations;
    }
}
