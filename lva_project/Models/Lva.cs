using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace lva_project.Models
{
    public partial class Lva
    {
        [DataMember, Required] public int LvaId { get; set; }
        [DataMember, Required] public string LvaName { get; set; } = null!;
        [DataMember, Required] public string LvaTeacher { get; set; } = null!;
        [DataMember, Required] public int LvaNumber { get; set; }
        [DataMember, Required] public int LvaType { get; set; }
        [DataMember, Required] public string LvaRoom { get; set; } = null!;
        [DataMember, Required] public string LvaInstitute { get; set; } = null!;
        [DataMember] public DateTime? LvaExam { get; set; }
        [DataMember, Required] public DateTime LvaCreatedOn { get; set; }
        [DataMember, Required] public double LvaEcts { get; set; }
        [DataMember] public int? LvaGrade { get; set; }
        [DataMember] public int? SemId { get; set; }
    }
}
