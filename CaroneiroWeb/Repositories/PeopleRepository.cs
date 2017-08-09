using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CaroneiroWeb.Models;
using CaroneiroWeb.DataBase;
using MySql.Data.MySqlClient;
using System.Text;

namespace CaroneiroWeb.Repositories
{
    public class PeopleRepository
    {
        Connection cnn = new Connection(); //Váriavel que instancia uma nova conexão

        #region busca de usuários
        public IEnumerable<Users> searchUsersByName(string pName, int idUser)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            List<Users> usersList = new List<Users>();

            sql.Append("SELECT id_user, name_user, genre, state, city, image, evalution ");
            sql.Append("FROM users ");
            sql.Append("WHERE (name_user LIKE @pName) AND (active  = '1') AND (confirmation = '1') AND (id_user <> @idUser) ");
            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@pName", "%" + pName + "%");
            cmm.Parameters.AddWithValue("@idUser", idUser);
            MySqlDataReader dr = cnn.executeQuery(cmm);

            while (dr.Read())
            {
                Users users = new Users
                {
                    id_user = (int)dr["id_user"],
                    name_user = (string)dr["name_user"],
                    genre = (string)dr["genre"],
                    state = (string)dr["state"],
                    city = (string)dr["city"],
                    image = dr.IsDBNull(dr.GetOrdinal("image")) ? "" : (string)dr["image"],
                    evalution = dr.IsDBNull(dr.GetOrdinal("evalution")) ? 0 : (float)dr["evalution"]
                };
                usersList.Add(users);
            }
            dr.Dispose();
            return usersList;
        } // Procura um usuário pelo nome

        public IEnumerable<Users> searchUsersByLocality(string pState)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            List<Users> usersList = new List<Users>();

            sql.Append("SELECT id_user, name_user, genre, state, city, image, evalution ");
            sql.Append("FROM users ");
            sql.Append("WHERE state LIKE @pState AND active  = '1' AND confirmation = '1' ");
            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@pState", "%" + pState + "%");
            MySqlDataReader dr = cnn.executeQuery(cmm);

            while (dr.Read())
            {
                Users users = new Users
                {
                    id_user = (int)dr["id_user"],
                    name_user = (string)dr["name_user"],
                    genre = (string)dr["genre"],
                    state = (string)dr["state"],
                    city = (string)dr["city"],
                    image = dr.IsDBNull(dr.GetOrdinal("image")) ? "" : (string)dr["image"],
                    evalution = dr.IsDBNull(dr.GetOrdinal("evalution")) ? 0 : (float)dr["evalution"]
                };
                usersList.Add(users);
            }
            dr.Dispose();
            return usersList;
        } // Procura um usuário pelo estado

        #endregion

        public Users getOnePerfilFriend(int pId)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT id_user, name_user, genre, date_birth, state, city, image, religion, relationship, schooling, profession, " +
                       "pref_music, emotional, description, evalution ");
            sql.Append("FROM users WHERE id_user = @pId ");
            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@pId", pId);
            MySqlDataReader dr = cnn.executeQuery(cmm);

            dr.Read();

            Users user = new Users
            {
                id_user = (int)dr["id_user"],
                name_user = (string)dr["name_user"],
                genre = (string)dr["genre"],
                date_birth = (DateTime)dr["date_birth"],
                state = (string)dr["state"],
                city = (string)dr["city"],
                image = dr.IsDBNull(dr.GetOrdinal("image")) ? "" : (string)dr["image"],
                religion = dr.IsDBNull(dr.GetOrdinal("religion")) ? "" : (string)dr["religion"],
                relationship = dr.IsDBNull(dr.GetOrdinal("relationship")) ? "" : (string)dr["relationship"],
                schooling = dr.IsDBNull(dr.GetOrdinal("schooling")) ? "" : (string)dr["schooling"],
                profession = dr.IsDBNull(dr.GetOrdinal("profession")) ? "" : (string)dr["profession"],
                pref_music = dr.IsDBNull(dr.GetOrdinal("pref_music")) ? "" : (string)dr["pref_music"],
                emotional = dr.IsDBNull(dr.GetOrdinal("emotional")) ? "" : (string)dr["emotional"],
                description = dr.IsDBNull(dr.GetOrdinal("description")) ? "" : (string)dr["description"],
                evalution = dr.IsDBNull(dr.GetOrdinal("evalution")) ? 0 : (float)dr["evalution"]
            };
            dr.Dispose();
            return user;
        } // Retorna o perfil de um usuário especifico

        public void sendMessage(int pIdTo, int pIdFrom, string pContent)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            DateTime pDateMsg = DateTime.Now;

            sql.Append("INSERT INTO messages (content, date_msg, to_user_id, from_user_id) ");
            sql.Append("VALUES (@pContent, @pDateMsg, @pIdTo, @pIdFrom ) ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@pContent", pContent);
            cmm.Parameters.AddWithValue("@pDateMsg", pDateMsg);
            cmm.Parameters.AddWithValue("@pIdTo", pIdTo);
            cmm.Parameters.AddWithValue("@pIdFrom", pIdFrom);

            cnn.executeQuery(cmm);

        } //Envia mensagem para outro usuário        

        public bool checkRequest(int pIdUser, int pIdAd)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT id_interested ");
            sql.Append("FROM interested ");
            sql.Append("WHERE id_advertisement = @pIdAd AND id_user = @pIdUser");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@pIdAd", pIdAd);
            cmm.Parameters.AddWithValue("@pIdUser", pIdUser);
            MySqlDataReader dr = cnn.executeQuery(cmm);
            dr.Read();
            if (dr.HasRows == true)
            {
                dr.Close();
                return true;
            }
            else
            {
                dr.Close();
                return false;
            }
        } //Verifica se o usuário já demonstrou interesse em determinado anúncio

        public bool checkParticipation(int pIdUser, int pIdAd)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT id_participantsads ");
            sql.Append("FROM participantsads ");
            sql.Append("WHERE id_user = @pIdUser AND id_advertisement = @pIdAd ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@pIdAd", pIdAd);
            cmm.Parameters.AddWithValue("@pIdUser", pIdUser);
            MySqlDataReader dr = cnn.executeQuery(cmm);
            dr.Read();
            if (dr.HasRows == true)
            {
                dr.Close();
                return true;
            }
            else
            {
                dr.Close();
                return false;
            }
        }//Verifica se o usuário esta participando de determinado anúncio
    }
}