using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NFSCarbonAppMvc4.Models;

namespace NFSCarbonAppMvc4.Tests.Features
{
    class CarRater
    {
        private Car car;

        public CarRater(Car car)
        {
            this.car = car;
        }

        public RatingResult ComputeResult(IRatingAlgorithm algorithm, int numberOfRewievsToUse)
        {
            var filteredReviews = car.CarReview.Take(numberOfRewievsToUse);

            return algorithm.Compute(filteredReviews.ToList());
        }

    }
}
