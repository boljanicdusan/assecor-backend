using System;
using System.IO;
using Assecor.Core.Exceptions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assecor.API.Controllers
{
    public abstract class BaseController : Controller
    {
        /// <summary>Handles all exceptions</summary>
        protected IActionResult Handle(Exception exception)
        {
            if (exception is ExceptionWithStatusCode)
            {
                var statusCode = (exception as ExceptionWithStatusCode).StatusCode;
                return StatusCode(statusCode, new ExceptionModel(exception.Message, statusCode));
            }

            // This is a tricky part
            // If a custom exception is thrown while mapping objects (using AutoMapper)
            // automapper wraps the custom exception in AutoMapperMappingException,
            // so we access the custom exception through inner exception
            if (exception is AutoMapperMappingException)
            {
                if (exception.InnerException != null)
                {
                    return Handle(exception.InnerException);
                }
            }

            return StatusCode(StatusCodes.Status500InternalServerError, new ExceptionModel(exception.Message, StatusCodes.Status500InternalServerError));
        }
    }
}