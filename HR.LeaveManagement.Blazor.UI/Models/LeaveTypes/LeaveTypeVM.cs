using System.ComponentModel.DataAnnotations;

namespace HR.LeaveManagement.Blazor.UI.Models.LeaveTypes;

public class LeaveTypeVM
{
    public int Id { get; set; }
    [Required(ErrorMessage = "The Name field is required.")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "The Default Days field is required.")]
    [Display(Name = "Default Number of Days")]
    public int DefaultDays { get; set; }

}
