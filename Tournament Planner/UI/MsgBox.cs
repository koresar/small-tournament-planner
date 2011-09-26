using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tournament_Planner.UI
{
    public static class MsgBox
    {
        public const string DefaultCaption = "Small tournament planner";

        public static DialogResult Show(string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(message, caption, buttons, icon);
        }

        public static void Error(string message, string caption = DefaultCaption)
        {
            Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void Exclamation(string message, string caption = DefaultCaption)
        {
            Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void Information(string message, string caption = DefaultCaption)
        {
            Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Warning(string message, string caption = DefaultCaption)
        {
            Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static bool YesNo(string message, string caption = DefaultCaption)
        {
            return Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static DialogResult YesNoCancel(string message, string caption = DefaultCaption)
        {
            return Show(message, caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }

        public static bool OkCancel(
            string message,
            string caption = DefaultCaption,
            MessageBoxIcon icon = MessageBoxIcon.Question)
        {
            return Show(message, caption, MessageBoxButtons.OKCancel, icon) == DialogResult.OK;
        }
    }
}
