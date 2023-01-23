namespace IndustrialLighting.Persistence.Entities
{
    public class Material
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int TypeId { get; set; }
        public virtual MaterialType? Type { get; set; }

        public Material Clone()
        {
            return new Material
            {
                Id = this.Id,
                IsActive = this.IsActive,
                Name = this.Name,
                Price = this.Price,
                TypeId = this.TypeId,
                Type = this.Type?.Clone()
            };
        }
    }
}
