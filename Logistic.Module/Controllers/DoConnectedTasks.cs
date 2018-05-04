using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using Logistic.Module.BusinessObjects;
using System;
using System.Linq;

namespace Logistic.Module.Controllers
{
    public partial class DoConnectedTasks : ViewController
    {
        public SimpleAction ClickSimpleAction { get; private set; }
        public DoConnectedTasks()
        {
            TargetObjectType = typeof(Cargo);
            ClickSimpleAction = new SimpleAction(this, "CargoController", PredefinedCategory.Edit)
            {
                Caption = "Wykonaj zlecenia",
                ToolTip = "Zostaną przesłane wszystkie przesyłki jakie mają przypisane samochody",
                ConfirmationMessage = "Czy napewno chcesz dokonać operacji. Jej zmiany są nieodwracalne"
            };
            ClickSimpleAction.Execute += ClickSimpleAction_Execute;
        }
        private void ClickSimpleAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var objectSpace = Application.CreateObjectSpace();
            var company = objectSpace.GetObjects<AboutCompanySingleton>()[0];
            
            var vechicles = objectSpace.GetObjects<Vehicle>().Where(v => v.Cargos.Count != 0);

            foreach (var v in vechicles)
            {
                double currentX = company.Xlocation;
                double currentY = company.Ylocation;
                double kilometers = 0;
                var cargos = v.Cargos.Where(c => c.IsCompleted == false);

                while(cargos.Count() != 0)
                {
                    var cargo = cargos.OrderBy(c => CalcLength(c.Task.Start.Xlocation, c.Task.Start.Ylocation, currentX, currentY)).First();
                    var task = cargo.Task;

                    kilometers += CalcLength(task.Start.Xlocation, task.Start.Ylocation, currentX, currentY);
                    kilometers += CalcLength(task.End.Xlocation, task.End.Ylocation, task.Start.Xlocation, task.Start.Ylocation);

                    currentX = task.End.Xlocation;
                    currentY = task.End.Ylocation;
                    cargo.IsCompleted = true;

                    if(task.Cargos.Where(c=> c.IsCompleted == false).Count() == 0)
                    {
                        company.Found += task.Salary;
                        task.IsCompleted = true;
                        task.AddToCalculation = false;
                    }
                }
                kilometers += CalcLength(company.Xlocation, company.Ylocation, currentX, currentY);
                company.Found -= (decimal)kilometers * v.CostPerKm;
                company.Found -= (int)(((decimal)kilometers / v.DistancePerDay)+1) * v.CostPerDay;
            }
            objectSpace.SetModified(company);
            objectSpace.CommitChanges();
        }

        private double CalcLength (double endX, double endY, double startX, double startY)
        {
            double x = Math.Pow((endX - startX),2);
            double y = Math.Pow((endY - startY), 2);

            return Math.Sqrt(x + y);
        }
    }
}
