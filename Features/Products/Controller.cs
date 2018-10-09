using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using be_master_with_core2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace be_master_with_core2.Features.Products
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly EcommerceContext _db;

        public ProductsController(EcommerceContext db)
        {
            _db = db;
        }
        /*
        [HttpGet]
        public async Task<IActionResult> Find()
        {
            var products = await _db.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet]
        public async Task<IActionResult> Find(string q, string brands, int? minPrice, int? maxPrice, int? minScreen, int? maxScreen, string capacity, string colours, string os, string features)
        {
          var Query = $"%{q?.ToLower()}%";
          var Brands = string.IsNullOrEmpty(brands) ? new List<string>() : brands.Split('|').ToList();
          var Capacity = string.IsNullOrEmpty(capacity) ? new List<string>() : capacity.Split('|').ToList();
          var Colours = string.IsNullOrEmpty(colours) ? new List<string>() : colours.Split('|').ToList();
          var OS = string.IsNullOrEmpty(os) ? new List<string>() : os.Split('|').ToList();
          var Features = string.IsNullOrEmpty(features) ? new List<string>() : features.Split('|').ToList();
            //method body omitted for brevity…

          var products = await _db.Products
            .Where(x => Brands.Any() == false || Brands.Contains(x.Brand.Name))
            .Where(x => minPrice.HasValue == false || x.ProductVariants.Any(v => v.Price >= minPrice.Value))
            .Where(x => maxPrice.HasValue == false || x.ProductVariants.Any(v => v.Price <= maxPrice.Value))
            .Where(x => minScreen.HasValue == false || x.ScreenSize >= Convert.ToDecimal(minScreen.Value))
            .Where(x => maxScreen.HasValue == false || x.ScreenSize <= Convert.ToDecimal(maxScreen.Value))
            .Where(x => Capacity.Any() == false || x.ProductVariants.Any(v => Capacity.Contains(v.Storage.Capacity)))
            .Where(x => Colours.Any() == false || x.ProductVariants.Any(v => Colours.Contains(v.Colour.Name)))
            .Where(x => OS.Any() == false || OS.Contains(x.OS.Name))
            .Where(x => Features.Any() == false || Features.All(f => x.ProductFeatures.Any(pf => pf.Feature.Name == f)))
            .Where(x =>
                string.IsNullOrEmpty(q) ||
                (
                    EF.Functions.Like(x.Name.ToLower(), Query) ||
                    EF.Functions.Like(x.ShortDescription.ToLower(), Query) ||
                    EF.Functions.Like(x.Description.ToLower(), Query) ||
                    EF.Functions.Like(x.Brand.Name.ToLower(), Query) ||
                    EF.Functions.Like(x.OS.Name.ToLower(), Query) ||
                    x.ProductFeatures.Any(f =>
                    EF.Functions.Like(f.Feature.Name.ToLower(), Query)
                    )
                )
                )
            .Select(x => new ProductListViewModel
            {
              Id = x.Id,
              Slug = x.Slug,
              Name = x.Name,
              ShortDescription = x.ShortDescription,
              Thumbnail = x.Thumbnail,
              Price = x.ProductVariants.OrderBy(v => v.Price).First().Price
            })
            .ToListAsync();

            return Ok(products);

        }

        ///////////
        var product =await_db.Products.Select(x =>newProductDetailsViewModel
{
  Id=x.Id,
  Slug=x.Slug,
  Name=x.Name,
  ShortDescription=x.ShortDescription,
  Description=x.Description,
  Price=x.ProductVariants.OrderBy(v =>v.Price).First().Price,
  Thumbnail=x.Thumbnail,
  Images=x.Images.Select(i =>i.Url),
  Features=x.ProductFeatures.Select(f =>f.Feature.Name),
  Colours=x.ProductVariants.Select(v =>newSelectListItem
  {
    Value=v.ColourId.ToString(),
    Text=v.Colour.Name
  }).Distinct(),
  Storage=x.ProductVariants.Select(v =>newSelectListItem
  {
    Value=v.StorageId.ToString(),
    Text=v.Storage.Capacity.ToString() +"GB"
  }).Distinct(),
  Variants=x.ProductVariants.Select(v =>newProductVariantViewModel
  {
    ProductId=x.Id,
    Name=x.Name,
    Thumbnail=x.Thumbnail,
    ColourId=v.ColourId,
    Colour=v.Colour.Name,
    StorageId=v.StorageId,
    Capacity=$"{v.Storage.Capacity}GB",
    Price=v.Price
  })
})
.FirstOrDefaultAsync(x =>x.Slug==slug);
        */

        [HttpGet("{slug}")]
        public async Task<IActionResult> Get(string slug)
        {
            var product = await _db.Products.SingleOrDefaultAsync(x => x.Slug == slug);

            if (product == null)
                return NotFound();

            return Ok(product);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _db.Products.ToListAsync();
            return Ok(products);
        }

    }
}