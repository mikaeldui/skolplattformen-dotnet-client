namespace Skolplattformen
{
    public class SkolplattformenChild
    {
        public string Id { get; set; }
        /// <summary>
        /// Special ID used to access certain subsystems
        /// </summary>
        public string SdsId { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// F - förskola, GR - grundskola?
        /// </summary>
        public string? Status { get; set; }
        public string? SchoolId { get; set; }
    }
}
