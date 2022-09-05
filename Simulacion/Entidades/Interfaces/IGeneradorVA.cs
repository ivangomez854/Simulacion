using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Entidades.Interfaces
{
    internal interface IGeneradorVA
    {
        /// <summary>
        /// Metodo que retorna una lista de variables aleatorias
        /// </summary>
        /// <param name="cantidad">Numero de variables aleatorias a generar y devolver en el listado</param>
        /// <param name="listaCompletar">Lista opcional. Si se recibe una lista de variables aleatorias, las nuevas variables se agregan al final de la misma.
        /// Esto permite procesar grandes volumenes de generacion por segmentos.</param>
        /// <returns></returns>
        LinkedList<VariableAleatoria> generarListaVA(double cantidad, [Optional] LinkedList<VariableAleatoria> listaCompletar);
        /// <summary>
        /// Metodo que retorna la ultima variable aleatoria generada.
        /// </summary>
        /// <returns></returns>
        VariableAleatoria ObtenerEstadoActual();
    }
}
