using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Results.CarDetailResults
{
	public class GetCarDetailByCarIdOueryResult
	{
		public int CarID { get; set; }
		public int BrandID { get; set; }
		public string BrandName { get; set; }
		public string Model { get; set; }
		public string CoverImageUrl { get; set; }
		public int Km { get; set; }
		public int Year { get; set; }
		public byte Seat { get; set; }
		public byte Luggage { get; set; }
		public string BigImageUrl { get; set; }
		public string CarScore { get; set; }

		public int VitesID { get; set; }
		public string VitesName { get; set; }

		public int YakitTuruID { get; set; }
		public string YakitTuruName { get; set; }
	}
}
