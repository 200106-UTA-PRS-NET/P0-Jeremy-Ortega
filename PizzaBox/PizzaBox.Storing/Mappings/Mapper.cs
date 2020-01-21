

using PizzaBox.Storing.TestModels;

namespace PizzaBox.Storing.Mappings


{
    public class Mapper
    {
        public static Customer1 Map(Domain.Models.Customer Cx)
        {
            return new Customer1()
            {
                Id = Cx.Id,
                Fname = Cx.Fname,
                Lname = Cx.Lname,
                Email = Cx.Email,
                UserPass = Cx.UserPass,
                Phone = Cx.Phone
            };
        }
        public static Domain.Models.Customer Map(Customer1 Cx)
        {
            return new Domain.Models.Customer()
            {
                Id=Cx.Id,
                Fname=Cx.Fname,
                Lname=Cx.Lname,
                Email=Cx.Email,
                UserPass=Cx.UserPass,
                Phone=Cx.Phone
            };
        }
    }
}
