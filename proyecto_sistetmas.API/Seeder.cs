
using Microsoft.EntityFrameworkCore;
using proyecto_sistemas.Shared.Entities;
using System.Drawing;

namespace proyecto_sistetmas.API
{
    public class Seeder
    {

        private readonly DataContext dataContext;
        public Seeder(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task SeedAsync()
        {
            await dataContext.Database.EnsureCreatedAsync();
            await CheckCategoryAsync();
            await CheckBrandAsync();
            await CheckProductsAsync();
            await CheckOrderAsync();


        }

        private async Task CheckCategoryAsync()
        {
            if (!dataContext.Categories.Any())
            {
                dataContext.Categories.Add(new Category { Name = "Tenis" });
                dataContext.Categories.Add(new Category { Name = "Cinturones" });
                dataContext.Categories.Add(new Category { Name = "Carteras / Tarjeteros" });
                dataContext.Categories.Add(new Category { Name = "Gorras" });
                dataContext.Categories.Add(new Category { Name = "Playeras / Camisas" });
                dataContext.Categories.Add(new Category { Name = "Sandalias" });
                dataContext.Categories.Add(new Category { Name = "Bolsas" });
                dataContext.Categories.Add(new Category { Name = "Pants Completos" });

            }
            await dataContext.SaveChangesAsync();
        }

        private async Task CheckBrandAsync()
        {
            if (!dataContext.Brands.Any())
            {
                dataContext.Brands.Add(new Brand { Name = "Givenchy" });
                dataContext.Brands.Add(new Brand { Name = "Yves Saint Laurent" });
                dataContext.Brands.Add(new Brand { Name = "Philip Plein" });
                dataContext.Brands.Add(new Brand { Name = "Christian Louboutin" });
                dataContext.Brands.Add(new Brand { Name = "Burberry" });
                dataContext.Brands.Add(new Brand { Name = "Alexander McQueen" });
                dataContext.Brands.Add(new Brand { Name = "Gucci" });
                dataContext.Brands.Add(new Brand { Name = "Versace" });
                dataContext.Brands.Add(new Brand { Name = "Fendi" });
                dataContext.Brands.Add(new Brand { Name = "Balmain" });
                dataContext.Brands.Add(new Brand { Name = "Dolce & Gabbana" });
                dataContext.Brands.Add(new Brand { Name = "Balenciaga" });
                dataContext.Brands.Add(new Brand { Name = "Diesel" });
                dataContext.Brands.Add(new Brand { Name = "Valentino" });
                dataContext.Brands.Add(new Brand { Name = "Karl Lagerfeld" });
                dataContext.Brands.Add(new Brand { Name = "Zadig & Voltaire" });
                dataContext.Brands.Add(new Brand { Name = "Michael Kors" });
                dataContext.Brands.Add(new Brand { Name = "Dior" });
                dataContext.Brands.Add(new Brand { Name = "Chanel" });
                dataContext.Brands.Add(new Brand { Name = "Louis Vuitton" });
                dataContext.Brands.Add(new Brand { Name = "Moschino" });
                dataContext.Brands.Add(new Brand { Name = "Off-white" });

            }
            await dataContext.SaveChangesAsync();

        }
        private async Task CheckProductsAsync()
        {
            if (!dataContext.Products.Any())
            {
                var tenis = dataContext.Categories.FirstOrDefault(c => c.Name == "Tenis");
                var cinturones = dataContext.Categories.FirstOrDefault(c => c.Name == "Cinturones");
                var carteras = dataContext.Categories.FirstOrDefault(c => c.Name == "Carteras / Tarjeteros");
                var gorras = dataContext.Categories.FirstOrDefault(c => c.Name == "Gorras");
                var playeras = dataContext.Categories.FirstOrDefault(c => c.Name == "Playeras / Camisas");
                var sandalias = dataContext.Categories.FirstOrDefault(c => c.Name == "Sandalias");
                var bolsas = dataContext.Categories.FirstOrDefault(c => c.Name == "Bolsas");
                var pants = dataContext.Categories.FirstOrDefault(c => c.Name == "Pants Completos");
                var givenchy = dataContext.Brands.FirstOrDefault(b => b.Name == "Givenchy");
                var yvesSaintLaurent = dataContext.Brands.FirstOrDefault(b => b.Name == "Yves Saint Laurent");
                var philipPlein = dataContext.Brands.FirstOrDefault(b => b.Name == "Philip Plein");
                var christianLouboutin = dataContext.Brands.FirstOrDefault(b => b.Name == "Christian Louboutin");
                var burberry = dataContext.Brands.FirstOrDefault(b => b.Name == "Burberry");
                var alexanderMcQueen = dataContext.Brands.FirstOrDefault(b => b.Name == "Alexander McQueen");
                var gucci = dataContext.Brands.FirstOrDefault(b => b.Name == "Gucci");
                var versace = dataContext.Brands.FirstOrDefault(b => b.Name == "Versace");
                var fendi = dataContext.Brands.FirstOrDefault(b => b.Name == "Fendi");
                var balmain = dataContext.Brands.FirstOrDefault(b => b.Name == "Balmain");
                var dolceGabbana = dataContext.Brands.FirstOrDefault(b => b.Name == "Dolce & Gabbana");
                var balenciaga = dataContext.Brands.FirstOrDefault(b => b.Name == "Balenciaga");
                var diesel = dataContext.Brands.FirstOrDefault(b => b.Name == "Diesel");
                var valentino = dataContext.Brands.FirstOrDefault(b => b.Name == "Valentino");
                var karlLagerfeld = dataContext.Brands.FirstOrDefault(b => b.Name == "Karl Lagerfeld");
                var zadigVoltaire = dataContext.Brands.FirstOrDefault(b => b.Name == "Zadig & Voltaire");
                var michaelKors = dataContext.Brands.FirstOrDefault(b => b.Name == "Michael Kors");
                var dior = dataContext.Brands.FirstOrDefault(b => b.Name == "Dior");
                var chanel = dataContext.Brands.FirstOrDefault(b => b.Name == "Chanel");
                var louisVuitton = dataContext.Brands.FirstOrDefault(b => b.Name == "Louis Vuitton");
                var moschino = dataContext.Brands.FirstOrDefault(b => b.Name == "Moschino");
                var offWhiteBrand = dataContext.Brands.FirstOrDefault(b => b.Name == "Off-white");


                if (givenchy != null)
                {
                    dataContext.Products.Add(new Product { Name = "Versace Negro Letras Blancas", Brand = versace, Category = tenis, Size = "24.5", Color = "Logo negro / blanco", Quantity = 1, Total = 10683 });
                    dataContext.Products.Add(new Product { Name = "Versace Medusa blanco con dorado", Brand = versace, Category = tenis, Size = "22.5", Color = "Blanco / Dorado", Quantity = 0, Total = 11544 });
                    dataContext.Products.Add(new Product { Name = "Versace Medusa blanco con dorado", Brand = versace, Category = tenis, Size = "24", Color = "Blanco / Dorado", Quantity = 0, Total = 11544 });
                    dataContext.Products.Add(new Product { Name = "Versace Medusa negro con Dorado", Brand = versace, Category = tenis, Size = "22.5", Color = "Negro", Quantity = 1, Total = 11544 });
                    dataContext.Products.Add(new Product { Name = "Versace medusa blanco con dorado", Brand = versace, Category = tenis, Size = "24", Color = "Blanco / Dorado", Quantity = 1, Total = 11544 });
                    dataContext.Products.Add(new Product { Name = "Versace medusa blanco", Brand = versace, Category = tenis, Size = "N/A", Color = "Blanco", Quantity = 0, Total = 11544 });

                    dataContext.Products.Add(new Product { Name = "Givenchy blancos logo verde pálido", Brand = givenchy, Category = tenis, Size = "26", Color = "Blanco", Quantity = 1, Total = 8820 });
                    dataContext.Products.Add(new Product { Name = "Givenchy monograma en maya negro con blanco", Brand = givenchy, Category = tenis, Size = "24.5", Color = "Blanco y Negro", Quantity = 1, Total = 10300 });
                    dataContext.Products.Add(new Product { Name = "Sandalia plataforma negra con letras blancas", Brand = givenchy, Category = sandalias, Size = "22.5", Color = "Negro", Quantity = 1, Total = 5564 });
                    dataContext.Products.Add(new Product { Name = "Givenchy bota mezclilla monograma", Brand = givenchy, Category = tenis, Size = "22.5", Color = "N/A", Quantity = 1, Total = 9620 });
                    dataContext.Products.Add(new Product { Name = "Givenchy blanco elástico mezclilla", Brand = givenchy, Category = tenis, Size = "23", Color = "Blanco", Quantity = 1, Total = 8140 });
                    dataContext.Products.Add(new Product { Name = "Sandalia plataforma negra con letras blancas", Brand = givenchy, Category = sandalias, Size = "24.5", Color = "Negro", Quantity = 1, Total = 5564 });
                    dataContext.Products.Add(new Product { Name = "Givenchy runner blancos con letras negras", Brand = givenchy, Category = tenis, Size = "26.5", Color = "Blanco y Negro", Quantity = 1, Total = 9620 });
                    dataContext.Products.Add(new Product { Name = "Sandalias verde fluorescente", Brand = givenchy, Category = sandalias, Size = "26", Color = "Fosforecente", Quantity = 1, Total = 3700 });
                    dataContext.Products.Add(new Product { Name = "Givenchy blancos letras atrás Givenchy", Brand = givenchy, Category = tenis, Size = "22.5", Color = "Blanco", Quantity = 1, Total = 8140 });
                    dataContext.Products.Add(new Product { Name = "Givenchy negros con logo rojo", Brand = givenchy, Category = tenis, Size = "N/A", Color = "Negro", Quantity = 1, Total = 8820 });
                    dataContext.Products.Add(new Product { Name = "Givenchy maya negra monograma con blanco", Brand = givenchy, Category = tenis, Size = "22.5", Color = "Negro", Quantity = 1, Total = 10300 });
                    dataContext.Products.Add(new Product { Name = "Sandalias rosas con logo blanco", Brand = givenchy, Category = sandalias, Size = "22.5", Color = "Rosa", Quantity = 1, Total = 3108 });
                    dataContext.Products.Add(new Product { Name = "Sandalias rojas con logo blanco", Brand = givenchy, Category = sandalias, Size = "28.5", Color = "N/A", Quantity = 0, Total = 3700 });
                    dataContext.Products.Add(new Product { Name = "Tenis blancos con logo verde", Brand = givenchy, Category = tenis, Size = "26", Color = "Blanco", Quantity = 1, Total = 8140 });
                    dataContext.Products.Add(new Product { Name = "Sandalias plataforma logo blanco", Brand = givenchy, Category = sandalias, Size = "22.5", Color = "Negro", Quantity = 1, Total = 5564 });

                    dataContext.Products.Add(new Product { Name = "Fendi blancos con broche café número 35", Brand = fendi, Category = tenis, Size = "22.5", Color = "Blanco", Quantity = 1, Total = 12284 });
                    dataContext.Products.Add(new Product { Name = "Fendi blancos con broche café", Brand = fendi, Category = tenis, Size = "23", Color = "Blanco", Quantity = 1, Total = 12284 });

                    dataContext.Products.Add(new Product { Name = "Balenciaga negro con blanco 43", Brand = balenciaga, Category = tenis, Size = "27.5", Color = "Blanco y Negro", Quantity = 1, Total = 12787 });
                    dataContext.Products.Add(new Product { Name = "Balenciaga negro con blanco", Brand = balenciaga, Category = tenis, Size = "26.5", Color = "Blanco y Negro", Quantity = -1, Total = 12787 });
                    dataContext.Products.Add(new Product { Name = "Balenciaga negros con blanco 41", Brand = balenciaga, Category = tenis, Size = "26", Color = "Blanco y Negro", Quantity = 0, Total = 12787 });
                    dataContext.Products.Add(new Product { Name = "Balenciaga calceta gris fuerte", Brand = balenciaga, Category = tenis, Size = "26.5", Color = "Gris", Quantity = 0, Total = 12313 });
                    dataContext.Products.Add(new Product { Name = "Balenciaga negros con letras blancas calceta", Brand = balenciaga, Category = tenis, Size = "24.5", Color = "Negro", Quantity = 1, Total = 13852 });
                    dataContext.Products.Add(new Product { Name = "PP trainer negros", Brand = fendi, Category = tenis, Size = "24", Color = "Negro", Quantity = 0, Total = 8140 });

                }

            }
            await dataContext.SaveChangesAsync();

        }

        private async Task CheckOrderAsync()
        {
            if (!dataContext.Orders.Any())
            {
                var product = await dataContext.Products.FirstOrDefaultAsync(x => x.Name == "PP trainer negros" );

                if (product != null)
                {
                    dataContext.Orders.Add(new Order { Name = "Orden 001", Total = 10683, OrderItems = new List<OrderItem> { new OrderItem { ProductId = 1, Quantity = 2 }, new OrderItem { ProductId = 2, Quantity = 1 } } });

                }
            }
            await dataContext.SaveChangesAsync();

        }
    }
}
