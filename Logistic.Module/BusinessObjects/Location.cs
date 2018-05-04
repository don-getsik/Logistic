using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using dc = DevExpress.ExpressApp.DC;

namespace Logistic.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Location : BaseObject
    {
        string name;
        double xlocation;
        double ylocation;

        public Location(Session session) : base(session) { }

        public override void AfterConstruction() => base.AfterConstruction();

        [Association("EndLocation")]
        public XPCollection<Task> EndTasks => GetCollection<Task>(nameof(EndTasks));

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [RuleRequiredField(DefaultContexts.Save)]
        [dc.XafDisplayName("Nazwa")]
        public string Name { get => name; set => SetPropertyValue(nameof(Name), ref name, value); }

        [Association("StartLocation")]
        public XPCollection<Task> StartTaks => GetCollection<Task>(nameof(StartTaks));

        [RuleRequiredField(DefaultContexts.Save)]
        [dc.XafDisplayName("Współżędna X")]
        public double Xlocation { get => xlocation; set => SetPropertyValue(nameof(Xlocation), ref xlocation, value); }

        [RuleRequiredField(DefaultContexts.Save)]
        [dc.XafDisplayName("Współżedna Y")]
        public double Ylocation { get => ylocation; set => SetPropertyValue(nameof(Ylocation), ref ylocation, value); }
    }
}