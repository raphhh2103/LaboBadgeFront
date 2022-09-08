namespace LaboBadge.Models
{
    public class Champ
    {
        public int IdChamp { get; set; }

        public string Name { get; set; }
        public BasicStatistic BasicStatistic { get; set; }
        public AffinityChamp Affinity { get; set; }
        public IEnumerable<Skills> Skills { get; set; }



    }
}
