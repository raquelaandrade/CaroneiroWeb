using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Text;
using CaroneiroWeb.DataBase;
using CaroneiroWeb.Models;

namespace CaroneiroWeb.Repositories
{
    public class AdvertisementRepository
    {
        Connection cnn = new Connection(); //Váriavel que instancia uma nova conexão

        public void saveAdHosting(Advertisement ad, int pId)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            string dateString = "2000/01/01";
            DateTime date1 = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);

            ad.type_ad = "Procura Hospedagem";
            ad.date_creation = DateTime.Now;
            ad.active = 1;
            ad.id_owner_ad = pId;
            ad.departure_date = date1 ;

            sql.Append("INSERT INTO advertisement (type_ad, date_creation, expiration_date, title, " +
                                    " state, city, start, end, accommodation_type, " +
                                    "quantity_people, maximum_people_value, departure_date, description, active, id_owner_ad) ");
            sql.Append("VALUES (@type_ad, @date_creation, @expiration_date, @title, " +
                               "@state, @city, @start, @end, @accommodation_type, " +
                               "@quantity_people, @maximum_people_value, @departure_date, @description, @active, @id_owner_ad )");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@type_ad", ad.type_ad);
            cmm.Parameters.AddWithValue("@date_creation", ad.date_creation);
            cmm.Parameters.AddWithValue("@expiration_date", ad.expiration_date);
            cmm.Parameters.AddWithValue("@title", ad.title);
            cmm.Parameters.AddWithValue("@state", ad.state);
            cmm.Parameters.AddWithValue("@city", ad.city);
            cmm.Parameters.AddWithValue("@start", ad.checkin);
            cmm.Parameters.AddWithValue("@end", ad.checkout);
            cmm.Parameters.AddWithValue("@accommodation_type", ad.accommodation_type);
            cmm.Parameters.AddWithValue("@quantity_people", ad.quantity_people);
            cmm.Parameters.AddWithValue("@maximum_people_value", ad.maximum_people_value);
            cmm.Parameters.AddWithValue("@departure_date", ad.departure_date);//data falsa
            cmm.Parameters.AddWithValue("@description", ad.description);
            cmm.Parameters.AddWithValue("@active", ad.active);
            cmm.Parameters.AddWithValue("@id_owner_ad", ad.id_owner_ad);

