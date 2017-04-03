using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace getCursorPos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Timer t1 = new Timer();
            t1.Interval = 50;
            t1.Tick += new EventHandler(timer1_Tick);
            t1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = Cursor.Position.X.ToString();
            textBox2.Text = Cursor.Position.Y.ToString();
        }

        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        // Activate an application window.
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        private void button1_Click(object sender, EventArgs e)
        {
            //// Get a handle to the Calculator application. The window class
            //// and window name were obtained using the Spy++ tool.
            //IntPtr calculatorHandle = FindWindow("CalcFrame", "Calculator");

            //// Verify that Calculator is a running process.
            //if (calculatorHandle == IntPtr.Zero)
            //{
            //    MessageBox.Show("Calculator is not running.");
            //    return;
            //}

            //// Make Calculator the foreground application and send it 
            //// a set of calculations.
            //SetForegroundWindow(calculatorHandle);
            //SendKeys.SendWait("111");
            //SendKeys.SendWait("*");
            //SendKeys.SendWait("11");
            //SendKeys.SendWait("=");


            SendLeftClick(-1210, 1180);
            LeftMouseClick(618,1059);
        }

        private void SendLeftClick(int x, int y)
        {
            //int old_x, old_y;
            //old_x = Cursor.Position.X;
            //old_y = Cursor.Position.Y;

            //SetCursorPos(x, y);
            //mouse_event(MouseEventFlag.LeftDown, x, y, 0, UIntPtr.Zero);
            //mouse_event(MouseEventFlag.LeftUp, x, y, 0, UIntPtr.Zero);
            //SetCursorPos(old_x, old_y);
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public const int MOUSE_LEFTDOWN = 0x02;
        public const int MOUSE_LEFTUP = 0x04;

        public static void LeftMouseClick(int x, int y)
        {
            SetCursorPos(x, y);
            mouse_event(MOUSE_LEFTDOWN, x, y, 0, 0);
            mouse_event(MOUSE_LEFTUP, x, y, 0, 0);
            SendKeys.SendWait("111");
            SendKeys.SendWait("*");
            SendKeys.SendWait("11");
            SendKeys.SendWait("=");
            
        }
    }
}
    
    

