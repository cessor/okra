using System;
using System.Windows.Forms;
using Application = System.Windows.Application;
using Control = System.Windows.Controls.Control;

namespace Seedling.Readability
{
    internal static class ControlDispatchExtension
    {
        public static void Dispatch(this Control control, Action action)
        {
            if (control.Dispatcher.CheckAccess())
            {
                action.Invoke();
            }
            else
            {
                control.Dispatcher.Invoke(new MethodInvoker(action));
            }
        }

        public static void Dispatch(this Application application, Action action)
        {
            if (application.Dispatcher.CheckAccess())
            {
                action.Invoke();
            }
            else
            {
                application.Dispatcher.Invoke(new MethodInvoker(action));
            }
        }
    }
}