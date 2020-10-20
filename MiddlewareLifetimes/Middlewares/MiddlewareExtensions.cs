using Microsoft.AspNetCore.Builder;

namespace MiddlewareLifetimes.Middlewares
{
    /// <summary>
    /// Clase que expone metodos de extensión para la administración de los middleware personalizados
    /// </summary>
    public static class MiddlewareExtensions
    {
        /// <summary>
        /// Metodo de extensión encargado de registrar el middleware <see cref="CustomMiddleware"/>
        /// </summary>
        /// <param name="builder">The Microsoft.AspNetCore.Builder.IApplicationBuilder instance.</param>
        /// <returns>The Microsoft.AspNetCore.Builder.IApplicationBuilder instance.</returns>
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}
