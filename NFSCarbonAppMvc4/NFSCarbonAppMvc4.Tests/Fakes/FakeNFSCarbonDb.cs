using System;
using System.Collections.Generic;
using System.Linq;
using NFSCarbonAppMvc4.Models;

namespace NFSCarbonAppMvc4.Tests.Fakes
{
    class FakeNFSCarbonDb : INFSCarbondb
    {
        public IQueryable<T> Query<T>() where T : class
        {
            return Sets[typeof (T)] as IQueryable<T>;
        }

        public void Dispose(){}

        public void AddSet<T>(IQueryable<T> objects)
        {
            Sets.Add(typeof (T), objects);
        }

        public Dictionary<Type, object> Sets = new Dictionary<Type, object>();
    }
}
