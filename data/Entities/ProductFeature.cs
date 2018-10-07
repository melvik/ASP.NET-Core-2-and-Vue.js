using be_master_with_core2.Data.Entities;

namespace be_master_with_core2.Data.Entities
{
  public class ProductFeature
  {
    public int ProductId { get; set; }
    public int FeatureId { get; set; }

    public Product Product { get; set; }
    public Feature Feature { get; set; }
  }
}