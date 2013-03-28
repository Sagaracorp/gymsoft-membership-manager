using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Xml;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace csharptest
{
    public partial class Form1 : Form
    {
        static short WM_CAP = 1024;
        static int WM_CAP_DRIVER_CONNECT  = WM_CAP + 10;

        static int WM_CAP_DRIVER_DISCONNECT = WM_CAP + 11;
        static int WM_CAP_EDIT_COPY = WM_CAP + 30;

        static int WM_CAP_SET_PREVIEW = WM_CAP + 50;
        static int WM_CAP_SET_PREVIEWRATE = WM_CAP + 52;
        static int WM_CAP_SET_SCALE = WM_CAP + 53;
        static int WS_CHILD = 1073741824;
        static int WS_VISIBLE = 268435456;
        static short SWP_NOMOVE =  2;
        //static short SWP_NOSIZE = 1;
        static short SWP_NOZORDER = 4;
        static short HWND_BOTTOM = 1;

        int iDevice = 0;
        int hHwnd; 

        [DllImport("user32", EntryPoint = "SendMessage")]
        public static extern int SendMessage(int hwnd, int wMsg, int wParam, int lParam);

        [DllImport("user32", EntryPoint = "SetWindowPos")]
        public static extern int SetWindowPos(int hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);

        [DllImport("user32", EntryPoint = "DestroyWindow")]
        public static extern int DestroyWindow(int hndw);

        [DllImport("avicap32.dll", EntryPoint = "capCreateCaptureWindowA")]
        public static extern int capCreateCaptureWindowA (string lpszWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, int hWndParent, int nID);

        [DllImport("avicap32.dll", EntryPoint = "capGetDriverDescriptionA")]
        public static extern bool capGetDriverDescriptionA (short wDriver, [MarshalAs(UnmanagedType.VBByRefStr)]ref string lpszName, int cbName, [MarshalAs(UnmanagedType.VBByRefStr)]ref string lpszVer, int cbVer);

        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sfdImage.Filter = "jpeg|*.jpg";

            LoadDeviceList();
            if (lstDevices.Items.Count > 0)
            {
                btnStart.Enabled = true;
                lstDevices.SelectedIndex = 0;
                btnStart.Enabled = true;
            }
            else
            {
                lstDevices.Items.Add("No Capture Device");
                btnStart.Enabled = false;
            }
        
            btnStop.Enabled = false;
            btnSave.Enabled = false;

            picCapture.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void LoadDeviceList()
        {
            string strName = "".PadRight(1024);
            string strVer = "".PadRight(1024);
            bool bReturn;
            short x = 0;

            do
            {
                bReturn = capGetDriverDescriptionA(x, ref strName, 1024, ref strVer, 1024);

                if(bReturn)
                {
                    lstDevices.Items.Add(strName.Trim());
                    x += 1;
                }
            }
            while (bReturn == false);
        }


        private void OpenPreviewWindow()
        {
            int iHeight = picCapture.Height;
            int iWidth = picCapture.Width;

            hHwnd = capCreateCaptureWindowA(iDevice.ToString(), WS_VISIBLE | WS_CHILD, 0, 0, 640, 480, picCapture.Handle.ToInt32(), 0);

            if(SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0) != 0)
            {
                SendMessage(hHwnd, WM_CAP_SET_SCALE, 1, 0);
                SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, 10, 0);
                SendMessage(hHwnd, WM_CAP_SET_PREVIEW, 1, 0);
                SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, picCapture.Width, picCapture.Height, SWP_NOMOVE | SWP_NOZORDER);
                
                btnSave.Enabled = true;
                btnStop.Enabled = true;
                btnStart.Enabled = false;
            }
            else
            {
                DestroyWindow(hHwnd);
                btnSave.Enabled = false;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            iDevice = lstDevices.SelectedIndex;
            OpenPreviewWindow();
        }

        private void ClosePreviewWindow()
        {
            SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, iDevice, 0);
            DestroyWindow(hHwnd);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            ClosePreviewWindow();
            btnSave.Enabled = false;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void Form1_Closing(object sender, EventArgs e)
        {
            if(btnStop.Enabled)
            {
                ClosePreviewWindow();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IDataObject data;
            Image bmap;

            SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0);

            data = Clipboard.GetDataObject();

            if (data.GetDataPresent(DataFormats.Bitmap))
            {
                bmap = (Image) data.GetData(DataFormats.Bitmap);
                picCapture.Image = bmap;
                ClosePreviewWindow();
                btnSave.Enabled = false;
                btnStop.Enabled = false;
                btnStart.Enabled = true;

                if (sfdImage.ShowDialog() == DialogResult.OK)
                {
                    bmap.Save(sfdImage.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }

            }
        }
    }
}
