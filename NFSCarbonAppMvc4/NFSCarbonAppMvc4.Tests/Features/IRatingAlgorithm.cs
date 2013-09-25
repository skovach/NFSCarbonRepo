using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NFSCarbonAppMvc4.Models;

namespace NFSCarbonAppMvc4.Tests.Features
{
    public interface IRatingAlgorithm
    {
        RatingResult Compute(IList<CarReview> reviews);
    }

    public class SimpleRatingAlgorithm : IRatingAlgorithm
    {
        public RatingResult Compute(IList<CarReview> reviews)
        {

            var result = new RatingResult();
            result.Rating = (int) reviews.Average(c => c.Rating);
            return result;
        }
    }

    public class ComputeWeughtedRate : IRatingAlgorithm
    {

        public RatingResult Compute(IList<CarReview> reviews)
        {
            var result = new RatingResult();
            var counter = 0;
            var total = 0;

            for (int i = 0; i < reviews.Count(); i++)
            {
                if (i < reviews.Count()/2)
                {
                    counter += 2;
                    total += reviews[i].Rating*2;
                }
                else
                {
                    counter += 1;
                    total += reviews[i].Rating;
                }
            }
            result.Rating = total/counter;
            return result;
        }
    }
}