            cnn.executeQuery(cmm);
        }// Salva anúncio de procura por hospedagem

        public void saveHostingOffer(Advertisement ad, int pId)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            string dateString = "2000/01/01";
            DateTime date1 = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);

            ad.type_ad = "Oferta Hospedagem";
            ad.date_creation = DateTime.Now;
            ad.active = 1;
            ad.id_owner_ad = pId;
            ad.departure_date = date1;

            sql.Append("INSERT INTO advertisement (type_ad, date_creation, expiration_date, title, " +
                                    " state, city, start, end, accommodation_type, " +
                                    "quantity_people, maximum_people_value, departure_date, description, active, id_owner_ad) ");
            sql.Append("VALUES (@type_ad, @date_creation, @expiration_date, @title, " +
                               "@state, @city, @start, @end, @accommodation_type, " +
                               "@quantity_people, @maximum_people_value, @departure_date, @description, @active, @id_owner_ad )");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@type_ad", ad.type_ad);
            cmm.Parameters.AddWithValue("@date_creation", ad.date_creation);
            cmm.Parameters.AddWithValue("@expiration_date", ad.expiration_date);
            cmm.Parameters.AddWithValue("@title", ad.title);
            cmm.Parameters.AddWithValue("@state", ad.state);
            cmm.Parameters.AddWithValue("@city", ad.city);
            cmm.Parameters.AddWithValue("@start", ad.start);
            cmm.Parameters.AddWithValue("@end", ad.end);
            cmm.Parameters.AddWithValue("@accommodation_type", ad.accommodation_type);
            cmm.Parameters.AddWithValue("@quantity_people", ad.quantity_people);
            cmm.Parameters.AddWithValue("@maximum_people_value", ad.maximum_people_value);
            cmm.Parameters.AddWithValue("@departure_date", ad.departure_date);//data falsa
            cmm.Parameters.AddWithValue("@description", ad.description);
            cmm.Parameters.AddWithValue("@active", ad.active);
            cmm.Parameters.AddWithValue("@id_owner_ad", ad.id_owner_ad);

            cnn.executeQuery(cmm);
        } // Salva anúncio de oferta de hospedagem

        public void saveSearchRide(Advertisement ad, int pId)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            string dateString = "2000/01/01";
            DateTime date1 = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);

            ad.type_ad = "Procura Carona";
            ad.date_creation = DateTime.Now;
            ad.active = 1;
            ad.id_owner_ad = pId;
            ad.start = date1;
            ad.end = date1;

            sql.Append("INSERT INTO advertisement (type_ad, date_creation, expiration_date, title, " +
                                                   "state, city, exitState, exitTown, start, end, quantity_people, " +
                                                   "maximum_route_value, local_exit, departure_date, description, active, id_owner_ad) ");
            sql.Append("VALUES (@type_ad, @date_creation, @expiration_date, @title, @state, @city, " +
                                "@exitState, @exitTown, @start, @end, @quantity_people, @maximum_route_value, @local_exit, " +
                                "@departure_date, @description, @active, @id_owner_ad )");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@type_ad", ad.type_ad);
            cmm.Parameters.AddWithValue("@date_creation", ad.date_creation);
            cmm.Parameters.AddWithValue("@expiration_date", ad.expiration_date);
            cmm.Parameters.AddWithValue("@title", ad.title);
            cmm.Parameters.AddWithValue("@state", ad.state);
            cmm.Parameters.AddWithValue("@city", ad.city);
            cmm.Parameters.AddWithValue("@exitState", ad.exitState);
            cmm.Parameters.AddWithValue("@exitTown", ad.exitTown);
            cmm.Parameters.AddWithValue("@start", ad.start);
            cmm.Parameters.AddWithValue("@end", ad.end);
            cmm.Parameters.AddWithValue("@quantity_people", ad.quantity_people);
            cmm.Parameters.AddWithValue("@maximum_route_value", ad.maximum_route_value);
            cmm.Parameters.AddWithValue("@local_exit", ad.local_exit);
            cmm.Parameters.AddWithValue("@departure_date", ad.departure_date);
            cmm.Parameters.AddWithValue("@description", ad.description);
            cmm.Parameters.AddWithValue("@active", ad.active);
            cmm.Parameters.AddWithValue("@id_owner_ad", ad.id_owner_ad);

            cnn.executeQuery(cmm);
        } // Salva anúncio de procura por carona

        public void saveOfferRide(Advertisement ad, int pId)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            string dateString = "2000/01/01";
            DateTime date1 = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);

            ad.type_ad = "Oferta Carona";
            ad.date_creation = DateTime.Now;
            ad.active = 1;
            ad.id_owner_ad = pId;
            ad.start = date1;
            ad.end = date1;

            sql.Append("INSERT INTO advertisement (type_ad, date_creation, expiration_date, title, " +
                                                   "state, city, exitState, exitTown, start, end, quantity_people, " +
                                                   "maximum_route_value, departure_date, description, active, id_owner_ad) ");
            sql.Append("VALUES (@type_ad, @date_creation, @expiration_date, @title, @state, @city, " +
                                "@exitState, @exitTown, @start, @end, @quantity_people, @maximum_route_value, " +
                                "@departure_date, @description, @active, @id_owner_ad )");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@type_ad", ad.type_ad);
            cmm.Parameters.AddWithValue("@date_creation", ad.date_creation);
            cmm.Parameters.AddWithValue("@expiration_date", ad.expiration_date);
            cmm.Parameters.AddWithValue("@title", ad.title);
            cmm.Parameters.AddWithValue("@state", ad.state);
            cmm.Parameters.AddWithValue("@city", ad.city);
            cmm.Parameters.AddWithValue("@exitState", ad.exitState);
            cmm.Parameters.AddWithValue("@exitTown", ad.exitTown);
            cmm.Parameters.AddWithValue("@start", ad.start);
            cmm.Parameters.AddWithValue("@end", ad.end);
            cmm.Parameters.AddWithValue("@quantity_people", ad.quantity_people);
            cmm.Parameters.AddWithValue("@maximum_route_value", ad.maximum_route_value);
            cmm.Parameters.AddWithValue("@departure_date", ad.departure_date);
            cmm.Parameters.AddWithValue("@description", ad.description);
            cmm.Parameters.AddWithValue("@active", ad.active);
            cmm.Parameters.AddWithValue("@id_owner_ad", ad.id_owner_ad);

            cnn.executeQuery(cmm);

        } // Salva anúncio de oferta de carona

        public void saveSearchCompany(Advertisement ad, int pId)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            string dateString = "2000/01/01";
            DateTime date1 = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);

            ad.type_ad = "Procura Companhia";
            ad.date_creation = DateTime.Now;
            ad.active = 1;
            ad.id_owner_ad = pId;
            ad.departure_date = date1;

            sql.Append("INSERT INTO advertisement (type_ad, date_creation, expiration_date, title, " +
                                                  "state, city, start, end, departure_date, finality, description, active, id_owner_ad) ");
            sql.Append("VALUES (@type_ad, @date_creation, @expiration_date, @title, " +
                               "@state, @city, @start, @end, @departure_date, @finality, @description, @active, @id_owner_ad )");

            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@type_ad", ad.type_ad);
            cmm.Parameters.AddWithValue("@date_creation", ad.date_creation);
            cmm.Parameters.AddWithValue("@expiration_date", ad.expiration_date);
            cmm.Parameters.AddWithValue("@title", ad.title);
            cmm.Parameters.AddWithValue("@state", ad.state);
            cmm.Parameters.AddWithValue("@city", ad.city);
            cmm.Parameters.AddWithValue("@start", ad.checkin);
            cmm.Parameters.AddWithValue("@end", ad.checkout);
            cmm.Parameters.AddWithValue("@departure_date", ad.departure_date); //data falsa
            cmm.Parameters.AddWithValue("@finality", ad.finality);
            cmm.Parameters.AddWithValue("@description", ad.description);
            cmm.Parameters.AddWithValue("@active", ad.active);
            cmm.Parameters.AddWithValue("@id_owner_ad", ad.id_owner_ad);

            cnn.executeQuery(cmm);

        }// Salva anúncio de procura por companhia

        public IEnumerable<Advertisement> searchAd(int pIdOwner)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            List<Advertisement> adList = new List<Advertisement>();

            sql.Append("SELECT ad.id_advertisement, ad.type_ad, ad.date_creation, ad.expiration_date, ad.title, ad.state, " +
                       "ad.city, ad.exitState, ad.exitTown, ad.start, ad.end, ad.accommodation_type, ad.quantity_people, ad.maximum_people_value, " +
                       "ad.maximum_route_value, ad.local_exit, ad.departure_date, ad.finality, ad.description, ad.active, ad.id_owner_ad, " +
                       "u.name_user, u.image ");
            sql.Append("FROM advertisement ad ");
            sql.Append("INNER JOIN users u ");
            sql.Append("ON u.id_user = ad.id_owner_ad ");
            sql.Append("WHERE ad.id_owner_ad = @pIdOwner ");
            sql.Append("ORDER by ad.date_creation DESC");
            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@pIdOwner", pIdOwner);
            MySqlDataReader dr = cnn.executeQuery(cmm);

            while (dr.Read())
            {
                Advertisement adv = new Advertisement
                {
                    id_advertisement = (int)dr["id_advertisement"],
                    type_ad = (string)dr["type_ad"],
                    date_creation = (DateTime)dr["date_creation"],
                    expiration_date = (DateTime)dr["expiration_date"],
                    title = (string)dr["title"],
                    state = (string)dr["state"],
                    city = dr.IsDBNull(dr.GetOrdinal("city")) ? "" : (string)dr["city"],
                    exitState = dr.IsDBNull(dr.GetOrdinal("exitState")) ? "" : (string)dr["exitState"],
                    exitTown = dr.IsDBNull(dr.GetOrdinal("exitTown")) ? "" : (string)dr["exitTown"],
                    start = (DateTime)dr["start"],
                    end = (DateTime)dr["end"],
                    accommodation_type = dr.IsDBNull(dr.GetOrdinal("accommodation_type")) ? "" : (string)dr["accommodation_type"],
                    quantity_people = dr.IsDBNull(dr.GetOrdinal("quantity_people")) ? 0 : (int)dr["quantity_people"],
                    maximum_people_value = dr.IsDBNull(dr.GetOrdinal("maximum_people_value")) ? 0 : (double)dr["maximum_people_value"],
                    maximum_route_value = dr.IsDBNull(dr.GetOrdinal("maximum_route_value")) ? 0 : (double)dr["maximum_route_value"],
                    local_exit = dr.IsDBNull(dr.GetOrdinal("local_exit")) ? "" : (string)dr["local_exit"],
                    departure_date = (DateTime)dr["departure_date"],
                    finality = dr.IsDBNull(dr.GetOrdinal("finality")) ? "" : (string)dr["finality"],
                    description = dr.IsDBNull(dr.GetOrdinal("description")) ? "" : (string)dr["description"],
                    active = (int)dr["active"],
                    id_owner_ad = (int)dr["id_owner_ad"],
                    User = new Users
                    {
                        name_user = (string)dr["name_user"],
                        image = dr.IsDBNull(dr.GetOrdinal("image")) ? "" : (string)dr["image"],
                    }
                };

                adList.Add(adv);
            }

            dr.Dispose();
            return adList;
        }// Retorna lista dos anúncios do usuários

        public Advertisement getOneAd(int pIdOwner, int pIdAd)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            List<Advertisement> adList = new List<Advertisement>();

            sql.Append("SELECT ad.id_advertisement, ad.type_ad, ad.date_creation, ad.expiration_date, ad.title, ad.state, " +
                       "ad.city, ad.exitState, ad.exitTown, ad.start, ad.end, ad.accommodation_type, ad.quantity_people, ad.maximum_people_value, " +
                       "ad.maximum_route_value, ad.local_exit, ad.departure_date, ad.finality, ad.description, ad.active, ad.id_owner_ad, " +
                       "u.name_user, u.image  ");
            sql.Append("FROM advertisement ad ");
            sql.Append("INNER JOIN users u ");
            sql.Append("ON u.id_user = ad.id_owner_ad ");
            sql.Append("WHERE ad.id_advertisement = @pIdAd AND ad.id_owner_ad = @pIdOwner ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@pIdAd", pIdAd);
            cmm.Parameters.AddWithValue("@pIdOwner", pIdOwner);
            MySqlDataReader dr = cnn.executeQuery(cmm);

            dr.Read();

            Advertisement ad = new Advertisement
            {
                id_advertisement = (int)dr["id_advertisement"],
                type_ad = (string)dr["type_ad"],
                date_creation = (DateTime)dr["date_creation"],
                expiration_date = (DateTime)dr["expiration_date"],
                title = (string)dr["title"],
                state = (string)dr["state"],
                city = dr.IsDBNull(dr.GetOrdinal("city")) ? "" : (string)dr["city"],
                exitState = dr.IsDBNull(dr.GetOrdinal("exitState")) ? "" : (string)dr["exitState"],
                exitTown = dr.IsDBNull(dr.GetOrdinal("exitTown")) ? "" : (string)dr["exitTown"],
                start = (DateTime)dr["start"],
                end = (DateTime)dr["end"],
                accommodation_type = dr.IsDBNull(dr.GetOrdinal("accommodation_type")) ? "" : (string)dr["accommodation_type"],
                quantity_people = dr.IsDBNull(dr.GetOrdinal("quantity_people")) ? 0 : (int)dr["quantity_people"],
                maximum_people_value = dr.IsDBNull(dr.GetOrdinal("maximum_people_value")) ? 0 : (double)dr["maximum_people_value"],
                maximum_route_value = dr.IsDBNull(dr.GetOrdinal("maximum_route_value")) ? 0 : (double)dr["maximum_route_value"],
                local_exit = dr.IsDBNull(dr.GetOrdinal("local_exit")) ? "" : (string)dr["local_exit"],
                departure_date = (DateTime)dr["departure_date"],
                finality = dr.IsDBNull(dr.GetOrdinal("finality")) ? "" : (string)dr["finality"],
                description = dr.IsDBNull(dr.GetOrdinal("description")) ? "" : (string)dr["description"],
                active = (int)dr["active"],
                id_owner_ad = (int)dr["id_owner_ad"],
                User = new Users
                {
                    name_user = (string)dr["name_user"],
                    image = dr.IsDBNull(dr.GetOrdinal("image")) ? "" : (string)dr["image"],
                }
            };

            dr.Dispose();
            return ad;
        }// Retorna um anúncio específico

        public void deleteAd(int pIdAd, int pIdOwnerAd)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("DELETE FROM advertisement ");
            sql.Append("WHERE id_advertisement = @pIdAd AND id_owner_ad = @pIdOwnerAd");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@pIdAd", pIdAd);
            cmm.Parameters.AddWithValue("@pIdOwnerAd", pIdOwnerAd);

            cnn.executeQuery(cmm);
        }

        public void editAd (Advertisement ad, int id_owner)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("UPDATE advertisement ");
            sql.Append("SET expiration_date = @expiration_date, title = @title, state = @state, city = @city, exitState = @exitState, exitTown = @exitTown, ");
            sql.Append("start = @start, end = @end, accommodation_type = @accommodation_type, quantity_people = @quantity_people, maximum_people_value = @maximum_people_value, ");
            sql.Append("maximum_route_value = @maximum_route_value, local_exit = @local_exit, departure_date = @departure_date, finality = @finality, description = @description ");
            sql.Append("WHERE id_advertisement = @id_advertisement AND id_owner_ad = @id_owner");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@expiration_date", ad.expiration_date);
            cmm.Parameters.AddWithValue("@title", ad.title);
            cmm.Parameters.AddWithValue("@state", ad.state);
            cmm.Parameters.AddWithValue("@city", ad.city);
            cmm.Parameters.AddWithValue("@exitState", ad.exitState);
            cmm.Parameters.AddWithValue("@exitTown", ad.exitTown);
            cmm.Parameters.AddWithValue("@start", ad.checkin);
            cmm.Parameters.AddWithValue("@start", ad.start);
            cmm.Parameters.AddWithValue("@end", ad.checkout);
            cmm.Parameters.AddWithValue("@end", ad.end);
            cmm.Parameters.AddWithValue("@accommodation_type", ad.accommodation_type);
            cmm.Parameters.AddWithValue("@quantity_people", ad.quantity_people);
            cmm.Parameters.AddWithValue("@maximum_people_value", ad.maximum_people_value);
            cmm.Parameters.AddWithValue("@maximum_route_value", ad.maximum_route_value);
            cmm.Parameters.AddWithValue("@local_exit",ad.local_exit);
            cmm.Parameters.AddWithValue("@departure_date", ad.departure_date);
            cmm.Parameters.AddWithValue("@finality", ad.finality);
            cmm.Parameters.AddWithValue("@description", ad.description);
            cmm.Parameters.AddWithValue("@id_owner", id_owner);

            cnn.executeQuery(cmm);
        }//Deixar em off

        public void editAdHosting(EditAdOfferHosting ad, int id_owner, int idAd)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("UPDATE advertisement ");
            sql.Append("SET expiration_date = @expiration_date, title = @title, state = @state, city = @city, ");
            sql.Append("start = @start, end = @end, accommodation_type = @accommodation_type, ");
            sql.Append("quantity_people = @quantity_people, maximum_people_value = @maximum_people_value, description = @description ");
            sql.Append("WHERE id_advertisement = @id_advertisement AND id_owner_ad = @id_owner");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@id_advertisement", idAd);
            cmm.Parameters.AddWithValue("@expiration_date", ad.expiration_date);
            cmm.Parameters.AddWithValue("@title", ad.title);
            cmm.Parameters.AddWithValue("@state", ad.state);
            cmm.Parameters.AddWithValue("@city", ad.city);
            cmm.Parameters.AddWithValue("@start", ad.start);
            cmm.Parameters.AddWithValue("@end", ad.end);
            cmm.Parameters.AddWithValue("@accommodation_type", ad.accommodation_type);
            cmm.Parameters.AddWithValue("@quantity_people", ad.quantity_people);
            cmm.Parameters.AddWithValue("@maximum_people_value", ad.maximum_people_value);
            cmm.Parameters.AddWithValue("@description", ad.description);
            cmm.Parameters.AddWithValue("@id_owner", id_owner);

            cnn.executeQuery(cmm);

        }

        public void editAdHosting1(EditAdOfferHosting ad, int id_owner, int idAd)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("UPDATE advertisement ");
            sql.Append("SET expiration_date = @expiration_date, title = @title, state = @state, city = @city, ");
            sql.Append("start = @start, end = @end, accommodation_type = @accommodation_type, ");
            sql.Append("quantity_people = @quantity_people, maximum_people_value = @maximum_people_value, description = @description ");
            sql.Append("WHERE id_advertisement = @id_advertisement AND id_owner_ad = @id_owner");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@id_advertisement", idAd);
            cmm.Parameters.AddWithValue("@expiration_date", ad.expiration_date);
            cmm.Parameters.AddWithValue("@title", ad.title);
            cmm.Parameters.AddWithValue("@state", ad.state);
            cmm.Parameters.AddWithValue("@city", ad.city);
            cmm.Parameters.AddWithValue("@start", ad.checkin);
            cmm.Parameters.AddWithValue("@end", ad.checkout);
            cmm.Parameters.AddWithValue("@accommodation_type", ad.accommodation_type);
            cmm.Parameters.AddWithValue("@quantity_people", ad.quantity_people);
            cmm.Parameters.AddWithValue("@maximum_people_value", ad.maximum_people_value);
            cmm.Parameters.AddWithValue("@description", ad.description);
            cmm.Parameters.AddWithValue("@id_owner", id_owner);

            cnn.executeQuery(cmm);

        }

        public void editAdRide(EditAdOfferRide ad, int id_owner, int idAd)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("UPDATE advertisement ");
            sql.Append("SET expiration_date = @expiration_date, title = @title, state = @state, city = @city, ");
            sql.Append("exitState = @exitState, exitTown = @exitTown, quantity_people = @quantity_people, maximum_route_value = @maximum_route_value,");
            sql.Append("local_exit = @local_exit, departure_date = @departure_date, description = @description ");
            sql.Append("WHERE id_advertisement = @idAd AND id_owner_ad = @id_owner");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@idAd", idAd);
            cmm.Parameters.AddWithValue("@expiration_date", ad.expiration_date);
            cmm.Parameters.AddWithValue("@title", ad.title);
            cmm.Parameters.AddWithValue("@state", ad.state);
            cmm.Parameters.AddWithValue("@city", ad.city);
            cmm.Parameters.AddWithValue("@exitState", ad.exitState);
            cmm.Parameters.AddWithValue("@exitTown", ad.exitTown);
            cmm.Parameters.AddWithValue("@quantity_people", ad.quantity_people);
            cmm.Parameters.AddWithValue("@maximum_route_value", ad.maximum_route_value);
            cmm.Parameters.AddWithValue("@local_exit", ad.local_exit);
            cmm.Parameters.AddWithValue("@departure_date", ad.departure_date);
            cmm.Parameters.AddWithValue("@description", ad.description);
            cmm.Parameters.AddWithValue("@id_owner", id_owner);

            cnn.executeQuery(cmm);


        }

        public void editAdCompany(EditAdCompany ad, int id_owner, int idAd)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();

            sql.Append("UPDATE advertisement ");
            sql.Append("SET expiration_date = @expiration_date, title = @title, ");
            sql.Append("state = @state, city = @city, start = @start, end = @end, ");
            sql.Append("finality = @finality, description = @description ");
            sql.Append("WHERE id_advertisement = @id_advertisement AND id_owner_ad = @id_owner");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@id_advertisement", idAd);
            cmm.Parameters.AddWithValue("@expiration_date", ad.expiration_date);
            cmm.Parameters.AddWithValue("@title", ad.title);
            cmm.Parameters.AddWithValue("@state", ad.state);
            cmm.Parameters.AddWithValue("@city", ad.city);
            cmm.Parameters.AddWithValue("@start", ad.checkin);
            cmm.Parameters.AddWithValue("@end", ad.checkout);
            cmm.Parameters.AddWithValue("@finality", ad.finality);
            cmm.Parameters.AddWithValue("@description", ad.description);
            cmm.Parameters.AddWithValue("@id_owner", id_owner);

            cnn.executeQuery(cmm);

        }

        public void ChangeStatusAnnouncement(int idAd, int active)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
          
            sql.Append("UPDATE advertisement ");
            sql.Append("SET active = @active ");
            sql.Append("WHERE id_advertisement = @idAd");

            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@idAd", idAd);
            cmm.Parameters.AddWithValue("@active", active);

            cnn.executeQuery(cmm);
        }

        public IEnumerable<Advertisement> listAdTimeLine(string state, DateTime currentDate, int idUser)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            List<Advertisement> adList = new List<Advertisement>();

            sql.Append("SELECT ad.id_advertisement, ad.type_ad, ad.date_creation, ad.expiration_date, ad.title, ad.state, " +
                       "ad.city, ad.exitState, ad.exitTown, ad.start, ad.end, ad.accommodation_type, ad.quantity_people, ad.maximum_people_value, " +
                       "ad.maximum_route_value, ad.local_exit, ad.departure_date, ad.finality, ad.description, ad.active, ad.id_owner_ad, " +
                       "u.image, u.name_user, u.state ");
            sql.Append("FROM advertisement ad ");
            sql.Append("INNER JOIN users u ");
            sql.Append("ON u.id_user = ad.id_owner_ad ");
            sql.Append("WHERE (ad.state LIKE @state OR ad.exitState LIKE @state OR ad.id_owner_ad = @idUser) AND (ad.active = 1) AND (ad.expiration_date >= @currentDate ) AND (u.active = 1) ");
            sql.Append("ORDER by ad.date_creation DESC");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@state", "%" + state + "%");
            cmm.Parameters.AddWithValue("@currentDate", currentDate);
            cmm.Parameters.AddWithValue("@idUser", idUser);
            MySqlDataReader dr = cnn.executeQuery(cmm);

            while (dr.Read())
            {
                Advertisement adv = new Advertisement
                {
                    id_advertisement = (int)dr["id_advertisement"],
                    type_ad = (string)dr["type_ad"],
                    date_creation = (DateTime)dr["date_creation"],
                    expiration_date = (DateTime)dr["expiration_date"],
                    title = (string)dr["title"],
                    state = (string)dr["state"],
                    city = dr.IsDBNull(dr.GetOrdinal("city")) ? "" : (string)dr["city"],
                    exitState = dr.IsDBNull(dr.GetOrdinal("exitState")) ? "" : (string)dr["exitState"],
                    exitTown = dr.IsDBNull(dr.GetOrdinal("exitTown")) ? "" : (string)dr["exitTown"],
                    start = (DateTime)dr["start"],
                    end = (DateTime)dr["end"],
                    accommodation_type = dr.IsDBNull(dr.GetOrdinal("accommodation_type")) ? "" : (string)dr["accommodation_type"],
                    quantity_people = dr.IsDBNull(dr.GetOrdinal("quantity_people")) ? 0 : (int)dr["quantity_people"],
                    maximum_people_value = dr.IsDBNull(dr.GetOrdinal("maximum_people_value")) ? 0 : (double)dr["maximum_people_value"],
                    maximum_route_value = dr.IsDBNull(dr.GetOrdinal("maximum_route_value")) ? 0 : (double)dr["maximum_route_value"],
                    local_exit = dr.IsDBNull(dr.GetOrdinal("local_exit")) ? "" : (string)dr["local_exit"],
                    departure_date = (DateTime)dr["departure_date"],
                    finality = dr.IsDBNull(dr.GetOrdinal("finality")) ? "" : (string)dr["finality"],
                    description = dr.IsDBNull(dr.GetOrdinal("description")) ? "" : (string)dr["description"],
                    active = (int)dr["active"],
                    id_owner_ad = (int)dr["id_owner_ad"],
                    User = new Users
                    {
                        name_user = (string)dr["name_user"],
                        image = dr.IsDBNull(dr.GetOrdinal("image")) ? "" : (string)dr["image"],
                        state = (string)dr["state"]
                    }

                };
                adList.Add(adv);
            }

            dr.Dispose();
            return adList;
        }

        public EditAdCompany getOneAd1(int pIdOwner, int pIdAd)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            List<EditAdCompany> adList = new List<EditAdCompany>();

            sql.Append("SELECT id_advertisement, expiration_date, title, state, " +
                       "city, start, end, finality, description, id_owner_ad ");                       
            sql.Append("FROM advertisement ");
            sql.Append("WHERE id_advertisement = @pIdAd AND id_owner_ad = @pIdOwner ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@pIdAd", pIdAd);
            cmm.Parameters.AddWithValue("@pIdOwner", pIdOwner);
            MySqlDataReader dr = cnn.executeQuery(cmm);

            dr.Read();

            EditAdCompany ad = new EditAdCompany
            {
                id_advertisement = (int)dr["id_advertisement"],
                expiration_date = (DateTime)dr["expiration_date"],
                title = (string)dr["title"],
                state = (string)dr["state"],
                city = dr.IsDBNull(dr.GetOrdinal("city")) ? "" : (string)dr["city"],
                checkin = (DateTime)dr["start"],
                checkout = (DateTime)dr["end"],
                finality = dr.IsDBNull(dr.GetOrdinal("finality")) ? "" : (string)dr["finality"],
                description = dr.IsDBNull(dr.GetOrdinal("description")) ? "" : (string)dr["description"],
                id_owner_ad = (int)dr["id_owner_ad"]
                
            };
            dr.Dispose();
            return ad;
        }

        public EditAdOfferRide getOneAd2(int pIdOwner, int pIdAd)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            List<EditAdOfferRide> adList = new List<EditAdOfferRide>();

            sql.Append("SELECT id_advertisement, expiration_date, title, state, " +
                       "city, exitState, exitTown, quantity_people, " +
                       "maximum_route_value, local_exit, departure_date, description, id_owner_ad ");
            sql.Append("FROM advertisement ");
            sql.Append("WHERE id_advertisement = @pIdAd AND id_owner_ad = @pIdOwner ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@pIdAd", pIdAd);
            cmm.Parameters.AddWithValue("@pIdOwner", pIdOwner);
            MySqlDataReader dr = cnn.executeQuery(cmm);

            dr.Read();

            EditAdOfferRide ad = new EditAdOfferRide
            {
                id_advertisement = (int)dr["id_advertisement"],
                expiration_date = (DateTime)dr["expiration_date"],
                title = (string)dr["title"],
                state = (string)dr["state"],
                city = dr.IsDBNull(dr.GetOrdinal("city")) ? "" : (string)dr["city"],
                exitState = dr.IsDBNull(dr.GetOrdinal("exitState")) ? "" : (string)dr["exitState"],
                exitTown = dr.IsDBNull(dr.GetOrdinal("exitTown")) ? "" : (string)dr["exitTown"],
                quantity_people = dr.IsDBNull(dr.GetOrdinal("quantity_people")) ? 0 : (int)dr["quantity_people"],
                maximum_route_value = dr.IsDBNull(dr.GetOrdinal("maximum_route_value")) ? 0 : (double)dr["maximum_route_value"],
                local_exit = dr.IsDBNull(dr.GetOrdinal("local_exit")) ? "" : (string)dr["local_exit"],
                departure_date = (DateTime)dr["departure_date"],
                description = dr.IsDBNull(dr.GetOrdinal("description")) ? "" : (string)dr["description"],
                id_owner_ad = (int)dr["id_owner_ad"]
            };
            dr.Dispose();
            return ad;
        }

        public EditAdOfferHosting getOneAd3(int pIdOwner, int pIdAd)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            List<EditAdOfferHosting> adList = new List<EditAdOfferHosting>();

            sql.Append("SELECT id_advertisement, expiration_date, title, state, " +
                       "city, start, end, accommodation_type, quantity_people, maximum_people_value, " +
                       "description, id_owner_ad ");
            sql.Append("FROM advertisement ");
            sql.Append("WHERE id_advertisement = @pIdAd AND id_owner_ad = @pIdOwner ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@pIdAd", pIdAd);
            cmm.Parameters.AddWithValue("@pIdOwner", pIdOwner);
            MySqlDataReader dr = cnn.executeQuery(cmm);

            dr.Read();

            EditAdOfferHosting ad = new EditAdOfferHosting
            {
                id_advertisement = (int)dr["id_advertisement"],
                expiration_date = (DateTime)dr["expiration_date"],
                title = (string)dr["title"],
                state = (string)dr["state"],
                city = dr.IsDBNull(dr.GetOrdinal("city")) ? "" : (string)dr["city"],
                start = (DateTime)dr["start"],
                end = (DateTime)dr["end"],
                accommodation_type = dr.IsDBNull(dr.GetOrdinal("accommodation_type")) ? "" : (string)dr["accommodation_type"],
                quantity_people = dr.IsDBNull(dr.GetOrdinal("quantity_people")) ? 0 : (int)dr["quantity_people"],
                maximum_people_value = dr.IsDBNull(dr.GetOrdinal("maximum_people_value")) ? 0 : (double)dr["maximum_people_value"],
                description = dr.IsDBNull(dr.GetOrdinal("description")) ? "" : (string)dr["description"],
                id_owner_ad = (int)dr["id_owner_ad"]
            };

            dr.Dispose();
            return ad;
        }

        public EditAdOfferHosting getOneAd4(int pIdOwner, int pIdAd)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            List<EditAdOfferHosting> adList = new List<EditAdOfferHosting>();

            sql.Append("SELECT id_advertisement, expiration_date, title, state, " +
                       "city, start, end, accommodation_type, quantity_people, maximum_people_value, " +
                       "description, id_owner_ad ");
            sql.Append("FROM advertisement ");
            sql.Append("WHERE id_advertisement = @pIdAd AND id_owner_ad = @pIdOwner ");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@pIdAd", pIdAd);
            cmm.Parameters.AddWithValue("@pIdOwner", pIdOwner);
            MySqlDataReader dr = cnn.executeQuery(cmm);

            dr.Read();

            EditAdOfferHosting ad = new EditAdOfferHosting
            {
                id_advertisement = (int)dr["id_advertisement"],
                expiration_date = (DateTime)dr["expiration_date"],
                title = (string)dr["title"],
                state = (string)dr["state"],
                city = dr.IsDBNull(dr.GetOrdinal("city")) ? "" : (string)dr["city"],
                checkin = (DateTime)dr["start"],
                checkout = (DateTime)dr["end"],
                accommodation_type = dr.IsDBNull(dr.GetOrdinal("accommodation_type")) ? "" : (string)dr["accommodation_type"],
                quantity_people = dr.IsDBNull(dr.GetOrdinal("quantity_people")) ? 0 : (int)dr["quantity_people"],
                maximum_people_value = dr.IsDBNull(dr.GetOrdinal("maximum_people_value")) ? 0 : (double)dr["maximum_people_value"],
                description = dr.IsDBNull(dr.GetOrdinal("description")) ? "" : (string)dr["description"],
                id_owner_ad = (int)dr["id_owner_ad"]
            };

            dr.Dispose();
            return ad;
        }


        public IEnumerable<Advertisement> listAdType(string pType, DateTime currentDate)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            List<Advertisement> adList = new List<Advertisement>();

            sql.Append("SELECT ad.id_advertisement, ad.type_ad, ad.date_creation, ad.expiration_date, ad.title, ad.state, " +
                       "ad.city, ad.exitState, ad.exitTown, ad.start, ad.end, ad.accommodation_type, ad.quantity_people, ad.maximum_people_value, " +
                       "ad.maximum_route_value, ad.local_exit, ad.departure_date, ad.finality, ad.description, ad.active, ad.id_owner_ad, " +
                       "u.image, u.name_user, u.state ");
            sql.Append("FROM advertisement ad ");
            sql.Append("INNER JOIN users u ");
            sql.Append("ON u.id_user = ad.id_owner_ad ");
            sql.Append("WHERE (ad.type_ad = @pType) AND (ad.active = 1) AND (ad.expiration_date >= @currentDate ) AND (u.active = 1) ");
            sql.Append("ORDER by ad.date_creation DESC");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@pType", pType);
            cmm.Parameters.AddWithValue("@currentDate", currentDate);
            MySqlDataReader dr = cnn.executeQuery(cmm);

            while (dr.Read())
            {
                Advertisement adv = new Advertisement
                {
                    id_advertisement = (int)dr["id_advertisement"],
                    type_ad = (string)dr["type_ad"],
                    date_creation = (DateTime)dr["date_creation"],
                    expiration_date = (DateTime)dr["expiration_date"],
                    title = (string)dr["title"],
                    state = (string)dr["state"],
                    city = dr.IsDBNull(dr.GetOrdinal("city")) ? "" : (string)dr["city"],
                    exitState = dr.IsDBNull(dr.GetOrdinal("exitState")) ? "" : (string)dr["exitState"],
                    exitTown = dr.IsDBNull(dr.GetOrdinal("exitTown")) ? "" : (string)dr["exitTown"],
                    start = (DateTime)dr["start"],
                    end = (DateTime)dr["end"],
                    accommodation_type = dr.IsDBNull(dr.GetOrdinal("accommodation_type")) ? "" : (string)dr["accommodation_type"],
                    quantity_people = dr.IsDBNull(dr.GetOrdinal("quantity_people")) ? 0 : (int)dr["quantity_people"],
                    maximum_people_value = dr.IsDBNull(dr.GetOrdinal("maximum_people_value")) ? 0 : (double)dr["maximum_people_value"],
                    maximum_route_value = dr.IsDBNull(dr.GetOrdinal("maximum_route_value")) ? 0 : (double)dr["maximum_route_value"],
                    local_exit = dr.IsDBNull(dr.GetOrdinal("local_exit")) ? "" : (string)dr["local_exit"],
                    departure_date = (DateTime)dr["departure_date"],
                    finality = dr.IsDBNull(dr.GetOrdinal("finality")) ? "" : (string)dr["finality"],
                    description = dr.IsDBNull(dr.GetOrdinal("description")) ? "" : (string)dr["description"],
                    active = (int)dr["active"],
                    id_owner_ad = (int)dr["id_owner_ad"],
                    User = new Users
                    {
                        name_user = (string)dr["name_user"],
                        image = dr.IsDBNull(dr.GetOrdinal("image")) ? "" : (string)dr["image"],
                        state = (string)dr["state"]
                    }

                };
                adList.Add(adv);
            }
            dr.Dispose();
            return adList;
        }

        public IEnumerable<Advertisement> listAdRide(RideSearch rideSearch, string type)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            List<Advertisement> adList = new List<Advertisement>();
            DateTime currentDate = DateTime.Now;

            sql.Append("SELECT ad.id_advertisement, ad.type_ad, ad.date_creation, ad.expiration_date, ad.title, ad.state, " +
                       "ad.city, ad.exitState, ad.exitTown, ad.start, ad.end, ad.accommodation_type, ad.quantity_people, ad.maximum_people_value, " +
                       "ad.maximum_route_value, ad.local_exit, ad.departure_date, ad.finality, ad.description, ad.active, ad.id_owner_ad, " +
                       "u.image, u.name_user, u.state ");
            sql.Append("FROM advertisement ad ");
            sql.Append("INNER JOIN users u ");
            sql.Append("ON u.id_user = ad.id_owner_ad ");
            sql.Append("WHERE (ad.exitState LIKE @exitState) AND (ad.exitTown LIKE @exitTown) AND (ad.state LIKE @state) AND (ad.city LIKE @city ) " +
                       "AND (ad.type_ad = @type) AND (ad.active = 1) AND (ad.expiration_date >= @currentDate ) AND (u.active = 1) ");
            sql.Append("ORDER by ad.date_creation DESC");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@exitState", "%" + rideSearch.exitState + "%");
            cmm.Parameters.AddWithValue("@exitTown", "%" + rideSearch.exitTown + "%");
            cmm.Parameters.AddWithValue("@state", "%" + rideSearch.state + "%");
            cmm.Parameters.AddWithValue("@city", "%" + rideSearch.city + "%");
            cmm.Parameters.AddWithValue("@currentDate", currentDate);
            cmm.Parameters.AddWithValue("@type", type);

            MySqlDataReader dr = cnn.executeQuery(cmm);

            while (dr.Read())
            {
                Advertisement adv = new Advertisement
                {
                    id_advertisement = (int)dr["id_advertisement"],
                    type_ad = (string)dr["type_ad"],
                    date_creation = (DateTime)dr["date_creation"],
                    expiration_date = (DateTime)dr["expiration_date"],
                    title = (string)dr["title"],
                    state = (string)dr["state"],
                    city = dr.IsDBNull(dr.GetOrdinal("city")) ? "" : (string)dr["city"],
                    exitState = dr.IsDBNull(dr.GetOrdinal("exitState")) ? "" : (string)dr["exitState"],
                    exitTown = dr.IsDBNull(dr.GetOrdinal("exitTown")) ? "" : (string)dr["exitTown"],
                    start = (DateTime)dr["start"],
                    end = (DateTime)dr["end"],
                    accommodation_type = dr.IsDBNull(dr.GetOrdinal("accommodation_type")) ? "" : (string)dr["accommodation_type"],
                    quantity_people = dr.IsDBNull(dr.GetOrdinal("quantity_people")) ? 0 : (int)dr["quantity_people"],
                    maximum_people_value = dr.IsDBNull(dr.GetOrdinal("maximum_people_value")) ? 0 : (double)dr["maximum_people_value"],
                    maximum_route_value = dr.IsDBNull(dr.GetOrdinal("maximum_route_value")) ? 0 : (double)dr["maximum_route_value"],
                    local_exit = dr.IsDBNull(dr.GetOrdinal("local_exit")) ? "" : (string)dr["local_exit"],
                    departure_date = (DateTime)dr["departure_date"],
                    finality = dr.IsDBNull(dr.GetOrdinal("finality")) ? "" : (string)dr["finality"],
                    description = dr.IsDBNull(dr.GetOrdinal("description")) ? "" : (string)dr["description"],
                    active = (int)dr["active"],
                    id_owner_ad = (int)dr["id_owner_ad"],
                    User = new Users
                    {
                        name_user = (string)dr["name_user"],
                        image = dr.IsDBNull(dr.GetOrdinal("image")) ? "" : (string)dr["image"],
                        state = (string)dr["state"]
                    }

                };
                adList.Add(adv);
            }
            dr.Dispose();
            return adList;
        }

        public IEnumerable<Advertisement> listAdHosting(HostingSearch hostingSearch, string type)
        {
            cnn.disconnecti();
            MySqlCommand cmm = new MySqlCommand();
            StringBuilder sql = new StringBuilder();
            List<Advertisement> adList = new List<Advertisement>();
            DateTime currentDate = DateTime.Now;

            sql.Append("SELECT ad.id_advertisement, ad.type_ad, ad.date_creation, ad.expiration_date, ad.title, ad.state, " +
                       "ad.city, ad.exitState, ad.exitTown, ad.start, ad.end, ad.accommodation_type, ad.quantity_people, ad.maximum_people_value, " +
                       "ad.maximum_route_value, ad.local_exit, ad.departure_date, ad.finality, ad.description, ad.active, ad.id_owner_ad, " +
                       "u.image, u.name_user, u.state ");
            sql.Append("FROM advertisement ad ");
            sql.Append("INNER JOIN users u ");
            sql.Append("ON u.id_user = ad.id_owner_ad ");
            sql.Append("WHERE (ad.state LIKE @state) AND (ad.city LIKE @city ) " +
                       "AND (ad.type_ad = @type) AND (ad.active = 1) AND (ad.expiration_date >= @currentDate ) AND (u.active = 1) ");
            sql.Append("ORDER by ad.date_creation DESC");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@state", "%" + hostingSearch.state + "%");
            cmm.Parameters.AddWithValue("@city", "%" + hostingSearch.city + "%");
            cmm.Parameters.AddWithValue("@currentDate", currentDate);
            cmm.Parameters.AddWithValue("@type", type);

            MySqlDataReader dr = cnn.executeQuery(cmm);

            while (dr.Read())
            {
                Advertisement adv = new Advertisement
                {
                    id_advertisement = (int)dr["id_advertisement"],
                    type_ad = (string)dr["type_ad"],
                    date_creation = (DateTime)dr["date_creation"],
                    expiration_date = (DateTime)dr["expiration_date"],
                    title = (string)dr["title"],
                    state = (string)dr["state"],
                    city = dr.IsDBNull(dr.GetOrdinal("city")) ? "" : (string)dr["city"],
                    exitState = dr.IsDBNull(dr.GetOrdinal("exitState")) ? "" : (string)dr["exitState"],
                    exitTown = dr.IsDBNull(dr.GetOrdinal("exitTown")) ? "" : (string)dr["exitTown"],
                    start = (DateTime)dr["start"],
                    end = (DateTime)dr["end"],
                    accommodation_type = dr.IsDBNull(dr.GetOrdinal("accommodation_type")) ? "" : (string)dr["accommodation_type"],
                    quantity_people = dr.IsDBNull(dr.GetOrdinal("quantity_people")) ? 0 : (int)dr["quantity_people"],
                    maximum_people_value = dr.IsDBNull(dr.GetOrdinal("maximum_people_value")) ? 0 : (double)dr["maximum_people_value"],
                    maximum_route_value = dr.IsDBNull(dr.GetOrdinal("maximum_route_value")) ? 0 : (double)dr["maximum_route_value"],
                    local_exit = dr.IsDBNull(dr.GetOrdinal("local_exit")) ? "" : (string)dr["local_exit"],
                    departure_date = (DateTime)dr["departure_date"],
                    finality = dr.IsDBNull(dr.GetOrdinal("finality")) ? "" : (string)dr["finality"],
                    description = dr.IsDBNull(dr.GetOrdinal("description")) ? "" : (string)dr["description"],
                    active = (int)dr["active"],
                    id_owner_ad = (int)dr["id_owner_ad"],
                    User = new Users
                    {
                        name_user = (string)dr["name_user"],
                        image = dr.IsDBNull(dr.GetOrdinal("image")) ? "" : (string)dr["image"],
                        state = (string)dr["state"]
                    }

                };
                adList.Add(adv);
            }
            dr.Dispose();
            return adList;
        }
    }       
}