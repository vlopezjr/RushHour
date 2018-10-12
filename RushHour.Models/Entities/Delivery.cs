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
    public class Delivery : EntityBase
    {
        [DataType(DataType.Text), MaxLength(30)]
        [Display(Name = "Cust#")]
        public string CustomerRefNo { get; set; }

        [Display(Name = "Ref.No.")]
        public int RefNo { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Delivery Charges")]
        public decimal DeliveryCharge { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Weight Charge")]
        public decimal? WeightCharge { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Return Charges")]
        public decimal? ReturnCharge { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Waiting Time")]
        public decimal? WaitingTimeCharge { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "C.O.D Charge")]
        public decimal? CodCharge { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Total Charges")]
        public decimal TotalCharge { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Arrival Time")]
        public DateTime? ArrivalTime { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Departure Time")]
        public DateTime? DepartureTime { get; set; }

        [Display(Name = "Date")]
        public DateTime? DeliveryDateTime { get; set; }

        [Display(Name = "Prepaid")]
        public bool? IsPrepaid { get; set; }

        [Display(Name = "reg.")]
        public bool? IsReg { get; set; }

        [Display(Name = "Rush")]
        public bool? IsRush { get; set; }

        [Display(Name = "C.O.D.")]
        public bool? IsCod { get; set; }        

        [DataType(DataType.Text), MaxLength(150)]
        public string ReceivedBy { get; set; }       

        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }

        public int DriverId { get; set; }

        [ForeignKey(nameof(DriverId))]
        public Driver Driver { get; set; }

        [InverseProperty(nameof(Freight.Delivery))]
        public List<Freight> Freights { get; set; }

        public int DeliverToAddressId { get; set; }

        [ForeignKey(nameof(DeliverToAddressId))]
        public CustomerAddress DeliverToAddress { get; set; }

        public int PickupAddressId { get; set; }

        [ForeignKey(nameof(PickupAddressId))]
        public CustomerAddress PickupAddress { get; set; }

    }
}
