using System;
using System.Collections.Generic;

#nullable disable

namespace PrototipoOracleAPIFull.Models
{
    public partial class Job
    {
        public Job()
        {
            Employees = new HashSet<Employee>();
            JobHistories = new HashSet<JobHistory>();
        }

        public string JobId { get; set; }
        public string JobTitle { get; set; }
        public int? MinSalary { get; set; }
        public int? MaxSalary { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<JobHistory> JobHistories { get; set; }
    }
}
