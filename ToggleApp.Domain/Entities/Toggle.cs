using System.ComponentModel.DataAnnotations.Schema;

namespace ToggleApp.Domain.Entities
{
    public class Toggle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public bool Enable { get; set; }

        [ForeignKey("ApplicationId")]
        public virtual Application Application { get; set; }
        public int? ApplicationId;
        public bool IsPublic
            => !ApplicationId.HasValue;

        public bool AcessibleTo(int applicationId, string version)
            => ApplicationId == applicationId && Version == version;
    }
}
