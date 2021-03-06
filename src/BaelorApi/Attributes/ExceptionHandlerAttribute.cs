﻿using BaelorApi.Exceptions;
using BaelorApi.Models.Api;
using BaelorApi.Models.Api.Error;
using Microsoft.AspNet.Mvc;
using System.Diagnostics;

#if DEBUG

using System.Net;
using BaelorApi.Models.Error.Enums;

#endif

namespace BaelorApi.Attributes
{
	public class ExceptionHandlerAttribute : 
		ExceptionFilterAttribute
	{
		/// <summary>
		/// Code that is run on exceptions
		/// </summary>
		/// <param name="context"></param>
		public override void OnException(ExceptionContext context)
		{
			if (context.Exception is BaelorV0Exception)
			{
				var exception = context.Exception as BaelorV0Exception;
				context.HttpContext.Response.StatusCode = (int) exception.HttpStatusCode;
				context.Result = new JsonResult(new ResponseBase
				{
					Success = false,
					Result = null,
					Error = new ErrorBase(exception.ErrorStatus)
					{
						Details = exception.ErrorDetails
					}
				});
				return;
			}

#if DEBUG

			// Log the error to the server, as it should not have happened.
			Trace.TraceError(context.Exception.ToString());

			context.HttpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
			context.Result = new JsonResult(new ResponseBase
			{
				Success = false,
				Result = null,
				Error = new ErrorBase(ErrorStatus.GenericServerError)
				{
					//Details = context.Exception
				}
			});

#endif
		}
	}
}