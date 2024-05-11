namespace HR.LeaveManagement.Domain.Common;

//It's going to be abstract because we don't want it to be able to stand on its own.
public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime? DateCreated { get; set; }
    public DateTime? DateModified { get; set; }
}
