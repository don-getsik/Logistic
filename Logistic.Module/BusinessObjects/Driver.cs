using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Linq;
using dc = DevExpress.ExpressApp.DC;

namespace Logistic.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Driver : BaseObject
    { 
        string firstName;
        string lastName;
        string pesel;
        string phoneNumber;
        Vehicle vehicle;


        public Driver(Session session) : base(session) {}

        public override void AfterConstruction() => base.AfterConstruction();

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [dc.XafDisplayName("Imię")]
        [Index(0)]
        public string FirstName { get => firstName; set => SetPropertyValue(nameof(FirstName), ref firstName, value); }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [dc.XafDisplayName("Nazwisko")]
        [Index(1)]
        public string LastName { get => lastName; set => SetPropertyValue(nameof(LastName), ref lastName, value); }

        [Size(11)]
        [dc.XafDisplayName(nameof(Pesel))]
        [ModelDefault("EditMask", "00000000000"), Index(2)]
        public string Pesel { get => pesel; set => SetPropertyValue(nameof(Pesel), ref pesel, value); }

        [Size(9)]
        [dc.XafDisplayName("Numer Telefonu")]
        [ModelDefault("EditMask", "000000000"), Index(3)]
        public string PhoneNumber { get => phoneNumber; set => SetPropertyValue(nameof(PhoneNumber), ref phoneNumber, value); }

        [Association("Vehicle-Drivers")]
        [dc.XafDisplayName("Pojazd")]
        [Index(4)]
        public Vehicle Vehicle { get => vehicle; set => SetPropertyValue(nameof(Vehicle), ref vehicle, value); }

    }
}