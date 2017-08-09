using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using CaroneiroWeb.DataBase;
using CaroneiroWeb.Models;
using MySql.Data.MySqlClient;


namespace CaroneiroWeb.Repositories
{
    public class AccessRepository
    {
        Connection cnn = new Connection(); //Váriavel que instancia uma nova conexão

        public void register(Users pUser) //Função que insere no banco um novo usuário
        {
            cnn.disconnecti();// ver se é correto, pois não estava conseguindo realizar o resto da verificação
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            pUser.date_registration = DateTime.Now;
            pUser.active = 1;
            pUser.confirmation = 0;
            pUser.access = 0;
            pUser.image = "/Design/images/user.png";
            
            sql.Append("INSERT INTO users (name_user, genre, date_birth, state, city, email, password_user, image, date_registration, active, confirmation, access ) ");
            sql.Append("VALUES (@name_user, @genre, @date_birth, @state, @city, @email, @password_user, @image,  @date_registration, @active, @confirmation, @access )");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@name_user", pUser.name_user);
            cmm.Parameters.AddWithValue("@genre", pUser.genre);
            cmm.Parameters.AddWithValue("@date_birth", pUser.date_birth);
            cmm.Parameters.AddWithValue("@state", pUser.state);
            cmm.Parameters.AddWithValue("@city", pUser.city);
            cmm.Parameters.AddWithValue("@email", pUser.email);
            cmm.Parameters.AddWithValue("@password_user", pUser.password_user);
            cmm.Parameters.AddWithValue("@image", pUser.image);
            cmm.Parameters.AddWithValue("@date_registration", pUser.date_registration);
            cmm.Parameters.AddWithValue("@active", pUser.active);
            cmm.Parameters.AddWithValue("@confirmation", pUser.confirmation);
            cmm.Parameters.AddWithValue("@access", pUser.access);
            cnn.executeQuery(cmm);
        }

        public bool verifyEmail(string pEmail) //Função que valida se o email inserido no cadastro existe
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT id_user ");
            sql.Append("FROM users ");
            sql.Append("WHERE email = @pEmail ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@pEmail", pEmail);
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
        }

        public int checkAge(DateTime pDateB) //Função que valida se o usuário tem idade para se cadastrar
        {

            int years = DateTime.Now.Year - pDateB.Year;

            if (DateTime.Now.Month < pDateB.Month || (DateTime.Now.Month == pDateB.Month && DateTime.Now.Day < pDateB.Day))

                years--;

            return years;
        }

        public Users authenticateUser(string pEmail, string pPassword)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT id_user, name_user, state, image, active, confirmation ");
            sql.Append("FROM users ");
            sql.Append("WHERE email = @pEmail ");
            sql.Append("AND password_user = @pPassword ");
         
            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@pEmail", pEmail);
            cmm.Parameters.AddWithValue("@pPassword", pPassword);

            MySqlDataReader dr = cnn.executeQuery(cmm);

            dr.Read();

