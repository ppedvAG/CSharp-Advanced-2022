using Autofac;
using ppedv.CarManager.Model.Contracts;
using ppedv.CarManager.UI.WPF.ViewModels;
using System;
using System.Linq;
using System.Reflection;

namespace ppedv.CarManager.UI.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            //manuall Dependency Injection
            //var path = @"C:\Users\Fred\source\repos\CSharp-Advanced-2022\CarManager\ppedv.CarManager.Logic\bin\Debug\net6.0\ppedv.CarManager.Logic.dll";
            //var ass = Assembly.LoadFrom(path);
            //var theLogicType = ass.GetTypes().FirstOrDefault(x => x.GetInterfaces().Contains(typeof(ILogic)));
            //var logicInstance = (ILogic)Activator.CreateInstance(theLogicType);
            //carView.DataContext = new CarViewModel(logicInstance);

            //DI via AutoFac
            var b = new ContainerBuilder();
            //b.RegisterType<Logic.CarLogic>().As<Model.Contracts.ILogic>();
            b.RegisterType<Logic.NEWCarLogic>().As<Model.Contracts.ILogic>();
            var container = b.Build();

            carView.DataContext = new CarViewModel(container.Resolve<ILogic>());

        }
    }
}
