using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;

namespace CodeLibrary
{
    public class CaptureImage
    {
        private static short WM_CAP = 1024;
        private static int WM_CAP_DRIVER_CONNECT = WM_CAP + 10;
        private static int WM_CAP_DRIVER_DISCONNECT = WM_CAP + 11;
        private static int WM_CAP_EDIT_COPY = WM_CAP + 30;
        private static int WM_CAP_SET_PREVIEW = WM_CAP + 50;
        private static int WM_CAP_SET_PREVIEWRATE = WM_CAP + 52;
        private static int WM_CAP_SET_SCALE = WM_CAP + 53;
        private static int WS_CHILD = 1073741824;
        private static int WS_VISIBLE = 268435456;
        private static short SWP_NOMOVE = 2;
        private static short SWP_NOZORDER = 4;
        private static short HWND_BOTTOM = 1;
        //private static short SWP_NOSIZE = 1;

        private int iDevice = 0;
        private int hHwnd;

        private List<string> devices = new List<string>();


        [DllImport("user32", EntryPoint = "SendMessage")]
        private static extern int SendMessage(int hwnd, int wMsg, int wParam, int lParam);

        [DllImport("user32", EntryPoint = "SetWindowPos")]
        private static extern int SetWindowPos(int hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);

        [DllImport("user32", EntryPoint = "DestroyWindow")]
        private static extern int DestroyWindow(int hndw);

        [DllImport("avicap32.dll", EntryPoint = "capCreateCaptureWindowA")]
        private static extern int capCreateCaptureWindowA(string lpszWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, int hWndParent, int nID);

        [DllImport("avicap32.dll", EntryPoint = "capGetDriverDescriptionA")]
        private static extern bool capGetDriverDescriptionA(short wDriver, [MarshalAs(UnmanagedType.VBByRefStr)]ref string lpszName, int cbName, [MarshalAs(UnmanagedType.VBByRefStr)]ref string lpszVer, int cbVer);


        public List<string> getImagingDevices()
        {
            string strName = "".PadRight(1024);
            string strVer = "".PadRight(1024);
            bool bReturn;
            short x = 0;
            
            do
            {
                bReturn = capGetDriverDescriptionA(x, ref strName, 1024, ref strVer, 1024);

                if (bReturn)
                {
                    devices.Add(strName.Trim());
                    x += 1;
                }
            }
            while (bReturn == false);

            return devices;
        }

        public int getImagePreview(string devicename,  ref PictureBox picCapture)
        {
            picCapture.SizeMode = PictureBoxSizeMode.StretchImage;
            
            hHwnd = capCreateCaptureWindowA(devices.IndexOf(devicename).ToString(), WS_VISIBLE | WS_CHILD, 0, 0, 640, 480, picCapture.Handle.ToInt32(), 0);

            if(SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0) != 0)
            {
                SendMessage(hHwnd, WM_CAP_SET_SCALE, 1, 0);
                SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, 10, 0);
                SendMessage(hHwnd, WM_CAP_SET_PREVIEW, 1, 0);
                SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, picCapture.Width, picCapture.Height, SWP_NOMOVE | SWP_NOZORDER);
                return 1;
            }
            else
            {
                DestroyWindow(hHwnd);
                return 0;
            }
        }

        public int stopImagePreview()
        {
            SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, iDevice, 0);
            DestroyWindow(hHwnd);
            return 1;
        }

        public int saveImage(string path, ref PictureBox picCapture)
        {
            IDataObject data;
            Image bmap;

            SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0);

            data = Clipboard.GetDataObject();

            if (data.GetDataPresent(DataFormats.Bitmap))
            {
                bmap = (Image)data.GetData(DataFormats.Bitmap);
                picCapture.Image = bmap;
                stopImagePreview();

                bmap.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);

                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
