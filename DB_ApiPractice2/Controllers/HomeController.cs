using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DB_ApiPractice2.Models;
using Microsoft.EntityFrameworkCore;
using DB_ApiPractice2.DataAccess;
using System.Net.Http;
using Newtonsoft.Json;
using static DB_ApiPractice2.Models.EF_Models;

namespace DB_ApiPractice2.Controllers
{
	public class HomeController : Controller
	{
		public ApplicationDbContext dbContext;
		static string Base_URL = "https://api.fda.gov/food/enforcement.json?";
		//No Api key needed;
		HttpClient httpClient;

		public HomeController(ApplicationDbContext context)
		{
			dbContext = context;

			httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Accept.Clear();
			httpClient.DefaultRequestHeaders.Accept.Add(
		  new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
		}
		public Rootobject GetReports()
		{
			string API_Path = Base_URL+ "limit=5";
			string rootObjectData = "";
			Rootobject rootObject = null;

			httpClient.BaseAddress = new Uri(API_Path);
			HttpResponseMessage response = httpClient.GetAsync(API_Path).GetAwaiter().GetResult();

			if (response.IsSuccessStatusCode)
			{
				rootObjectData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
			}

			if (!rootObjectData.Equals(""))
			{
				rootObject = JsonConvert.DeserializeObject<Rootobject>(rootObjectData);
			}

			return rootObject;

		}
		public Rootobject GetTampaReports()
		{
			string API_Path = Base_URL + "search=city:'Tampa'&limit=5";
			string rootObjectData = "";
			Rootobject rootObject = null;

			httpClient.BaseAddress = new Uri(API_Path);
			HttpResponseMessage response = httpClient.GetAsync(API_Path).GetAwaiter().GetResult();

			if (response.IsSuccessStatusCode)
			{
				rootObjectData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
			}

			if (!rootObjectData.Equals(""))
			{
				rootObject = JsonConvert.DeserializeObject<Rootobject>(rootObjectData);
			}

			return rootObject;
		}


			public IActionResult Index()
			{
			ViewBag.dbSuccessComp = 0;
			Rootobject rootObject = GetReports();

			TempData["Reports"]= JsonConvert.SerializeObject(rootObject);

			return View(rootObject);
			}
		public IActionResult TampaRecalls()
		{
			ViewBag.dbSuccessComp = 0;
			Rootobject rootObject = GetTampaReports();

			TempData["TampaReports"] = JsonConvert.SerializeObject(rootObject);

			return View(rootObject);
		}
		/*public IActionResult Reports()
		{
			ViewBag.dbSuccessComp = 0;
			Rootobject rootObject = GetReports();

			TempData["Reports"] = JsonConvert.SerializeObject(rootObject);

			return View(rootObject);
		}*/
		public IActionResult PopulateTampaReports()
		{
			Rootobject rootObject = GetTampaReports();

			TempData["Reports"] = JsonConvert.SerializeObject(rootObject);

			rootObject = JsonConvert.DeserializeObject<Rootobject>(TempData["TampaReports"].ToString());

			foreach (Reports report in rootObject.results)
			{
				if (dbContext.Reports.Where(c => c.recall_number.Equals(report.recall_number)).Count() == 0)
				{
					dbContext.Reports.Add(report);
				}


			}

			dbContext.SaveChanges();
			ViewBag.dbSuccessComp = 1;
			return View("TampaRecalls", rootObject);
		}
		public IActionResult PopulateReports()
		{
			Rootobject rootObject = GetReports();

			TempData["Reports"] = JsonConvert.SerializeObject(rootObject);

			rootObject = JsonConvert.DeserializeObject<Rootobject>(TempData["Reports"].ToString());

			foreach(Reports report in rootObject.results)
			{
				if (dbContext.Reports.Where(c => c.recall_number.Equals(report.recall_number)).Count() == 0)
				{
					dbContext.Reports.Add(report);
				}

				
			}

			dbContext.SaveChanges();
			ViewBag.dbSuccessComp = 1;
			return View("Index", rootObject);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
