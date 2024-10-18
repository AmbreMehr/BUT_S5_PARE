﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.InterfaceDAO
{
    /// <summary>
    /// Interface qui permet de gérer les données des enseignants
    /// </summary>
    /// <author> Clotilde MALO</author>
    public interface ITeacherDao
    {
        /// <summary>
        /// Renvoi tous les enseignants pour un module
        /// </summary>
        /// <param name="module">module</param>
        /// <returns>enseignants qui est assigné au module</returns>
        public Teacher[] ListForModule(Module module);

        /// <summary>
        /// Met à jour l'enseignant
        /// </summary>
        /// <param name="teacher">enseignant mis à jour</param>
        public void Update(Teacher teacher);
    }
}
