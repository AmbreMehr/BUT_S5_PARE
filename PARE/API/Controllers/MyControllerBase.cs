using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Classe de base pour les contrôleurs de l'API
    /// Contient les différents services
    /// </summary>
    public class MyControllerBase : ControllerBase
    {
        private ModuleService moduleService;
        private SemesterService semesterService;
        private TeacherService teacherService;
        private UserService userService;

        public MyControllerBase() 
        {
            this.moduleService = new ModuleService();
            this.semesterService = new SemesterService();
            this.teacherService = new TeacherService();
            this.userService = new UserService();
        }

        public ModuleService ModuleService { get => moduleService; set => moduleService = value; }
        public SemesterService SemesterService { get => semesterService; set => semesterService = value; }
        public TeacherService TeacherService { get => teacherService; set => teacherService = value; }
        public UserService UserService { get => userService; set => userService = value; }
    }
}
