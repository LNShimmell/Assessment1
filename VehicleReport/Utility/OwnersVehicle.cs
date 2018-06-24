using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleReport.Models;

namespace VehicleReport.Utility {
	public class OwnersVehicle {
		public IEnumerable<Vehcile> Vehicles { get; set; }
		public Owner Owner { get; set; }
		
	}
}