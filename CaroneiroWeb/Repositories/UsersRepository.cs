using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using CaroneiroWeb.Models;
using CaroneiroWeb.DataBase;
using MySql.Data.MySqlClient;


namespace CaroneiroWeb.Repositories
{
    public class UsersRepository
    {
        Connection cnn = new Connection(); //Váriavel que instancia uma nova conexão

        public Users getOnePerfil(int pId)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT name_user, genre, date_birth, state, city, email, religion, relationship, schooling, profession, " +
                       "pref_music, emotional, description, evalution ");
            sql.Append("FROM users WHERE id_user = @pId ");
            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@pId", pId);
            MySqlDataReader dr = cnn.executeQuery(cmm);

            dr.Read();

            Users user = new Users
            {
                name_user = (string)dr["name_user"],
                genre = (string)dr["genre"],
                date_birth = (DateTime)dr["date_birth"],
                state = (string)dr["state"],
                city = (string)dr["city"],
                email = (string)dr["email"],
                religion = dr.IsDBNull(dr.GetOrdinal("religion")) ? "" : (string)dr["religion"],
                relationship = dr.IsDBNull(dr.GetOrdinal("relationship")) ? "" : (string)dr["relationship"],
                schooling = dr.IsDBNull(dr.GetOrdinal("schooling")) ? "" : (string)dr["schooling"],
                profession = dr.IsDBNull(dr.GetOrdinal("profession")) ? "" : (string)dr["profession"],
                pref_music = dr.IsDBNull(dr.GetOrdinal("pref_music")) ? "" : (string)dr["pref_music"],
                emotional = dr.IsDBNull(dr.GetOrdinal("emotional")) ? "" : (string)dr["emotional"],
                description = dr.IsDBNull(dr.GetOrdinal("description")) ? "" : (string)dr["description"]
            };
            dr.Dispose();
            return user;
        } // Função que retorna um perfil especifico do banco - esta faltando mostrar avaliação

        public Users getOnePerfilAccess(int pId)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT name_user, genre, date_birth ");
            sql.Append("FROM users WHERE id_user = @pId ");
            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@pId", pId);
            MySqlDataReader dr = cnn.executeQuery(cmm);

            dr.Read();

            Users user = new Users
            {
                name_user = (string)dr["name_user"],
                genre = (string)dr["genre"],
                date_birth = (DateTime)dr["date_birth"]
            };
            dr.Dispose();
            return user;
        }

        public void editPerfil(Users pUser)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("UPDATE users ");
            sql.Append("SET name_user = @name_user, genre = @genre, state = @state, city = @city, religion = @religion, relationship = @relationship,");
            sql.Append(" schooling = @schooling, profession = @profession, pref_music = @pref_music, emotional = @emotional, description = @description ");
            sql.Append("WHERE id_user = @id_user ");

            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@name_user", pUser.name_user);
            cmm.Parameters.AddWithValue("@genre", pUser.genre);
            cmm.Parameters.AddWithValue("@state", pUser.state);
            cmm.Parameters.AddWithValue("@city", pUser.city);
            cmm.Parameters.AddWithValue("@religion", pUser.religion);
            cmm.Parameters.AddWithValue("@relationship", pUser.relationship);
            cmm.Parameters.AddWithValue("@schooling", pUser.schooling);
            cmm.Parameters.AddWithValue("@profession", pUser.profession);
            cmm.Parameters.AddWithValue("@pref_music", pUser.pref_music);
            cmm.Parameters.AddWithValue("@emotional", pUser.emotional);
            cmm.Parameters.AddWithValue("@description", pUser.description);
            cmm.Parameters.AddWithValue("@id_user", pUser.id_user);

            cnn.executeQuery(cmm);
        } // Função que edita o perfil do usuário

        public void editPerfilAccess(Users pUser)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("UPDATE users ");
            sql.Append("SET name_user = @name_user, genre = @genre, date_birth = @date_birth, state = @state, city = @city, religion = @religion, relationship = @relationship,");
            sql.Append(" schooling = @schooling, profession = @profession, pref_music = @pref_music, emotional = @emotional, description = @description ");
            sql.Append("WHERE id_user = @id_user ");

            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@name_user", pUser.name_user);
            cmm.Parameters.AddWithValue("@genre", pUser.genre);
            cmm.Parameters.AddWithValue("@date_birth", pUser.date_birth);
            cmm.Parameters.AddWithValue("@state", pUser.state);
            cmm.Parameters.AddWithValue("@city", pUser.city);
            cmm.Parameters.AddWithValue("@religion", pUser.religion);
            cmm.Parameters.AddWithValue("@relationship", pUser.relationship);
            cmm.Parameters.AddWithValue("@schooling", pUser.schooling);
            cmm.Parameters.AddWithValue("@profession", pUser.profession);
            cmm.Parameters.AddWithValue("@pref_music", pUser.pref_music);
            cmm.Parameters.AddWithValue("@emotional", pUser.emotional);
            cmm.Parameters.AddWithValue("@description", pUser.description);
            cmm.Parameters.AddWithValue("@id_user", pUser.id_user);

            cnn.executeQuery(cmm);
        } // Função que edita o perfil do usuário

        public IEnumerable<Messages> receivedMessages(int pId)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            List<Messages> messageList = new List<Messages>();

            sql.Append("SELECT messages.id_message, users.name_user, users.active, users.image, messages.from_user_id , messages.content, messages.date_msg ");
            sql.Append("FROM users ");
            sql.Append("INNER JOIN messages ");
            sql.Append("ON messages.from_user_id = users.id_user ");
            sql.Append("WHERE messages.to_user_id = @pId ");
            sql.Append("ORDER by messages.date_msg DESC ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@pId", pId);
            MySqlDataReader dr = cnn.executeQuery(cmm);

            while (dr.Read())
            {
                Messages message = new Messages
                {
                    id_message = (int)dr["id_message"],
                    User = new Users
                    {
                        name_user = (string)dr["name_user"],
                        active = (int)dr["active"],
                        image = (string)dr["image"]
                    },
                    from_user_id = (int)dr["from_user_id"],
                    content = (string)dr["content"],
                    date_msg = (DateTime)dr["date_msg"]
                };
                messageList.Add(message);
            }
            dr.Dispose();
            return messageList;

        } // Função que mostra as mensagens recebidas do usúario

        public void deleteMessage(int pId)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("DELETE FROM messages ");
            sql.Append("WHERE id_message = @pId ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@pId", pId);

            cnn.executeQuery(cmm);
        }// Função que deleta uma mensagem 
        
        public IEnumerable<Interested> interestedPeople(int pIdAd)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            List<Interested> interestedList = new List<Interested>();

            sql.Append("SELECT interested.id_interested, interested.id_user, interested.id_advertisement, users.name_user, users.image ");
            sql.Append("FROM users ");
            sql.Append("INNER JOIN interested ");
            sql.Append("ON interested.id_user = users.id_user ");
            sql.Append("WHERE interested.id_advertisement = @pIdAd AND interested.status <> 0");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@pIdAd", pIdAd);
            MySqlDataReader dr = cnn.executeQuery(cmm);

            while (dr.Read())
            {
                Interested interested = new Interested
                {
                    id_interested = (int)dr["id_interested"],
                    id_user = (int)dr["id_user"],
                    id_advertisement = (int)dr["id_advertisement"],
                    User = new Users
                    {
                        name_user = (string)dr["name_user"],
                        image = dr.IsDBNull(dr.GetOrdinal("image")) ? "" : (string)dr["image"],
                    }
                };
                interestedList.Add(interested);
            }
            dr.Dispose();
            return interestedList;
        }//Retorna os usuários interessados num determinado anúncio

        public IEnumerable<Participants> participantPeople(int pIdAd)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            List<Participants> participantsList = new List<Participants>();

            sql.Append("SELECT participantsads.id_participantsads, participantsads.id_advertisement, participantsads.id_user, users.name_user, users.image ");
            sql.Append("FROM users ");
            sql.Append("INNER JOIN participantsads ");
            sql.Append("ON participantsads.id_user = users.id_user ");
            sql.Append("WHERE participantsads.id_advertisement = @pIdAd ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@pIdAd", pIdAd);
            MySqlDataReader dr = cnn.executeQuery(cmm);

            while (dr.Read())
            {
                Participants participants = new Participants
                {
                    id_participantsads = (int)dr["id_participantsads"],
                    id_user = (int)dr["id_user"],
                    id_advertisement = (int)dr["id_advertisement"],
                    User = new Users
                    {
                        name_user = (string)dr["name_user"],
                        image = dr.IsDBNull(dr.GetOrdinal("image")) ? "" : (string)dr["image"],
                    }
                };
                participantsList.Add(participants);
            }
            dr.Dispose();
            return participantsList;
        }//Retorna os usuários participantes num determinado anúncio

        public void adParticipationRequest(string title, int pIdUser, int pIdAd, int id_owner_ad)
        {
            cnn.disconnecti();// ver se é correto, pois não estava conseguindo realizar o resto da verificação
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            int status = 1;
            DateTime dateInterest = DateTime.Now;

            sql.Append("INSERT INTO interested (status, date_interested, title, id_user, id_advertisement, id_owner_ad) ");
            sql.Append("VALUES (@status, @dateInterest, @title, @pIdUser,  @pIdAd, @id_owner_ad)");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@status", status);
            cmm.Parameters.AddWithValue("@dateInterest", dateInterest);
            cmm.Parameters.AddWithValue("@pIdAd", pIdAd);
            cmm.Parameters.AddWithValue("@pIdUser", pIdUser);
            cmm.Parameters.AddWithValue("@title", title);
            cmm.Parameters.AddWithValue("@id_owner_ad", id_owner_ad);

            cnn.executeQuery(cmm);
        }// Adiciona a solicitação de interesse de um usuário

        public void deleteRequestForParticipation(int pIdAd, int pIdUser)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("DELETE FROM interested  ");
            sql.Append("WHERE id_advertisement = @pIdAd AND id_user = @pIdUser ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@pIdAd", pIdAd);
            cmm.Parameters.AddWithValue("@pIdUser", pIdUser);

            cnn.executeQuery(cmm);
        }//Deleta uma solicitação de participação

        public void acceptParticipationRequest(int pIdAd, int pIdUser, string title, int idOwner )
        {
            cnn.disconnecti();// ver se é correto, pois não estava conseguindo realizar o resto da verificação
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            DateTime dateAccept = DateTime.Now; 

            sql.Append("INSERT INTO participantsads (date_participant, title, id_user, id_advertisement, id_owner_ad) ");
            sql.Append("VALUES (@dateAccept, @title, @pIdUser, @pIdAd, @idOwner)");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@dateAccept", dateAccept);
            cmm.Parameters.AddWithValue("@title", title);
            cmm.Parameters.AddWithValue("@pIdAd", pIdAd);
            cmm.Parameters.AddWithValue("@pIdUser", pIdUser);
            cmm.Parameters.AddWithValue("@idOwner", idOwner);

            cnn.executeQuery(cmm);
        }//O usuário logado aceita um participante em seu anúncio

        public void refuseRequestParticipation(int pIdAd, int pIdUser)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            int status = 0;

            sql.Append("UPDATE interested ");
            sql.Append("SET status = @status ");
            sql.Append("WHERE id_advertisement = @pIdAd AND id_user = @pIdUser ");

            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@pIdAd", pIdAd);
            cmm.Parameters.AddWithValue("@pIdUser", pIdUser);
            cmm.Parameters.AddWithValue("@status", status);

            cnn.executeQuery(cmm);

        }//O usuário logado recusa uma solicitação

        public void deleteParticipation(int pIdAd, int pIdUser)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("DELETE FROM participantsads ");
            sql.Append("WHERE id_advertisement = @pIdAd AND id_user = @pIdUser ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@pIdAd", pIdAd);
            cmm.Parameters.AddWithValue("@pIdUser", pIdUser);

            cnn.executeQuery(cmm);
        }// O usuário deleta um participante de seu anúncio

        public void alterEditAccess(int access, int pIdUser)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE users ");
            sql.Append("SET access = @access ");
            sql.Append("WHERE id_user = @idUser ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@access", access);
            cmm.Parameters.AddWithValue("@idUser", pIdUser);

            cnn.executeQuery(cmm);
        }

        public IEnumerable<Interested> notificationInterestedList (int idUser)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            List<Interested> interestedList = new List<Interested>();

            sql.Append("SELECT interested.id_interested, interested.date_interested, interested.title, interested.id_user, " +
                       "interested.id_advertisement, users.name_user, users.image ");
            sql.Append("FROM users ");
            sql.Append("INNER JOIN interested ");
            sql.Append("ON interested.id_user = users.id_user ");
            sql.Append("WHERE interested.id_owner_ad = @idUser ");
            sql.Append("ORDER by interested.date_interested DESC ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@idUser",idUser);
            MySqlDataReader dr = cnn.executeQuery(cmm);

            while (dr.Read())
            {
                Interested interested = new Interested
                {
                    id_interested = (int)dr["id_interested"],
                    date_interested = (DateTime)dr["date_interested"],
                    title = dr.IsDBNull(dr.GetOrdinal("title")) ? "" : (string)dr["title"],
                    id_user = (int)dr["id_user"],
                    id_advertisement = (int)dr["id_advertisement"],
                    User = new Users
                    {
                        name_user = (string)dr["name_user"],
                        image = dr.IsDBNull(dr.GetOrdinal("image")) ? "" : (string)dr["image"],
                    }
                };
                interestedList.Add(interested);
            }
            dr.Dispose();
            return interestedList;
        }

        public IEnumerable<Participants> notificationParticipantsList(int idUser)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            List<Participants> participantsList = new List<Participants>();

            sql.Append("SELECT p.id_participantsads, p.date_participant, p.title, p.id_user, p.id_advertisement, p.id_owner_ad, u.name_user, u.image ");
            sql.Append("FROM users u ");
            sql.Append("INNER JOIN participantsads p ");
            sql.Append("ON p.id_owner_ad = u.id_user ");
            sql.Append("WHERE p.id_user = @idUser AND u.active = 1 ");
            sql.Append("ORDER by p.date_participant DESC ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@idUser", idUser);
            MySqlDataReader dr = cnn.executeQuery(cmm);

            while (dr.Read())
            {
                Participants participants = new Participants
                {
                    id_participantsads = (int)dr["id_participantsads"],
                    date_participant = (DateTime)dr["date_participant"],
                    title = dr.IsDBNull(dr.GetOrdinal("title")) ? "" : (string)dr["title"],
                    id_user = (int)dr["id_user"],
                    id_advertisement = (int)dr["id_advertisement"],
                    id_owner_ad = (int)dr["id_owner_ad"],
                    User = new Users
                    {
                        name_user = (string)dr["name_user"],
                        image = dr.IsDBNull(dr.GetOrdinal("image")) ? "" : (string)dr["image"]
                    }
                };
                participantsList.Add(participants);
            }
            dr.Dispose();
            return participantsList;
        }

        public void deleteNotificationParticipant(int idNotification)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("DELETE FROM participantsads ");
            sql.Append("WHERE id_participantsads = @idNotification ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@idNotification", idNotification);

            cnn.executeQuery(cmm);
        }

        public void deleteNotificationInterested(int idNotification)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("DELETE FROM interested ");
            sql.Append("WHERE id_interested = @idNotification ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@idNotification", idNotification);

            cnn.executeQuery(cmm);
        }

    }
}