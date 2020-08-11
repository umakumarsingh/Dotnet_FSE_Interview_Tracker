using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace User.Microservice.Entities
{
    public enum Status
    {
        Locked = 1,
        Bench = 2,
        [Display(Name = "In Training")]
        InTraining = 3,
        Released = 4
    }
}
