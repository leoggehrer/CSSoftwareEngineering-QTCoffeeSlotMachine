using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTCoffeeSlotMachine.ConApp
{
    partial class Program
    {
        static partial void AfterRun()
        {
            Task.Run(async () => await CreateSlotMaschinesAsync()).Wait();
        }
        static async Task CreateSlotMaschinesAsync()
        {
            using var smCtrl = new Logic.Controllers.SlotMachinesController();
            var sm = new Logic.Entities.SlotMachine
            {
                Location = "HTL-Leonding",
                Address = "Limesstrße 12-14, 4060 Leonding",
                Price = 50,
                DepoteCoin5 = 3,
                DepoteCoin10 = 3,
                DepoteCoin20 = 3,
                DepoteCoin50 = 3,
                DepoteCoin100 = 3,
                DepoteCoin200 = 3,
            };
            sm.Products.Add(new Logic.Entities.Product { Name = "Cappuccino" });
            sm.Products.Add(new Logic.Entities.Product { Name = "Mocca" });
            sm.Products.Add(new Logic.Entities.Product { Name = "Kakao" });

            await smCtrl.InsertAsync(sm);
            await smCtrl.SaveChangesAsync();
        }
    }

}
