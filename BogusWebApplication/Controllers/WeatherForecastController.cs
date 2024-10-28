using Bogus;
using BogusWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace BogusWebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        [HttpGet(Name = "GetWeatherForecast")]
        public List<Order> Get()
        {

            //var UserFake = new Faker<User>(locale: "fa")
            //    .RuleFor(x => x.Id, f => f.Random.Int(1, 100))
            //    .RuleFor(x => x.UserName, f => f.Person.UserName)
            //    .RuleFor(x => x.FirstName, f => f.Person.FirstName)
            //    .RuleFor(x => x.LastName, f => f.Person.LastName)
            //    .RuleFor(x => x.Address, f => f.Person.Address.City)
            //    .RuleFor(x => x.PhoneNumber, f => f.Phone.PhoneNumber("###########"))
            //    ;
            //return UserFake.Generate(200);


            // تنظیم تولید داده‌های جعلی برای محصولات
            var productFaker = new Faker<Product>(locale: "fa")
                .RuleFor(p => p.ProductId, f => f.Random.Int(1000, 9999))
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Price, f => f.Random.Decimal(5, 100))
                .RuleFor(p => p.Quantity, f => f.Random.Int(1, 10));

            // تنظیم تولید داده‌های جعلی برای مشتریان
            var customerFaker = new Faker<Customer>(locale: "fa")
                .RuleFor(c => c.CustomerId, f => f.Random.Int(1, 1000))
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.Email, f => f.Internet.Email())
                .RuleFor(c => c.Address, f => f.Address.FullAddress());

            // تنظیم تولید داده‌های جعلی برای سفارش‌ها
            var orderFaker = new Faker<Order>(locale: "fa")
                .RuleFor(o => o.OrderId, f => f.Random.Int(10000, 99999))
                .RuleFor(o => o.Customer, f => customerFaker.Generate())
                .RuleFor(o => o.Products, f => productFaker.Generate(f.Random.Int(1, 5)))
                .RuleFor(o => o.TotalAmount, (f, o) => o.Products.Sum(p => p.Price * p.Quantity))
                .RuleFor(o => o.OrderDate, f => f.Date.Past(1))
                .RuleFor(o => o.IsPaid, f => f.Random.Bool());

            // تولید 3 سفارش جعلی
            List<Order> fakeOrders = orderFaker.Generate(3);

            // نمایش داده‌های جعلی
            //foreach (var order in fakeOrders)
            //{
            //    Console.WriteLine($"Order ID: {order.OrderId}");
            //    Console.WriteLine($"Customer: {order.Customer.FirstName} {order.Customer.LastName}");
            //    Console.WriteLine($"Email: {order.Customer.Email}");
            //    Console.WriteLine($"Address: {order.Customer.Address}");
            //    Console.WriteLine($"Order Date: {order.OrderDate}");
            //    Console.WriteLine($"Is Paid: {order.IsPaid}");
            //    Console.WriteLine("Products:");

            //    foreach (var product in order.Products)
            //    {
            //        Console.WriteLine($"  - {product.Name} (Qty: {product.Quantity}) - ${product.Price}");
            //    }

            //    Console.WriteLine($"Total Amount: ${order.TotalAmount}");
            //    Console.WriteLine("-------------------------------");
            //}
            return fakeOrders;
        }
    }
}
