using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace BeamModTextureOptimiser
{
    [ComImport]
    [Guid("EBBC7C04-315E-11d2-B62F-006097DF5BD4")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IProgressDialog
    {
        void StartProgressDialog(IntPtr hwndParent, object punkEnableModless, ProgressDialogFlags dwFlags, IntPtr pvResevered);

        void StopProgressDialog();

        void SetTitle(string title);

        void SetAnimation(IntPtr hInstAnimation, ushort idAnimation);

        [PreserveSig]
        bool HasUserCancelled();

        void SetProgress(uint dwCompleted, uint dwTotal);

        void SetProgress64(ulong ullCompleted, ulong ullTotal);

        void SetLine(uint dwLineNum, string pwzString, bool fCompactPath, IntPtr pvResevered);

        void SetCancelMsg(string pwzCancelMsg, object pvResevered);

    }

    [Flags]
    public enum ProgressDialogFlags : uint
    {
        Normal = 0,
        Modal = 1,
        AutoTime = 2,
        NoTime = 4,
        NoMinimize = 8,
        NoProgressBar = 16,
        Marquee = 32,
        NoCancel = 64
    }

    class FakeProgressDialog : IProgressDialog
    {
        public void StartProgressDialog(IntPtr hwndParent, object punkEnableModless, ProgressDialogFlags dwFlags, IntPtr pvResevered)
        {
        }

        public void StopProgressDialog()
        {
        }

        public void SetTitle(string title)
        {
        }

        public void SetAnimation(IntPtr hInstAnimation, ushort idAnimation)
        {
        }

        public bool HasUserCancelled()
        {
            return false;
        }

        public void SetProgress(uint dwCompleted, uint dwTotal)
        {
        }

        public void SetProgress64(ulong ullCompleted, ulong ullTotal)
        {
        }

        public void SetLine(uint dwLineNum, string pwzString, bool fCompactPath, IntPtr pvResevered)
        {
        }

        public void SetCancelMsg(string pwzCancelMsg, object pvResevered)
        {
        }
    }
    public class Win32Factory
    {
        public static IProgressDialog CreateProgressDialogue()
        {
            var type = Type.GetTypeFromCLSID(new Guid("F8383852-FCD3-11d1-A6B9-006097DF5BD4"));
            object ret = Activator.CreateInstance(type);
            // for non-windows systems, where the IProgressDialog interface doesn't exist
            if (ret == null) return new FakeProgressDialog();
            return (IProgressDialog)ret;
        }
    }
}
