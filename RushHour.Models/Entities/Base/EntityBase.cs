using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RushHour.Models.Entities.Base
{
    public abstract class EntityBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime? DateCreated { get; set; }

        public string UserCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public string UserModified { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }
    }
}              
