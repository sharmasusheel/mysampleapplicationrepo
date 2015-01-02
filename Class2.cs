using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Class2
    {
    }

    public class ClassDataBase
    {

        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt;

        public void insertdata(ClassProperty p)
        {
            cmd = new SqlCommand("insertdata", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@name",p.name );
            cmd.Parameters.AddWithValue("@stateid", p.stateid);
            cmd.Parameters.AddWithValue("@cityid", p.cityid);
            //cmd.Parameters.AddWithValue("@ghender",p.ghender);
            //cmd.Parameters.AddWithValue("@hobbies" , p.hobbies);
            sqlcon.Open();
            cmd.ExecuteNonQuery();
            sqlcon.Close();
        }

        public void updatedata(ClassProperty p)
        {
            cmd = new SqlCommand("updatedata", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            //  cmd.Parameters.AddWithValue("", p.name);
            cmd.Parameters.AddWithValue("@stateid", p.stateid);
            cmd.Parameters.AddWithValue("@cityid", p.cityid);
            //cmd.Parameters.AddWithValue("", p.ghender);
            //cmd.Parameters.AddWithValue("", p.hobbies);
            cmd.Parameters.AddWithValue("@id", p.id);
            sqlcon.Open();
            cmd.ExecuteNonQuery();
            sqlcon.Close();

        }
        public DataTable getcity(int id)
        {
            da = new SqlDataAdapter("getcity", sqlcon);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@id", id);
            dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public DataTable getstate()
        {
            da = new SqlDataAdapter("getstate", sqlcon);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable getalldata()
        {

            da = new SqlDataAdapter("getalldata", sqlcon);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public void deleteuser(ClassProperty p)
        {

            cmd = new SqlCommand("deleteuser", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", p.id);
            sqlcon.Open();
            cmd.ExecuteNonQuery();
            sqlcon.Close();


        }



    }
}