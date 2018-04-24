using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using dc = DevExpress.ExpressApp.DC;

namespace Logistic.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class HistoryTask : BaseObject
    { 
        decimal cost;
        string name;
        decimal salary;

        public HistoryTask(Session session) : base(session) {}

        public override void AfterConstruction() => base.AfterConstruction();

        [dc.XafDisplayName("Koszt"), ToolTip("Koszt jaki poniosła firma za wykoananie zlecenia")]
        [Index(2)]
        public decimal Cost { get => cost; set => SetPropertyValue(nameof(Cost), ref cost, value); }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [dc.XafDisplayName("Nazwa"), ToolTip("Nazwa zlecenia")]
        [Index(0)]
        public string Name { get => name; set => SetPropertyValue(nameof(Name), ref name, value); }

        [dc.XafDisplayName("Wypłata"), ToolTip("Wypłata za wykonanie zlecenia")]
        [Index(1)]
        public decimal Salary { get => salary; set => SetPropertyValue(nameof(Salary), ref salary, value); }

        [NonPersistent]
        [dc.XafDisplayName("Różnica"), ToolTip("Ostateczny zarobek firmy")]
        [Index(3)]
        public decimal Sum => Salary - Cost;
    }
}