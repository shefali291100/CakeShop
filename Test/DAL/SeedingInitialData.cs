using Microsoft.AspNetCore.Identity;
using Test.DAL.Entities;


namespace Test.DAL
{
    public class SeedingInitialData
    {
        public static List<Cake> GetCakes() {
            return new List<Cake>
           {
               new Cake
               {
                   Id = 1,
                   Name = "Red velvet cake",
                   Price = 350,
                   Description = "Red velvet cake is a red-colored cake with white icing."
               },
               new Cake
               {
                   Id= 2,   
                   Name = "Chocolate Cake",
                   Price = 300,
                   Description = "Chocolate cake is a dessert made with cocoa or melted chocolate."

               },
           };
        }
    }
}
