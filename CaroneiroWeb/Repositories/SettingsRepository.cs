using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using CaroneiroWeb.DataBase;
using CaroneiroWeb.Models;

namespace CaroneiroWeb.Repositories
{
    public class SettingsRepository
    {
        Connection cnn = new Connection();

        public void changeAccountStatus(int pActive, int pId)//Atribui o valor 0 ou 1 ao campo disabled, reativando ou desativando a conta
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("UPDATE users ");
            sql.Append("SET active = @pActive ");
            sql.Append("WHERE id_user = @pId");

            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@pActive", pActive);
            cmm.Parameters.AddWithValue("@pId", pId);
            cnn.executeQuery(cmm);
        }

        public void changeConfirmation(int pConfirmation, int pId)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("UPDATE users ");
            sql.Append("SET confirmation = @pConfirmation ");
            sql.Append("WHERE id_user = @pId");

            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@pConfirmation", pConfirmation);
            cmm.Parameters.AddWithValue("@pId", pId);
            cnn.executeQuery(cmm);

        } //Função chamada no login link do email, troca o status do campo confirmation, que significa que o email esta confirmado

        public bool verifyPassword (int idUser, string password) 
        {
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT id_user ");
            sql.Append("FROM users ");
            sql.Append("WHERE id_user = @idUser AND password_user = @password ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@idUser", idUser);
            cmm.Parameters.AddWithValue("@password", password);

            MySqlDataReader dr = cnn.executeQuery(cmm);

            dr.Read();

            if (dr.HasRows == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void alterPassword(string password, int idUser)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("UPDATE users ");
            sql.Append("SET password_user = @password_user ");
            sql.Append("WHERE id_user = @id_user ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@password_user", password);
            cmm.Parameters.AddWithValue("@id_user", idUser);
            
            cnn.executeQuery(cmm);
        }

    }
}