using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestService.Controllers
{
    public class StringController : ApiController
    {
        [HttpGet]
        [Route("api/arrayString/{str}")]
        public IHttpActionResult ConvertToArray(string str)
        {
            int strInt = 0;
            if (string.IsNullOrEmpty(str))
            {
                return Content(HttpStatusCode.NotAcceptable, "You can not send an empty string");
            }
            else if (str.Length == 1)
            {
                return Content(HttpStatusCode.NotAcceptable, "The string must be more than 1 character");
            }
            else if (int.TryParse(str, out strInt))
            {
                return Content(HttpStatusCode.NotAcceptable, "The string must have atleast 1 alphabetic character");
            }
            else
            {
                List<string> listWords = new List<string>(str.Split(' '));
                return Ok(listWords);
            }
        }

        [HttpGet]
        [Route("api/upperCase/{str}")]
        public IHttpActionResult ConvertToUpper(string str)
        {
            int strInt = 0;
            if (string.IsNullOrEmpty(str))
            {
                return Content(HttpStatusCode.NotAcceptable, "You can not send an empty string");
            }
            else if (str.Length == 1)
            {
                return Content(HttpStatusCode.NotAcceptable, "The string must be more than 1 character");
            }
            else if (int.TryParse(str, out strInt))
            {
                return Content(HttpStatusCode.NotAcceptable, "The string must have atleast 1 alphabetic character");
            }
            else
            {
                return Ok(str.ToUpper());
            }
        }

        [HttpGet]
        [Route("api/stringLength/{str}")]
        public IHttpActionResult LengthOfString(string str)
        {
            int strInt = 0;
            if (string.IsNullOrEmpty(str))
            {
                return Content(HttpStatusCode.NotAcceptable, "You can not send an empty string");
            }
            else if (str.Length == 1)
            {
                return Content(HttpStatusCode.NotAcceptable, "The string must be more than 1 character");
            }
            else if (int.TryParse(str, out strInt))
            {
                return Content(HttpStatusCode.NotAcceptable, "The string must have atleast 1 alphabetic character");
            }
            else
            {
                return Ok(str.Length);
            }
        }

        [HttpGet]
        [Route("api/wordAndLength/{str}")]
        public IHttpActionResult WordAndLength(string str)
        {
            int strInt = 0;
            if (string.IsNullOrEmpty(str))
            {
                return Content(HttpStatusCode.NotAcceptable, "You can not send an empty string");
            }
            else if (str.Length == 1)
            {
                return Content(HttpStatusCode.NotAcceptable, "The string must be more than 1 character");
            }
            else if (int.TryParse(str, out strInt))
            {
                return Content(HttpStatusCode.NotAcceptable, "The string must have atleast 1 alphabetic character");
            }
            else
            {
                List<CustomClass> customClass = new List<CustomClass>();
                List<string> wordsString = new List<string>(str.Split(' '));
                foreach (var word in wordsString)
                {
                    customClass.Add(new CustomClass { Word = word, Length = word.Length });
                }
                return Ok(customClass);
            }
        }
    }
}
