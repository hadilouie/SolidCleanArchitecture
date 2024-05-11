using AutoMapper;
using HR.LeaveManagement.Blazor.UI.Models.LeaveAllocation;
using HR.LeaveManagement.Blazor.UI.Models.LeaveRequests;
using HR.LeaveManagement.Blazor.UI.Models;
using HR.LeaveManagement.Blazor.UI.Models.LeaveTypes;
using HR.LeaveManagement.Blazor.UI.Services.Base;

namespace HR.LeaveManagement.Blazor.UI.MappingProfiles;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<LeaveTypeDto, LeaveTypeVM>().ReverseMap();
        CreateMap<LeaveTypeDetaislDto, LeaveTypeVM>().ReverseMap();
        CreateMap<CreateLeaveTypeCommand, LeaveTypeVM>().ReverseMap();
        CreateMap<UpdateLeaveTypeCommand, LeaveTypeVM>().ReverseMap();

        CreateMap<LeaveRequestListDto, LeaveRequestVM>()
            .ForMember(q => q.DateRequested, opt => opt.MapFrom(x => x.DateRequested.DateTime)).
             ForMember(q => q.StartDate, opt => opt.MapFrom(x => x.StartDate.DateTime)).
             ForMember(q => q.EndDate, opt => opt.MapFrom(x => x.EndDate.DateTime))
            .ReverseMap();

        CreateMap<LeaveRequestDetailsDto, LeaveRequestVM>()
            .ForMember(q => q.DateRequested, opt => opt.MapFrom(x => x.DateRequested.DateTime))
            .ForMember(q => q.StartDate, opt => opt.MapFrom(x => x.StartDate.DateTime))
            .ForMember(q => q.EndDate, opt => opt.MapFrom(x => x.EndDate.DateTime))
            .ReverseMap();

        CreateMap<CreateLeaveRequestCommand, LeaveRequestVM>().ReverseMap();
        CreateMap<UpdateLeaveRequestCommand, LeaveRequestVM>().ReverseMap();

        CreateMap<LeaveAllocationDto, LeaveAllocationVM>().ReverseMap();
        CreateMap<LeaveAllocationDetailsDto, LeaveAllocationVM>().ReverseMap();
        CreateMap<CreateLeaveAllocationCommand, LeaveAllocationVM>().ReverseMap();
        CreateMap<UpdateLeaveAllocationCommand, LeaveAllocationVM>().ReverseMap();

        CreateMap<EmployeeVM, Employee>().ReverseMap();
    }
}
