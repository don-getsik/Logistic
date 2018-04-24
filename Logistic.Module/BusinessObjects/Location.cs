using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Linq;

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
        public string Name { get => name; set => SetPropertyValue(nameof(Name), ref name, value); }

        [Association("StartLocation")]
        public XPCollection<Task> StartTaks => GetCollection<Task>(nameof(StartTaks));
        public double Xlocation { get => xlocation; set => SetPropertyValue(nameof(Xlocation), ref xlocation, value); }
        public double Ylocation { get => ylocation; set => SetPropertyValue(nameof(Ylocation), ref ylocation, value); }
    }
}