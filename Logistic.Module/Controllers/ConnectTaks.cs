using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using Logistic.Module.BusinessObjects;
using System;
using System.Linq;

namespace Logistic.Module.Controllers
{
    public partial class ConnectTaks : ViewController
    {
        public SimpleAction ClickSimpleAction { get; private set; }
        public ConnectTaks()
        {
            InitializeComponent();
            TargetObjectType = typeof(Task);
            ClickSimpleAction = new SimpleAction(this, "TaskController", PredefinedCategory.Edit)
            {
                Caption = "Powiąż zlecenia",
                ToolTip = "Powiąż przesyłki wybranych zadań z wybranymi pojazdami"
            };
            ClickSimpleAction.Execute += ClickSimpleAction_Execute;

        }


        void ClickSimpleAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var objectSpace = Application.CreateObjectSpace();
            var vechicles = objectSpace.GetObjects<Vehicle>().Where(v => v.AddToCalculate == true && v.IsSold == false);
            var tasks = objectSpace.GetObjects<Task>().Where(t => t.AddToCalculation == true && t.IsCompleted == false);

            foreach(Task task in tasks)
            {
                var cargos = task.Cargos.Where(c => c.Vehicle == null);
                foreach(Cargo c in cargos)
                {
                    int i = 0;
                    vechicles = vechicles.OrderBy(v => cargos.Count());
                    while (vechicles.Count() > i && vechicles.ToArray()[i].Capacity < c.Weight) i++;
                    if (vechicles.Count() > i)
                    {
                        vechicles.ToArray()[i].Cargos.Add(c);
                        c.Vehicle = vechicles.ToArray()[i];
                    }
                }
                if (task.Cargos.Count() == 0) task.AddToCalculation = false;
            }
            objectSpace.CommitChanges();
        }
    }
}
