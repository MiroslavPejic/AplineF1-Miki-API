namespace AplineF1_Miki_API.Models
{
    public class UpdateTyreModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
        public string? Type { get; set; }
        public string? Placement { get; set; }

        public string? degradationCoefficient { get; set; }
    }
}
