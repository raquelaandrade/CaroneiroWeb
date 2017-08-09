using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using CaroneiroWeb.Models;
using System.Text;

namespace CaroneiroWeb.Repositories
{
    public class EmailServerAccount
    {
        public string sendEmail(string pReceiver)
        {
            string message;

            try
            {
                //crio objeto responsável pela mensagem de email
                MailMessage objEmail = new MailMessage();

                //rementente do email
                objEmail.From = new MailAddress("webcaroneiro@gmail.com");
                objEmail.To.Add(pReceiver);

                //email para resposta(quando o destinatário receber e clicar em responder, vai para:)
                objEmail.ReplyToList.Add(new MailAddress("webcaroneiro@gmail.com"));

                //prioridade do email
                objEmail.Priority = MailPriority.Normal;

                //utilize true pra ativar html no conteúdo do email, ou false, para somente texto
                objEmail.IsBodyHtml = true;

                //Assunto do email
                objEmail.Subject = "Confirmação de cadastro Caroneiro";


                //corpo do email a ser enviado
                objEmail.Body = "<h3>Bem-vindo ao Caroneiro</h3> " +
                                "<a href='http://localhost:64781/Access/ConfirmationRegister/'>Clique aqui</a> para confirmar a criação de seu cadastro";


                //codificação do assunto do email para que os caracteres acentuados serem reconhecidos.
                objEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");

                //codificação do corpo do emailpara que os caracteres acentuados serem reconhecidos.
                objEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

                //cria o objeto responsável pelo envio do email
                SmtpClient objSmtp = new SmtpClient();

                //endereço do servidor SMTP(para mais detalhes leia abaixo do código)
                objSmtp.Host = "smtp.gmail.com";

                objSmtp.Port = 587;

                objSmtp.UseDefaultCredentials = true;

                //para envio de email autenticado, coloque login e senha de seu servidor de email
                //para detalhes leia abaixo do código
                objSmtp.Credentials = new NetworkCredential("webcaroneiro@gmail.com", "caroneirotcc");
                objSmtp.EnableSsl = true;

                //envia o email
                objSmtp.Send(objEmail);

                message = "ok";
                return message;
            }
            catch
            {
                message = "falha";
                return message;

            };
        }// Envia email de confirmação de cadastro

        public string sendEmailContact(Contact contact)
        {

            string message;

            try
            {
                //crio objeto responsável pela mensagem de email
                MailMessage objEmail = new MailMessage();

                //rementente do email
                objEmail.From = new MailAddress("webcaroneiro@gmail.com");
                objEmail.To.Add("webcaroneiro@gmail.com");

                //email para resposta(quando o destinatário receber e clicar em responder, vai para:)
                objEmail.ReplyToList.Add(new MailAddress("webcaroneiro@gmail.com"));

                //prioridade do email
                objEmail.Priority = MailPriority.Normal;

                //utilize true pra ativar html no conteúdo do email, ou false, para somente texto
                objEmail.IsBodyHtml = true;

                //Assunto do email
                objEmail.Subject = contact.topic;


                //corpo do email a ser enviado
                objEmail.Body = "<h4>Nome: "+ contact.name +"</h4> <br> <h4>Email: "+contact.email+"</h4> <br> <h4>Mensagem: "+ contact.message+"</h4>";

                //codificação do assunto do email para que os caracteres acentuados serem reconhecidos.
                objEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");

                //codificação do corpo do emailpara que os caracteres acentuados serem reconhecidos.
                objEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

                //cria o objeto responsável pelo envio do email
                SmtpClient objSmtp = new SmtpClient();

                //endereço do servidor SMTP(para mais detalhes leia abaixo do código)
                objSmtp.Host = "smtp.gmail.com";

                objSmtp.Port = 587;

                objSmtp.UseDefaultCredentials = true;

                //para envio de email autenticado, coloque login e senha de seu servidor de email
                //para detalhes leia abaixo do código
                objSmtp.Credentials = new NetworkCredential("webcaroneiro@gmail.com", "caroneirotcc");
                objSmtp.EnableSsl = true;

                //envia o email
                objSmtp.Send(objEmail);

                message = "ok";
                return message;
            }
            catch
            {
                message = "falha";
                return message;

            };
        }

