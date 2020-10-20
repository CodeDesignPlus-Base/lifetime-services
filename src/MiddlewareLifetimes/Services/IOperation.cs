namespace MiddlewareLifetimes.Services
{
    /// <summary>
    /// Representa una tarea como una operación con un identificador
    /// </summary>
    public interface IOperation
    {
        /// <summary>
        /// Gets the operation id
        /// </summary>
        string OperationId { get; }
    }
}