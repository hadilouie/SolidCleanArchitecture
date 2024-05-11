using Blazored.LocalStorage;
using HR.LeaveManagement.Blazor.UI.Contracts;
using HR.LeaveManagement.Blazor.UI.Services.Base;

namespace HR.LeaveManagement.Blazor.UI.Services;

public class LeaveAllocationService : BaseHttpService, ILeaveAllocationService
{
    private readonly ILocalStorageService _localStorage;

    public LeaveAllocationService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task<Response<Guid>> CreateLeaveAllocations(int leaveTypeId)
    {
        try
        {
            var response = new Response<Guid>();
            CreateLeaveAllocationCommand createLeaveAllocation = new() { LeaveTypeId = leaveTypeId };

            await _client.LeaveAllocationsPOSTAsync(createLeaveAllocation);
            return response;
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }
}
