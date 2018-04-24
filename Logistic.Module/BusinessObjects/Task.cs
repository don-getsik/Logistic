using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using dc = DevExpress.ExpressApp.DC;

namespace Logistic.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Task : BaseObject
    {
        bool addToCalculation;
        Location end;
        string name;
        decimal salary;
        Location start;

        public Task(Session session) : base(session){}

        public override void AfterConstruction() => base.AfterConstruction();

        [dc.XafDisplayName("Kalkuluj trasy")]
        [Index(4)]
        public bool AddToCalculation { get => addToCalculation; set => SetPropertyValue(nameof(AddToCalculation), ref addToCalculation, value); }

        [Association("Task-Cargos")]
        [dc.XafDisplayName("Przesyłki"), ToolTip("Wszystkie przesyłki związane z tym zleceniem")]
        [Index(-1)]
        public XPCollection<Cargo> Cargos => GetCollection<Cargo>(nameof(Cargos));

        [Association("EndLocation")]
        [dc.XafDisplayName("Lokalizacja końcowa")]
        [Index(3)]
        public Location End { get => end; set => SetPropertyValue(nameof(End), ref end, value); }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [dc.XafDisplayName("Nazwa")]
        [Index(0)]
        public string Name { get => name; set => SetPropertyValue(nameof(Name), ref name, value); }

        [dc.XafDisplayName("Wypłata"), ToolTip("Wypłata za wykonanie zlecenia")]
        [Index(1)]
        public decimal Salary { get => salary; set => SetPropertyValue(nameof(Salary), ref salary, value); }

        [Association("StartLocation")]
        [dc.XafDisplayName("Lokalizacja początkowa")]
        [Index(2)]
        public Location Start { get => start; set => SetPropertyValue(nameof(Start), ref start, value); }
    }
}