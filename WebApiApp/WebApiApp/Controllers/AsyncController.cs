using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiApp.Helpers;
using WebApiApp.Models.Product;
using WebApiApp.Repositorys.Products;

namespace WebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsyncController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> HandleAsync()
        {
            int[] arrayInt =  { 10, 20, 30, 40}; 
            List<int> arrayEmpty = new List<int>();
            /*string value1 = await Strings.Async1("Async1");
            Console.WriteLine("Lan222222 {0}", value1);*/
            /*var watch = new System.Diagnostics.Stopwatch();*/
            /*watch.Start();*/
            Strings.TestWaitOrWhenAll();
            /*Task.Delay(3000).GetAwaiter().GetResult();*/
            /*watch.Stop();*/
            /*Console.WriteLine($"last log Time: {watch.ElapsedMilliseconds} ms");*/
            /*Console.WriteLine("last log");*/
            return Ok();
        }
    }
}
