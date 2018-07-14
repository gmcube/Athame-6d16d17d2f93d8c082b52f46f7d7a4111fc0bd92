﻿using System;
using System.Windows.Forms;

// ReSharper disable InconsistentNaming

namespace Athame.UI.Win32
{
    /// <summary>
    /// Progress bar state as defined in CommCtrl.h.
    /// </summary>
    public enum ProgressBarState
    {
        /// <summary>
        /// Progress bar appears green (default)
        /// </summary>
        Normal = 1,
        /// <summary>
        /// Progress bar appears red
        /// </summary>
        Error = 2,
        /// <summary>
        /// Progress bar appears yellow
        /// </summary>
        Warning = 3
    }

    public static class ProgressBarExtensions
    {
        

        // CommCtrl.h
        private const int PBM_SETSTATE = Native.WM_USER + 16;
        private const int PBM_GETSTATE = Native.WM_USER + 17;

        public static ProgressBarState GetState(this ProgressBar progressBar)
        {
            return (ProgressBarState)Native.SendMessage(progressBar.Handle, PBM_GETSTATE, IntPtr.Zero, IntPtr.Zero);
        }

        public static void SetState(this ProgressBar progressBar, ProgressBarState state)
        {
            Native.SendMessage(progressBar.Handle, PBM_SETSTATE, new IntPtr((int) state), IntPtr.Zero);
        }
    }
}
