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
    public class CustomerAddress : EntityBase
    {
        [DataType(DataType.Text), MaxLength(100)]
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

        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
    }
}
