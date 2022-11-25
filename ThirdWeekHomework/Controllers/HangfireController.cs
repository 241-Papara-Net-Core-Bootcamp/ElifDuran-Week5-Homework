using DocumentFormat.OpenXml.Office.CustomUI;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ThirdWeekHomework.Business.Interfaces;
using ThirdWeekHomework.Data.DTOs;

namespace ThirdWeekHomework.Hangfire.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangfireController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;
        public HangfireController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [Route("GetAllUsers")]
        [HttpGet]
        public ActionResult GetUser()
        {
            var result =  _userService.GetAllUsers();
            return Ok(result);
        }

        [HttpGet("RetrieveDataFromAPI")]
        public void RetrieveDataFromAPI()
        {
            //Logic to retrieve data from external api 

            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create("https://jsonplaceholder.typicode.com/posts"); // retrieve posts from external api 

            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            Console.WriteLine(WebResp.StatusCode);
            Console.WriteLine(WebResp.Server);

            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())   
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            List<UserDTO> items = (List<UserDTO>)JsonConvert.DeserializeObject(jsonString, typeof(List<UserDTO>));
            _userService.Add(items[0]); // get the first user from list which has been retrieved from external api
            Console.WriteLine(items);
            Console.WriteLine($"Data has been retrieved from external API");
        }      
        
        [HttpGet]
        [Route("RetrieveData")]
        public IActionResult RetrieveData()
        {
            RecurringJob.AddOrUpdate(() => RetrieveDataFromAPI(), _config.GetConnectionString("CronTime")); // recurring job fires the method
            return Ok($"Recurring Job Scheduled. Data will be retrieved every 5 minutes from external API!");
        }        
    }
}
