using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Helpers
{
    public static class QueryHelper
    {
        public static IQueryable<T> Include<T>(IQueryable<T> sequence, string includeProperties)
        {
            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                var properties = includeProperties.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var includeProperty in properties)
                {
                    sequence = sequence.Include(includeProperty);
                }
            }
            return sequence;
        }
    }
}
