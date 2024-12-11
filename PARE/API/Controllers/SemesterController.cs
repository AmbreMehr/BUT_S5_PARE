using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Diagnostics;

namespace API.Controllers
{
    [Route("api/semester")]
    [ApiController]
    public class SemesterController : MyControllerBase
    {
        /// <summary>
        /// Renvoie tous les semestres
        /// </summary>
        /// <returns>Liste de Semester</returns>
        /// <author>AmbreMehr</author>
        [HttpGet("GetAll", Name = "GetAllSemesters")]
        public Semester[] GetAll()
        {
            IEnumerable<Semester> semesters = this.SemesterService.GetAll();
            return semesters.ToArray();
        }

        /// <summary>
        /// Renvoie le nombre d'heures que les étudiants feront par semaine sur un semestre donné
        /// </summary>
        /// <param name="semester">semestre pour lequel calculer</param>
        /// <returns>dictionnaire semaine -> heures des étudiants</returns>
        [HttpGet("GetStudentsHoursPerWeek", Name = "GetStudentsHoursPerWeek")]
        public Dictionary<int, float> GetHoursPerWeekBySemester(int semester)
        {
            return this.SemesterService.GetHoursPerWeekBySemester(semester);
        }
    }
}
