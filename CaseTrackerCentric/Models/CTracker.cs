using System;
using System.Collections.Generic;

namespace CaseTrackerCentric.Models
{
    public partial class CTracker
    {
        public int Id { get; set; }
        public string? ConsultationName { get; set; }
        public string? ClientName { get; set; }
        public DateTime? TimeShare { get; set; }
        public string? LeadConsultant { get; set; }
        public DateTime? FillingDate { get; set; }
        public DateTime? DocSubDate { get; set; }
        public string? CaseSummary { get; set; }
        public string? ConsultationId { get; set; }
        public string? ConsultantStatus { get; set; }
        public int? PaymentRec { get; set; }
        public string? AssistantCons { get; set; }
        public DateTime? HearningDate { get; set; }
        public DateTime? DateOfTransfer { get; set; }
        public string? Email { get; set; }
        public int? Phone { get; set; }
    }
}
