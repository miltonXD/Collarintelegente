using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MySql.Data.MySqlClient;
using System.Data;

namespace arqui
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        string connString = "SERVER=localhost" + ";" +
         "DATABASE=mydb;" +
         "user=root;" +
         "password=arqui;";

        [WebMethod]
        public DataSet HelloWorld()
        {

            MySqlConnection cnMySQL = new MySqlConnection(connString);
            cnMySQL.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from persona", cnMySQL);
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

    }
}
