using Microsoft.AspNetCore.Mvc;
using System;

/// <summary>
/// Yaniv Kriachko
/// 04/10/2021 , 09:00
/// </summary>
namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OpenAPIController : Controller
    {
        [HttpGet]
        [Route("GetData")]

        // <summary>
        ///  Note: I can set ExceptionType as string and not as Exception
        ///        and then I can add .Message to return string Exception message
        /// 
        /// Note: because it's simple function, I have use fat arrow to return message.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>

        public SwaggerOpenApiClass Get()
        {
            Random rnd = new Random();
            SwaggerOpenApiClass items = new SwaggerOpenApiClass() 
            { 
                Id = rnd.Next(Int32.MaxValue),
                ExceptionType = new NullReferenceException("Object reference not set to an instance of an object")
            };
          
            return items;
        }

        /// <summary>
        ///  Without [FromBody] so there will be textbox which accepts text as natural string, can be null
        ///  
        /// 
        /// Note: because it's simple function, I have use fat arrow to return message.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PostDataNoFromBody")]
        public IActionResult PostDataNoFromBody(String message) => Json(message);

        /// <summary>
        /// 
        ///    With [FromBody] which gets the value of primitive data type as json type, body value must contains " " 
        ///    which says it's string value.. request body can not be empty
        ///    /// 
        /// Note: because it's simple function, I have use fat arrow to return message.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PostDataWithFromBody")]
        public IActionResult PostDataWithFromBody([FromBody]String message) => Json(message);

    }
}
