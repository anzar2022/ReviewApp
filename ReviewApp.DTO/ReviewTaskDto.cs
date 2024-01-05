using System.ComponentModel.DataAnnotations;

namespace ReviewApp.DTO
{
    public record UpdateTaskStartDateDto(long Id, DateOnly TaskStartDate);
    public record UpdateTaskCompleteDateDto(long Id, DateOnly TaskCompleteDate);

    public record CreateReviewTaskDto(
       [Required(ErrorMessage = "Enter task title")] string TaskTitle,
       [Required(ErrorMessage = "Enter task Description")] string TaskDescription,
       string EmployeeComment,
       string ManagerComment,
       double ManagerRating,
       double EmployeeRating,
       int Weightage,
       DateOnly TaskStartDate,
       bool IsTaskStartDate,
       DateOnly TaskCompleteDate,
       bool IsTaskCompleteDate,
       int StatusId,
       int QuarterId,
       int PercentageComplete,
       int UserId
     );

    public record UpdateReviewTaskDto(
      long Id,
      [Required(ErrorMessage = "Enter task title")] string TaskTitle,
      [Required(ErrorMessage = "Enter task Description")] string TaskDescription,
      string EmployeeComment,
      string ManagerComment,
      double ManagerRating,
      double EmployeeRating,
      int Weightage,
      DateOnly TaskStartDate,
      bool IsTaskStartDate,
      DateOnly TaskCompleteDate,
      bool IsTaskCompleteDate,
      int StatusId,
      int QuarterId,
      int PercentageComplete,
      int UserId
    );

}
