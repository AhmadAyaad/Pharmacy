using Microsoft.AspNetCore.Mvc;
using System.Net;
using ZPharmacy.Shared.Models;

namespace ZPharmacy.API.Extensions
{
    public static class ControllerBaseExtensions
    {
        public static ObjectResult FailedResponseResult(this ControllerBase controllerBase, Response response)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            switch (response.Status)
            {
                case (ResponseStatus.Unauthorized):
                    statusCode = HttpStatusCode.Unauthorized; break;
                case (ResponseStatus.NotFound):
                    statusCode = HttpStatusCode.NotFound; break;
                case (ResponseStatus.BadRequest):
                case (ResponseStatus.Failed):
                    statusCode = HttpStatusCode.BadRequest; break;
            }
            return controllerBase.StatusCode((int)statusCode, response.GetMessages());
        }
        public static StatusCodeResult Created(this ControllerBase controller)
        {
            return controller.StatusCode((int)HttpStatusCode.Created);
        }
    }
}
