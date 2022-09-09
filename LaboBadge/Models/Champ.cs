namespace LaboBadge.Models
{
    public class Champ
    {
        public int IdChamp { get; set; }

        public string Name { get; set; }
        public int BasicsStatisticsId { get; set; }
        public AffinityChamp Affinity { get; set; }
        public Skills[] Skills { get; set; }



    }
}
