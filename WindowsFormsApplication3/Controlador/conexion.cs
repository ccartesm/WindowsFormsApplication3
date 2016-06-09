using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApplication3.Controlador
{
    class conexion
    {
        //static public void leer(Modelos.Animal vaca)
        //{

        //    SqlConnection conn = new SqlConnection();
        //    SqlCommand cmd = new SqlCommand();
        //    SqlDataReader dr;
        //    string mens = null;
        //    bool estBD = true;
        //    bool estOP = true;

        //    //conn.ConnectionString = "Server=pmt_lab0414;Database=pro2013;User Id=sa;Password=jt357;";
        //    conn.ConnectionString = "Server = cgyo-PC; Database = bdganaderia; Trusted_Connection = True;";
        //    cmd.Connection = conn;

        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = "select id_vaca, tipo_vaca, fech_nac_vaca, origen_vaca, gen_vaca, comentario_vaca,  from Vaca where id_vaca = " + vaca.Diio;
        //    //cmd.CommandType = CommandType.StoredProcedure;
        //    //cmd.CommandText = "SUC_Leer";
        //    //cmd.Parameters.AddWithValue("@Codigo", vaca.Codigo);

        //    try
        //    {
        //        conn.Open();

        //        dr = cmd.ExecuteReader();

        //        if (dr.Read() == true)
        //        {
        //            vaca.Nombre = dr.GetString(1);
        //            vaca.Direccion = dr.GetString(2);
        //            estOP = true;
        //        }
        //        else
        //        {
        //            vaca.Nombre = null;
        //            vaca.Direccion = null;
        //            estOP = false;
        //        }
        //        estBD = true;
        //    }

        //    catch (SqlException ex)
        //    {
        //        mens = ex.Message;
        //        estBD = false;
        //    }

        //    finally
        //    {
        //        cmd.Dispose();
        //        conn.Close();
        //    }

        //    vaca.EstadoBD = estBD;
        //    vaca.MensajeBD = mens;
        //    vaca.EstadoOP = estOP;
        //}

        //static public int eliminarSucursal(Modelos.Animal vaca)
        //{

        //    SqlConnection conn = new SqlConnection();
        //    SqlCommand cmd = new SqlCommand();
        //    String sql;

        //    conn.ConnectionString = "Server=pmt_lab0414;Database=pro2013;User Id=sa;Password=jt357;";
        //    cmd.Connection = conn;

        //    //cmd.CommandType = CommandType.Text; //De que tipo es el comando
        //    //sql = "delete from sucursal where codigo=" + sucur.Codigo;
        //    //cmd.CommandText = sql;

        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "SUC_Eliminar";
        //    cmd.Parameters.AddWithValue("@Codigo", vaca.Codigo);


        //    conn.Open();

        //    int filas = cmd.ExecuteNonQuery();

        //    cmd.Dispose();
        //    conn.Close();

        //    return filas;
        //}

        //static public int ingresarAnimal(Modelos.Animal vaca)
        //{
        //    SqlConnection conn = new SqlConnection();
        //    SqlCommand cmd = new SqlCommand();
        //    String sql;

        //    //conn.ConnectionString = "Server=pmt_lab0414;Database=pro2013;User Id=sa;Password=jt357;";
        //    //conn.ConnectionString = "Server = cgyo-PC; Database = bdganaderia; Trusted_Connection = True;";
        //    //conn.ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\cgyo\Documents\bdganaderia.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
        //    //cmd.Connection = conn;

        //    //sql = "insert into Vaca values (" + vaca.Diio + ",'";
        //    //sql = sql + vaca.Tipo + "','";
        //    //sql = sql + vaca.FechaNac + "','";
        //    //sql = sql + vaca.Origen + "','";
        //    //sql = sql + vaca.Genetica + "','";
        //    //sql = sql + vaca.Comentario + "','";
        //    //sql = sql + vaca.FechaIngreso + "','";
        //    //sql = sql + vaca.Peso + "')";

        //    ////cmd.CommandType = CommandType.Text;
        //    ////cmd.CommandText = sql;

        //    //cmd.CommandType = CommandType.StoredProcedure;
        //    //cmd.CommandText = "SUC_Grabar";
        //    //cmd.Parameters.AddWithValue("@Codigo", vaca.Diio);
        //    //cmd.Parameters.AddWithValue("@Nombre", vaca.Tipo);
        //    //cmd.Parameters.AddWithValue("@Direccion", vaca.FechaNac);
        //    //cmd.Parameters.AddWithValue("@Nombre", vaca.Origen);
        //    //cmd.Parameters.AddWithValue("@Nombre", vaca.Genetica);
        //    //cmd.Parameters.AddWithValue("@Nombre", vaca.Comentario);
        //    //cmd.Parameters.AddWithValue("@Nombre", vaca.FechaIngreso);
        //    //cmd.Parameters.AddWithValue("@Nombre", vaca.Peso);

        //    conn.Open();

        //    int filas = cmd.ExecuteNonQuery();

        //    cmd.Dispose();
        //    conn.Close();

        //    return filas;
        //}

        //static public int actualizarSucursal(Modelos.Animal vaca)
        //{
        //    SqlConnection conn = new SqlConnection();
        //    SqlCommand cmd = new SqlCommand();
        //    String sql;

        //    conn.ConnectionString = "Server=pmt_lab0414;Database=pro2013;User Id=sa;Password=jt357;";

        //    cmd.Connection = conn;
        //    //cmd.CommandType = CommandType.Text;

        //    sql = "update sucursal set nombre ='" + vaca.Nombre;
        //    sql = sql + "',direccion='" + vaca.Direccion;
        //    sql = sql + "'where codigo = " + vaca.Codigo;

        //    //cmd.CommandText = sql;

        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "SUC_Actualizar";
        //    cmd.Parameters.AddWithValue("@Nombre", vaca.Nombre);
        //    cmd.Parameters.AddWithValue("@Codigo", vaca.Codigo);
        //    cmd.Parameters.AddWithValue("@Direccion", vaca.Direccion);

        //    conn.Open();

        //    int filas = cmd.ExecuteNonQuery();

        //    cmd.Dispose();
        //    conn.Close();

        //    return filas;
        //}

        //static public List<Modelos.Animal> listaSuc()
        //{

        //    SqlConnection conn = new SqlConnection();
        //    SqlCommand cmd = new SqlCommand();
        //    SqlDataReader dr;
        //    List<Sucursal> lista = new List<Sucursal>();

        //    conn.ConnectionString =

        //    "Server=pmt_lab0414;Database=pro2013;User Id=sa;Password=jt357;";

        //    cmd.Connection = conn;
        //    cmd.CommandType =
        //    CommandType.Text;
        //    cmd.CommandText = "SELECT codigo,nombre,direccion FROM sucursal ";
        //    conn.Open();
        //    dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        Sucursal suc = new Sucursal();
        //        suc.Codigo = dr.GetInt32(0);
        //        suc.Nombre = dr.GetString(1);
        //        suc.Direccion = dr.GetString(2);
        //        lista.Add(suc);
        //    }
        //    cmd.Dispose();
        //    conn.Close();
        //    return lista;



        //}


    }


    
}
