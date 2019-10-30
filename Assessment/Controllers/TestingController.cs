using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.Models;
using DataTables.AspNetCore.Mvc.Binder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Npgsql;
using GeneralClass;


namespace Assessment.Models
{
    public class Products
    {
        static IList<Product> myProducts;

        public static IList<Product> GetProducts()
        {
            if (myProducts == null)
            {
                myProducts = new List<Product>()
            {
                new Product("Tiger Nixon", "System Architect", "Edinburgh", "5421", "2011/04/25", "$320,800"),
                new Product("Garrett Winters", "Accountant", "Tokyo", "8422", "2011/07/25", "$170,750"),
                new Product("Ashton Cox", "Junior Technical Author", "San Francisco", "1562", "2009/01/12", "$86,000"),
                new Product("Cedric Kelly", "Senior Javascript Developer", "Edinburgh", "6224", "2012/03/29", "$433,060"),
                new Product("Airi Satou", "Accountant", "Tokyo", "5407", "2008/11/28", "$162,700"),
                new Product("Brielle Williamson", "Integration Specialist", "New York", "4804", "2012/12/02", "$372,000"),
                new Product("Herrod Chandler", "Sales Assistant", "San Francisco", "9608", "2012/08/06", "$137,500"),
                new Product("Rhona Davidson", "Integration Specialist", "Tokyo", "6200", "2010/10/14", "$327,900"),
                new Product("Colleen Hurst", "Javascript Developer", "San Francisco", "2360", "2009/09/15", "$205,500"),
                new Product("Sonya Frost", "Software Engineer", "Edinburgh", "1667", "2008/12/13", "$103,600"),
                new Product("Jena Gaines", "Office Manager", "London", "3814", "2008/12/19", "$90,560"),
                new Product("Quinn Flynn", "Support Lead", "Edinburgh", "9497", "2013/03/03", "$342,000"),
                new Product("Charde Marshall", "Regional Director", "San Francisco", "6741", "2008/10/16", "$470,600"),
                new Product("Haley Kennedy", "Senior Marketing Designer", "London", "3597", "2012/12/18", "$313,500"),
                new Product("Tatyana Fitzpatrick", "Regional Director", "London", "1965", "2010/03/17", "$385,750"),
                new Product("Michael Silva", "Marketing Designer", "London", "1581", "2012/11/27", "$198,500"),
                new Product("Paul Byrd", "Chief Financial Officer (CFO)", "New York", "3059", "2010/06/09", "$725,000"),
                new Product("Gloria Little", "Systems Administrator", "New York", "1721", "2009/04/10", "$237,500"),
                new Product("Bradley Greer", "Software Engineer", "London", "2558", "2012/10/13", "$132,000"),
                new Product("Dai Rios", "Personnel Lead", "Edinburgh", "2290", "2012/09/26", "$217,500"),
                new Product("Jenette Caldwell", "Development Lead", "New York", "1937", "2011/09/03", "$345,000"),
                new Product("Yuri Berry", "Chief Marketing Officer (CMO)", "New York", "6154", "2009/06/25", "$675,000"),
                new Product("Caesar Vance", "Pre-Sales Support", "New York", "8330", "2011/12/12", "$106,450"),
                new Product("Doris Wilder", "Sales Assistant", "Sidney", "3023", "2010/09/20", "$85,600"),
                new Product("Angelica Ramos", "Chief Executive Officer (CEO)", "London", "5797", "2009/10/09", "$1,200,000"),
                new Product("Gavin Joyce", "Developer", "Edinburgh", "8822", "2010/12/22", "$92,575"),
                new Product("Jennifer Chang", "Regional Director", "Singapore", "9239", "2010/11/14", "$357,650"),
                new Product("Brenden Wagner", "Software Engineer", "San Francisco", "1314", "2011/06/07", "$206,850"),
                new Product("Fiona Green", "Chief Operating Officer (COO)", "San Francisco", "2947", "2010/03/11", "$850,000"),
                new Product("Shou Itou", "Regional Marketing", "Tokyo", "8899", "2011/08/14", "$163,000"),
                new Product("Michelle House", "Integration Specialist", "Sidney", "2769", "2011/06/02", "$95,400"),
                new Product("Suki Burks", "Developer", "London", "6832", "2009/10/22", "$114,500"),
                new Product("Prescott Bartlett", "Technical Author", "London", "3606", "2011/05/07", "$145,000"),
                new Product("Gavin Cortez", "Team Leader", "San Francisco", "2860", "2008/10/26", "$235,500"),
                new Product("Martena Mccray", "Post-Sales support", "Edinburgh", "8240", "2011/03/09", "$324,050"),
                new Product("Unity Butler", "Marketing Designer", "San Francisco", "5384", "2009/12/09", "$85,675")
            };
            }
            return myProducts;
        }
    }
    public class Product
    {
        public Product(string name, string position, string office, string extn, string date, string salary)
        {
            this.Checks = "";
            this.Name = name;
            this.Id = Convert.ToInt32(extn);
            this.Created = DateTime.Parse(date);
            this.Salary = salary;
            this.Office = office;
            this.Position = position;
        }

        public int Id { get; set; }
        [JsonProperty(PropertyName = "checks")] public string Checks { get; set; }
        [JsonProperty(PropertyName = "name")] public string Name { get; set; }
        [JsonProperty(PropertyName = "position")] public string Position { get; set; }
        [JsonProperty(PropertyName = "office")] public string Office { get; set; }
        [JsonProperty(PropertyName = "salary")] public string Salary { get; set; }
        [JsonProperty(PropertyName = "created")] public DateTime Created { get; set; }
    }
}

namespace Assessment.Controllers
{
    public class Eselon
    {
        public DataTable Dt { get; set; }
    }
    public class TestingController : Controller
    {
        public ActionResult eselon()
        {
            var sb = new StringBuilder();
            var dt = new DataTable();

            sb.Append(" select * from eselon");
            dt = GeneralClass.POSTGREMYSQL.Instance.ExecuteQuery(sb.ToString());
            var eselon = new Eselon { Dt = dt };
            //for (var i = 0; i <= dt.Rows.Count - 1; i++)
            //{
            //    string a = "";

            //    a = dt.Rows[i][0].ToString();
            //}
            return View(eselon);
        }
        // GET: Testing
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult Index3()
        {
            return View();
        }

        [HttpDelete()]
        [Route("api/value/{id:int}")]
        public IActionResult Delete(int id)
        {
            Products.GetProducts().Remove(Products.GetProducts().First(i => i.Id == id));
            return Ok();
        }

        [HttpGet()]
        [Route("api/value")]
        public IActionResult Get([DataTablesRequest] DataTablesRequest dataRequest)
        {
            IEnumerable<Product> products = Products.GetProducts();
            int recordsTotal = products.Count();
            int recordsFilterd = recordsTotal;

            if (!string.IsNullOrEmpty(dataRequest.Search?.Value))
            {
                products = products.Where(e => e.Name.Contains(dataRequest.Search.Value));
                recordsFilterd = products.Count();
            }
            if (dataRequest.Length > 0)
            {
                products = products.Skip(dataRequest.Start).Take(dataRequest.Length);
            }

            return Json(products
                .Select(e => new
                {
                    Checks = e.Checks,
                    Id = e.Id,
                    Name = e.Name,
                    Created = e.Created,
                    Salary = e.Salary,
                    Position = e.Position,
                    Office = e.Office
                })
                .ToDataTablesResponse(dataRequest, recordsTotal, recordsFilterd));
        }

        // GET: Testing/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Testing/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Testing/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Testing/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Testing/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //// GET: Testing/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Testing/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}