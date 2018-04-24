using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using Logistic.Module.BusinessObjects;

namespace Logistic.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class DoConnectedTasks : ViewController
    {
        public SimpleAction ClickSimpleAction { get; private set; }
        public DoConnectedTasks()
        {
            TargetObjectType = typeof(Cargo);
            ClickSimpleAction = new SimpleAction(this, "CargoController-ClickSimpleAction", PredefinedCategory.Edit);
            ClickSimpleAction.Caption = "Wykonaj zlecenia";
            ClickSimpleAction.ToolTip = "Zostaną przesłane wszystkie przesyłki jakie mają przypisane samochody";
            ClickSimpleAction.Execute += ClickSimpleAction_Execute;
        }
        private void ClickSimpleAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var objectSpace = Application.CreateObjectSpace();
            var company = objectSpace.GetObjects<AboutCompanySingleton>()[0];

            var number = objectSpace.GetObjects<Task>().Count;
            
            var vechicles = objectSpace.GetObjects<Vehicle>().Where(v => v.Cargos.Count != 0);

            foreach (var v in vechicles)
            {
                double currentX = company.Xlocation;
                double currentY = company.Ylocation;
                double kilometers = 0;
                while(v.Cargos.Count() != 0)
                {
                    var cargo = v.Cargos.OrderBy(c => CalcLength(c.Task.Start.Xlocation, c.Task.Start.Ylocation, currentX, currentY)).First();
                    var task = cargo.Task;
                    kilometers += CalcLength(task.Start.Xlocation, task.Start.Ylocation, currentX, currentY);
                    kilometers += CalcLength(task.End.Xlocation, task.End.Ylocation, task.Start.Xlocation, task.Start.Ylocation);
                    currentX = task.End.Xlocation;
                    currentY = task.End.Ylocation;
                    task.Cargos.Remove(cargo);
                    v.Cargos.Remove(cargo);
                    objectSpace.Delete(cargo);
                    if(task.Cargos.Count == 0)
                    {
                        company.Found += task.Salary;
                        task.Delete();
                        objectSpace.Delete(task);
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
