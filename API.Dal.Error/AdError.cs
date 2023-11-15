using API.Bll.Error.Interfaces;
using API.Dal.General;
using API.Dto.Error.Salida;
using API.Dto.General;
using Microsoft.Extensions.Options;
using System.Data;

namespace API.Dal.Error
{
    public class AdError : IAdError
    {
        private ConnectionManager _manager;
        public AdError(IOptions<AppSettings> oconfiguraciones)
        {
            _manager = new ConnectionManager(oconfiguraciones);
        }

        public VerTodosErrores VerTodosErrores()
        {
            IDbConnection oConexion = null;
            VerTodosErrores resultado = new();

            oConexion = _manager.GetConnection();
            oConexion.Open();
            IDbCommand oComando = _manager.GetComando();

            try
            {
                IDataReader objDr = _manager.GetDataReader(oComando, oConexion, "dbo.Ver_Todos_Errores");

                DatosError dato;

                while (objDr.Read())
                {
                    dato = new DatosError();
                    dato.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    dato.CodigoUsuario = Convert.ToInt32(objDr["CodigoUsuario"].ToString());
                    dato.FechaHora = Convert.ToDateTime(objDr["FechaHora"].ToString());
                    dato.Modulo = objDr["Modulo"].ToString();
                    dato.Clase = objDr["Clase"].ToString();
                    dato.Metodo = objDr["Metodo"].ToString();
                    dato.Fuente = objDr["Fuente"].ToString();
                    dato.Numero = Convert.ToInt32(objDr["Numero"].ToString());
                    dato.Excepcion = objDr["Exception"].ToString();

                    resultado.ListaErrores.Add(dato);
                }
            }
            catch (Exception)
            {
                _manager.CerrarConexion(oConexion);
            }
            finally
            {
                _manager.CerrarConexion(oConexion);
            }

            return resultado;
        }
        public Dto.Error.Salida.AgregarError AgregarError(Dto.Error.Entrada.AgregarError pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = _manager.GetComando();
            AgregarError resultado = new Dto.Error.Salida.AgregarError();

            try
            {
                oConexion = _manager.GetConnection();
                oConexion.Open();

                oComando.Parameters.Add(_manager.GetParametro("@CodigoUsuario", pInformacion.CodigoUsuario));
                oComando.Parameters.Add(_manager.GetParametro("@FechaHora", pInformacion.FechaHora));
                oComando.Parameters.Add(_manager.GetParametro("@Modulo", pInformacion.Modulo));
                oComando.Parameters.Add(_manager.GetParametro("@Clase", pInformacion.Clase));
                oComando.Parameters.Add(_manager.GetParametro("@Metodo", pInformacion.Metodo));
                oComando.Parameters.Add(_manager.GetParametro("@Fuente", pInformacion.Fuente));
                oComando.Parameters.Add(_manager.GetParametro("@Numero", pInformacion.Numero));
                oComando.Parameters.Add(_manager.GetParametro("@Exception", pInformacion.Exception));

                IDataReader objDr = _manager.GetDataReader(oComando, oConexion, "dbo.Agregar_Error");

                if (objDr.Read())
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());

            }
            catch (Exception ex)
            {
                resultado.DetalleRespuesta = ex.Message;
                _manager.CerrarConexion(oConexion);
            }
            finally
            {
                _manager.CerrarConexion(oConexion);
            }

            return resultado;
        }
    }
}
