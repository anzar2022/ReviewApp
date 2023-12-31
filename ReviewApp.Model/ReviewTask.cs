﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewApp.Model
{
    [Table("ReviewTasks")]
    public class ReviewTask
    {
        public long Id { get; set; }
        public string TaskTitle { get; set; } = string.Empty;
        public string TaskDescription { get; set; } = string.Empty;
        public string EmployeeComment { get; set; } = string.Empty;
        public string ManagerComment { get; set; } = string.Empty;
        public double ManagerRating { get; set; } = 0;
        public double EmployeeRating { get; set; } = 0;
        public int Weightage { get; set; } = 0;
        public DateOnly TaskStartDate { get; set; }

        public bool IsTaskStartDate { get; set; } = false;

        public DateOnly TaskCompleteDate { get; set; }

        public bool IsTaskCompleteDate { get; set; } = false;

        public int StatusId { get; set; } = 0;
        [ForeignKey("StatusId")]
        public virtual Status? Status { get; set; }
        public int QuarterId { get; set; } = 0;
        [ForeignKey("QuarterId")]
        public virtual Quarter? Quarter { get; set; }
        public int PercentageComplete { get; set; } = 0;

        [ForeignKey("User")]
        public long UserId { get; set; }
        public virtual User User { get; set; }

    }
}
