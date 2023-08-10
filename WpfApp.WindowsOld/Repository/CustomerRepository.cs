using System.Collections.Generic;
using System.Threading.Tasks;
using WpfApp.WindowsOld.Models;

namespace WpfApp.WindowsOld.Repository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customers>> GetCustomers();
    }

    public class CustomerRepository : ICustomerRepository
    {
        public async Task<IEnumerable<Customers>> GetCustomers()
        {
            await Task.Delay(1000);

            return new List<Customers>()
            {
                new Customers
                {
                    FirstName= "Anish",
                    Id= 1,
                    IsDeveloper= true,
                    LastName= "Aravind"
                },
                new Customers
                {
                    FirstName= "Vipin",
                    Id= 2,
                    IsDeveloper= true,
                    LastName= "V"
                },
                new Customers
                {
                    FirstName= "Libu",
                    Id= 2,
                    IsDeveloper= true,
                    LastName= "Mathew"
                },
            };
        }
    }
}
