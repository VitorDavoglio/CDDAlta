using System;

namespace Domain_CodigoPenal.Models
{
    public class CriminalCode: BaseModel
    {
        public Guid Id { get; set; }
        public int StatusId { get; set; }
        public Guid CreateUserId { get; set; }
        public Guid? UpdateUserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Penalty { get; set; }
        public int PrisonTime { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }


        public User CreateUser { get; set; }
        public User UpdateUser { get; set; }
        public Status Status { get; set; }
    }
}
