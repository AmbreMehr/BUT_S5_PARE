using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    [Route("api/semester")]
    [ApiController]
    public class SemesterController : ControllerBase
    {
        /// <summary>
        /// Renvoie tous les semestres
        /// </summary>
        /// <returns>Liste de Semester</returns>
        [HttpGet("GetAll", Name = "GetAllSemesters")]
        public Semester[] GetAll()
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Renvoie les modules contenus dans un semestre
        /// </summary>
        /// <param name="semester">Semester</param>
        /// <returns>Liste de Module du semestre</returns>
        [HttpGet("GetModulesBySemester", Name = "GetModulesBySemester")]
        public Module[] GetModuleBySemester(Semester semester)
        {
            throw new NotImplementedException();
        }
    }
}
