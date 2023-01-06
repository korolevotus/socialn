using Microsoft.AspNetCore.Mvc;
using OTUSHigloadTestProject.Models.Responses;

namespace OTUSHigloadTestProject.Controllers
{
    public class ResultController : Controller
    {
        public override OkObjectResult Ok(object value)
        {
            return base.Ok(new BaseResponse<object>(true, value));
        }

        public override CreatedAtActionResult CreatedAtAction(string actionName, object routeValues, object value)
        {
            return base.CreatedAtAction(actionName, routeValues, new BaseResponse<object>(true, value));
        }

        public override BadRequestObjectResult BadRequest(object error)
        {
            return base.BadRequest(new BaseResponse<object>(false, error));
        }

        public override ObjectResult StatusCode(int statusCode, object value)
        {
            return base.StatusCode(statusCode, new BaseResponse<object>(statusCode / 100 == 2, value));
        }
    }
}
