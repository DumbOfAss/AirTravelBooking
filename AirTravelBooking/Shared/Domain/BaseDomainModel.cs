using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTravelBooking.Shared.Domain
{
    public abstract class BaseDomainModel
    {
        public int Id { get; set; }
        //public DateTime DateCreated { get; set; }
        //public DateTime DateUpdated { get; set; }
        //public string CreatedBy { get; set; }
        //public string UpdatedBy { get; set; }
    }
    
    public class Feature : BaseDomainModel
    {
        public string Name { get; set; }
    }

    public class Seat : BaseDomainModel
    {
        public string Availability { get; set; }
        public string Location { get; set; }
    }
    
    public class Priority : BaseDomainModel
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public int FeatureId { get; set; }
        public virtual Feature Feature { get; set; }
    }
}
