using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using Logistic.Module.BusinessObjects;
using System;
using System.Linq;

namespace Logistic.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class SellCar : ViewController
    {
        public SimpleAction ClickSimpleAction { get; private set; }
        public SellCar()
        {
            InitializeComponent();
            TargetObjectType = typeof(Vehicle);
            ClickSimpleAction = new SimpleAction(this, "VechicleController", PredefinedCategory.Edit)
            {
                Caption = "Sprzedaj pojazd",
                ToolTip = "Oznacza samochod jako sprzedany"
            };
            ClickSimpleAction.Execute += ClickSimpleAction_Execute;
            ClickSimpleAction.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
        }
        void ClickSimpleAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var vechicle = (e.SelectedObjects)[0];
            if (vechicle != null)
            {
                (vechicle as Vehicle).IsSold = true;
                (vechicle as Vehicle).AddToCalculate = false;
            }

            ObjectSpace.CommitChanges();
        }
    }
}
