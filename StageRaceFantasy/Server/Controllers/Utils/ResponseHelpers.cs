using Microsoft.AspNetCore.Mvc;
using StageRaceFantasy.Server.Commands;
using StageRaceFantasy.Server.Queries;
using System;

namespace StageRaceFantasy.Server.Controllers.Utils
{
    public static class ResponseHelpers
    {
        public static ActionResult<T> BuildRawContentResponse<T>(ControllerBase controller, QueryResult<T> queryResult)
        {
            if (queryResult.IsNotFound)
            {
                return controller.NotFound();
            }

            return queryResult.Content;
        }

        public static ActionResult<T> BuildRawContentResponse<T>(ControllerBase controller, CommandResult<T> commandResult)
        {
            if (commandResult.IsBadRequest)
            {
                return controller.BadRequest();
            }

            if (commandResult.IsNotFound)
            {
                return controller.NotFound();
            }

            return commandResult.Content;
        }

        public static ActionResult BuildNoContentResponse(ControllerBase controller, CommandResult commandResult)
        {
            if (commandResult.IsBadRequest)
            {
                return controller.BadRequest();
            }

            if (commandResult.IsNotFound)
            {
                return controller.NotFound();
            }

            return controller.NoContent();
        }

        public static ActionResult<T> BuildCreatedAtResponse<T>(
            ControllerBase controller,
            CommandResult<T> commandResult,
            string actionName,
            Func<object> buildRouteValues)
        {
            if (commandResult.IsBadRequest)
            {
                return controller.BadRequest();
            }

            if (commandResult.IsNotFound)
            {
                return controller.NotFound();
            }

            var routeValues = buildRouteValues();
            return controller.CreatedAtAction(actionName, routeValues, commandResult.Content);
        }
    }
}
