using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace MVCBarcounsil.Models
{
    public class common
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LawHelper;Integrated Security=True");
        public int Execute(string qry)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            int res = cmd.ExecuteNonQuery();
            return res;
        }


        public DataTable GetData(string qry)
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
             da.Fill(dt);
            return dt;
        }
    }
}