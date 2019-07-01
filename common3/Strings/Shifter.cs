using Microsoft.SqlServer.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text.RegularExpressions;

namespace common.Strings
{
    public class Shifter
    {
        public static string Words_shift(string input, List<string> Words, bool toEnd = true)

        {
            List<string> w = Regex.Split(input, " ").OfType<string>().ToList<string>();
            List<string> inter = w.Intersect(Words).ToList();
            if (toEnd)
            {
                List<string> res = w.Except(inter).ToList();
                res.AddRange(inter);
                return String.Join(" ", res);
            }
            else
            { return inter.ToString(); }
        }
        public static string to_fias_AO_inter(string input, List<string> Words, bool toEnd = true, IComparer comparer = null)

        {
            List<string> w = Regex.Split(input, " ").OfType<string>().ToList<string>();
            List<string> inter = w.Intersect(Words).ToList();
            inter.Sort();
            if (toEnd)
            {
                List<string> res = w.Except(inter).ToList();
                res.AddRange(inter);

                return String.Join(" ", res);
            }
            else
            { return inter.ToString(); }
        }
        [SqlFunction]
        public static string To_fias(SqlString input)
        {
            List<string> words = new List<string>();
            for (int n = 1; n <= 99; n++)
            {
                words.Add(n.ToString() + "-й");
                words.Add(n.ToString() + "-я");
                words.Add(n.ToString() + "-е");
            }
            words.Add("улица");
            words.Add("аллея");
            words.Add("бульвар");
            words.Add("проезд");
            words.Add("переулок");
            words.Add("проспект");
            words.Add("площадь");
            words.Add("шоссе");
            words.Add("тупик");
            return to_fias_AO_inter(input.ToString(), words);
        }

    }
}