using Model;
using System.Reflection.Metadata.Ecma335;

namespace IHM_Model
{
    public class SemesterVM : BaseVM
    {
        private Semester model;

        public Semester Model
        {
            get => model;
        }

        public string Name
        {
            get => model.Name;
        }

        public SemesterVM(Semester model)
        {
            this.model = model;
        }
    }
}