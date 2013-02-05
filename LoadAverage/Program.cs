#region header

// LoadAverage - Program.cs
// 
// Alistair J. R. Young
// Arkane Systems
// 
// Copyright Arkane Systems 2012-2013.  All rights reserved.
// 
// Licensed and made available under MS-PL: http://opensource.org/licenses/ms-pl .
// 
// Created: 2013-02-05 8:47 AM

#endregion

using System.ServiceProcess;

namespace LoadAverage
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        private static void Main()
        {
            var ServicesToRun = new ServiceBase[]
                {
                    new LoadAvg()
                };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
