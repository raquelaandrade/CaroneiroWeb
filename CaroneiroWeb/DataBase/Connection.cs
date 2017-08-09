using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CaroneiroWeb.DataBase
{
    public class Connection
    {
        public MySqlConnection conn = new MySqlConnection();
        public MySqlCommand cmm;
        public MySqlDataReader dr;

        public string connString
        {
            get { return "Server=localhost;Database=caroneiro;Uid=root;Pwd=;"; }
        }

        private void connect()
        {
            conn.ConnectionString = connString;

            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public void disconnecti()
        {
            // só entra no if se a conexão estiver aberta
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

        }//Alterei para public, estava private

        public void executeCommand(MySqlCommand cmm)
        {
            connect();//abro a conexão
            cmm.Connection = conn;
            cmm.ExecuteNonQuery();
        }


        public MySqlDataReader executeQuery(string sql)
        {
            connect();
            cmm = new MySqlCommand(sql, conn);
            try
            {
                dr = cmm.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                dr.Dispose();
                throw ex;
            }
            return dr;
        }

        public MySqlDataReader executeQuery(MySqlCommand cmm)
        {
            connect();
            cmm.Connection = conn;
            try
            {
                dr = cmm.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                dr.Dispose();
                throw ex;
            }
            return dr;
        }
    }
}