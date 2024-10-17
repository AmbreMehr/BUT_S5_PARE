using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

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
        [HttpGet("GetAll", Name = "GetAllSemesters")]
        public Semester[] GetAll()
        {
            IEnumerable<Semester> semesters = this.SemesterService.GetAll();
            return semesters.ToArray();
        }
    }
}
