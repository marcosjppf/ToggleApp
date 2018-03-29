namespace ToggleApp.AppService.Dto
{
    public class ToggleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public int? ApplicationId { get; set; }
        public bool Activated { get; set; }
    }
}
