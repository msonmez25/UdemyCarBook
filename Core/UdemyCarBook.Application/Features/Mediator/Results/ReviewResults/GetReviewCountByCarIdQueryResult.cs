using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Results.ReviewResults
{
	public class GetReviewCountByCarIdQueryResult
	{
		public int CarID { get; set; }
		public int ReviewCount { get; set; }
	}
}
