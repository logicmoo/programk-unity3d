// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.InterceptKeys
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace de.springwald.toolbox
{
  public class InterceptKeys
  {
    private static InterceptKeys.LowLevelKeyboardProc _proc = new InterceptKeys.LowLevelKeyboardProc(InterceptKeys.HookCallback);
    private static IntPtr _hookID = IntPtr.Zero;
    private const int WH_KEYBOARD_LL = 13;
    private const int WM_KEYDOWN = 256;

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr SetWindowsHookEx(
      int idHook,
      InterceptKeys.LowLevelKeyboardProc lpfn,
      IntPtr hMod,
      uint dwThreadId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool UnhookWindowsHookEx(IntPtr hhk);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr CallNextHookEx(
      IntPtr hhk,
      int nCode,
      IntPtr wParam,
      IntPtr lParam);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr GetModuleHandle(string lpModuleName);

    public static event EventHandler<EventArgs<int>> KeyPress;

    public static void Init()
    {
      InterceptKeys._hookID = InterceptKeys.SetHook(InterceptKeys._proc);
    }

    public static void Dispose()
    {
      InterceptKeys.UnhookWindowsHookEx(InterceptKeys._hookID);
    }

    private static IntPtr SetHook(InterceptKeys.LowLevelKeyboardProc proc)
    {
      using (Process currentProcess = Process.GetCurrentProcess())
      {
        using (ProcessModule mainModule = currentProcess.MainModule)
          return InterceptKeys.SetWindowsHookEx(13, proc, InterceptKeys.GetModuleHandle(mainModule.ModuleName), 0U);
      }
    }

    private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
      if (nCode >= 0 && wParam == (IntPtr) 256)
      {
        int num = Marshal.ReadInt32(lParam);
        if (InterceptKeys.KeyPress != null)
          InterceptKeys.KeyPress((object) null, new EventArgs<int>(num));
      }
      return InterceptKeys.CallNextHookEx(InterceptKeys._hookID, nCode, wParam, lParam);
    }

    private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
  }
}
