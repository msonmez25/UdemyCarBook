using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Results.CarDescription
{
	public class GetCarDescriptionByIdQueryResult
	{
		public int CarDescriptionID { get; set; }
		public int CarID { get; set; }
		public string Details { get; set; }
	}
}
