using System;
using System.Windows.Forms;
using Gma.UserActivityMonitor.WinApi;

namespace Gma.UserActivityMonitor
{
    /// <summary>
    /// This class monitors all mouse activities globally (also outside of the application) 
    /// and provides appropriate events.
    /// </summary>
    public class KeyboardHookListener : BaseHookListener
    {
        public KeyboardHookListener(BaseHooker hooker)
            : base(hooker)
        {
        }

        protected override bool ProcessCallback(int wParam, IntPtr lParam)
        {
            KeyEventArgsExt e = KeyEventArgsExt.FromRawData(wParam, lParam, IsGlobal);

            InvokeKeyDown(e);
            InvokeKeyPress(wParam, lParam);
            InvokeKeyUp(e);

            return e.Handled;
        }

        protected override int GetHookId()
        {
            return IsGlobal ? 
                GlobalHooker.WH_KEYBOARD_LL : 
                AppHooker.WH_KEYBOARD;
        }

        /// <summary>
        /// Occurs when a key is preseed. 
        /// </summary>
        public event KeyEventHandler KeyDown;

        private void InvokeKeyDown(KeyEventArgsExt e)
        {
            KeyEventHandler handler = KeyDown;
            if (handler == null || e.Handled || !e.IsKeyDown) { return; }
            handler(this, e);
        }

        /// <summary>
        /// Occurs when a key is pressed.
        /// </summary>
        /// <remarks>
        /// Key events occur in the following order: 
        /// <list type="number">
        /// <item>KeyDown</item>
        /// <item>KeyPress</item>
        /// <item>KeyUp</item>
        /// </list>
        ///The KeyPress event is not raised by noncharacter keys; however, the noncharacter keys do raise the KeyDown and KeyUp events. 
        ///Use the KeyChar property to sample keystrokes at run time and to consume or modify a subset of common keystrokes. 
        ///To handle keyboard events only in your application and not enable other applications to receive keyboard events, 
        /// set the KeyPressEventArgs.Handled property in your form's KeyPress event-handling method to <b>true</b>. 
        /// </remarks>
        public event KeyPressEventHandler KeyPress;

        private void InvokeKeyPress(int wParam, IntPtr lParam)
        {
            InvokeKeyPress(KeyPressEventArgsExt.FromRawData(wParam, lParam, IsGlobal));
        }

        private void InvokeKeyPress(KeyPressEventArgsExt e)
        {
            KeyPressEventHandler handler = KeyPress;
            if (handler == null || e.Handled || e.IsNonChar) { return; }
            handler(this, e);
        }

        /// <summary>
        /// Occurs when a key is released. 
        /// </summary>
        public event KeyEventHandler KeyUp;

        private void InvokeKeyUp(KeyEventArgsExt e)
        {
            KeyEventHandler handler = KeyUp;
            if (handler == null || e.Handled || !e.IsKeyUp) { return; }
            handler(this, e);
        }

        public override void Dispose()
        {
            KeyPress = null;
            KeyDown = null;
            KeyUp = null;

            base.Dispose();
        }
    }
}