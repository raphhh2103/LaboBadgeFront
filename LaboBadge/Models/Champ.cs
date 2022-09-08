namespace LaboBadge.Models
{
    public class Champ
    {
        public int IdChamp { get; set; }

        public string Name { get; set; }
        public int BasicStatisticId { get; set; }
        public AffinityChamp Affinity { get; set; }
        public Skills[] Skills { get; set; }



    }
}
