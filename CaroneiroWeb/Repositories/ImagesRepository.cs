using CaroneiroWeb.DataBase;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace CaroneiroWeb.Repositories
{
    public class ImagesRepository
    {
        Connection cnn = new Connection(); //Váriavel que instancia uma nova conexão 

        #region Ta funcionando
        public void saveImagePath(string pPathImage, int pId)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("UPDATE users ");
            sql.Append("SET image = @pPathImage ");
            sql.Append("WHERE id_user = @pId");

            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@pPathImage", pPathImage);
            cmm.Parameters.AddWithValue("@pId", pId);

            cnn.executeQuery(cmm);
        }//Função que salva na tabela usuário o caminho da imagem 

        public string searchImagePath(int pId)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT image ");
            sql.Append("FROM users ");
            sql.Append("WHERE id_user = @pId ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@pId", pId);

            MySqlDataReader dr = cnn.executeQuery(cmm);

            dr.Read();

            string path = (string)dr["image"];


            return path;
        } //Retorna caminho da imagem

        #endregion


        

    }
}