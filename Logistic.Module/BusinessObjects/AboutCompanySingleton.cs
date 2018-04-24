using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using dc = DevExpress.ExpressApp.DC;

namespace Logistic.Module.BusinessObjects
{
    [DefaultClassOptions]
    [RuleObjectExists("AnotherSingletonExists", DefaultContexts.Save, "True", InvertResult = true, CustomMessageTemplate = "Another Singleton already exists.")]
    [RuleCriteria("CannotDeleteSingleton", DefaultContexts.Delete, "False", CustomMessageTemplate = "Cannot delete Singleton.")]
    public class AboutCompanySingleton : BaseObject
    {
        private decimal found;
        private string name;
        double xlocation;
        double ylocation;

        public AboutCompanySingleton(Session session) : base(session) => Found = 1000000;

        public override void AfterConstruction() => base.AfterConstruction();

        [dc.XafDisplayName("Fundusz firmy")]
        public decimal Found { get => found; set => SetPropertyValue(nameof(Found), ref found, value); }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [dc.XafDisplayName("Nazwa Firmy")]
        public string Name { get => name; set => SetPropertyValue(nameof(Name), ref name, value); }

        public double Xlocation { get => xlocation; set => SetPropertyValue(nameof(Xlocation), ref xlocation, value); }

        public double Ylocation { get => ylocation; set => SetPropertyValue(nameof(Ylocation), ref ylocation, value); }
    }
}