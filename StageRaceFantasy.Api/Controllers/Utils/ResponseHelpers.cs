using Microsoft.AspNetCore.Mvc;
using StageRaceFantasy.Application.Common.Requests;
using System;
using System.Linq;

namespace StageRaceFantasy.Server.Controllers.Utils
{
    public static class ResponseHelpers
    {
        public static ActionResult<T> BuildRawContentResponse<T>(ControllerBase controller, ApplicationRequestResult<T> commandResult)
        {
            if (commandResult.IsBadRequest)
            {
                return BuildBadRequestResponse(controller, commandResult);
            }

            if (commandResult.IsNotFound)
            {
                return controller.NotFound();
            }

            return commandResult.Content;
        }

        public static ActionResult BuildNoContentResponse(ControllerBase controller, ApplicationRequestResult commandResult)
        {
            if (commandResult.IsBadRequest)
            {
                return BuildBadRequestResponse(controller, commandResult);
            }

            if (commandResult.IsNotFound)
            {
                return controller.NotFound();
            }

            return controller.NoContent();
        }

        public static ActionResult<T> BuildCreatedAtResponse<T>(
            ControllerBase controller,
            ApplicationRequestResult<T> commandResult,
            string actionName,
            Func<object> buildRouteValues)
        {
            if (commandResult.IsBadRequest)
            {
                return BuildBadRequestResponse(controller, commandResult);
            }

            if (commandResult.IsNotFound)
            {
                return controller.NotFound();
            }

            var routeValues = buildRouteValues();
            return controller.CreatedAtAction(actionName, routeValues, commandResult.Content);
        }

        private static ActionResult<T> BuildBadRequestResponse<T>(ControllerBase controller, ApplicationRequestResult<T> commandResult)
        {
            return commandResult.ValidationFailures.Any() ?
                    controller.BadRequest(commandResult.ValidationFailures) :
                    controller.BadRequest();
        }

        private static ActionResult BuildBadRequestResponse(ControllerBase controller, ApplicationRequestResult commandResult)
        {
            return commandResult.ValidationFailures.Any() ?
                    controller.BadRequest(commandResult.ValidationFailures) :
                    controller.BadRequest();
        }
    }
}
