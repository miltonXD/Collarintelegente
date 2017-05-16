using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MySql.Data.MySqlClient;
using System.Data;

[WebService(Namespace = "http://smartcollar")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]

public class Service : System.Web.Services.WebService
{

    string connString = "SERVER=localhost" + ";" +
          "DATABASE=mydb;" +
          "user=root;" +
          "password=arqui;";

    public Service () {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public DataSet HelloWorld() {
        
        MySqlConnection cnMySQL = new MySqlConnection(connString);
        cnMySQL.Open();
        MySqlDataAdapter da = new MySqlDataAdapter("select * from persona",cnMySQL);
        DataSet ds = new DataSet("persona");
        //da.FillSchema(ds,SchemaType.Source,"persona");
        da.Fill(ds, "persona");
        return ds;
    }

    [WebMethod]
    public String Fecha()
    {
        return DateTime.Today.ToString();
    }

    [WebMethod]
    public String nombre()
    {
        MySqlConnection cnMySQL = new MySqlConnection(connString);
        cnMySQL.Open();
        MySqlDataAdapter da = new MySqlDataAdapter("select * from persona", cnMySQL);
        DataSet ds = new DataSet("persona");
        //da.FillSchema(ds,SchemaType.Source,"persona");
        da.Fill(ds, "persona");
        return ds.Tables[0].Rows[0]["nombre"].ToString();
    }
    
}