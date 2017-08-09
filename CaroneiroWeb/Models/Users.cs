using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CaroneiroWeb.Models
{
    public class Users
    {
        public int id_user { get; set; }

        [Required(ErrorMessage = "Informe um nome de usuário")]
        [Display(Name = "Nome")]
        [DataType(DataType.Text)]
        [StringLength(30, ErrorMessage = "Informe um nome de até 30 caracteres!")]
        public string name_user { get; set; }

        [Required]
        [Display(Name = "Eu sou")]
        public string genre { get; set; }

        [Display(Name = "País")]
        [StringLength(50, ErrorMessage = "Informe um nome de até 50 caracteres!")]
        public string country { get; set; }

        [Required(ErrorMessage = "Informe o estado onde mora.")]
        [Display(Name = "Estado")]
        [StringLength(50, ErrorMessage = "Informe um nome de até 50 caracteres!")]
        public string state { get; set; }

        [Required(ErrorMessage = "Informe a cidade onde mora.")]
        [Display(Name ="Cidade")]
        [StringLength(70, ErrorMessage = "Informe um nome de até 70 caracteres!")]
        public string city { get; set; }

        [Required(ErrorMessage = "Informe sua data de nascimento.")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date_birth { get; set; }

        [Required(ErrorMessage = "Infome seu email.")]
        [Display(Name = "Email")]
        [StringLength(70, ErrorMessage = "Informe um email de até 70 caracteres!")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string email { get; set; }

        [Required(ErrorMessage = "Informe uma senha.")]
        [Display(Name = "Senha")]
        [StringLength(50, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string password_user { get; set; }

        [Display(Name = "Confirme a senha")]
        [StringLength(50, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string password_confirm { get; set; }

        [Display(Name = "Nova senha")]
        [StringLength(50, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string password_new { get; set; }

        [Display(Name = "Imagem")]
        public string image { get; set; }
                
        public DateTime date_registration { get; set; }

        [Display(Name = "Religião")]
        [StringLength(45, ErrorMessage = "Sua resposta deve conter até 45 caracteres!")]
        public string religion { get; set; }

        [Display(Name = "Relacionamento")]
        [StringLength(45, ErrorMessage = "Sua resposta deve conter até 45 caracteres!")]
        public string relationship { get; set; }

        [Display(Name = "Escolaridade")]
        [StringLength(45, ErrorMessage = "Sua resposta deve conter até 45 caracteres!")]
        public string schooling { get; set; }

        [Display(Name = "Profissão")]
        [StringLength(45, ErrorMessage = "Sua resposta deve conter até 45 caracteres!")]
        public string profession { get; set; }

        [Display(Name = "Gosto Musical")]
        [StringLength(100, ErrorMessage = "Sua resposta deve conter até 100 caracteres!")]
        public string pref_music { get; set; }

        [Display(Name = "Humor")]
        [StringLength(100, ErrorMessage = "Sua resposta deve conter até 100 caracteres!")]
        public string emotional { get; set; }
        
        [Display(Name = "Descrição")]
        public string description { get; set; }

        [Display(Name = "Avaliação")]
        public float evalution { get; set; }

        public int active { get; set; }

        public int confirmation { get; set; }

        public int access { get; set; }

        public Users()
        {

        }

        public Users(int pIdUser, string pNameUser, string pGenre, string pCity, DateTime pDateBirth, string pEmail, 
                     string pPassword, string pImage, DateTime pDateRegistration, string pReligion, string pRelationship, 
                     string pSchooling, string pProfession, string pPrefMusic, string pDescription, float pEvalution, int pActive)
        {
            id_user = pIdUser;
            name_user = pNameUser;
            genre = pGenre;
            city = pCity;
            date_birth = pDateBirth;
            email = pEmail;
            password_user = pPassword;
            image = pImage;
            date_registration = pDateRegistration;
            religion = pReligion;
            relationship = pRelationship;
            schooling = pSchooling;
            profession = pProfession;
            pref_music = pPrefMusic;
            description = pDescription;
            evalution = pEvalution;
            active = pActive;
        }


    }
}