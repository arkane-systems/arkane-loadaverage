namespace LoadAverage
{
    partial class LoadAvg
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", MessageId = "exitNow")]
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OneMinuteAverage = new System.Diagnostics.PerformanceCounter();
            this.FiveMinuteAverage = new System.Diagnostics.PerformanceCounter();
            this.FifteenMinuteAverage = new System.Diagnostics.PerformanceCounter();
            ((System.ComponentModel.ISupportInitialize)(this.OneMinuteAverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FiveMinuteAverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FifteenMinuteAverage)).BeginInit();
            // 
            // OneMinuteAverage
            // 
            this.OneMinuteAverage.CategoryName = "Load";
            this.OneMinuteAverage.CounterName = "One Minute Load Average (x 1000)";
            this.OneMinuteAverage.ReadOnly = false;
            // 
            // FiveMinuteAverage
            // 
            this.FiveMinuteAverage.CategoryName = "Load";
            this.FiveMinuteAverage.CounterName = "Five Minute Load Average (x 1000)";
            this.FiveMinuteAverage.ReadOnly = false;
            // 
            // FifteenMinuteAverage
            // 
            this.FifteenMinuteAverage.CategoryName = "Load";
            this.FifteenMinuteAverage.CounterName = "Fifteen Minute Load Average (x 1000)";
            this.FifteenMinuteAverage.ReadOnly = false;
            // 
            // LoadAvg
            // 
            this.CanShutdown = true;
            this.ServiceName = "LoadAvg";
            ((System.ComponentModel.ISupportInitialize)(this.OneMinuteAverage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FiveMinuteAverage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FifteenMinuteAverage)).EndInit();

        }

        #endregion

        private System.Diagnostics.PerformanceCounter OneMinuteAverage;
        private System.Diagnostics.PerformanceCounter FiveMinuteAverage;
        private System.Diagnostics.PerformanceCounter FifteenMinuteAverage;


    }
}
