using System.Collections.Generic;
using System.Linq;
using be_master_with_core2.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace be_master_with_core2.Data
{
    public static class DbContextExtensions
    {
        public static UserManager<AppUser> UserManager
        { get; set; }

        public static void EnsureSeeded(this EcommerceContext context)
        {

            AddUsers(context);
            AddColoursFeaturesAndStorage(context);
            AddOperatingSystemsAndBrands(context);
            AddProducts(context);
        }

        private static void AddUsers(EcommerceContext context)
        {
            if (UserManager.FindByEmailAsync("stu@ratcliffe.io").GetAwaiter().GetResult() == null)
            {
                var user = new AppUser
                {
                    FirstName = "Stu",
                    LastName = "Ratcliffe",
                    UserName = "stu@ratcliffe.io",
                    Email = "stu@ratcliffe.io",
                    EmailConfirmed = true,
                    LockoutEnabled = false
                };


                UserManager.CreateAsync(user, "Password1*").GetAwaiter().GetResult();
            }
        }

        private static void AddProducts(EcommerceContext context)
        {
            if (context.Products.Any() == false)
            {
                var products = new List<Product>()
                {
                    new Product
                    {
                        Name = "Samsung Galaxy S8",
                        Slug = "samsung-galaxy-s8",
                        Thumbnail = "http://placehold.it/200x300",
                        ShortDescription = "Samsung Galaxy S8 Android smartphone with true edge to edge display",
                        Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Perferendis tempora ad cum laudantium, omnis fugit amet iure animi corporis labore repellat magnam perspiciatis explicabo maiores fuga provident a obcaecati tenetur nostrum, quidem quod dignissimos, voluptatem quasi? Nisi quaerat, fugit voluptas ducimus facilis impedit quod dicta, laborum sint iure nihil veniam aspernatur delectus officia culpa, at cupiditate? Totam minima ut deleniti laboriosam dolores cumque in, nesciunt optio! Quod recusandae voluptate facere pariatur soluta vel corrupti tenetur aut maiores, cumque mollitia fugiat laudantium error odit voluptas nobis laboriosam quo, rem deleniti? Iste quidem amet perferendis sed iusto tempora modi illo tempore quibusdam laborum? Dicta aliquam libero, facere, maxime corporis qui officiis explicabo aspernatur non consequatur mollitia iure magnam odit enim. Eligendi suscipit, optio officiis repellat eos quis iure? Omnis, error aliquid quibusdam iste amet nihil nisi cumque magni sequi enim illo autem nesciunt optio accusantium animi commodi tenetur neque eum vitae est.",
                        ScreenSize = 5M,
                        TalkTime = 8M,
                        StandbyTime = 36M,
                        Brand = context.Brands.Single(b => b.Name == "Acme"),
                        OS = context.OS.Single(os => os.Name == "Android"),
                        Images = new List<Image>
                        {
                            new Image { Url = "/assets/images/gallery1.jpeg" },
                            new Image { Url = "/assets/images/gallery2.jpeg" },
                            new Image { Url = "/assets/images/gallery3.jpeg" },
                            new Image { Url = "/assets/images/gallery4.jpeg" },
                            new Image { Url = "/assets/images/gallery5.jpeg" },
                            new Image { Url = "/assets/images/gallery6.jpeg" }
                        },
                        ProductFeatures = new List<ProductFeature>
                        {
                            new ProductFeature
                            {
                                Feature = context.Features.Single(f => f.Name == "3G")
                            },
                            new ProductFeature
                            {
                                Feature = context.Features.Single(f => f.Name == "Bluetooth")
                            },
                            new ProductFeature
                            {
                                Feature = context.Features.Single(f => f.Name == "WiFi")
                            },
                            new ProductFeature
                            {
                                Feature = context.Features.Single(f => f.Name == "GPS")
                            }
                        },
                        ProductVariants = new List<ProductVariant>
                        {
                            new ProductVariant
                            {
                                Colour = context.Colours.Single(c => c.Name == "Black"),
                                Storage = context.Storage.Single(s => s.Capacity == "32GB"),
                                Price = 299M
                            },
                            new ProductVariant
                            {
                                Colour = context.Colours.Single(c => c.Name == "Black"),
                                Storage = context.Storage.Single(s => s.Capacity == "64GB"),
                                Price = 349M
                            },
                            new ProductVariant
                            {
                                Colour = context.Colours.Single(c => c.Name == "Gold"),
                                Storage = context.Storage.Single(s => s.Capacity == "32GB"),
                                Price = 319M
                            },
                            new ProductVariant
                            {
                                Colour = context.Colours.Single(c => c.Name == "Gold"),
                                Storage = context.Storage.Single(s => s.Capacity == "64GB"),
                                Price = 369M
                            }
                        }
                    }
                // rest of product list omitted for brevity…
                };

                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }

        private static void AddColoursFeaturesAndStorage(EcommerceContext context)
        {
            if (context.Colours.Any() == false)
            {
                var colours = new List<string>() { "Black", "White", "Gold", "Silver", "Grey", "Spacegrey", "Red", "Pink" };

                colours.ForEach(c => context.Add(new Colour
                {
                    Name = c
                }));

                context.SaveChanges();
            }

            if (context.Storage.Any() == false)
            {
                var storage = new List<string>() { "4GB", "8GB", "16GB", "32GB", "64GB", "128GB", "256GB" };

                storage.ForEach(s => context.Storage.Add(new Storage
                {
                    Capacity = s
                }));

                context.SaveChanges();
            }

            if (context.Features.Any() == false)
            {
                var features = new List<string>() { "3G", "4G", "Bluetooth", "WiFi", "Fast charge", "GPS", "NFC" };

                features.ForEach(f => context.Add(new Feature
                {
                    Name = f
                }));

                context.SaveChanges();
            }
            // rest of method omitted for brevity…
        }

        private static void AddOperatingSystemsAndBrands(EcommerceContext context)
        {
            if (context.OS.Any() == false)
            {
                var os = new List<string>() { "Android", "iOS", "Windows" };

                os.ForEach(o => context.OS.Add(new OS
                {
                    Name = o
                }));

                context.SaveChanges();
            }

            if (context.Brands.Any() == false)
            {
                var brands = new List<string>() { "Acme", "Globex", "Soylent", "Initech", "Umbrella" };

                brands.ForEach(b => context.Brands.Add(new Brand
                {
                    Name = b
                }));

                context.SaveChanges();
            }
            // rest of method omitted for brevity…
        }
    }
}