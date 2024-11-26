using Model;

namespace IHM_Model
{
    public class RoleVM : BaseVM
    {
        private Role model;

        public String Name
        {
            get => model.Name;
        }

        public RoleVM(Role model) 
        {
            this.model = model;
        }
    }
}