namespace Skolplattformen
{
    public class SkolplattformenClassmate
    {
        public string SisId { get; set; }
        public string? ClassName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public SkolplattformenCollection<SkolplattformenGuardian> Guardians { get; set; }
    }
}
