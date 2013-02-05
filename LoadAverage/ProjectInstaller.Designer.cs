namespace ArkaneSystems.LoadAverage
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.serviceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstaller = new System.ServiceProcess.ServiceInstaller();
            this.performanceCounterInstaller = new System.Diagnostics.PerformanceCounterInstaller();
            // 
            // serviceProcessInstaller
            // 
            this.serviceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstaller.Password = null;
            this.serviceProcessInstaller.Username = null;
            // 
            // serviceInstaller
            // 
            this.serviceInstaller.Description = "Calculate running load averages of the local computer.";
            this.serviceInstaller.DisplayName = "Load Average";
            this.serviceInstaller.ServiceName = "LoadAvg";
            this.serviceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // performanceCounterInstaller
            // 
            this.performanceCounterInstaller.CategoryHelp = "Unix-style load averages for this machine.";
            this.performanceCounterInstaller.CategoryName = "Load";
            this.performanceCounterInstaller.CategoryType = System.Diagnostics.PerformanceCounterCategoryType.SingleInstance;
            this.performanceCounterInstaller.Counters.AddRange(new System.Diagnostics.CounterCreationData[] {
            new System.Diagnostics.CounterCreationData("One Minute Load Average (x 1000)", "Number of processes in the system run queue averaged over one minute.", System.Diagnostics.PerformanceCounterType.NumberOfItems32)});
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller,
            this.serviceInstaller,
            this.performanceCounterInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller serviceInstaller;
        private System.Diagnostics.PerformanceCounterInstaller performanceCounterInstaller;
    }
}