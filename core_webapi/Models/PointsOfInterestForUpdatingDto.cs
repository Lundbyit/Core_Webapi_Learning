using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace core_webapi.Models
{
    public class PointsOfInterestForUpdatingDto
    {
        [Required(ErrorMessage = "A name must be provided")]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
