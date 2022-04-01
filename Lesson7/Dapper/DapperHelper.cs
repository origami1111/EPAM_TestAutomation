using System.Linq;

namespace DataBases.Dapper
{
    public class DapperHelper : BaseContext
    {
        public bool IsAllPersonsWhoBoughtCarsAreOlderThanTheirBuyersInfoYear()
        {
            return PerformQuery("SELECT p.ID, p.FirstName, p.LastName, p.Year AS 'PersonYear', b.Year AS 'BuyerInfoYear'" +
                                "FROM BuyersInfo b INNER JOIN Person p " +
                                "ON b.PersonID = p.ID;")
                .All(row => row.BuyerInfoYear > row.PersonYear);
        }

        public bool IsAllPersonsBoughtCars()
        {
            return !PerformQuery("SELECT ID " +
                                "FROM Person " +
                                "EXCEPT " +
                                "SELECT PersonID " +
                                "FROM BuyersInfo")
                    .Any();
        }

        public bool IsThereArePersonsWhoBoughtCarsNotInTheirHomeCity()
        {
            return PerformQuery("SELECT * " +
                                "FROM BuyersInfo b JOIN Person p ON b.PersonID = p.ID " +
                                "JOIN City c ON b.CityID = c.ID AND p.CityID != c.ID;")
                .Any();
        }
    }
}
