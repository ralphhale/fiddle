namespace IndustrialLighting.Persistence.Entities
{
    public class Material
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public MaterialType Type { get; set; }
    }
}
