using Lesson7.EntityFramework.EntityDataModel;
using System.Linq;

namespace Lesson7
{
    public class EFHelper
    {
        public bool IsThereArePersonsWhoBoughtCarsNOTInTheirHomeCity()
        {
            using (var context = new masterEntities())
            {
                return context.BuyersInfoes.Any(r => r.Person.City.CityName != r.City.CityName);
            }
        }

        public bool IsAllPersonsWhoBoughtCarsAreOlderThanTheirBuyersInfoYear()
        {
            using (var context = new masterEntities())
            {
                return context.BuyersInfoes.All(r => r.Year > r.Person.Year);
            }
        }

        public bool IsAllPersonsBoughtCars()
        {
            using (var context = new masterEntities())
            {
                return !context.People.Select(p => p.ID)
                    .Except(context.BuyersInfoes.Select(b => b.PersonID))
                    .Any();
            }
        }
    }
}
