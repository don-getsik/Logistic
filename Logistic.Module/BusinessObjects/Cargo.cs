using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Model;
using DevExpress.Xpo;
using dc = DevExpress.ExpressApp.DC;

namespace Logistic.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Cargo : BaseObject
    { 
        string restrictions;
        Task task;
        string type;
        double weight;

        public Cargo(Session session) : base(session) {}

        public override void AfterConstruction() => base.AfterConstruction();

        [dc.XafDisplayName("Restrykcje"), ToolTip("Czy przesyłka posiada szczególne zasady obchodzenia")]
        [Index(2)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Restrictions { get => restrictions; set => SetPropertyValue(nameof(Restrictions), ref restrictions, value); }

        [dc.XafDisplayName("Zadanie"), ToolTip("Zadanie do którego ładunek jest przypisany")]
        [Index(3)]
        [Association("Task-Cargos")]
        public Task Task { get => task; set => SetPropertyValue(nameof(Task), ref task, value); }

        [dc.XafDisplayName("Typ"), ToolTip("Rodzaj przesyłki")]
        [Index(0)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Type { get => type; set => SetPropertyValue(nameof(Type), ref type, value); }

        [dc.XafDisplayName("Objętość"), ToolTip("Wielkość przesyłki")]
        [ModelDefault("DisplayFormat", "{0:n3} kg")]
        [Index(1)]
        public double Weight { get => weight; set => SetPropertyValue(nameof(Weight), ref weight, value); }

        Vehicle vehicle;
        [Association("Vehicle-Cargos")]
        [dc.XafDisplayName("Pojazd"), ToolTip("Przypisany pojazd do przewiezienia przesyłki")]
        [Index(4)]
        public Vehicle Vehicle { get { return vehicle; } set { SetPropertyValue("Vehicle", ref vehicle, value); } }
    }
}