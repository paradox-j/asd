namespace TestWebApp.Models
{
    public class VisitorsModel
    {
        public int VisitorID { get; set; }
        public string? VisitorSurname { get; set; }
        public string? VisitorName { get; set; }
        public string? VisitorPatronymic { get; set; }
        public string? VisitorPhone { get; set; }
        public string? VisitorEmail { get; set; }
        public string? VisitorLogin { get; set; }
        public string? VisitorPassword { get; set; }
        public string? VisitorOrganisation { get; set; }
        public DateTime? VisitorDateOfBirth { get; set; }
        public string? VisitorDescription { get; set; }
        public string? VisitorSeriaPassport { get; set; }
        public string? VisitorNumberPassport { get; set; }
        public byte[]? VisitorPhoto { get; set; }
        public string? VisitorSkan { get; set; }
    }
}
