using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class RegistrationForm
    {
        public int RegistrationFormId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }

        public Status? Status { get; set; }
        public int? StatusId { get; set; }

        public Category? Category { get; set; }
        public int? CategoryId { get; set; }

        public User? Candidate { get; set; }
        public int? CandidateId { get; set; }

        public User? ResearchAssistant { get; set; }
        public int? ResearchAssistantId { get; set; }

        public User? Professor { get; set; }
        public int? ProfessorId { get; set; }
    }
}
