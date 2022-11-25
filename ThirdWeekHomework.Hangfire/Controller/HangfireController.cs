using DocumentFormat.OpenXml.Office.CustomUI;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ThirdWeekHomework.Hangfire.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangfireController : ControllerBase
    {        
        public void RetrieveDataFromAPI()
        {
            //Logic to retrieve data from external api 

            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://randomuser.me/api"));

            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            Console.WriteLine(WebResp.StatusCode);
            Console.WriteLine(WebResp.Server);

            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            List<Item> items = JsonConvert.DeserializeObject<List<Item>>(jsonString);

            Console.WriteLine(items);
            Console.WriteLine($"Data has been retrieved from external API");
        }      
        
        [HttpPost]
        [Route("RetrieveData")]
        [Obsolete]
        public IActionResult RetrieveData(string userName)
        {
            RecurringJob.AddOrUpdate(() => RetrieveDataFromAPI(), Cron.MinuteInterval(5));
            return Ok($"Recurring Job Scheduled. Data will be retrieved every 5 minutes from external API!");
        }        
    }
}
