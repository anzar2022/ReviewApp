using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace ReviewApp.Model
{
    [Table("ReviewTasks")]
    public class ReviewTask
    {
        public long Id { get; set; }
        public string TaskTitle { get; set; } =string.Empty;
        public string TaskDescription { get; set; }=string.Empty;
        public string EmployeeComment {  get; set; }    =string.Empty;
        public string ManagerComment {  get; set; } =string.Empty;
        public double ManagerRating { get; set; } = 0;
        public double EmployeeRating {  get; set; } =0;
        public int Weightage { get; set; } =0;
        public DateOnly TaskStartDate { get; set; }
        public DateOnly TaskCompleteDate { get; set; }
        public int StatusId { get; set; } = 0;
        [ForeignKey("StatusId")]
        public virtual Status? Status { get; set; }
        public int QuarterId { get; set; } = 0;
        [ForeignKey("QuarterId")]
        public virtual Quarter? Quarter { get; set; }
        public int PercentageComplete { get; set; } =0;


    }
}
