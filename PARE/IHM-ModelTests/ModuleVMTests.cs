using IHM_Model;
using Model;

namespace IHM_ModelTests
{
    public class ModuleVMTests
    {
        [Fact]
        public void TestGetSet()
        {
            Module module = new Module { Name = "Old Name" };
            ModuleVM vm = new ModuleVM(module);

            vm.Name = "New Name";

            Assert.Equal("New Name", vm.Name);
            Assert.Equal("New Name", module.Name);
        }

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

        [Fact]
        public void TestEmptyConstrutor()
        {
            ModuleVM vm = new ModuleVM();

            Assert.NotNull(vm.Model);
            Assert.IsType<Module>(vm.Model);
        }

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