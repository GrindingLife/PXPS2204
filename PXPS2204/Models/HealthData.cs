using System.ComponentModel.DataAnnotations;

namespace PXPS2204.Models
{
    public class HealthData
    {
        private DbContext _db;
        [Key]
        public int Id { get; set; }
        public int NEET { get; set; }
        public int Selfharm { get; set; }
        public int Psychosis { get; set; }
        public int Medical { get; set; }
        public int ChildDx { get; set; }
        public int Circadian { get; set; }
        public int Tripartite { get; set; }
        public int ClinicalStage { get; set; }
        public int Sofas { get; set; }
    }
}
