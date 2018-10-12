using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RushHour.Models.Entities.Base;

namespace RushHour.Models.Entities
{
    public class Customer : EntityBase
    {
        [DataType(DataType.Text), MaxLength(150)]
        public string Name { get; set; }

        [DataType(DataType.Text), MaxLength(255)]
        public string Address1 { get; set; }

        [DataType(DataType.Text), MaxLength(255)]
        public string Address2 { get; set; }

        [DataType(DataType.Text), MaxLength(100)]
        public string City { get; set; }

        [DataType(DataType.Text), MaxLength(2)]
        public string State { get; set; }

        [DataType(DataType.Text), MaxLength(9)]
        public string Zip { get; set; }       

        [DataType(DataType.Text), MaxLength(150)]
        public string EmailAddress { get; set; }

        [DataType(DataType.Text), MaxLength(100)]
        public string PointOfContact { get; set; }

        [DataType(DataType.Text), MaxLength(10)]
        public string PrimaryPhone { get; set; }

        [DataType(DataType.Text), MaxLength(10)]
        public string SecondaryPhone { get; set; }

        [InverseProperty(nameof(Delivery.Customer))]
        public List<Delivery> Deliveries { get; set; }

        [InverseProperty(nameof(CustomerAddress.Customer))]
        public List<CustomerAddress> CustomerAddresses { get; set; }

    }
}
