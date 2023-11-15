using API.Bll.Beca.Interfaces;
using API.Dal.General;
using API.Dto.Beca.Salida;
using API.Dto.General;
using Microsoft.Extensions.Options;
using System.Data;

namespace API.Dal.Beca;

public class AdBeca : IAdBeca
{
    private readonly ConnectionManager _manager;

    public AdBeca(IOptions<AppSettings> oConfiguraciones)
    {
        _manager = new ConnectionManager(oConfiguraciones);
    }

    public VerTodasBecas VerTodasBecas()
    {
        IDbConnection oConexion = null;
        VerTodasBecas resultado = new();

        oConexion = _manager.GetConnection();
        oConexion.Open();
        IDbCommand oComando = _manager.GetComando();

        try
        {
            IDataReader objDr = _manager.GetDataReader(oComando, oConexion, "dbo.Ver_Todas_Becas");

            DatosBeca dato;

            while (objDr.Read())
            {
                dato = new DatosBeca
                {
                    Codigo = Convert.ToInt32(objDr["Codigo"].ToString()),
                    Tipo = objDr["Tipo"].ToString(),
                    NombreEstudiante = objDr["NombreEstudiante"].ToString(),
                    NombreCurso = objDr["NombreCurso"].ToString(),
                    CodigoUsuarioCrea = Convert.ToInt32(objDr["CodigoUsuarioCrea"].ToString()),
                    Porcentaje = Convert.ToInt32(objDr["Porcentaje"].ToString()),
                    AnhoAcademico = Convert.ToInt32(objDr["AnhoAcademico"].ToString()),
                    Monto = Convert.ToDecimal(objDr["Monto"].ToString()),
                    Comentario = objDr["Comentario"].ToString(),
                    Estado = objDr["Estado"].ToString()
                };

                resultado.ListaBecas.Add(dato);
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

    public VerDetalleBeca VerDetalleBeca(Dto.Beca.Entrada.VerDetalleBeca pInformacion)
    {
        IDbConnection oConexion = null;
        VerDetalleBeca resultado = new();

        oConexion = _manager.GetConnection();
        oConexion.Open();
        IDbCommand oComando = _manager.GetComando();

        try
        {
            oComando.Parameters.Add(_manager.GetParametro("@Codigo", pInformacion.Codigo));
            IDataReader objDr = _manager.GetDataReader(oComando, oConexion, "dbo.Ver_Detalle_Beca");

            if (objDr.Read())
            {
                resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                resultado.Tipo = objDr["Tipo"].ToString();
                resultado.NombreEstudiante = objDr["NombreEstudiante"].ToString();
                resultado.NombreCurso = objDr["NombreCurso"].ToString();
                resultado.CodigoUsuarioCrea = Convert.ToInt32(objDr["CodigoUsuarioCrea"].ToString());
                resultado.Porcentaje = Convert.ToInt32(objDr["Porcentaje"].ToString());
                resultado.AnhoAcademico = Convert.ToInt32(objDr["AnhoAcademico"].ToString());
                resultado.Monto = Convert.ToDecimal(objDr["Monto"].ToString());
                resultado.Comentario = objDr["Comentario"].ToString();
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

    public EditarBeca EditarBeca(Dto.Beca.Entrada.EditarBeca pInformacion)
    {
        IDbConnection oConexion = null;
        IDbCommand oComando = _manager.GetComando();
        EditarBeca resultado = new();

        try
        {
            oConexion = _manager.GetConnection();
            oConexion.Open();

            oComando.Parameters.Add(_manager.GetParametro("@Codigo", pInformacion.Codigo));
            oComando.Parameters.Add(_manager.GetParametro("@CodigoEstudiante", pInformacion.CodigoEstudiante));
            oComando.Parameters.Add(_manager.GetParametro("@CodigoCurso", pInformacion.CodigoCurso));
            oComando.Parameters.Add(_manager.GetParametro("@CodigoUltimoUsuarioModifica", pInformacion.CodigoUltimoUsuarioModifica));
            oComando.Parameters.Add(_manager.GetParametro("@Tipo", pInformacion.Tipo));
            oComando.Parameters.Add(_manager.GetParametro("@Porcentaje", pInformacion.Porcentaje));
            oComando.Parameters.Add(_manager.GetParametro("@Monto", pInformacion.Monto));
            oComando.Parameters.Add(_manager.GetParametro("@AnhoAcademico", pInformacion.AnhoAcademico));
            oComando.Parameters.Add(_manager.GetParametro("@Estado", pInformacion.Estado));
            oComando.Parameters.Add(_manager.GetParametro("@Comentario", pInformacion.Comentario));

            IDataReader objDr = _manager.GetDataReader(oComando, oConexion, "dbo.Editar_Beca");

            if (objDr.Read())
            {
                resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                resultado.CodigoEstudiante = Convert.ToInt32(objDr["CodigoEstudiante"].ToString());
                resultado.CodigoCurso = Convert.ToInt32(objDr["CodigoCurso"].ToString());
                resultado.CodigoUltimoUsuarioModifica = Convert.ToInt32(objDr["CodigoUltimoUsuarioModifica"].ToString());
                resultado.Tipo = objDr["Tipo"].ToString();
                resultado.Porcentaje = Convert.ToInt32(objDr["Porcentaje"].ToString());
                resultado.AnhoAcademico = Convert.ToInt32(objDr["AnhoAcademico"].ToString());
                resultado.Monto = Convert.ToDecimal(objDr["Monto"].ToString());
                resultado.Comentario = objDr["Comentario"].ToString();
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

    public AgregarBeca AgregarBeca(Dto.Beca.Entrada.AgregarBeca pInformacion)
    {
        IDbConnection oConexion = null;
        IDbCommand oComando = _manager.GetComando();
        AgregarBeca resultado = new();

        try
        {
            oConexion = _manager.GetConnection();
            oConexion.Open();

            oComando.Parameters.Add(_manager.GetParametro("@Tipo", pInformacion.Tipo));
            oComando.Parameters.Add(_manager.GetParametro("@CodigoEstudiante", pInformacion.CodigoEstudiante));
            oComando.Parameters.Add(_manager.GetParametro("@CodigoCurso", pInformacion.CodigoCurso));
            oComando.Parameters.Add(_manager.GetParametro("@CodigoUsuarioCrea", pInformacion.CodigoUsuarioCrea));
            oComando.Parameters.Add(_manager.GetParametro("@Porcentaje", pInformacion.Porcentaje));
            oComando.Parameters.Add(_manager.GetParametro("@AnhoAcademico", pInformacion.AnhoAcademico));
            oComando.Parameters.Add(_manager.GetParametro("@Monto", pInformacion.Monto));
            oComando.Parameters.Add(_manager.GetParametro("@Comentario", pInformacion.Comentario));
            oComando.Parameters.Add(_manager.GetParametro("@Estado", pInformacion.Estado));

            IDataReader objDr = _manager.GetDataReader(oComando, oConexion, "dbo.Agregar_Beca");

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

    public EliminarBeca EliminarBeca(Dto.Beca.Entrada.EliminarBeca pInformacion)
    {
        IDbConnection oConexion = null;
        IDbCommand oComando = _manager.GetComando();
        EliminarBeca resultado = new();

        try
        {
            oConexion = _manager.GetConnection();
            oConexion.Open();

            oComando.Parameters.Add(_manager.GetParametro("@Codigo", pInformacion.Codigo));

            IDataReader objDr = _manager.GetDataReader(oComando, oConexion, "dbo.Eliminar_Beca");
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
