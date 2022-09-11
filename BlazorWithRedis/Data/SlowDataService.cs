using BlazorWithRedis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWithRedis.Data
{
    public class SlowDataService
    {
        private readonly DatabaseContext _context;

        public SlowDataService(DatabaseContext context)
        {
            _context = context;
        }

        public List<User> GetUsers()
        {
            return _context.Users
                .Where(x => x.FirstName.Contains("john") && x.LastName.Contains("sm")).Take(1000)
                .ToList();
        }
    }
}
