namespace IndustrialLighting.Persistence.Entities
{
    public class MaterialType
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }

        public MaterialType Clone()
        {
            return new MaterialType
            {
                Id = this.Id,
                IsActive = this.IsActive,
                Name = this.Name
            };
        }
    }
}
