#region header

// LoadAverage - LoadAvg.cs
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

using System;
using System.Diagnostics;
using System.ServiceProcess;
using System.Threading;

namespace LoadAverage
{
    public sealed partial class LoadAvg : ServiceBase
    {
        private const double exp1 = 1.0;
        private const double exp5 = 5.0;
        private const double exp15 = 15.0;
        private readonly object averageLocker = new object();

        private readonly ManualResetEvent exitNow = new ManualResetEvent(false);
        private Thread calcThread;

        private double currentLoadAverage;

        private double fifteenMinuteLoadAverage;
        private double fiveMinuteLoadAverage;
        private double oneMinuteLoadAverage;

        private PerformanceCounter pqlCount;

        public LoadAvg()
        {
            this.InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // Set up the process queue length performance counter.
            this.pqlCount = new PerformanceCounter("System", "Processor Queue Length", true);

            // Run the calculation thread.
            this.calcThread = new Thread(this.CalculationLoop);
        }

        protected override void OnStop()
        {
            this.StopService();
        }

        protected override void OnShutdown()
        {
            this.StopService();
        }

        private void StopService()
        {
            // Tell the calculation thread to exit, then wait for it to do so.
            this.exitNow.Set();
            this.calcThread.Join();

            this.exitNow.Reset();
            this.calcThread = null;

            // Stop watching the process queue length performance counter.
            this.pqlCount.Close();
            this.pqlCount = null;
        }

        private double CalculateLoad(double currentLoad, double period, double accumulated)
        {
            return accumulated*Math.Exp(-5.0/(60.0*period)) + currentLoad*(1.0 - Math.Exp(-5.0/(60.0*period)));
        }

        private void CalculationLoop()
        {
            do
            {
                lock (this.averageLocker)
                {
                    this.currentLoadAverage = this.pqlCount.NextValue();

                    this.oneMinuteLoadAverage = this.CalculateLoad(this.currentLoadAverage,
                                                                   exp1,
                                                                   this.oneMinuteLoadAverage);
                    this.fiveMinuteLoadAverage = this.CalculateLoad(this.currentLoadAverage,
                                                                    exp5,
                                                                    this.fiveMinuteLoadAverage);
                    this.fifteenMinuteLoadAverage = this.CalculateLoad(this.currentLoadAverage,
                                                                       exp15,
                                                                       this.fifteenMinuteLoadAverage);
                }

                this.OneMinuteAverage.RawValue = (long) (this.oneMinuteLoadAverage*1000.0);
                this.FiveMinuteAverage.RawValue = (long) (this.fiveMinuteLoadAverage*1000.0);
                this.FifteenMinuteAverage.RawValue = (long) (this.fifteenMinuteLoadAverage*1000.0);
            } while (!this.exitNow.WaitOne(5000, false));
        }
    }
}
