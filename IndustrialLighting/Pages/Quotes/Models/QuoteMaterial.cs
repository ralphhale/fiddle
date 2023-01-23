using IndustrialLighting.Persistence.Entities;

namespace IndustrialLighting.Pages.Quotes.Models
{
    public class QuoteMaterial
    {
        public Material? Material { get; set; }

        public decimal TotalPrice 
        { 
            get 
            { 
                var price = Convert.ToDecimal(Material?.Price ?? 0);
                var totalUnits = Convert.ToDecimal(TotalUnits);

                return price * totalUnits; 
            } 
        }

        public int TotalUnits { get; set; }

        public QuoteMaterial()
        {
            Material = new Material
            {
                Type = new MaterialType()
            };

            TotalUnits = 1;
        }
    }
}
