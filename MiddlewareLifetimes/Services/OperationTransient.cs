using System;

namespace MiddlewareLifetimes.Services
{
    /// <summary>
    /// Implementación de la logica de una operación
    /// </summary>
    public class OperationTransient : IOperationTransient
    {
        /// <summary>
        /// Id de la operación
        /// </summary>
        public string OperationId { get; }

        /// <summary>
        /// Crea una nueva instancia de Operation
        /// </summary>
        public OperationTransient()
        {
            this.OperationId = Guid.NewGuid().ToString()[^4..];
        }
    }
}
