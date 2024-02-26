using Log_inWeb_Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Log_inWeb_Api.Controllers
{
    public class ValuesController : Controller
    {
        //Get api/values

        public IEnumerable<string> Get()
        {
            return new string[] { "valuel", "valueltwo" };
        }

        //Get api/values/Five

        public string Get(int id)
        {
            return "valuel";
        }

        //Post api/values

        public void Post([FromBody] string vlue)
        {
        }

        //Put api/values/Five

        public void Put(int id, [FromBody] string value)
        {
        }


        //Delete api/values/Five

        public void Delete(int id)
        {
        }

        [Route("/api/Values/GetLogin")]
        [HttpPost]
        public string GetLogin(LoginModel loginModel)
        {
            BAL bal = new BAL();
            string response = bal.GetLogin(loginModel);
            return response;
        }
    }
}
