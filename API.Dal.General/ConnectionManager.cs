using API.Dto.General;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace API.Dal.General;

public class ConnectionManager
{
    protected int Timeout = 60;
    protected string BaseDatos = string.Empty;

    public ConnectionManager(IOptions<AppSettings> config)
    {
        //string connectionStringEncriptado = Encriptador.Encriptar("Server=L019010;Database=MatriculaULACIT_1C2022;Trusted_Connection=True;");
        //string connectionStringEncriptado = Encriptador.Encriptar("Server=tcp:server.database.windows.net,1433;Database=NombreBD;User ID=usuario@dominio.com@server;Password=Hola123*;Trusted_Connection=False;Encrypt=True;");

        BaseDatos = Encrypter.Decrypt(config.Value.BaseDatos);
    }

    public IDbConnection GetConnection()
    {
        return new SqlConnection(BaseDatos);
    }

    public IDbCommand GetComando(bool RequiereProcedimientoAlmacenado = true)
    {
        var sqlcommand = new SqlCommand();

        if (RequiereProcedimientoAlmacenado)
        {
            sqlcommand.CommandType = CommandType.StoredProcedure;
        }

        sqlcommand.CommandTimeout = Timeout;
        return sqlcommand;
    }

    public IDataReader GetDataReader(IDbCommand comando, IDbConnection conexion, string nombreProcedimientoAlmacenado)
    {
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = nombreProcedimientoAlmacenado;
        comando.Connection = conexion;

        try
        {
            return comando.ExecuteReader();
        }
        catch (SqlException)
        {
            CerrarConexion(conexion);
            throw;
        }

    }

    public void CerrarConexion(IDbConnection oConexion)
    {
        if (oConexion != null)
        {
            if (oConexion.State == ConnectionState.Open)
            {
                oConexion.Close();
            }
        }
    }

    public IDataParameter GetParametro(string oParametro, object oValor)
    {
        return new SqlParameter(oParametro, oValor);
    }

    public IDataParameter GetParametroOutPutApi(string parametro, DbType tipo, int tamano)
    {
        var oParametro = new SqlParameter(parametro, tipo) { Direction = ParameterDirection.Input, DbType = tipo };

        if (tamano != 0)
        {
            oParametro.Size = tamano;
        }

        return oParametro;
    }
}
