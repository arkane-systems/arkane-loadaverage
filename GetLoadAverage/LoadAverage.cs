#region header

// GetLoadAverage - LoadAverage.cs
// 
// Alistair J. R. Young
// Arkane Systems
// 
// Copyright Arkane Systems 2012-2013.  All rights reserved.
// 
// Licensed and made available under MS-PL: http://opensource.org/licenses/ms-pl .
// 
// Created: 2013-02-05 9:52 AM

#endregion

using System;
using System.Diagnostics;

namespace ArkaneSystems.LoadAverage
{
    /// <summary>
    ///     A class representing the ongoing system load average.
    /// </summary>
    /// <remarks>
    ///     This is the class to steal if you're going to use load averages in your own applications.
    ///     (Which is why it's more complex than it needs to be here.)
    /// </remarks>
    public static class LoadAverage
    {
        private static int nextUpdateTime;

        private static readonly PerformanceCounter oneMinuteLoadAverage = new PerformanceCounter("Load",
                                                                                                 "One Minute Load Average (x 1000)",
                                                                                                 true);

        private static readonly PerformanceCounter fiveMinuteLoadAverage = new PerformanceCounter("Load",
                                                                                                  "Five Minute Load Average (x 1000)",
                                                                                                  true);

        private static readonly PerformanceCounter fifteenMinuteLoadAverage = new PerformanceCounter("Load",
                                                                                                     "Fifteen Minute Load Average (x 1000)",
                                                                                                     true);

        /// <summary>
        ///     One-minute load average of the local system.
        /// </summary>
        public static double OneMinute { get; private set; }

        /// <summary>
        ///     Five-minute load average of the local system.
        /// </summary>
        public static double FiveMinute { get; private set; }

        /// <summary>
        ///     Fifteen-minute load average of the local system.
        /// </summary>
        public static double FifteenMinute { get; private set; }

        private static void UpdateCounters()
        {
            if (Environment.TickCount > nextUpdateTime)
            {
                // This is the granularity of the updates at the other end, so no point in updating more often.
                nextUpdateTime = Environment.TickCount + 5000;

                OneMinute = oneMinuteLoadAverage.RawValue/1000.0;
                FiveMinute = fiveMinuteLoadAverage.RawValue/1000.0;
                FifteenMinute = fifteenMinuteLoadAverage.RawValue/1000.0;
            }
        }
    }
}
