using IHM_Model;
using Model;

namespace IHM_ModelTests
{
    public class RoleVMTests
    {
        /// <summary>
        /// Teste la création d'un nom
        /// </summary>
        [Fact]
        public void TestName()
        {
            Role role = new Role { Name = "Administrator" };
            RoleVM vm = new RoleVM(role);

            string name = vm.Name;

            Assert.Equal("Administrator", name);
        }

        /// <summary>
        /// Teste la relation model ViewModel
        /// </summary>
        [Fact]
        public void TestLikeModelViewModel()
        {
            Role role = new Role { Name = "User" };
            RoleVM vm = new RoleVM(role);

            role.Name = "Directeur du département";

            Assert.Equal("Directeur du département", vm.Name);
        }


    }
}
