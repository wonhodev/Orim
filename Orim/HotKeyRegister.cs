using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Orim
{
    class HotKeyRegister : IMessageFilter, IDisposable
    {
        [Flags]
        public enum ModifierKeys
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            Win = 8
        }

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, ModifierKeys fsModifiers, Keys vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr Hwnd, int id);

        // Hotkey Windows message
        const int WM_HOTKEY = 0x0312;

        public IntPtr Handle { get; }

        public int ID { get; }

        public ModifierKeys Modifiers { get; }

        public Keys Key { get; }

        public event EventHandler HotKeyPressed;

        public HotKeyRegister(IntPtr handle, int id, ModifierKeys modifiers, Keys key)
        {
            this.Handle = handle;
            this.ID = id;
            this.Modifiers = modifiers;
            this.Key = key;

            RegisterHotKey();

            // To get Windows messages for hotkey
            Application.AddMessageFilter(this);
        }

        public void RegisterHotKey()
        {
            bool isRegistered = RegisterHotKey(Handle, ID, Modifiers, Key);

            // The hotkey is already used
            if (!isRegistered)
            {
                // Unregister existed hotkey
                UnregisterHotKey(IntPtr.Zero, ID);

                // Register the hotkey again
                isRegistered = RegisterHotKey(Handle, ID, Modifiers, Key);

                // The hotkey is already used in others
                if (!isRegistered)
                {
                    throw new ApplicationException("The hotkey is already used");
                }
            }
        }

        /// <summary>
        /// Filters out a message before it is dispatched
        /// </summary>
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_HOTKEY && m.HWnd == Handle && m.WParam == (IntPtr)ID)
            {
                HotKeyPressed?.Invoke(this, EventArgs.Empty);

                // To stop the message from being dispatched
                return true;
            }

            // To allow the message to continue  to the next filter or control
            return false;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Application.RemoveMessageFilter(this);
                    UnregisterHotKey(IntPtr.Zero, 0);
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion
    }
}
