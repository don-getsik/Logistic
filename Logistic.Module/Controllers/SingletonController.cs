using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.Base;
using Logistic.Module.BusinessObjects;
using System;
using System.Linq;

namespace Logistic.Module.Controllers
{
    public partial class SingletonController : WindowController
    {
        public SingletonController()
        {
            InitializeComponent();
            this.TargetWindowType = WindowType.Main;
            PopupWindowShowAction showSingletonAction = new PopupWindowShowAction(this, "ShowSingleton", PredefinedCategory.View);
            showSingletonAction.CustomizePopupWindowParams += CustomizePopupWindowParams;
        }

        private void CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            DetailView detailView = Application.CreateDetailView(objectSpace, objectSpace.GetObjects<AboutCompanySingleton>()[0]);
            detailView.ViewEditMode = ViewEditMode.Edit;
            e.View = detailView;
        }
    }
}
