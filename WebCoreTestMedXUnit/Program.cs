using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebCoreTestMedXUnit
{
    public class Program
    {
        public static void Main(string[] args)
        {
          
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }

    public interface IApiRequestSend<T>
    {
        IEnumerable<T> GetAllData();

        void AddEntity(T entity);

        void ModifyEntity(int id, T entity);

        void DeleteEntity(T entity);
    }

    public class testClass : IApiRequestSend<Book>
    {
        public void AddEntity(Book entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(Book entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAllData()
        {
            throw new NotImplementedException();
        }

        public void ModifyEntity(int id, Book entity)
        {
            throw new NotImplementedException();
        }
    }

}
