using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using dc = DevExpress.ExpressApp.DC;

namespace Logistic.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Vehicle : BaseObject
    {
        bool addToCalculate;
        decimal capacity;
        decimal costPerDay;
        decimal costPerKm;
        decimal distancePerDay;
        string name;

        public Vehicle(Session session) : base(session) {}

        [dc.XafDisplayName("Kalkuluj"), ToolTip("Dodaj ten pojazd do kalkulacji tras")]
        [Index(5)]
        public bool AddToCalculate { get => addToCalculate; set => SetPropertyValue(nameof(AddToCalculate), ref addToCalculate, value); }

        [dc.XafDisplayName("Ładowność")]
        [ModelDefault("DisplayFormat", "{0:n3} kg")]
        [Index(2)]
        public decimal Capacity { get => capacity; set => SetPropertyValue(nameof(Capacity), ref capacity, value); }

        [dc.XafDisplayName("Koszt na dzień"), ToolTip("Koszt związany z jednym dniem pracy pojazdu")]
        [Index(3)]
        public decimal CostPerDay { get => costPerDay; set => SetPropertyValue(nameof(CostPerDay), ref costPerDay, value); }

        [dc.XafDisplayName("Koszt na km"), ToolTip("Koszt związany z pokonaniem kilometra przez pojazd")]
        [Index(4)]
        public decimal CostPerKm { get => costPerKm; set => SetPropertyValue(nameof(CostPerKm), ref costPerKm, value); }

        [dc.XafDisplayName("Dystans dzienny"), ToolTip("Ilość kilometrów ile dziennie może pokonać pojazd")]
        [ModelDefault("DisplayFormat", "{0:n3} km")]
        [Index(1)]
        public decimal DistancePerDay { get => distancePerDay; set => SetPropertyValue(nameof(DistancePerDay), ref distancePerDay, value); }

        [Association("Vehicle-Drivers")]
        [dc.XafDisplayName("Kierowcy")]
        [Index(-1)]
        public XPCollection<Driver> Drivers => GetCollection<Driver>(nameof(Drivers));

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [dc.XafDisplayName("Nazwa")]
        [Index(0)]
        public string Name { get => name; set => SetPropertyValue(nameof(Name), ref name, value); }

        [Association("Vehicle-Cargos")]
        public XPCollection<Cargo> Cargos { get { return GetCollection<Cargo>(nameof(Cargos)); } }
    }
}