            if (dr.HasRows == true)
            {
                Users user = new Users
                {
                    id_user = (int)dr["id_user"],
                    name_user = (string)dr["name_user"],
                    state = (string)dr["state"],
                    image = (string)dr["image"],
                    active = (int)dr["active"],
                    confirmation = (int)dr["confirmation"]
                };
                return user;
                dr.Dispose();

            }
            else
            {
                return null;
                dr.Dispose();
            }
        }// Função que verifica a existencia do email e senha autenticando o usuário, está retornando também o valor disabled

        public void registerFacebook(Users pUser)
        {
            cnn.disconnecti();// ver se é correto, pois não estava conseguindo realizar o resto da verificação
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            pUser.date_registration = DateTime.Now;
            pUser.active = 1;
            pUser.confirmation = 1;
            
            sql.Append("INSERT INTO users (name_user, genre, date_birth, state, city, email, password_user, image, date_registration, active, confirmation ) ");
            sql.Append("VALUES (@name_user, @genre, @date_birth, @state, @city, @email, @password_user, @image,  @date_registration, @active, @confirmation )");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@name_user", pUser.name_user);
            cmm.Parameters.AddWithValue("@genre", pUser.genre);
            cmm.Parameters.AddWithValue("@date_birth", pUser.date_birth);
            cmm.Parameters.AddWithValue("@state", pUser.state);
            cmm.Parameters.AddWithValue("@city", pUser.city);
            cmm.Parameters.AddWithValue("@email", pUser.email);
            cmm.Parameters.AddWithValue("@password_user", pUser.password_user);
            cmm.Parameters.AddWithValue("@image", pUser.image);
            cmm.Parameters.AddWithValue("@date_registration", pUser.date_registration);
            cmm.Parameters.AddWithValue("@active", pUser.active);
            cmm.Parameters.AddWithValue("@confirmation", pUser.confirmation);
            cnn.executeQuery(cmm);
        }

        public Users authenticateUserFaceboook(string pEmail)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT id_user, name_user, state, image, active, confirmation, access ");
            sql.Append("FROM users ");
            sql.Append("WHERE email = @pEmail ");
           
            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@pEmail", pEmail);
            
            MySqlDataReader dr = cnn.executeQuery(cmm);

            dr.Read();

            if (dr.HasRows == true)
            {
                Users user = new Users
                {
                    id_user = (int)dr["id_user"],
                    name_user = (string)dr["name_user"],
                    state = (string)dr["state"],
                    image = (string)dr["image"],
                    active = (int)dr["active"],
                    confirmation = (int)dr["confirmation"],
                    access = dr.IsDBNull(dr.GetOrdinal("access")) ? 0 : (int)dr["access"]
                };
                return user;
                dr.Dispose();

            }
            else
            {
                return null;
                dr.Dispose();
            }
        }// Função que verifica a existencia do email e senha autenticando o usuário, está retornando também o valor disabled


        #region deixar em off
        //public int countMessage(int idUser)
        //{

        //    cnn.disconnecti();
        //    MySqlCommand cmm = new MySqlCommand();
        //    StringBuilder sql = new StringBuilder();

        //    sql.Append("SELECT COUNT(id_message) ");
        //    sql.Append("FROM messages ");
        //    sql.Append("WHERE to_user_id = @idUser ");

        //    cmm.CommandText = sql.ToString();
        //    cmm.Parameters.AddWithValue("@idUser", idUser);

        //    MySqlDataReader dr = cnn.executeQuery(cmm);
        //    dr.Read();
        //    int count = int.Parse(dr[0].ToString());



        //    return count;
        //}

        //public void notificationMessage(int qtdMsg, int id_user)
        //{
        //    cnn.disconnecti();// ver se é correto, pois não estava conseguindo realizar o resto da verificação
        //    MySqlCommand cmm = new MySqlCommand();
        //    StringBuilder sql = new StringBuilder();
        //    DateTime lastAccess = DateTime.Now;


        //    sql.Append("INSERT INTO notificationmessages (lastAccess, qtdMsg, id_user) ");
        //    sql.Append("VALUES (@lastAccess, @qtdMsg, @id_user)");

        //    cmm.CommandText = sql.ToString();
        //    cmm.Parameters.AddWithValue("@lastAccess", lastAccess);
        //    cmm.Parameters.AddWithValue("@qtdMsg", qtdMsg);
        //    cmm.Parameters.AddWithValue("@id_user", id_user);
        //    cnn.executeQuery(cmm);
        //}

        //public void alterNotificationMessage(DateTime lastAccess, int qtdMsg, int id_user)
        //{
        //    cnn.disconnecti();
        //    MySqlCommand cmm = new MySqlCommand();
        //    StringBuilder sql = new StringBuilder();

        //    sql.Append("UPDATE notificationmessages ");
        //    sql.Append("SET lastAccess = @lastAccess, qtdMsg = @qtdMsg ");
        //    sql.Append("WHERE id_user = @id_user ");

        //    cmm.CommandText = sql.ToString();
        //    cmm.Parameters.AddWithValue("@lastAccess", lastAccess);
        //    cmm.Parameters.AddWithValue("@qtdMsg", qtdMsg);
        //    cmm.Parameters.AddWithValue("@id_user", id_user);

        //    cnn.executeQuery(cmm);
        //}

        //public NotificationMessages notificationReader(int idUser)
        //{
        //    MySqlCommand cmm = new MySqlCommand();
        //    StringBuilder sql = new StringBuilder();

        //    sql.Append("SELECT qtdMsg ");
        //    sql.Append("FROM notificationmessages ");
        //    sql.Append("WHERE id_user = @idUser ");

        //    cmm.CommandText = sql.ToString();
        //    cmm.Parameters.AddWithValue("@idUser", idUser);

        //    MySqlDataReader dr = cnn.executeQuery(cmm);

        //    dr.Read();

        //    if (dr.HasRows == true)
        //    {
        //        NotificationMessages nm = new NotificationMessages
        //        {
        //            qtdMsg = (int)dr["qtdMsg"],
        //        };
        //        dr.Dispose();
        //        return nm;

        //    }
        //    else
        //    {
        //        dr.Dispose();
        //        return null;
        //    }
        //}

        //public Users verifyId(string pEmail)
        //{
        //    cnn.disconnecti();
        //    MySqlCommand cmm = new MySqlCommand();
        //    StringBuilder sql = new StringBuilder();

        //    sql.Append("SELECT id_user ");
        //    sql.Append("FROM users ");
        //    sql.Append("WHERE email = @pEmail ");

        //    cmm.CommandText = sql.ToString();
        //    cmm.Parameters.AddWithValue("@pEmail", pEmail);

        //    MySqlDataReader dr = cnn.executeQuery(cmm);

        //    dr.Read();

        //    if (dr.HasRows == true)
        //    {
        //        Users user = new Users
        //        {
        //            id_user = (int)dr["id_user"]
        //        };
        //        dr.Dispose();
        //        return user;

        //    }
        //    else
        //    {
        //        dr.Dispose();
        //        return null;
        //    }
        //}

        #endregion

        public NotificationMessages notificationMessage(int idUser)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT qtdMsg ");
            sql.Append("FROM notificationmessages ");
            sql.Append("WHERE id_user = @idUser ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@idUser", idUser);

            MySqlDataReader dr = cnn.executeQuery(cmm);

            dr.Read();

            if (dr.HasRows == true)
            {
                NotificationMessages notification = new NotificationMessages
                {
                    qtdMsg = (int)dr["qtdMsg"],
                };
                dr.Dispose();
                return notification;

            }
            else
            {
                dr.Dispose();
                return null;
            }
        }

        public void alterNotificationMessage(int idUser)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            int qtdMsg = 0;
            sql.Append("UPDATE notificationmessages ");
            sql.Append("SET qtdMsg = @qtdMsg ");
            sql.Append("WHERE id_user = @idUser ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@qtdMsg", qtdMsg);
            cmm.Parameters.AddWithValue("@idUser", idUser);

            cnn.executeQuery(cmm);
        }

        public Notification notificationInterested(int idUser)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT qtdNI ");
            sql.Append("FROM notificationinterest ");
            sql.Append("WHERE id_user = @idUser ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@idUser", idUser);

            MySqlDataReader dr = cnn.executeQuery(cmm);

            dr.Read();

            if (dr.HasRows == true)
            {
                Notification notification = new Notification
                {
                    qtd = (int)dr["qtdNI"],
                };
                dr.Dispose();
                return notification;

            }
            else
            {
                dr.Dispose();
                return null;
            }
        }

        public void alterNotificationInterested(int idUser)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            int qtdNI = 0;
            sql.Append("UPDATE notificationinterest ");
            sql.Append("SET qtdNI = @qtdNI ");
            sql.Append("WHERE id_user = @idUser ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@qtdNI", qtdNI);
            cmm.Parameters.AddWithValue("@idUser", idUser);

            cnn.executeQuery(cmm);
        }

        public Notification notificationParticipation (int idUser)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT qtdNP ");
            sql.Append("FROM notificationparticipation ");
            sql.Append("WHERE id_user = @idUser ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@idUser", idUser);

            MySqlDataReader dr = cnn.executeQuery(cmm);

            dr.Read();

            if (dr.HasRows == true)
            {
                Notification notification = new Notification
                {
                    qtdP = (int)dr["qtdNP"],
                };
                dr.Dispose();
                return notification;

            }
            else
            {
                dr.Dispose();
                return null;
            }
        }
         
        public void alterNotificationParticipation(int idUser)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            int qtdNP = 0;
            sql.Append("UPDATE notificationparticipation ");
            sql.Append("SET qtdNP = @qtdNP ");
            sql.Append("WHERE id_user = @idUser ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@qtdNP", qtdNP);
            cmm.Parameters.AddWithValue("@idUser", idUser);

            cnn.executeQuery(cmm);
        }

        public bool verifyFacebook (string email)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT id_user ");
            sql.Append("FROM users ");
            sql.Append("WHERE email = @pEmail AND access = 1 ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@pEmail", email);
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
        }

        public Users verifyPassword(Users user)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT password_user ");
            sql.Append("FROM users WHERE email = @email");
            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@email",user.email);
            MySqlDataReader dr = cnn.executeQuery(cmm);

            dr.Read();

            Users users = new Users
            {
                password_user = (string)dr["password_user"]
            };
            dr.Dispose();
            return users;
        }
    }
}