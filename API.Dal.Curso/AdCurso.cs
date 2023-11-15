using API.Bll.Curso.Interfaces;
using API.Dal.General;
using API.Dto.Curso.Salida;
using API.Dto.General;
using Microsoft.Extensions.Options;
using System.Data;

namespace API.Dal.Curso;

public class AdCurso : IAdCurso
{
    private readonly ConnectionManager _manager;

    public AdCurso(IOptions<AppSettings> oConfiguraciones) => _manager = new ConnectionManager(oConfiguraciones);

    public Dto.Curso.Salida.VerTodosCursos VerTodosCursos()
    {
        IDbConnection oConexion = null;
        VerTodosCursos resultado = new();

        oConexion = _manager.GetConnection();
        oConexion.Open();
        IDbCommand oComando = _manager.GetComando();

        try
        {
            IDataReader objDr = _manager.GetDataReader(oComando, oConexion, "dbo.Ver_Todos_Cursos");

            DatosCurso dato;

            while (objDr.Read())
            {
                dato = new DatosCurso();
                dato.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                dato.Nombre = objDr["Nombre"].ToString();
                dato.Creditos = Convert.ToInt32(objDr["Creditos"].ToString());
                dato.Horario = objDr["Horario"].ToString();
                dato.Cupo = Convert.ToInt32(objDr["Cupo"].ToString());
                dato.Estado = objDr["Estado"].ToString();

                resultado.ListaCursos.Add(dato);
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

    public VerDetalleCurso VerDetalleCurso(Dto.Curso.Entrada.VerDetalleCurso pInformacion)
    {
        IDbConnection oConexion = null;
        VerDetalleCurso resultado = new API.Dto.Curso.Salida.VerDetalleCurso();

        oConexion = _manager.GetConnection();
        oConexion.Open();
        IDbCommand oComando = _manager.GetComando();

        try
        {
            oComando.Parameters.Add(_manager.GetParametro("@Codigo", pInformacion.Codigo));
            IDataReader objDr = _manager.GetDataReader(oComando, oConexion, "dbo.Ver_Detalle_Curso");

            if (objDr.Read())
            {
                resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                resultado.Nombre = objDr["Nombre"].ToString();
                resultado.Creditos = Convert.ToInt32(objDr["Creditos"].ToString());
                resultado.Horario = objDr["Horario"].ToString();
                resultado.Cupo = Convert.ToInt32(objDr["Cupo"].ToString());
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

    public EditarCurso EditarCurso(Dto.Curso.Entrada.EditarCurso pInformacion)
    {
        IDbConnection oConexion = null;
        IDbCommand oComando = _manager.GetComando();
        EditarCurso resultado = new();

        try
        {
            oConexion = _manager.GetConnection();
            oConexion.Open();

            oComando.Parameters.Add(_manager.GetParametro("@Codigo", pInformacion));
            oComando.Parameters.Add(_manager.GetParametro("@Nombre", pInformacion.Nombre));
            oComando.Parameters.Add(_manager.GetParametro("@Creditos", pInformacion.Creditos));
            oComando.Parameters.Add(_manager.GetParametro("@Horario", pInformacion.Horario));
            oComando.Parameters.Add(_manager.GetParametro("@Cupo", pInformacion.Cupo));
            oComando.Parameters.Add(_manager.GetParametro("@Estado", pInformacion.Estado));

            IDataReader objDr = _manager.GetDataReader(oComando, oConexion, "dbo.Editar_Curso");

            if (objDr.Read())
            {
                resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                resultado.Nombre = objDr["Nombre"].ToString();
                resultado.Creditos = Convert.ToInt32(objDr["Creditos"].ToString());
                resultado.Cupo = Convert.ToInt32(objDr["Cupo"].ToString());
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

    public AgregarCurso AgregarCurso(Dto.Curso.Entrada.AgregarCurso pInformacion)
    {
        IDbConnection oConexion = null;
        IDbCommand oComando = _manager.GetComando();
        AgregarCurso resultado = new();

        try
        {
            oConexion = _manager.GetConnection();
            oConexion.Open();

            oComando.Parameters.Add(_manager.GetParametro("@Nombre", pInformacion.Nombre));
            oComando.Parameters.Add(_manager.GetParametro("@Creditos", pInformacion.Creditos));
            oComando.Parameters.Add(_manager.GetParametro("@Horario", pInformacion.Horario));
            oComando.Parameters.Add(_manager.GetParametro("@Cupo", pInformacion.Cupo));
            oComando.Parameters.Add(_manager.GetParametro("@Estado", pInformacion.Estado));

            IDataReader objDr = _manager.GetDataReader(oComando, oConexion, "dbo.Agregar_Curso");

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

    public EliminarCurso EliminarCurso(Dto.Curso.Entrada.EliminarCurso pInformacion)
    {
        IDbConnection oConexion = null;
        IDbCommand oComando = _manager.GetComando();
        EliminarCurso resultado = new();

        try
        {
            oConexion = _manager.GetConnection();
            oConexion.Open();

            oComando.Parameters.Add(_manager.GetParametro("@Codigo", pInformacion.Codigo));

            IDataReader objDr = _manager.GetDataReader(oComando, oConexion, "dbo.Eliminar_Curso");
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
