﻿using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using Eplan.EplApi.System;
using Suplanus.Sepla.Gui;

namespace Suplanus.Sepla.Application
{
    public class EplanOffline
    {
        public EplApplication Application;

	    public Preview Preview;

		/// <summary>
		/// Starts EPLAN with the last version of Electric P8 and attach to (WPF) window
		/// </summary>
		/// <param name="window"></param>
		public void StartWpf(Window window)
	    {
			IntPtr handle = new WindowInteropHelper(window).Handle;
			string binPath = Starter.GetBinPathLastVersion();
			Start(handle,binPath);
		}

		/// <summary>
		/// Starts EPLAN with the last version of Electric P8 and attach to (WF) form
		/// </summary>
		/// <param name="form"></param>
		public void StartWindowsForms(Form form)
		{
			IntPtr handle = form.Handle;
			string binPath = Starter.GetBinPathLastVersion();
			Start(handle, binPath);
		}

		/// <summary>
		/// Starts EPLAN with the given version of program variant and attach to (WPF) window
		/// </summary>
		/// <param name="window"></param>
		/// <param name="binPath"></param>
		public void StartWpf(Window window, string binPath)
		{
			IntPtr handle = new WindowInteropHelper(window).Handle;
			Start(handle, binPath);
		}

		/// <summary>
		/// Returns if the EPLAN-Application is running
		/// </summary>
		public bool IsRunning
        {
            get { return Application != null; }
        }

	    

	    /// <summary>
		/// Starts the application
		/// </summary>
		/// <param name="handle"></param>
		/// <param name="binPath"></param>
        private void Start(IntPtr handle, string binPath)
        {
            if (Application == null)
            {
                try
                {
                    EplApplication eplApplication = new EplApplication();
                    eplApplication.EplanBinFolder = binPath;
                    eplApplication.ResetQuietMode();
                    eplApplication.SetMainFrame(handle);
                    eplApplication.Init("", true, true);
                    Application = eplApplication;
                }
                catch
                {
                    Application = null;
                } 
            }
        }

		/// <summary>
		/// Release all objects
		/// </summary>
        public void Close()
        {
            if (Application != null)
            {
                Application.Exit();
                Application = null;
            }
        }
    }
}