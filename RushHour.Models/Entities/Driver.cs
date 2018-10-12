using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RushHour.Models.Entities.Base;

namespace RushHour.Models.Entities
{
    public class Driver : EntityBase
    {
        [DataType(DataType.Text), MaxLength(50)]
        public string FirstName { get; set; }

        [DataType(DataType.Text), MaxLength(50)]
        public string MiddleName { get; set; }

        [DataType(DataType.Text), MaxLength(50)]
        public string LastName { get; set; }

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

        [DataType(DataType.Text), MaxLength(10)]
        public string HomePhone { get; set; }

        [DataType(DataType.Text), MaxLength(50)]
        public string MobilePhone { get; set; }

        [DataType(DataType.Text), MaxLength(150)]
        public string EmailAddress { get; set; }

        [DataType(DataType.Text), MaxLength(9)]
        public string Social { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime? DateHired { get; set; }

        public decimal? HourlyRate { get; set; }

    }
}
