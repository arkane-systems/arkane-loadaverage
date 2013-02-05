#region header

// GetLoadAverage - Program.cs
// 
// Alistair J. R. Young
// Arkane Systems
// 
// Copyright Arkane Systems 2012-2013.  All rights reserved.
// 
// Licensed and made available under MS-PL: http://opensource.org/licenses/ms-pl .
// 
// Created: 2013-02-05 8:52 AM

#endregion

using System;

namespace ArkaneSystems.LoadAverage
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 1 && (args[0] == "-?" || args[0] == "/?" || (args[0] == "-h" || args[0] == "/h")))
            {
                Console.WriteLine("usage: GetLoadAverage\n");
                Console.WriteLine(
                    "The GetLoadAverage command gives a one line display of the system load averages\nfor the past 1, 5, and 15 minutes.");
            }
            else if (args.Length != 0)
            {
                Console.WriteLine("error: bad option.");
                Environment.ExitCode = 1;
            }
            else
            {
                try
                {
                    Console.WriteLine("load average: {0:F2}, {1:F2}, {2:F2}",
                                      LoadAverage.OneMinute,
                                      LoadAverage.FiveMinute,
                                      LoadAverage.FifteenMinute);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error: {0}", ex.Message);
                    Environment.ExitCode = 2;
                }
            }
        }
    }
}
