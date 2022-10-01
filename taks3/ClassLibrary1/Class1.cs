using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {
        public SqlConnection con;
        public void connection()
        {
            string str = @"Data Source=DESKTOP-GI21EV1\SQLEXPRESS; Initial Catalog=Internship1; Integrated Security=true;";
            con = new SqlConnection(str);

        }

        public DataSet selectData()
        {
            con.Open();
            string query = "select * from condoctor";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqlDataAdapter.Fill(ds);
            //var temp = ds.Tables[0].AsEnumerable().ToList();
            con.Close();
            return ds;

        }

        public void insertData(int id, string name, string route)
        {
            con.Open();
            string query = "insert into condoctor (c_id,c_name,bus_route) values('" + id + "','" + name + "','" + route + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.SelectCommand.ExecuteNonQuery();
            con.Close();
        }

        public void updateData(int id, string name, string route)
        {
            con.Open();
            string query = "update condoctor set c_name='"+name+"',bus_route='"+route+"' where c_id='"+id+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            sqlDataAdapter.SelectCommand.ExecuteNonQuery();
            con.Close();
        }

        public void deleteData(int id)
        {
            con.Open();
            string query = "delete from condoctor where c_id='"+id+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            sqlDataAdapter.SelectCommand.ExecuteNonQuery();
            con.Close();
        }
    }
}
