using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsightFlow.Documents.Api.Core.Wrappers
{
    /// <summary>
    /// Estructura estándar para las respuestas de la API.
    /// </summary>
    /// <typeparam name="T">Tipo de dato que contiene la respuesta.</typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        /// Indica si la operación fue exitosa.
        /// </summary>
        /// <value></value>
        public bool Success { get; set; }
        /// <summary>
        /// Mensaje descriptivo de la respuesta.
        /// </summary>
        /// <value></value>
        public string Message { get; set; }
        /// <summary>
        /// Datos devueltos en la respuesta.
        /// </summary>
        /// <value></value>
        public T Data { get; set; }
        /// <summary>
        /// Lista de errores ocurridos durante la operación.
        /// </summary>
        /// <value></value>
        public List<string> Errors { get; set; }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        /// 
        public ApiResponse()
        {
        }
        /// <summary>
        /// Constructor para respuestas exitosas.
        /// </summary>
        /// <param name="data">Datos de la respuesta.</param>
        /// <param name="message">Mensaje opcional.</param>
        /// <returns>Una instancia de ApiResponse con éxito.</returns>
        public ApiResponse(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }
        /// <summary>
        /// Constructor para respuestas fallidas.
        /// </summary>
        /// <param name="message">Mensaje de error.</param>
        /// <param name="errors">Lista de errores detallados.</param>
        /// <returns>Una instancia de ApiResponse con error.</returns>
        public ApiResponse(string Message, List<string> errors = null)
        {
            Success = false;
            this.Message = Message;
            Errors = errors ?? new List<string>();
        }
    }
}