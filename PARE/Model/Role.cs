namespace Model
{
    /// <summary>
    /// Classe qui représente le rôle global de l'utilisateur
    /// </summary>
    /// <author>Clotilde MALO</author>
    public class Role
    {
        private int id;
        private string name;

        /// <summary>
        /// Id du role global
        /// </summary>
        public int Id { get => id; set => id = value; }

        /// <summary>
        /// Nom du role global
        /// </summary>
        public string Name { get => name; set => name = value; }

        /// <summary>
        /// Constructeur de rôle avec tous les paramètres
        /// </summary>
        /// <param name="id">id du role</param>
        /// <param name="name">nom du role</param>
        public Role(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        /// <summary>
        /// Constructeur vide de rôle
        /// </summary>
        public Role()
        {
        }

    }
}
