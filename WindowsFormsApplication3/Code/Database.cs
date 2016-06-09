using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Windows.Forms;
//using System.Web.Hosting;

namespace WindowsFormsApplication3.Code
{
    public class Database
    {
        #region Definiciones

        /// <summary>
        /// Lista de errores de las conexiones
        /// </summary>
        private List<DatabaseErrorContainer> ErrorLog = new List<DatabaseErrorContainer>();

        /// <summary>
        /// Cadena de conexion seleccionada
        /// </summary>
        private string ConnectionString;

        /// <summary>
        /// Tiempo limite de la conexion
        /// </summary>
        private int ConnectionTimeOut = 60 * 5;

        /// <summary>
        /// Tipo de base de datos seleccionada
        /// </summary>
        private DatabaseType SelectedDatabaseType = DatabaseType.Sybase;

        /// <summary>
        /// Tipo de base de datos
        /// </summary>
        public enum DatabaseType
        {
            Sybase,
            MSSSQLS,
            Oracle
        }

        private Hashtable emptyParameters = new Hashtable();

        #endregion

        #region Constructores

        /// <summary>
        /// Crear la instancia de conexion
        /// </summary>
        public Database()
        {
            this.ErrorLog.Clear();
            this.ConnectionString = "";
            this.SelectedDatabaseType = DatabaseType.MSSSQLS;
        }

        /// <summary>
        /// Crear la instancia con otra cadena de conexion
        /// </summary>
        /// <param name="connectionString">Nombre de la cadena de conexion, ingresada en la libreria Config</param>
        public Database(string connectionString)
        {
            this.ErrorLog.Clear();
            this.ConnectionString = connectionString;
            this.SelectedDatabaseType = DatabaseType.MSSSQLS;
        }

        /// <summary>
        /// Crear la instancia con otra cadena de conexion y con otro tipo de Base de datos
        /// </summary>
        /// <param name="connectionString">Cadena de conexión</param>
        /// <param name="databaseType">Sybase, MSSql, Oracle</param>
        public Database(string connectionString, DatabaseType databaseType)
        {
            this.ErrorLog.Clear();
            this.ConnectionString = connectionString;
            this.SelectedDatabaseType = databaseType;
        }

        #endregion

        #region Procedimientos almacenados

        public DataTable ExecuteProcedure(string procedure)
        {
            switch (SelectedDatabaseType)
            {
                case DatabaseType.MSSSQLS:
                    return ExecuteMSSQLSProcedure(procedure, new Hashtable(), DatabaseCache.Time.None);
                default:
                    return new DataTable();
            }
        }

        public DataTable ExecuteProcedure(string procedure, Hashtable parameters)
        {
            switch (SelectedDatabaseType)
            {
                case DatabaseType.MSSSQLS:
                    return ExecuteMSSQLSProcedure(procedure, parameters, DatabaseCache.Time.None);
                default:
                    return new DataTable();
            }
        }

        public DataTable ExecuteProcedure(string procedure, DatabaseCache.Time cacheDuration)
        {
            switch (SelectedDatabaseType)
            {
                case DatabaseType.MSSSQLS:
                    return ExecuteMSSQLSProcedure(procedure, new Hashtable(), cacheDuration);
                default:
                    return new DataTable();
            }
        }

        public DataTable ExecuteProcedure(string procedure, Hashtable Parameters, DatabaseCache.Time cacheDuration)
        {
            switch (SelectedDatabaseType)
            {
                case DatabaseType.MSSSQLS:
                    return ExecuteMSSQLSProcedure(procedure, Parameters, cacheDuration);
                default:
                    return new DataTable();
            }
        }

