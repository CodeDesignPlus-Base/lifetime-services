using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiddlewareLifetimes.Services;

namespace MiddlewareLifetimes.Controllers
{
    /// <summary>
    /// Servicio principal de la aplicación
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IOperationTransient _transientOperation;
        private readonly IOperationSingleton _singletonOperation;
        private readonly IOperationScoped _scopedOperation;

        /// <summary>
        /// Crea una nueva instancia de HomeController
        /// </summary>
        /// <param name="logger">Represents a type used to perform logging.</param>
        /// <param name="transientOperation">Transient Operation</param>
        /// <param name="scopedOperation">Scoped Transient</param>
        /// <param name="singletonOperation">Singleton Transient</param>
        public HomeController(ILogger<HomeController> logger, IOperationTransient transientOperation, IOperationScoped scopedOperation, IOperationSingleton singletonOperation)
        {
            this._logger = logger;
            this._transientOperation = transientOperation;
            this._scopedOperation = scopedOperation;
            this._singletonOperation = singletonOperation;
        }

        /// <summary>
        /// Servicio encargado de retornar los identificadores de las operaciones
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            this._logger.LogInformation("Transient: " + this._transientOperation.OperationId);
            this._logger.LogInformation("Scoped: " + this._scopedOperation.OperationId);
            this._logger.LogInformation("Singleton: " + this._singletonOperation.OperationId);

            var result = new
            {
                transient = this._transientOperation.OperationId,
                scoped = this._scopedOperation.OperationId,
                singleton = this._singletonOperation.OperationId
            };

            return Ok(result);
        }

    }
}
