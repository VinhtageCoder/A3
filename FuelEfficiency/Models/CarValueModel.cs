using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FuelEfficiency.Models
{
    public class CarValueModel
    {  
        /// <summary>
        /// validation for MakeModel 
        /// </summary>
        [Required(ErrorMessage =  "Please enter a make and model.")]
        [MinLength(3, ErrorMessage = "The Make/Model must be at least 3 characters")]
        [MaxLength(20, ErrorMessage = "The Make/Model cannot be more than 25 characters")]
        public String MakeModel { get; set; }

        /// <summary>
        /// validation for Year
        /// </summary>
        [Required(ErrorMessage = "Please enter a number of years.")]
        [Range(1950, 2021, ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public int? Year { get; set; } // ? for blank Required error message

        /// <summary>
        /// validation for Kilometers
        /// </summary>
        [Required(ErrorMessage = "Please enter kilometers.")]
        [Range(1 , 999999, ErrorMessage = "Kilometers must be between 1 and 999999.")]
        public double? Kilometers { get; set; }

        /// <summary>
        /// validation for Liters
        /// </summary>
        [Required(ErrorMessage = "Please enter liters.")]
        [Range(1, 65, ErrorMessage = "Liters amount must be between 1 and 65.")]
        public double? Liters { get; set; }

        /// <summary>
        /// when this is called, also do calculations
        /// </summary>
        public double? MilesPerGallon => CalculateMilesPerGallon();

        /// <summary>
        /// 1L/100km = mpg
        /// </summary>
        /// <returns></returns>
        public double? CalculateMilesPerGallon()
        {
                          //100km / user input L * 1miles/1.6km * 3.8L/1gallon
            double? milePerGallon = (100 / Liters) * (.625) * (3.8); 


            return milePerGallon; 
        }

        public double? CalculateLitersPerKilometer()
        {
            double? europeanFuelEconomy = (Liters/ Kilometers*100 ); 

            return europeanFuelEconomy;

        }
    }
}