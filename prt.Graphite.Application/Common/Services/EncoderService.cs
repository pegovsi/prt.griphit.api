using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Prt.Graphit.Application.Common.Services
{
    public class EncoderService
    {
        public static string GetSHA256(string user, string password)
        {
            if (string.IsNullOrEmpty(user))
                throw new ArgumentNullException("user");

            var usUpper = user.ToUpper();
            var usLower = user.ToLower();

            using SHA256 sha256 = SHA256Managed.Create();
            var part1 = sha256.ComputeHash(Encoding.UTF8.GetBytes(usUpper));
            var part2 = sha256.ComputeHash(Encoding.UTF8.GetBytes(string.Concat(usLower, ":", password)));

            var strPart1 = string.Join("", part1.Select(b => b.ToString("x2")).ToArray());
            var strPart2 = string.Join("", part2.Select(b => b.ToString("x2")).ToArray());

            var complete = sha256.ComputeHash(Encoding.UTF8.GetBytes(string.Concat(strPart1, strPart2)));
            var strComplete = string.Join("", complete.Select(b => b.ToString("x2")).ToArray());

            return strComplete;
        }
    }
}