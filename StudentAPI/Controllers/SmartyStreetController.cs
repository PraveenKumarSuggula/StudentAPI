using System;
using SmartyStreets;
using SmartyStreets.USStreetApi;
using System.Web.Http;
using StudentAPI.Models;
using System.Linq;
using System.Collections.Generic;

namespace StudentAPI.Controllers
{
    [RoutePrefix("Api/Smartstreet")]
    public class SmartyStreetController : ApiController
    {
        //public IHttpActionResult SearchSmartstreet(SmartStreetDto smartStreetDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    try
        //    {
        //        SmartStreetDto objStd = new SmartStreetDto();
        //        //objStd = db.Studentstbls.Find(smartStreetDto.StudentID);
        //        if (objStd != null)
        //        {
        //            objStd.DeliveryLine1 = smartStreetDto.DeliveryLine1;
        //            objStd.CityName = smartStreetDto.CityName;
        //            objStd.LastLine = smartStreetDto.LastLine;

        //       }

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return Ok(smartStreetDto);
        //}
        [HttpGet]
        [Route("SendDataToUI/{data}")]
        public IHttpActionResult PostSmartstreet(string data)
        {
            var authId = "3058a467-b5ee-e687-dc2e-b4ea687278ef";
            var authToken = "uXkhqF70wtPYdkGZuqbd";

            var client = new ClientBuilder(authId, authToken).BuildUsStreetApiClient();

            var lookup = new Lookup
            {//"1 Rosedale" street
                //"Baltimore MD" lastline
                Street = data,
                Lastline = "Baltimore MD",
                MaxCandidates = 10
            };

            try
            {
                client.Send(lookup);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            var candidates = lookup.Result;
            
            var results = new List<SmartStreetDto>();
            for (var i = 0; i < candidates.Count; i++)
            {
                var candidateComponent = candidates[i];
                results.Add(new SmartStreetDto()
                {
                    CityName = candidateComponent.Components.CityName,
                    DeliveryLine1 = candidateComponent.DeliveryLine1,
                    LastLine = candidateComponent.LastLine,
                    Street = candidateComponent.Components.StreetName
                });
            }
            return Ok(results);
        }
    }
}
