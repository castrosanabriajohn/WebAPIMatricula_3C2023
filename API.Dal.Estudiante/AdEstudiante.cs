using API.Bll.Estudiante.Interfaces;
using API.Dal.General;
using API.Dto.Estudiante.Salida;
using API.Dto.General;
using Microsoft.Extensions.Options;
using System.Data;

namespace API.Dal.Estudiante;

public class AdEstudiante : IAdEstudiante
{
    private readonly ConnectionManager _manager;

    public AdEstudiante(IOptions<AppSettings> oConfiguraciones)
    {
        _manager = new ConnectionManager(oConfiguraciones);
    }

    public VerTodosEstudiantes VerTodosEstudiantes()
    {
        IDbConnection oConexion = null;
        VerTodosEstudiantes resultado = new();

        oConexion = _manager.GetConnection();
        oConexion.Open();
        IDbCommand oComando = _manager.GetComando();

        try
        {
            IDataReader objDr = _manager.GetDataReader(oComando, oConexion, "dbo.Ver_Todos_Estudiantes");

            DatosEstudiante dato;

            while (objDr.Read())
            {
                dato = new DatosEstudiante
                {
                    Codigo = Convert.ToInt32(objDr["Codigo"].ToString()),
                    Identificacion = objDr["Identificacion"].ToString(),
                    NombreCompleto = objDr["NombreCompleto"].ToString(),
                    CorreoElectronico = objDr["CorreoElectronico"].ToString(),
                    Estado = objDr["Estado"].ToString()
                };

                resultado.ListaEstudiantes.Add(dato);
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

    public Dto.Estudiante.Salida.VerDetalleEstudiante VerDetalleEstudiante(Dto.Estudiante.Entrada.VerDetalleEstudiante pInformacion)
    {
        IDbConnection oConexion = null;
        API.Dto.Estudiante.Salida.VerDetalleEstudiante resultado = new API.Dto.Estudiante.Salida.VerDetalleEstudiante();

        oConexion = _manager.GetConnection();
        oConexion.Open();
        IDbCommand oComando = _manager.GetComando();

        try
        {
            oComando.Parameters.Add(_manager.GetParametro("@Codigo", pInformacion.Codigo));
            IDataReader objDr = _manager.GetDataReader(oComando, oConexion, "dbo.Ver_Detalle_Estudiante");

            if (objDr.Read())
            {
                resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                resultado.Identificacion = objDr["Identificacion"].ToString();
                resultado.NombreCompleto = objDr["NombreCompleto"].ToString();
                resultado.CorreoElectronico = objDr["CorreoElectronico"].ToString();
                resultado.Estado = objDr["Estado"].ToString();
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

    public Dto.Estudiante.Salida.EditarEstudiante EditarEstudiante(Dto.Estudiante.Entrada.EditarEstudiante pInformacion)
    {
        IDbConnection oConexion = null;
        IDbCommand oComando = _manager.GetComando();
        EditarEstudiante resultado = new();

        try
        {
            oConexion = _manager.GetConnection();
            oConexion.Open();

            oComando.Parameters.Add(_manager.GetParametro("@Codigo", pInformacion.Codigo));
            oComando.Parameters.Add(_manager.GetParametro("@Identificacion", pInformacion.Identificacion));
            oComando.Parameters.Add(_manager.GetParametro("@NombreCompleto", pInformacion.NombreCompleto));
            oComando.Parameters.Add(_manager.GetParametro("@CorreoElectronico", pInformacion.CorreoElectronico));
            oComando.Parameters.Add(_manager.GetParametro("@Estado", pInformacion.Estado));

            IDataReader objDr = _manager.GetDataReader(oComando, oConexion, "dbo.Editar_Estudiante");

            if (objDr.Read())
            {
                resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                resultado.Identificacion = objDr["Identificacion"].ToString();
                resultado.NombreCompleto = objDr["NombreCompleto"].ToString();
                resultado.CorreoElectronico = objDr["CorreoElectronico"].ToString();
                resultado.Estado = objDr["Estado"].ToString();
            }

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

    public AgregarEstudiante AgregarEstudiante(Dto.Estudiante.Entrada.AgregarEstudiante pInformacion)
    {
        IDbConnection oConexion = null;
        IDbCommand oComando = _manager.GetComando();
        AgregarEstudiante resultado = new();

        try
        {
            oConexion = _manager.GetConnection();
            oConexion.Open();

            oComando.Parameters.Add(_manager.GetParametro("@Identificacion", pInformacion.Identificacion));
            oComando.Parameters.Add(_manager.GetParametro("@NombreCompleto", pInformacion.NombreCompleto));
            oComando.Parameters.Add(_manager.GetParametro("@CorreoElectronico", pInformacion.CorreoElectronico));
            oComando.Parameters.Add(_manager.GetParametro("@Estado", pInformacion.Estado));

            IDataReader objDr = _manager.GetDataReader(oComando, oConexion, "dbo.Agregar_Estudiante");

            if (objDr.Read())
            {
                resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
            }
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

    public EliminarEstudiante EliminarEstudiante(Dto.Estudiante.Entrada.EliminarEstudiante pInformacion)
    {
        IDbConnection oConexion = null;
        IDbCommand oComando = _manager.GetComando();
        EliminarEstudiante resultado = new();

        try
        {
            oConexion = _manager.GetConnection();
            oConexion.Open();

            oComando.Parameters.Add(_manager.GetParametro("@Codigo", pInformacion.Codigo));

            IDataReader objDr = _manager.GetDataReader(oComando, oConexion, "dbo.Eliminar_Estudiante");
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
