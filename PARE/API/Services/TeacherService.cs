﻿using Microsoft.AspNetCore.Mvc;
using Model;
using Storage;
using Storage.InterfaceDAO;

namespace API.Services
{
    /// <summary>
    /// Classe qui gère les services enseignants
    /// </summary>
    public class TeacherService
    {
        private ITeacherDao teacherDao;

        /// <summary>
        /// Initialise le teacherdao
        /// </summary>
        public TeacherService()
        {
            this.teacherDao = new TeacherDaoSqlite();
        }

        /// <summary>
        /// Renvoie tous les enseignants qui sont assignés au module
        /// <author>Clotilde MALO</author>
        /// </summary>
        /// <param name="idModule">id du module enseigné</param>
        /// <returns>Liste de Teacher qui enseignent le module</returns>
        public Teacher[] GetTeachersByModule(string idModule)
        {
            return this.teacherDao.ListForModule(idModule);
        }

        /// <summary>
        /// Met à jour l'objet Enseignant reçu
        /// </summary>
        /// <param name="teacher">Teacher à mettre à jour</param>
        /// <returns>boolean</returns>
        public void UpdateTeacher(Teacher teacher)
        {
            this.teacherDao.Update(teacher);
        }

        /// <summary>
        /// Supprime l'objet Enseignant reçu
        /// </summary>
        /// <param name="teacher">Teacher à supprimer</param>
        /// <returns>bool</returns>
        public bool DeleteTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Créer l'objet Enseignant reçu
        /// </summary>
        /// <param name="teacher">Teacher à créer</param>
        /// <returns>boolean</returns>
        public bool CreateTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }
    }
}
