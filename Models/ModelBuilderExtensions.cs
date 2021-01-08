using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CoksaProject.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
       
            modelBuilder.Entity<Tasks>().HasData(
                new Tasks
                {
                    ID = 1,
                    CodeName= "A1", 
                    Description= "Upoznavanje vozila, Voznja po pravcu, mijenjanje brzina i zaustavljanje",
                    Hours = 1
                    
                },new Tasks
                {
                    ID = 2,
                    CodeName= "A2", 
                    Description= "Voznja unaprijed-unatrag po pravcu s promjenom smjera",
                    Hours = 2,

                },new Tasks
                {
                    ID = 3,
                    CodeName= "A3", 
                    Description= "Okretanje vozila zbog promjene smjera",
                    Hours = 1,

                },new Tasks
                {
                    ID = 4,
                    CodeName= "A4", 
                    Description= "Parkiranje vozila",
                    Hours = 1,

                },new Tasks
                {
                    ID = 5,
                    CodeName= "A5", 
                    Description= "Kocenje i zaustavljanje",
                    Hours = 1,

                },new Tasks
                {
                    ID = 6,
                    CodeName= "B1", 
                    Description = "Ukljucivanje u promet i iskljucivanje iz prometa",
                    Hours = 2,

                },new Tasks
                {
                    ID = 7,
                    CodeName= "B2", 
                    Description= "Polukruzno okretanje, okretanje vozila s vise postupaka, okretanje vozila zbog promjene smjera, parkiranje vozila",
                    Hours = 2,

                },new Tasks
                {
                    ID = 8,
                    CodeName= "B3", 
                    Description= "Postupanje prema znakovima u prometu",
                    Hours = 4,

                },new Tasks
                {
                    ID = 9,
                    CodeName= "B4", 
                    Description= "Voznja",
                    Hours = 4,

                },new Tasks
                {
                    ID = 10,
                    CodeName= "B5", 
                    Description= "Voznja zavojima, prilagodba brzine voznje, kocenje",
                    Hours = 2,

                },new Tasks
                {
                    ID = 11,
                    CodeName= "B6", 
                    Description= "Voznja raskrizjem",
                    Hours = 2,

                },new Tasks
                {
                    ID = 12,
                    CodeName= "B7", 
                    Description= "Pretjecanje i  obilaznje",
                    Hours = 2,

                },new Tasks
                {
                    ID = 13,
                    CodeName= "B8", 
                    Description= "Ukljucivanje na autocestu ili brzu cestu ili cestu namijenjenu za promet motornih vozila i iskljucivanje s tih cesta",
                    Hours = 3,

                },new Tasks
                {
                    ID = 14,
                    CodeName= "B9", 
                    Description= "Voznja u naselju (gradu) i izvan naselja (grada)",
                    Hours = 2,

                },new Tasks
                {
                    ID = 15,
                    CodeName= "B10", 
                    Description= "Voznja prometnicama s posebnim karakteristikama",
                    Hours = 2,

                },new Tasks
                {
                    ID = 16,
                    CodeName= "B11", 
                    Description= "Samostalna voznja",
                    Hours = 1,

                },new Tasks
                {
                    ID = 17,
                    CodeName= "B12", 
                    Description= "Sigurna i energetski ucinkovita voznja",
                    Hours = 2,

                },new Tasks
                {
                    ID = 18,
                    CodeName= "B13", 
                    Description= "Ponasanje prema drugim sudionicima u prometu sukladno prometnim propisima i pravilima",
                    Hours = 2,

                }
                
            );
            modelBuilder.Entity<DrivingSchool>().HasData(
                new DrivingSchool
                {
                    ID = 1,
                    City = "Sibenik",
                    Country = "Hrvatska",
                    Established = 1990,
                    Name = "Autoskola Neno"
                },    new DrivingSchool
                {
                    ID = 2,
                    City = "Sibenik",
                    Country = "Hrvatska",
                    Established = 1995,
                    Name = "Autoskola Zeleni Val"
                }
                );
            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    ID = 1,
                    Brand = "BMW M4",
                    ManufactureYear = 2016,
                  
                },    new Car
                {
                    ID = 2,
                    Brand = "Audi A4",
                    ManufactureYear = 2019,
                }, new Car
                {
                    ID = 3,
                    Brand = "Ford Focus RS",
                    ManufactureYear = 2016,
                }
            );
        }
    }
}