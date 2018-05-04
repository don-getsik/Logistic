using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using dc = DevExpress.ExpressApp.DC;

namespace Logistic.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Task : BaseObject
    {
        bool addToCalculation;
        Location end;
        bool isCompleted;
        string name;
        decimal salary;
        Location start;

        public Task(Session session) : base(session) { }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            IsCompleted = false;
        }

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
        [RuleRequiredField(DefaultContexts.Save)]
        public Location End { get => end; set => SetPropertyValue(nameof(End), ref end, value); }

        [Index(-1)]
        public bool IsCompleted { get => isCompleted; set => SetPropertyValue(nameof(IsCompleted), ref isCompleted, value); }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [dc.XafDisplayName("Nazwa")]
        [Index(0)]
        [RuleRequiredField(DefaultContexts.Save)]
        public string Name { get => name; set => SetPropertyValue(nameof(Name), ref name, value); }

        [dc.XafDisplayName("Wypłata"), ToolTip("Wypłata za wykonanie zlecenia")]
        [Index(1)]
        [RuleRequiredField(DefaultContexts.Save)]
        public decimal Salary { get => salary; set => SetPropertyValue(nameof(Salary), ref salary, value); }

        [Association("StartLocation")]
        [dc.XafDisplayName("Lokalizacja początkowa")]
        [Index(2)]
        [RuleRequiredField(DefaultContexts.Save)]
        public Location Start { get => start; set => SetPropertyValue(nameof(Start), ref start, value); }
    }
}