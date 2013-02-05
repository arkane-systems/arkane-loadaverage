#region header

// LoadAverage - ProjectInstaller.cs
// 
// Alistair J. R. Young
// Arkane Systems
// 
// Copyright Arkane Systems 2012-2013.  All rights reserved.
// 
// Licensed and made available under MS-PL: http://opensource.org/licenses/ms-pl .
// 
// Created: 2013-02-05 9:42 AM

#endregion

using System.ComponentModel;
using System.Configuration.Install;

namespace ArkaneSystems.LoadAverage
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            this.InitializeComponent();
        }
    }
}
