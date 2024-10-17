using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Classe qui représente les informations de connexion de l'utilisateur
    /// </summary>
    /// <author>Clotilde MALO</author>
    public class UserLogin
    {
        private string login;
        private string password;
        private string token;
        private User user;

        /// <summary>
        /// Get et set de l'identifiant de connexion de l'utilisateur
        /// </summary>
        public string Login { get => login; set => login = value; }

        /// <summary>
        /// Get et set du mot de passe de connexion de l'utilisateur
        /// </summary>
        public string Password { get => password; set => password = value; }

        /// <summary>
        /// Get et set du jeton de connexion de l'utilisateur
        /// </summary>
        public string Token { get => token; set => token = value; }

        /// <summary>
        /// Get et set de l'utilisateur concerné par la connexion
        /// </summary>
        public User User { get => user; set => user = value; }

        /// <summary>
        /// Constructeur de userLogin avec seulement utilisateur 
        /// </summary>
        public UserLogin(User user)
        {
            this.user = user;
        }

        /// <summary>
        /// Constructeur de UserLogin avec tous les paramètres
        /// </summary>
        /// <param name="login">identifiant de connexion</param>
        /// <param name="password">mot de passe</param>
        /// <param name="token">jeton de connexion</param>
        public UserLogin(User user, string login, string password, string token)
        {
            this.user = user;
            this.login = login;
            this.password = password;
            this.token = token;
        }
    }
}
