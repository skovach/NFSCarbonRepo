using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFSCarbonAppMvc4.Models;
using System.Linq;

namespace NFSCarbonAppMvc4.Tests.Features
{
    [TestClass]
    public class RatingTests
    {
        [TestMethod]
        public void Computes_Result_For_One_Review()
        {
            var data = BuildCarReview(4);
            var rater = new CarRater(data);
            var result = rater.ComputeResult(new SimpleRatingAlgorithm(), 10);

            Assert.AreEqual(4, result.Rating);

        }
        [TestMethod]
        public void Computes_Result_For_Two_Review()
        {
            var data = BuildCarReview(ratings: new[] {4, 8});
            var rater = new CarRater(data);
            var result = rater.ComputeResult(new SimpleRatingAlgorithm(), 10);

            Assert.AreEqual(6, result.Rating);
        }

        [TestMethod]
        public void Weighted_Averaging_For_Two_Reviews()
        {
            var data = BuildCarReview(3, 9);

            var rater = new CarRater(data);
            var result = rater.ComputeResult(new ComputeWeughtedRate(), 10);

            Assert.AreEqual(5, result.Rating);
        }

        [TestMethod]
        public void Rating_Includes_Only_First_N_Reviews()
        {
            var data = BuildCarReview(1, 1, 1, 10, 10, 10);
            var rater = new CarRater(data);
            var result = rater.ComputeResult(new SimpleRatingAlgorithm(), 3);

            Assert.AreEqual(1, result.Rating);
        }

        private Car BuildCarReview(params int[] ratings)
        {
            var car = new Car();

            //need a using statement for SystemLinq at the  top of the file
            car.CarReview =
                ratings.Select(c => new CarReview() {Rating = c}).ToList();

            return car;
        }
    }


}