        private DataTable ExecuteMSSQLSProcedure(string procedure, Hashtable parameters, DatabaseCache.Time cacheDuration)
        {
            if (cacheDuration != DatabaseCache.Time.None)
            {
                DataTable Cache = DatabaseCache.Read(procedure, parameters);

                if (Cache != null)
                {
                    return Cache;
                }
            }

            SqlConnection Connection = new SqlConnection(this.ConnectionString);
            SqlCommand Command = new SqlCommand(procedure, Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.CommandTimeout = this.ConnectionTimeOut;

            foreach (DictionaryEntry Row in parameters)
            {
                try
                {
                    if (Row.Value.GetType().ToString() == typeof(float).ToString() ||
                        Row.Value.GetType().ToString() == typeof(Single).ToString())
                    {
                        Command.Parameters.Add(new SqlParameter(Row.Key.ToString(), SqlDbType.Decimal)).Value = Row.Value;
                    }
                    else if (Row.Value.GetType().ToString() == typeof(int).ToString())
                    {
                        Command.Parameters.Add(new SqlParameter(Row.Key.ToString(), SqlDbType.Int)).Value = Row.Value;
                    }
                    else if (Row.Value.GetType().ToString() == typeof(string).ToString())
                    {
                        Command.Parameters.Add(new SqlParameter(Row.Key.ToString(), SqlDbType.VarChar)).Value = Row.Value;
                    }
                    else if (Row.Value.GetType().ToString() == typeof(DateTime).ToString())
                    {
                        Command.Parameters.Add(new SqlParameter(Row.Key.ToString(), SqlDbType.DateTime)).Value = Row.Value;
                    }
                    else if (Row.Value.GetType().ToString() == typeof(Int64).ToString())
                    {
                        Command.Parameters.Add(new SqlParameter(Row.Key.ToString(), SqlDbType.Real)).Value = Row.Value;
                    }
                    else if (Row.Value.GetType().ToString() == typeof(byte[]).ToString())
                    {
                        Command.Parameters.Add(new SqlParameter(Row.Key.ToString(), SqlDbType.Image)).Value = Row.Value;
                    }

                    ErrorLog.Add(new DatabaseErrorContainer(string.Format("{0} ({1})", Row.Key.ToString(), Row.Value.GetType().ToString()), Row.Value.ToString()));
                }
                catch (Exception)
                {
                    Command.Parameters.Add(new SqlParameter(Row.Key.ToString(), DBNull.Value));
                    ErrorLog.Add(new DatabaseErrorContainer(string.Format("{0} ({1})", Row.Key.ToString(), "NULL"), "[NULL]"));
                }
            }

            SqlDataAdapter DataAdapter = new SqlDataAdapter(Command);
            DataTable Data = new DataTable();

            try
            {
                DataAdapter.Fill(Data);
            }
            catch (Exception Ex)
            {
                ShowError(Ex.Message, Command.CommandText);
                return new DataTable();
            }
            finally
            {
                DataAdapter.Dispose();
                Command.Dispose();
                Connection.Close();
            }

            if (cacheDuration != DatabaseCache.Time.None)
            {
                DatabaseCache.Create(procedure, parameters, Data, cacheDuration);
            }

            return (this.GetRowsCount(Data) > 0) ? Data : new DataTable();
        }

        #endregion

        #region Consultas SQL

        public DataTable ExecuteQuery(string query)
        {
            switch (SelectedDatabaseType)
            {
                case DatabaseType.MSSSQLS:
                    return ExecuteMSSQLSQuery(query, new Hashtable(), DatabaseCache.Time.None);
                default:
                    return new DataTable();
            }
        }

        public DataTable ExecuteQuery(string query, Hashtable parameters)
        {
            switch (SelectedDatabaseType)
            {
                case DatabaseType.MSSSQLS:
                    return ExecuteMSSQLSQuery(query, parameters, DatabaseCache.Time.None);
                default:
                    return new DataTable();
            }
        }

        public DataTable ExecuteQuery(string query, DatabaseCache.Time cacheDuration)
        {
            switch (SelectedDatabaseType)
            {
                case DatabaseType.MSSSQLS:
                    return ExecuteMSSQLSQuery(query, new Hashtable(), cacheDuration);
                default:
                    return new DataTable();
            }
        }

        public DataTable ExecuteQuery(string query, Hashtable parameters, DatabaseCache.Time cacheDuration)
        {
            switch (SelectedDatabaseType)
            {
                case DatabaseType.MSSSQLS:
                    return ExecuteMSSQLSQuery(query, parameters, cacheDuration);
                default:
                    return new DataTable();
            }
        }

        private DataTable ExecuteMSSQLSQuery(string query, Hashtable parameters, DatabaseCache.Time cacheDuration)
        {
            if (cacheDuration != DatabaseCache.Time.None)
            {
                DataTable Cache = DatabaseCache.Read(query, parameters);

                if (Cache != null)
                {
                    return Cache;
                }
            }

            SqlConnection Connection = new SqlConnection(this.ConnectionString);
            SqlCommand Command = new SqlCommand(query, Connection);
            Command.CommandType = CommandType.Text;
            Command.CommandTimeout = this.ConnectionTimeOut;

            #region Iteración de parámetros

            foreach (DictionaryEntry row in parameters)
            {
                try
                {
                    if (row.Value.GetType().ToString() == typeof(float).ToString() || row.Value.GetType().ToString() == typeof(Single).ToString())
                    {
                        Command.Parameters.Add(new SqlParameter(row.Key.ToString(), SqlDbType.Decimal)).Value = row.Value;
                    }
                    else if (row.Value.GetType().ToString() == typeof(int).ToString())
                    {
                        Command.Parameters.Add(new SqlParameter(row.Key.ToString(), SqlDbType.Int)).Value = row.Value;
                    }
                    else if (row.Value.GetType().ToString() == typeof(string).ToString())
                    {
                        Command.Parameters.Add(new SqlParameter(row.Key.ToString(), SqlDbType.VarChar)).Value = row.Value;
                    }
                    else if (row.Value.GetType().ToString() == typeof(DateTime).ToString())
                    {
                        Command.Parameters.Add(new SqlParameter(row.Key.ToString(), SqlDbType.DateTime)).Value = row.Value;
                    }
                    else if (row.Value.GetType().ToString() == typeof(Int64).ToString())
                    {
                        Command.Parameters.Add(new SqlParameter(row.Key.ToString(), SqlDbType.Real)).Value = row.Value;
                    }
                    else if (row.Value.GetType().ToString() == typeof(byte[]).ToString())
                    {
                        Command.Parameters.Add(new SqlParameter(row.Key.ToString(), SqlDbType.Image)).Value = row.Value;
                    }

                    ErrorLog.Add(new DatabaseErrorContainer(string.Format("{0} ({1})", row.Key.ToString(), row.Value.GetType().ToString()), row.Value.ToString()));

                }
                catch (Exception)
                {
                    Command.Parameters.Add(new SqlParameter(row.Key.ToString(), DBNull.Value));
                    ErrorLog.Add(new DatabaseErrorContainer(string.Format("{0} ({1})", row.Key.ToString(), "NULL"), "[NULL]"));
                }
            }

            #endregion

            SqlDataAdapter DataAdapter = new SqlDataAdapter(Command);
            DataTable Data = new DataTable();

            try
            {
                DataAdapter.Fill(Data);
            }
            catch (Exception Ex)
            {
                //ShowError(Ex.Message, Command.CommandText);
                MessageBox.Show(Ex.Message);
                return new DataTable();
            }
            finally
            {
                DataAdapter.Dispose();
                Command.Dispose();
                Connection.Close();
            }

            if (cacheDuration != DatabaseCache.Time.None)
            {
                DatabaseCache.Create(query, parameters, Data, cacheDuration);
            }                       

            return (this.GetRowsCount(Data) > 0) ? Data : new DataTable();
        }

        #endregion               

        //public bool CreateFromControlFields(string tableName, List<TableFieldControl> fields)
        //{
        //    return true;
        //}

        #region Miscelaneo

        private DataSet DataReaderToDataSet(IDataReader reader)
        {
            DataTable table = new DataTable();
            int fieldCount = reader.FieldCount;

            for (int i = 0; i < fieldCount; i++)
            {
                table.Columns.Add(reader.GetName(i), reader.GetFieldType(i));
            }

            table.BeginLoadData();
            object[] values = new object[fieldCount];

            while (reader.Read())
            {
                reader.GetValues(values);
                table.LoadDataRow(values, true);
            }

            table.EndLoadData();

            DataSet ds = new DataSet();
            ds.Tables.Add(table);
            reader.Close();

            return ds;
        }

        public string GetRow(DataTable data, string column)
        {
            return this.GetRow(data, column, 0);
        }

        public string GetRow(DataTable data, int column)
        {
            return this.GetRow(data, column, 0);
        }

        public string GetRow(DataTable data, string column, int row)
        {
            try
            {
                return data.Columns[0].Table.Rows[row][column].ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public string GetRow(DataTable data, int column, int row)
        {
            try
            {
                return data.Columns[0].Table.Rows[row][column].ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public byte[] GetRowAsBytes(DataTable data, string column, int row)
        {
            try
            {
                return (byte[])data.Columns[0].Table.Rows[row][column];
            }
            catch (Exception)
            {
                return (byte[])null;
            }
        }
        
        public int GetRowsCount(DataTable data)
        {
            try
            {
                return data.Columns[0].Table.Rows.Count;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool HasData(DataTable data)
        {
            return (data.Columns[0].Table.Rows.Count > 0) ? true : false;
        }

        public void ShowError()
        {
            ShowError("Error", "Descripcion");
        }

        public void ShowError(string Error, string Command)
        {
            //string ReturnError = string.Empty;
            //string PaginaError;

            //PaginaError = File.ReadAllText(
            //    HttpContext.Current.Server.MapPath(@"~/Views/Shared/ErrorPage.aspx"));

            //ReturnError += "<b>Descripción:</b><br>";
            //ReturnError += Error;
            //ReturnError += "<br><br><b>Sintaxis:</b><br>";
            //ReturnError += Command;
            //ReturnError += "<br><br><b>Detalles:</b><br>";

            //for (int i = 0; i < ErrorLog.Count; i++)
            //{
            //    ReturnError += string.Format("{0}: {1}<br>"
            //        , ErrorLog[i].Header
            //        , ErrorLog[i].ErrorText);
            //}

            //ReturnError += string.Format("<br><br><b>URL:</b> {0}<br>"
            //    , HttpContext.Current.Request.Url.ToString());
            //ReturnError += string.Format("<b>Cliente:</b> {0}<br>"
            //    , HttpContext.Current.Request.UserHostAddress);
            //ReturnError += string.Format("<b>Servidor:</b> {0}<br>"
            //    , HttpContext.Current.Server.MachineName);
            //ReturnError += string.Format("<b>Fecha:</b> {0} {1}"
            //    , DateTime.Now.ToShortTimeString()
            //    , DateTime.Now.ToShortDateString());

            //ReturnError = string.Format(PaginaError, ReturnError);
            //HttpContext.Current.Response.Write(ReturnError);
            //HttpContext.Current.Response.End();
        }

        #endregion
    }

    /// <summary>
    /// Clase para los cache de las llamadas a la base de datos
    /// </summary>
    public class DatabaseCache
    {
        /// <summary>
        /// Tiempo de duracion del cache
        /// </summary>
        public enum Time : int
        {
            /// <summary>
            /// Sin Cache
            /// </summary>
            None = 0,

            /// <summary>
            /// Cache valido por 5 minutos
            /// </summary>
            Low = 5,

            /// <summary>
            /// Cache valido por 30 minutos
            /// </summary>
            Medium = 30,

            /// <summary>
            /// Cache valido por 6 horas
            /// </summary>
            Hight = 60 * 6,

            /// <summary>
            /// Cache valido por 1 día
            /// </summary>
            Daily = 60 * 24,

            /// <summary>
            /// Cache valido por 1 semana
            /// </summary>
            Max = 60 * 24 * 7
        }

        /// <summary>
        /// Lee el cache para la llamada a la base de datos actual. 
        /// Retorna NULL en caso de no existir.
        /// </summary>
        /// <param name="Procedure">Nombre del procedimiento</param>
        /// <param name="Parameters">Parametros del procedimiento</param>
        public static DataTable Read(string Procedure, Hashtable Parameters)
        {
            //Strings Str = new Strings();
            //Procedure = Str.Md5Hash(Procedure);

            //double HashCode = (double)(Procedure.GetHashCode());

            //foreach (DictionaryEntry Row in Parameters)
            //{
            //    HashCode += Row.Key.GetHashCode() * Row.Value.ToString().GetHashCode();
            //}

            //DatabaseCacheSerializer Cache = new DatabaseCacheSerializer();
            //Stream stream;
            //BinaryFormatter formater = new BinaryFormatter(); ;

            //string FileName = string.Format(Config.CacheFile, Procedure, HashCode);
            //FileName = HostingEnvironment.MapPath(FileName);

            //try
            //{
            //    stream = File.Open(FileName, FileMode.Open);
            //    formater = new BinaryFormatter();
            //    Cache = (DatabaseCacheSerializer)formater.Deserialize(stream);
            //    stream.Close();
            //}
            //catch (Exception)
            //{
            //    return null;
            //}

            //if (Cache.CreateTime.AddMinutes((int)Cache.Duration) > DateTime.Now)
            //{
            //    return Cache.Data;
            //}

            //return null;

            return null;
        }

        /// <summary>
        /// Crear un cache de una llamada a la base de datos.
        /// </summary>
        /// <param name="procedure">Nombre del procedimiento</param>
        /// <param name="parameters">Parametros del procedimiento</param>
        /// <param name="data">Datos a grabar en el cache</param>
        /// <param name="duration">Duracion del cache generado</param>
        public static bool Create(string procedure, Hashtable parameters, DataTable data, Time duration)
        {
            //Strings Str = new Strings();
            //procedure = Str.Md5Hash(procedure);

            //double HashCode = (double)(procedure.GetHashCode());

            //foreach (DictionaryEntry Row in parameters)
            //{
            //    HashCode += Row.Key.GetHashCode() * Row.Value.ToString().GetHashCode();
            //}

            //string FileName = string.Format(Config.CacheFile, procedure, HashCode);
            //FileName = HostingEnvironment.MapPath(FileName);

            //DatabaseCacheSerializer Cache = new DatabaseCacheSerializer();
            //Cache.HashCode = HashCode;
            //Cache.Data = data;
            //Cache.Duration = duration;

            //Stream stream;
            //BinaryFormatter formater = new BinaryFormatter(); ;

            //try
            //{
            //    if (File.Exists(FileName))
            //    {
            //        File.Delete(FileName);
            //    }

            //    stream = File.Open(FileName, FileMode.CreateNew);
            //    formater.Serialize(stream, Cache);
            //    stream.Close();
            //}
            //catch (Exception)
            //{
            //    return false;
            //}

            //return true;
            return false;
        }

        /// <summary>
        /// Lee el cache para la llamada a la base de datos actual. 
        /// Retorna NULL en caso de no existir.
        /// </summary>
        /// <param name="Procedure">Nombre del procedimiento</param>
        /// <param name="Parameters">Parametros del procedimiento</param>
        public static byte[] ReadByte(string Procedure, Hashtable Parameters)
        {
            //Strings Str = new Strings();
            //Procedure = Str.Md5Hash(Procedure);

            //double HashCode = (double)(Procedure.GetHashCode());

            //foreach (DictionaryEntry Row in Parameters)
            //{
            //    HashCode += Row.Key.GetHashCode() * Row.Value.ToString().GetHashCode();
            //}

            //DatabaseCacheBytesSerializer cache = new DatabaseCacheBytesSerializer();
            //Stream stream;
            //BinaryFormatter formater = new BinaryFormatter(); ;

            //string FileName = string.Format(Config.CacheFile, Procedure, HashCode);
            //FileName = HostingEnvironment.MapPath(FileName);

            //try
            //{
            //    stream = File.Open(FileName, FileMode.Open);
            //    formater = new BinaryFormatter();
            //    cache = (DatabaseCacheBytesSerializer)formater.Deserialize(stream);
            //    stream.Close();
            //}
            //catch (Exception)
            //{
            //    return null;
            //}

            //if (cache.CreateTime.AddMinutes((int)cache.Duration) > DateTime.Now)
            //{
            //    return cache.Data;
            //}

            return null;
        }

        /// <summary>
        /// Crear un cache de una llamada a la base de datos.
        /// </summary>
        /// <param name="Procedure">Nombre del procedimiento</param>
        /// <param name="Parameters">Parametros del procedimiento</param>
        /// <param name="Data">Datos a grabar en el cache</param>
        /// <param name="Duration">Duracion del cache generado</param>
        public static bool CreateByte(string Procedure, Hashtable Parameters, byte[] Data, Time Duration)
        {
            //Strings Str = new Strings();

            //double HashCode = (double)(Procedure.GetHashCode());
            //Procedure = Str.Md5Hash(Procedure);

            //foreach (DictionaryEntry Row in Parameters)
            //{
            //    HashCode += Row.Key.GetHashCode() * Row.Value.ToString().GetHashCode();
            //}

            //string FileName = string.Format(Config.CacheFile, Procedure, HashCode);
            //FileName = HostingEnvironment.MapPath(FileName);

            //DatabaseCacheBytesSerializer cache = new DatabaseCacheBytesSerializer();
            //cache.HashCode = HashCode;
            //cache.Data = Data;
            //cache.Duration = Duration;

            //Stream stream;
            //BinaryFormatter formater = new BinaryFormatter(); ;

            //try
            //{
            //    if (File.Exists(FileName))
            //    {
            //        File.Delete(FileName);
            //    }

            //    stream = File.Open(FileName, FileMode.CreateNew);
            //    formater.Serialize(stream, cache);
            //    stream.Close();
            //}
            //catch (Exception)
            //{
            //    return false;
            //}

            //return true;
            return false;
        }

        /// <summary>
        /// Limpiar todo el cache de sitio
        /// </summary>
        public static void ClearAll()
        {
            //string cachePath = HostingEnvironment.MapPath(Config.CacheDir);

            //string[] files = Directory.GetFiles(
            //      cachePath
            //    , "*"
            //    , SearchOption.TopDirectoryOnly);

            //foreach (string file in files)
            //{
            //    File.Delete(file);
            //}
        }
    }

    [Serializable]
    public class DatabaseCacheBytesSerializer : ISerializable
    {
        public double HashCode;
        public byte[] Data;
        public DateTime CreateTime;
        public DatabaseCache.Time Duration;

        public DatabaseCacheBytesSerializer()
        {
            HashCode = 0;
            Data = null;
            CreateTime = DateTime.Now;
            Duration = DatabaseCache.Time.Low;
        }

        public DatabaseCacheBytesSerializer(SerializationInfo info, StreamingContext ctxt)
        {
            HashCode = (double)info.GetValue("HashCode", typeof(double));
            Data = (byte[])info.GetValue("Data", typeof(byte[]));
            CreateTime = (DateTime)info.GetValue("CreateTime", typeof(DateTime));
            Duration = (DatabaseCache.Time)info.GetValue("Duration", typeof(DatabaseCache.Time));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("HashCode", HashCode);
            info.AddValue("Data", Data);
            info.AddValue("CreateTime", CreateTime);
            info.AddValue("Duration", Duration);
        }
    }

    [Serializable]
    public class DatabaseCacheSerializer : ISerializable
    {
        public double HashCode;
        public DataTable Data;
        public DateTime CreateTime;
        public DatabaseCache.Time Duration;

        public DatabaseCacheSerializer()
        {
            HashCode = 0;
            Data = null;
            CreateTime = DateTime.Now;
            Duration = DatabaseCache.Time.Low;
        }

        public DatabaseCacheSerializer(SerializationInfo info, StreamingContext ctxt)
        {
            HashCode = (double)info.GetValue("HashCode", typeof(double));
            Data = (DataTable)info.GetValue("Data", typeof(DataTable));
            CreateTime = (DateTime)info.GetValue("CreateTime", typeof(DateTime));
            CreateTime = (DateTime)info.GetValue("CreateTime", typeof(DateTime));
            Duration = (DatabaseCache.Time)info.GetValue("Duration", typeof(DatabaseCache.Time));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("HashCode", HashCode);
            info.AddValue("Data", Data);
            info.AddValue("CreateTime", CreateTime);
            info.AddValue("Duration", Duration);
        }
    }

    /// <summary>
    /// Descripción breve de DataBaseError
    /// </summary>
    public class DatabaseErrorContainer
    {
        public string Header;
        public string ErrorText;

        public DatabaseErrorContainer(string Header, string ErrorText)
        {
            this.Header = Header;
            this.ErrorText = ErrorText;
        }
    }
}