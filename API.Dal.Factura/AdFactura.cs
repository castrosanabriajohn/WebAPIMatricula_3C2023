using API.Bll.Factura.Interfaces;
using API.Dal.General;
using API.Dto.Factura.Salida;
using API.Dto.General;
using Microsoft.Extensions.Options;
using System.Data;

namespace API.Dal.Factura;

public class AdFactura : IAdFactura
{
    private readonly ConnectionManager _manager;

    public AdFactura(IOptions<AppSettings> oConfiguraciones)
    {
        _manager = new ConnectionManager(oConfiguraciones);
    }

    public VerTodasFacturas VerTodasFacturas()
    {
        IDbConnection oConexion = null;
        VerTodasFacturas resultado = new();

        oConexion = _manager.GetConnection();
        oConexion.Open();
        IDbCommand oComando = _manager.GetComando();

        try
        {
            IDataReader objDr = _manager.GetDataReader(oComando, oConexion, "dbo.Ver_Todas_Facturas");

            DatosFactura dato;

            while (objDr.Read())
            {
                dato = new DatosFactura
                {
                    Codigo = Convert.ToInt32(objDr["Codigo"].ToString()),
                    NumeroReferencia = objDr["NumeroReferencia"].ToString(),
                    NombreEstudiante = objDr["NombreEstudiante"].ToString(),
                    NombreCurso = objDr["NombreCurso"].ToString(),
                    FechaPago = Convert.ToDateTime(objDr["FechaPago"].ToString()),
                    AnhoAcademico = Convert.ToInt32(objDr["AnhoAcademico"].ToString()),
                    Cuatrimestre = Convert.ToInt32(objDr["Cuatrimestre"].ToString()),
                    MontoTotal = Convert.ToDecimal(objDr["MontoTotal"].ToString()),
                    Estado = objDr["Estado"].ToString(),
                    Comentario = objDr["Comentario"].ToString(),
                };

                resultado.ListaFacturas.Add(dato);
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

    public VerDetalleFactura VerDetalleFactura(Dto.Factura.Entrada.VerDetalleFactura pInformacion)
    {
        IDbConnection oConexion = null;
        VerDetalleFactura resultado = new();

        oConexion = _manager.GetConnection();
        oConexion.Open();
        IDbCommand oComando = _manager.GetComando();

        try
        {
            oComando.Parameters.Add(_manager.GetParametro("@Codigo", pInformacion.Codigo));
            IDataReader objDr = _manager.GetDataReader(oComando, oConexion, "dbo.Ver_Detalle_Factura");

            if (objDr.Read())
            {
                resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                resultado.NumeroReferencia = objDr["NumeroReferencia"].ToString();
                resultado.NombreEstudiante = (objDr["NombreEstudiante"].ToString());
                resultado.NombreCurso = (objDr["NombreCurso"].ToString());
                resultado.CodigoUsuarioCrea = Convert.ToInt32(objDr["CodigoUsuarioCrea"].ToString());
                resultado.FechaPago = Convert.ToDateTime(objDr["FechaPago"].ToString());
                resultado.AnhoAcademico = Convert.ToInt32(objDr["AnhoAcademico"].ToString());
                resultado.Cuatrimestre = Convert.ToInt32(objDr["Cuatrimestre"].ToString());
                resultado.MontoTotal = Convert.ToDecimal(objDr["MontoTotal"].ToString());
                resultado.Estado = objDr["Estado"].ToString();
                resultado.Comentario = objDr["Comentario"].ToString();
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

    public EditarFactura EditarFactura(Dto.Factura.Entrada.EditarFactura pInformacion)
    {
        IDbConnection oConexion = null;
        IDbCommand oComando = _manager.GetComando();
        EditarFactura resultado = new();

        try
        {
            oConexion = _manager.GetConnection();
            oConexion.Open();

            oComando.Parameters.Add(_manager.GetParametro("@Codigo", pInformacion.Codigo));
            oComando.Parameters.Add(_manager.GetParametro("@NumeroReferencia", pInformacion.NumeroReferencia));
            oComando.Parameters.Add(_manager.GetParametro("@CodigoEstudiante", pInformacion.CodigoEstudiante));
            oComando.Parameters.Add(_manager.GetParametro("@CodigoCurso", pInformacion.CodigoCurso));
            oComando.Parameters.Add(_manager.GetParametro("@CodigoUltimoUsuarioModifica", pInformacion.CodigoUltimoUsuarioModifica));
            oComando.Parameters.Add(_manager.GetParametro("@FechaPago", pInformacion.FechaPago));
            oComando.Parameters.Add(_manager.GetParametro("@AnhoAcademico", pInformacion.AnhoAcademico));
            oComando.Parameters.Add(_manager.GetParametro("@Cuatrimestre", pInformacion.Cuatrimestre));
            oComando.Parameters.Add(_manager.GetParametro("@MontoTotal", pInformacion.MontoTotal));
            oComando.Parameters.Add(_manager.GetParametro("@Estado", pInformacion.Estado));
            oComando.Parameters.Add(_manager.GetParametro("@Comentario", pInformacion.Comentario));


            IDataReader objDr = _manager.GetDataReader(oComando, oConexion, "dbo.Editar_Factura");

            if (objDr.Read())
            {
                resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                resultado.NumeroReferencia = objDr["NumeroReferencia"].ToString();
                resultado.CodigoEstudiante = Convert.ToInt32(objDr["CodigoEstudiante"].ToString());
                resultado.CodigoCurso = Convert.ToInt32(objDr["CodigoCurso"].ToString());
                resultado.CodigoUltimoUsuarioModifica = Convert.ToInt32(objDr["CodigoUltimoUsuarioModifica"].ToString());
                resultado.FechaPago = Convert.ToDateTime(objDr["FechaPago"].ToString());
                resultado.AnhoAcademico = Convert.ToInt32(objDr["AnhoAcademico"].ToString());
                resultado.Cuatrimestre = Convert.ToInt32(objDr["Cuatrimestre"].ToString());
                resultado.MontoTotal = Convert.ToDecimal(objDr["MontoTotal"].ToString());
                resultado.Estado = objDr["Estado"].ToString();
                resultado.Comentario = objDr["Comentario"].ToString();
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

    public AgregarFactura AgregarFactura(Dto.Factura.Entrada.AgregarFactura pInformacion)
    {
        IDbConnection oConexion = null;
        IDbCommand oComando = _manager.GetComando();
        AgregarFactura resultado = new();

        try
        {
            oConexion = _manager.GetConnection();
            oConexion.Open();

            oComando.Parameters.Add(_manager.GetParametro("@NumeroReferencia", pInformacion.NumeroReferencia));
            oComando.Parameters.Add(_manager.GetParametro("@CodigoEstudiante", pInformacion.CodigoEstudiante));
            oComando.Parameters.Add(_manager.GetParametro("@CodigoCurso", pInformacion.CodigoCurso));
            oComando.Parameters.Add(_manager.GetParametro("@CodigoUsuarioCrea", pInformacion.CodigoUsuarioCrea));
            oComando.Parameters.Add(_manager.GetParametro("@FechaPago", pInformacion.FechaPago));
            oComando.Parameters.Add(_manager.GetParametro("@AnhoAcademico", pInformacion.AnhoAcademico));
            oComando.Parameters.Add(_manager.GetParametro("@Cuatrimestre", pInformacion.Cuatrimestre));
            oComando.Parameters.Add(_manager.GetParametro("@MontoTotal", pInformacion.MontoTotal));
            oComando.Parameters.Add(_manager.GetParametro("@Estado", pInformacion.Estado));
            oComando.Parameters.Add(_manager.GetParametro("@Comentario", pInformacion.Comentario));

            IDataReader objDr = _manager.GetDataReader(oComando, oConexion, "dbo.Agregar_Factura");

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

    public EliminarFactura EliminarFactura(Dto.Factura.Entrada.EliminarFactura pInformacion)
    {
        IDbConnection oConexion = null;
        IDbCommand oComando = _manager.GetComando();
        EliminarFactura resultado = new();

        try
        {
            oConexion = _manager.GetConnection();
            oConexion.Open();

            oComando.Parameters.Add(_manager.GetParametro("@Codigo", pInformacion.Codigo));

            IDataReader objDr = _manager.GetDataReader(oComando, oConexion, "dbo.Eliminar_Factura");
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
