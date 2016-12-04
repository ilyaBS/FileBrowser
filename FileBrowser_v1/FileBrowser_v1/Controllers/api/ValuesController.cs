using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FileBrowser_v1.Models;
using Newtonsoft.Json.Linq;

namespace FileBrowser_v1.Controllers
{
    
    public class ValuesController : ApiController
    {
         //GET api/values
        //public string[] Get()
        //{
        //    return new string[] { "value1", "value2" };
        //    //return new FolderSummary();
        //}

        //// GET api/values/5
        //public FolderSummary Get(string id)
        //{
        //    return new FolderSummary("");
        //}

        // POST api/values
        public FolderSummary Post([FromBody] JObject value)
        {
            string newPath = "";
            if (value != null)
            {
                newPath = value["path"].ToString();
            }
            return new FolderSummary(newPath);
        }

        //// PUT api/values/5
        //public void Put(int id, [FromBody]JObject value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}