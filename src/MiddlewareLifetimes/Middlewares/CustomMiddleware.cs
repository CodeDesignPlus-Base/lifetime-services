using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MiddlewareLifetimes.Services;
using System.Threading.Tasks;

namespace MiddlewareLifetimes.Middlewares
{
    /// <summary>
    /// Custom Middleware que mostrara por primera vez el id de la operación del servicio operation scoped
    /// </summary>
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        private readonly IOperationTransient _transientOperation;
        private readonly IOperationSingleton _singletonOperation;

        /// <summary>
        /// Crea una nueva instancia de CustomMiddleware
        /// </summary>
        /// <param name="next">A function that can process an HTTP request.</param>
        /// <param name="logger">Represents a type used to perform logging.</param>
        /// <param name="transientOperation">Transient Operation</param>
        /// <param name="singletonOperation">Singleton Operation</param>
        public CustomMiddleware(RequestDelegate next, ILogger<CustomMiddleware> logger, IOperationTransient transientOperation, IOperationSingleton singletonOperation)
        {
            this._logger = logger;
            this._transientOperation = transientOperation;
            this._singletonOperation = singletonOperation;
            this._next = next;
        }

        /// <summary>
        /// Representing the remaining middleware in the request pipeline.
        /// </summary>
        /// <param name="context">Encapsulates all HTTP-specific information about an individual HTTP request.</param>
        /// <param name="scopedOperation">Scoped Operation</param>
        /// <returns>Represents an asynchronous operation.</returns>
        public async Task InvokeAsync(HttpContext context, IOperationScoped scopedOperation)
        {
            this._logger.LogInformation("---------------------------------------------------------------");
            this._logger.LogInformation("Transient: " + _transientOperation.OperationId);
            this._logger.LogInformation("Scoped: " + scopedOperation.OperationId);
            this._logger.LogInformation("Singleton: " + _singletonOperation.OperationId);

            await _next(context);
        }
    }
}
