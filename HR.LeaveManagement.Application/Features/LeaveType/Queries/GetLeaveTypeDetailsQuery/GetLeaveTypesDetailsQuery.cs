
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetailsQuery;

public record GetLeaveTypesDetailsQuery(int Id): IRequest<LeaveTypeDetaislDto>;
