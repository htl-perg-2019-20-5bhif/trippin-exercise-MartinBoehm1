using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tripping
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var file = await System.IO.File.ReadAllTextAsync("Data/users.txt");
            var users=JsonSerializer.Deserialize<IEnumerable<User>>(file);
            var k = 0;
            foreach(var i in users)
            {
                string s = await Tripping.GetSingleAsync(i.UserName);
                if ("{ \"error\":{ \"code\":\"\",\"message\":\"The request resource is not found.\"} }".Equals(s)) {
                    List<User> userList = new List<User>();
                    userList.Add(i);
                    Tripping.Post(JsonSerializer.Serialize<IEnumerable<User>>(userList));
                }
                k++;
            }
        }
    }
}
