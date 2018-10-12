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
    public enum FreightType
    {
        Pallet,
        Box,
        Envelope
    }

    public class Freight : EntityBase
    {
        public int Quantity { get; set; }

        public FreightType Type { get; set; }

        [DataType(DataType.Text), MaxLength(255)]
        public string Description { get; set; }

        [DataType(DataType.Text), MaxLength(25)]
        public string Weight { get; set; }

        public int DeliveryId { get; set; }

        [ForeignKey(nameof(DeliveryId))]
        public Delivery Delivery { get; set; }
    }
}