        public string sendEmailRecover(string email)
        {
            string message;

            try
            {
                //crio objeto responsável pela mensagem de email
                MailMessage objEmail = new MailMessage();

                //rementente do email
                objEmail.From = new MailAddress("webcaroneiro@gmail.com");
                objEmail.To.Add(email);

                //email para resposta(quando o destinatário receber e clicar em responder, vai para:)
                objEmail.ReplyToList.Add(new MailAddress("webcaroneiro@gmail.com"));

                //prioridade do email
                objEmail.Priority = MailPriority.Normal;

                //utilize true pra ativar html no conteúdo do email, ou false, para somente texto
                objEmail.IsBodyHtml = true;

                //Assunto do email
                objEmail.Subject = "Confirmação de cadastro Caroneiro";


                //corpo do email a ser enviado
                objEmail.Body = "<h3>Bem-vindo ao Caroneiro</h3> " +
                                "<a href='http://localhost:64781/Access/ConfirmationRegister/'>Clique aqui</a> para confirmar a criação de seu cadastro";


                //codificação do assunto do email para que os caracteres acentuados serem reconhecidos.
                objEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");

                //codificação do corpo do emailpara que os caracteres acentuados serem reconhecidos.
                objEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

                //cria o objeto responsável pelo envio do email
                SmtpClient objSmtp = new SmtpClient();

                //endereço do servidor SMTP(para mais detalhes leia abaixo do código)
                objSmtp.Host = "smtp.gmail.com";

                objSmtp.Port = 587;

                objSmtp.UseDefaultCredentials = true;

                //para envio de email autenticado, coloque login e senha de seu servidor de email
                //para detalhes leia abaixo do código
                objSmtp.Credentials = new NetworkCredential("webcaroneiro@gmail.com", "caroneirotcc");
                objSmtp.EnableSsl = true;

                //envia o email
                objSmtp.Send(objEmail);

                message = "ok";
                return message;
            }
            catch
            {
                message = "falha";
                return message;

            };
        }

        public string sendPassword(string email, string password)
        {
            string message;

            try
            {
                //crio objeto responsável pela mensagem de email
                MailMessage objEmail = new MailMessage();

                //rementente do email
                objEmail.From = new MailAddress("webcaroneiro@gmail.com");
                objEmail.To.Add(email);

                //email para resposta(quando o destinatário receber e clicar em responder, vai para:)
                objEmail.ReplyToList.Add(new MailAddress("webcaroneiro@gmail.com"));

                //prioridade do email
                objEmail.Priority = MailPriority.Normal;

                //utilize true pra ativar html no conteúdo do email, ou false, para somente texto
                objEmail.IsBodyHtml = true;

                //Assunto do email
                objEmail.Subject = "Recuperação de Senha Caroneiro";


                //corpo do email a ser enviado
                objEmail.Body = "<h5>Sua senha é </h5>" + password ;


                //codificação do assunto do email para que os caracteres acentuados serem reconhecidos.
                objEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");

                //codificação do corpo do emailpara que os caracteres acentuados serem reconhecidos.
                objEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

                //cria o objeto responsável pelo envio do email
                SmtpClient objSmtp = new SmtpClient();

                //endereço do servidor SMTP(para mais detalhes leia abaixo do código)
                objSmtp.Host = "smtp.gmail.com";

                objSmtp.Port = 587;

                objSmtp.UseDefaultCredentials = true;

                //para envio de email autenticado, coloque login e senha de seu servidor de email
                //para detalhes leia abaixo do código
                objSmtp.Credentials = new NetworkCredential("webcaroneiro@gmail.com", "caroneirotcc");
                objSmtp.EnableSsl = true;

                //envia o email
                objSmtp.Send(objEmail);

                message = "ok";
                return message;
            }
            catch
            {
                message = "falha";
                return message;

            };
        }


    }
}