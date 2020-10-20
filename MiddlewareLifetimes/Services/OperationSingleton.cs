using System;

namespace MiddlewareLifetimes.Services
{
    /// <summary>
    /// Implementación de la logica de una operación
    /// </summary>
    public class OperationSingleton : IOperationSingleton
    {
        /// <summary>
        /// Id de la operación
        /// </summary>
        public string OperationId { get; }

        /// <summary>
        /// Crea una nueva instancia de Operation
        /// </summary>
        public OperationSingleton()
        {
            this.OperationId = Guid.NewGuid().ToString()[^4..];
        }
    }
}
