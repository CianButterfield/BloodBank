using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BloodBank.Models
{
    [MetadataType(typeof(DonorValidation))]
    public partial class Donor
    {
    }

    public class DonorValidation
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Blood_Group { get; set; }
        public string Medical_report { get; set; }
        public string Donor_Address { get; set; }
        [Required]
        public string Contact_Number { get; set; }
    }
}