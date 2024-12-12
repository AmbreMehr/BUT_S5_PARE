using API.Services;
using Model;

namespace Service_Tests
{
    /// <summary>
    /// Test pour le service des semestres
    /// </summary>
    public class SemesterServiceTest
    {
        /// <summary>
        /// Vérifie que le nombre d'heure des étudiants est correctement calculé
        /// </summary>
        [Fact]
        public void ComputeHoursPerWeekTest()
        {
            // recuperation d'un semestre
            SemesterService semesterService = new SemesterService();
            Semester semester = semesterService.GetAll().First();

            // recupération des modules pour semestre
            ModuleService moduleService = new ModuleService();
            Module[] modules = moduleService.GetModulesForSemester(semester.Id);

            // calcul des heures étudiants par semaine pour tout les modules du semestre
            Dictionary<int, float> dictionaryWeekHourManuel = new Dictionary<int, float>();
            foreach(Module module in modules)
            {
                int moduleDuration = module.WeekEnd - module.WeekBegin + 1;
                float moduleHours = module.HoursCM + module.HoursTd + module.HoursTp;

                for (int week = module.WeekBegin; week <= module.WeekEnd; week++)
                {
                    if (!dictionaryWeekHourManuel.ContainsKey(week))
                        dictionaryWeekHourManuel[week] = 0;
                    dictionaryWeekHourManuel[week] += moduleHours / moduleDuration;
                }
            }

            // recuperation par l'api
            Dictionary<int, float> dictionaryWeekHourAPI = semesterService.GetHoursPerWeekBySemester(semester.Id);

            // comparaison des deux
            Assert.Equal(dictionaryWeekHourManuel, dictionaryWeekHourAPI);
        }
    }
}