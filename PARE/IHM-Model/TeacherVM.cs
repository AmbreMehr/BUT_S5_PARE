using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHM_Model
{
    public class TeacherVM : BaseVM
    {
        private Teacher _model;
        public Teacher Model
            { 
            get { return _model;}
            set { 
                _model = value;
                NotifyChange("Teacher");
            }
        }

        public void UpdateTeacher(Teacher teacherModify)
        {
            _model = teacherModify;
        }

        public void DeleteTeacher(Teacher teacherDelete)
        {
            _model = teacherDelete;
        }

        public void CreateTeacher( Teacher teacherToCreate)
        {   
            _model = teacherToCreate;
        }
    }
}
