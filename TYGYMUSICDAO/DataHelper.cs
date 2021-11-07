using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace TYGYMUSICDAO
{
	public class DataHelper
	{
        string stcon;
        SqlConnection con;
        public DataHelper(string conStr)
        {
            this.stcon = conStr;
            con = new SqlConnection(conStr);
        }
        public DataHelper()
        {
            stcon = "Data Source=LAPTOP-R9I0TVIS;Initial Catalog=TYGYMusic;Integrated Security=True";
            con = new SqlConnection(stcon);
        }
        public string Open()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                return "";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public void Close()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        public SqlDataReader ExcuteReader(string sqlSelect)
        {
            string st = Open();
            if (st != "")
                throw new Exception(st);
            SqlCommand cm = new SqlCommand(sqlSelect, con);
            SqlDataReader dr = cm.ExecuteReader();
            return dr;
        }
        public void ExcuteNonQuery(string sql)
        {
            Open();
            SqlCommand cm = new SqlCommand(sql, con);
            cm.ExecuteNonQuery();
            Close();
        }
        /// <summary>
		/// Method to get database by SQLDataAdapter
		/// </summary>
		/// <param name="sql">select sql statement</param>
		/// <returns> data table contain records</returns>
		public DataTable FillDataTable(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, stcon);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void UpdateRow(DataTable dt, string dk, params object[] values)
        {
            //b1: Loc ra cac ban ghi can sua
            DataView dv = FillRow(dt, dk);
            dv.AllowEdit = true;
            //b2: Sua
            if (dv.Count > 0)
            {
                for (int i = 0; i < values.Length; i++)
                    dv[0][i] = values[i];
            }
        }
        public void DeleteRow(DataTable dt, string dk)
        {
            DataView dv = FillRow(dt, dk);
            dv.AllowDelete = true;
            while (dv.Count > 0)
                dv.Delete(0);
        }
        public DataView FillRow(DataTable dt, string dk)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = dk;
            return dv;
        }
        public void InsertRow(DataTable dt, params object[] values)
        {
            DataRow dr = dt.NewRow();
            for (int i = 0; i < values.Length; i++)
            {
                dr[i] = values[i];
            }
            dt.Rows.Add(dr);
        }
        public void InsertRow1(DataTable dt, params object[] Field_values)
        {
            DataRow dr = dt.NewRow();
            for (int i = 0; i < Field_values.Length; i += 2)
            {
                dr[Field_values[i].ToString()] = Field_values[i + 1];
            }
        }
        public void UpdateDataTbToDatabase(params Object[] DataTable_TableNames)
        {
            string st = "";
            for (int i = 0; i < DataTable_TableNames.Length; i++)
            {
                if (i == DataTable_TableNames.Length - 1)
                    st = st + "Select * from " + DataTable_TableNames[i];
                else
                    st = st + "Select * from " + DataTable_TableNames[i] + ";";

            }
            SqlDataAdapter da = new SqlDataAdapter(st, con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            for (int i = 0; i < DataTable_TableNames.Length; i++)
            {
                ds.Tables.Add((DataTable)DataTable_TableNames[i]);
            }
            da.Update(ds);
        }
        public void UpdateDataTbToDatabase(DataTable dt, string tablename)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from " + tablename, con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(dt);
        }
        public DataTable ExcuteProcedure(string storeProcName, params object[] values)
        {
            Open();
            SqlCommand cm = new SqlCommand(storeProcName, con);
            cm.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters(cm);
            for (int i = 1; i < cm.Parameters.Count; i++)
            {
                cm.Parameters[i].Value = values[i - 1];
            }
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);
            return dt;
        }
        public void ExcuteNonProcedure(string storeProcName, params object[] values)
        {
            Open();
            SqlCommand cm = new SqlCommand(storeProcName, con);
            cm.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters(cm);
            for (int i = 1; i < cm.Parameters.Count; i++)
            {
                cm.Parameters[i].Value = values[i - 1];
            }
            cm.ExecuteNonQuery();
            Close();
        }
        public SqlDataReader StoreReader(string storeProcName, params object[] values)
        {
            Open();
            SqlCommand cm;
            try
            {
                cm = new SqlCommand(storeProcName, con);
                cm.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cm);
                for (int i = 1; i < cm.Parameters.Count; i++)
                {
                    cm.Parameters[i].Value = values[i - 1];
                }
                SqlDataReader dr = cm.ExecuteReader();
                return dr;
            }
            catch
            {
                return null;
            }

        }
    }
}
