using IHM_Model;
using Model;

namespace IHM_ModelTests
{
    public class ModuleVMTests
    {
        /// <summary>
        /// Teste le Get et le Set de ModulesVM
        /// </summary>
        [Fact]
        public void TestGetSet()
        {
            Module module = new Module { Name = "Old Name" };
            ModuleVM vm = new ModuleVM(module);

            vm.Name = "New Name";

            Assert.Equal("New Name", vm.Name);
            Assert.Equal("New Name", module.Name);
        }

        /// <summary>
        /// Teste le Notify Change
        /// </summary>
        [Fact]
        public void TestNotifyChange()
        {
            Module module = new Module { Name = "Old Name" };
            ModuleVM vm = new ModuleVM(module);
            bool eventTriggered = false;

            vm.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(vm.Name))
                {
                    eventTriggered = true;
                }
            };

            vm.Name = "New Name";

            Assert.True(eventTriggered);
        }

        /// <summary>
        /// Teste un constructeur vide
        /// </summary>
        [Fact]
        public void TestEmptyConstrutor()
        {
            ModuleVM vm = new ModuleVM();

            Assert.NotNull(vm.Model);
            Assert.IsType<Module>(vm.Model);
        }

        /// <summary>
        /// Teste un constructeur avec un module en paramètre
        /// </summary>
        [Fact]
        public void TestConstrutorWithModule()
        {
            Module module = new Module { Name = "Test Module" };

            ModuleVM vm = new ModuleVM(module);

            Assert.Equal("Test Module", vm.Name);
            Assert.Equal(module, vm.Model);
        }
    }
}