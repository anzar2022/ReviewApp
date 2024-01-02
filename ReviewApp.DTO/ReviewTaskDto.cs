namespace ReviewApp.DTO
{
   public record UpdateTaskStartDateDto (long Id, DateOnly TaskStartDate);
   public record UpdateTaskCompleteDateDto(long Id, DateOnly TaskCompleteDate);

}
