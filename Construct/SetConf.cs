using AccCheck.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccCheck.Construct
{
    public class SetConf
    {
        [DllImport("user32.dll")]
        public static extern void keybd_event(Keys bVk, byte bScan, UInt32 dwFlags, IntPtr dwExtraInfo);

        public const UInt32 KEYEVENTF_EXTENDEDKEY = 1;
        public const UInt32 KEYEVENTF_KEYUP = 2;

        [DllImport("User32.dll")]
        static extern void mouse_event(MouseFlags dwFlags, int dx, int dy, int dwData, UIntPtr dwExtraInfo);

        [Flags]
        enum MouseFlags
        {
            Move = 0x0001, LeftDown = 0x0002, LeftUp = 0x0004, RightDown = 0x0008, RightUp = 0x0010, Absolute = 0x8000, WeelDown = 0x0800
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        [DllImport("user32.dll")]
        static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int nFlags);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left, Top, Right, Bottom;
        }

        public static void MyMouseMove(int x, int y)
        { // поставить курсор мыши в координаты x и y
            PointConverter pc = new PointConverter();

            Point pt = new Point(x, y);

            Cursor.Position = pt;
        }


        public static void PlayerMove(string direction)
        { //нажатие клавиш
            switch (direction)
            {
                case "l":
                    keybd_event(Keys.L, 0, KEYEVENTF_EXTENDEDKEY, IntPtr.Zero);
                    Thread.Sleep(100);
                    keybd_event(Keys.L, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, IntPtr.Zero);
                    break;
                case "b":
                    keybd_event(Keys.B, 0, KEYEVENTF_EXTENDEDKEY, IntPtr.Zero);
                    Thread.Sleep(100);
                    keybd_event(Keys.B, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, IntPtr.Zero);
                    break;
                case "d":
                    keybd_event(Keys.D, 0, KEYEVENTF_EXTENDEDKEY, IntPtr.Zero);
                    Thread.Sleep(100);
                    keybd_event(Keys.D, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, IntPtr.Zero);
                    break;
                case "a":
                    keybd_event(Keys.A, 0, KEYEVENTF_EXTENDEDKEY, IntPtr.Zero);
                    Thread.Sleep(100);
                    keybd_event(Keys.A, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, IntPtr.Zero);
                    break;
                case "space":
                    keybd_event(Keys.Space, 0, KEYEVENTF_EXTENDEDKEY, IntPtr.Zero);
                    Thread.Sleep(100);
                    keybd_event(Keys.Space, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, IntPtr.Zero);
                    break;
                case "e":
                    keybd_event(Keys.E, 0, KEYEVENTF_EXTENDEDKEY, IntPtr.Zero);
                    Thread.Sleep(50);
                    keybd_event(Keys.E, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, IntPtr.Zero);
                    break;
                case "f3":
                    keybd_event(Keys.F3, 0, KEYEVENTF_EXTENDEDKEY, IntPtr.Zero);
                    Thread.Sleep(50);
                    keybd_event(Keys.F3, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, IntPtr.Zero);
                    break;
                case "esc":
                    keybd_event(Keys.Escape, 0, KEYEVENTF_EXTENDEDKEY, IntPtr.Zero);
                    Thread.Sleep(50);
                    keybd_event(Keys.Escape, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, IntPtr.Zero);
                    break;
                case "lmb":
                    mouse_event(MouseFlags.LeftDown, 0, 0, 0, UIntPtr.Zero);
                    Thread.Sleep(50);
                    mouse_event(MouseFlags.LeftDown | MouseFlags.LeftUp, 0, 0, 0, UIntPtr.Zero);
                    break;
                case "wld":
                    mouse_event(MouseFlags.WeelDown, 0, 0, -120, UIntPtr.Zero);
                    break;
                case "rmb":
                    keybd_event(Keys.RButton, 0, KEYEVENTF_EXTENDEDKEY, IntPtr.Zero);
                    Thread.Sleep(50);
                    keybd_event(Keys.RButton, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, IntPtr.Zero);
                    break;
            }
        }

        public static Color Paimonico = Color.FromArgb(255, 255, 255, 255);
        public static Color Buttonback = Color.FromArgb(255, 236, 229, 216);
        public static Color Fqualityapassive = Color.FromArgb(255, 73, 83, 102);
        public static Color Fqualityaactive = Color.FromArgb(255, 96, 105, 121);
        public static Color Bagweaponactive = Color.FromArgb(255, 211, 188, 142);
        public static Color Artloaded = Color.FromArgb(255, 233, 229, 220);
        public static Color Scrollerbottom = Color.FromArgb(255, 255, 255, 255);
        public static Color Primogem = Color.FromArgb(255, 154, 237, 253);
        public static Color Historybutton = Color.FromArgb(255, 60, 67, 86);
        public static Color Wishhistoryback = Color.FromArgb(255, 240, 236, 230);
        public static Color Wishhistorytableloaded = Color.FromArgb(255, 211, 188, 142);
        public static Color Legendarychar = Color.FromArgb(255, 189, 105, 50);
        public static Color Testpixel = Color.FromArgb(0, 0, 0, 0);
        public static Color Menumarketplateloaded = Color.FromArgb(255, 82, 91, 108);
        public static Color Paimonfirstmarketloaded = Color.FromArgb(255, 236, 229, 216);
        public static Color Paimonmarketloaded = Color.FromArgb(255, 254, 230, 176);
        public static Color Archiveloaded = Color.FromArgb(255, 200, 179, 137);
        public static Color Settingscontrolloaded = Color.FromArgb(255, 211, 188, 142);
        public static Color Settingsaccountloaded = Color.FromArgb(255, 255, 255, 255);
        public static Color Accountloaded = Color.FromArgb(255, 255, 255, 255);
        public static Color SupportButton = Color.FromArgb(255, 236, 229, 216);
        public static Color Gemloaded = Color.FromArgb(255, 118, 155, 248);

        public static void PixValue()
        {
            var process = Process.GetProcessesByName("GenshinImpact").FirstOrDefault();
            if (process == null)
            {
                MessageBox.Show(
                "Genshin impact не запущен",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                return;
            }
            var hwnd = process.MainWindowHandle;
            GetWindowRect(hwnd, out var rect);
            string result = "Настройка успешно завершена";
            MyMouseMove(rect.Left + 643, rect.Top + 374);
            PlayerMove("lmb");

            //Скрин комманды
            Thread.Sleep(100);
            MessageBox.Show(
            "Нажмите ок, когда игра будет в исходном положении",
            "Калибровка",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
            {
                using (var graphics = Graphics.FromImage(image))
                {
                    var hdcBitmap = graphics.GetHdc();
                    PrintWindow(hwnd, hdcBitmap, 0);
                    graphics.ReleaseHdc(hdcBitmap);
                    Paimonico = image.GetPixel(53, 57);
                }
            }
            PlayerMove("l");
            Thread.Sleep(100);

            MessageBox.Show(
            "Нажмите ок, когда вкладка с построением отряда будет целиком загружена",
            "Калибровка",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
            {
                using (var graphics = Graphics.FromImage(image))
                {
                    var hdcBitmap = graphics.GetHdc();
                    PrintWindow(hwnd, hdcBitmap, 0);
                    graphics.ReleaseHdc(hdcBitmap);
                    Buttonback = image.GetPixel(959, 689);
                }
            }
            Thread.Sleep(600);
            MyMouseMove(rect.Left + 901, rect.Top + 709);
            PlayerMove("lmb");
            for (Color pixel = Color.FromArgb(0, 0, 0, 0); Buttonback != pixel;)
            {
                Thread.Sleep(200);
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    using (var graphics = Graphics.FromImage(image))
                    {
                        var hdcBitmap = graphics.GetHdc();
                        PrintWindow(hwnd, hdcBitmap, 0);
                        graphics.ReleaseHdc(hdcBitmap);
                        pixel = image.GetPixel(317, 57);
                    }
                }
            }
            MyMouseMove(rect.Left + 222, rect.Top + 57);
            PlayerMove("lmb");
            Thread.Sleep(100);

            MessageBox.Show(
            "Нажмите ок, когда параметр с выбором фильтра будет целиком загружен",
            "Калибровка",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
            {
                using (var graphics = Graphics.FromImage(image))
                {
                    var hdcBitmap = graphics.GetHdc();
                    PrintWindow(hwnd, hdcBitmap, 0);
                    graphics.ReleaseHdc(hdcBitmap);
                    Fqualityapassive = image.GetPixel(264, 120);
                }
            }
            MyMouseMove(rect.Left + 222, rect.Top + 125);
            PlayerMove("lmb");
            PlayerMove("esc");
            Thread.Sleep(50);
            PlayerMove("esc");
            //

            //Скрин оружия
            for (Color pixel = Color.FromArgb(0, 0, 0, 0); Paimonico != pixel;)
            {
                Thread.Sleep(200);
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    using (var graphics = Graphics.FromImage(image))
                    {
                        var hdcBitmap = graphics.GetHdc();
                        PrintWindow(hwnd, hdcBitmap, 0);
                        graphics.ReleaseHdc(hdcBitmap);
                        pixel = image.GetPixel(53, 57);
                    }
                }
            }
            PlayerMove("b");
            Thread.Sleep(100);

            MessageBox.Show(
            "Нажмите ок, когда инвентарь оружия будет целиком загружен (если открылась не та вкладка, то переключитесь на необходимую вкладку)",
            "Калибровка",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
            {
                using (var graphics = Graphics.FromImage(image))
                {
                    var hdcBitmap = graphics.GetHdc();
                    PrintWindow(hwnd, hdcBitmap, 0);
                    graphics.ReleaseHdc(hdcBitmap);
                    Bagweaponactive = image.GetPixel(393, 89);
                }
            }
            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
            {
                using (var graphics = Graphics.FromImage(image))
                {
                    var hdcBitmap = graphics.GetHdc();
                    PrintWindow(hwnd, hdcBitmap, 0);
                    graphics.ReleaseHdc(hdcBitmap);
                    Buttonback = image.GetPixel(1161, 697);
                }
            }
            //

            //Скрин артефактов
            if (Form1.art == true)
            {
                MyMouseMove(rect.Left + 452, rect.Top + 60);
                PlayerMove("lmb");
                Thread.Sleep(100);
                PlayerMove("lmb");
                Thread.Sleep(200);

                MessageBox.Show(
                "Нажмите ок, когда инвентарь артефактов будет целиком загружен",
                "Калибровка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    using (var graphics = Graphics.FromImage(image))
                    {
                        var hdcBitmap = graphics.GetHdc();
                        PrintWindow(hwnd, hdcBitmap, 0);
                        graphics.ReleaseHdc(hdcBitmap);
                        Artloaded = image.GetPixel(162, 648);
                    }
                }
                Thread.Sleep(100);

                MessageBox.Show(
                "Прокрутите инвентарь артефактов в самый конец и нажмите ок",
                "Калибровка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                MyMouseMove(rect.Left + 863, rect.Top + 653);
                PlayerMove("lmb");
                for (int i = 0; i != 49; PlayerMove("wld"), i++) ;
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    using (var graphics = Graphics.FromImage(image))
                    {
                        var hdcBitmap = graphics.GetHdc();
                        PrintWindow(hwnd, hdcBitmap, 0);
                        graphics.ReleaseHdc(hdcBitmap);
                        Scrollerbottom = image.GetPixel(862, 650);
                    }
                }
            }
            //

            //Скрин карт опыта
            if (Form1.exp == true)
            {
                MyMouseMove(rect.Left + 518, rect.Top + 60);
                PlayerMove("lmb");
                Thread.Sleep(100);

                MessageBox.Show(
                "Нажмите ок, когда вкладка материалов будет целиком загружена",
                "Калибровка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    using (var graphics = Graphics.FromImage(image))
                    {
                        var hdcBitmap = graphics.GetHdc();
                        PrintWindow(hwnd, hdcBitmap, 0);
                        graphics.ReleaseHdc(hdcBitmap);
                        Primogem = image.GetPixel(117, 710);
                    }
                }
            }
            PlayerMove("esc");
            //




            //Скрин баннера
            if (Form1.banner == true)
            {
                for (Color pixel = Color.FromArgb(0, 0, 0, 0); Paimonico != pixel;)
                {
                    Thread.Sleep(200);
                    using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                    {
                        using (var graphics = Graphics.FromImage(image))
                        {
                            var hdcBitmap = graphics.GetHdc();
                            PrintWindow(hwnd, hdcBitmap, 0);
                            graphics.ReleaseHdc(hdcBitmap);
                            pixel = image.GetPixel(53, 57);
                        }
                    }
                }
                Thread.Sleep(400);
                PlayerMove("f3");
                Thread.Sleep(100);

                MessageBox.Show(
                "Нажмите ок, когда вклака молитв будет целиком загружена",
                "Калибровка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    using (var graphics = Graphics.FromImage(image))
                    {
                        var hdcBitmap = graphics.GetHdc();
                        PrintWindow(hwnd, hdcBitmap, 0);
                        graphics.ReleaseHdc(hdcBitmap);
                        Historybutton = image.GetPixel(337, 706);
                    }
                }
                MyMouseMove(rect.Left + 360, rect.Top + 705);
                PlayerMove("lmb");
                Thread.Sleep(100);

                MessageBox.Show(
                "Нажмите ок, когда история молитв будет целиком загружена",
                "Калибровка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    using (var graphics = Graphics.FromImage(image))
                    {
                        var hdcBitmap = graphics.GetHdc();
                        PrintWindow(hwnd, hdcBitmap, 0);
                        graphics.ReleaseHdc(hdcBitmap);
                        Wishhistoryback = image.GetPixel(620, 180);
                    }
                }
                MyMouseMove(rect.Left + 1010, rect.Top + 550);
                Thread.Sleep(200);
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    using (var graphics = Graphics.FromImage(image))
                    {
                        var hdcBitmap = graphics.GetHdc();
                        PrintWindow(hwnd, hdcBitmap, 0);
                        graphics.ReleaseHdc(hdcBitmap);
                        Wishhistorytableloaded = image.GetPixel(567, 547);
                    }
                }
                for (int i = 0; i != 20; PlayerMove("wld"), i++) ;
                Thread.Sleep(100);

                MessageBox.Show(
                "Нажмите ок, когда таблица истории молитв прокрутится ниже и будет целиком загружена",
                "Калибровка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                PlayerMove("esc");
                Thread.Sleep(200);
                PlayerMove("esc");
            }
            //

            //Скрин менюшки 
            for (Color pixel = Color.FromArgb(0, 0, 0, 0); Paimonico != pixel;)
            {
                Thread.Sleep(200);
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    using (var graphics = Graphics.FromImage(image))
                    {
                        var hdcBitmap = graphics.GetHdc();
                        PrintWindow(hwnd, hdcBitmap, 0);
                        graphics.ReleaseHdc(hdcBitmap);
                        pixel = image.GetPixel(53, 57);
                    }
                }
            }
            PlayerMove("esc");
            Thread.Sleep(100);

            MessageBox.Show(
            "Нажмите ок, когда меню паймон (пауза) будет целиком загружено",
            "Калибровка",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
            {
                using (var graphics = Graphics.FromImage(image))
                {
                    var hdcBitmap = graphics.GetHdc();
                    PrintWindow(hwnd, hdcBitmap, 0);
                    graphics.ReleaseHdc(hdcBitmap);
                    Menumarketplateloaded = image.GetPixel(488, 275);
                }
            }
            //

            //Скрин магазина кристаллов
            MyMouseMove(rect.Left + 135, rect.Top + 303);
            PlayerMove("lmb");
            Thread.Sleep(100);
            MessageBox.Show(
            "Нажмите ок, когда начальная вкладка магазин паймон будет целиком загружен",
            "Калибровка",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
            {
                using (var graphics = Graphics.FromImage(image))
                {
                    var hdcBitmap = graphics.GetHdc();
                    PrintWindow(hwnd, hdcBitmap, 0);
                    graphics.ReleaseHdc(hdcBitmap);
                    Paimonfirstmarketloaded = image.GetPixel(302, 120);
                }
            }
            MyMouseMove(rect.Left + 110, rect.Top + 376);
            PlayerMove("lmb");
            Thread.Sleep(100);

            MessageBox.Show(
            "Нажмите ок, когда магазин паймон с кристаллами будет целиком загружен",
            "Калибровка",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
            {
                using (var graphics = Graphics.FromImage(image))
                {
                    var hdcBitmap = graphics.GetHdc();
                    PrintWindow(hwnd, hdcBitmap, 0);
                    graphics.ReleaseHdc(hdcBitmap);
                    Paimonmarketloaded = image.GetPixel(696, 500);
                }
            }
            PlayerMove("esc");
            //

            //Проверка архива
            if (Form1.arch == true)
            {
                for (Color pixel = Color.FromArgb(0, 0, 0, 0); Menumarketplateloaded != pixel;)
                {
                    Thread.Sleep(200);
                    using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                    {
                        using (var graphics = Graphics.FromImage(image))
                        {
                            var hdcBitmap = graphics.GetHdc();
                            PrintWindow(hwnd, hdcBitmap, 0);
                            graphics.ReleaseHdc(hdcBitmap);
                            pixel = image.GetPixel(488, 275);
                        }
                    }
                }
                MyMouseMove(rect.Left + 135, rect.Top + 390);
                PlayerMove("lmb");
                Thread.Sleep(100);

                MessageBox.Show(
                "Нажмите ок, когда вкладка выбора разделов архива будет целиком загружена",
                "Калибровка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    using (var graphics = Graphics.FromImage(image))
                    {
                        var hdcBitmap = graphics.GetHdc();
                        PrintWindow(hwnd, hdcBitmap, 0);
                        graphics.ReleaseHdc(hdcBitmap);
                        Archiveloaded = image.GetPixel(53, 55);
                    }
                }
                PlayerMove("esc");
            }
            //

            //Скрин Привязок
            for (Color pixel = Color.FromArgb(0, 0, 0, 0); Menumarketplateloaded != pixel;)
            {
                Thread.Sleep(200);
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    using (var graphics = Graphics.FromImage(image))
                    {
                        var hdcBitmap = graphics.GetHdc();
                        PrintWindow(hwnd, hdcBitmap, 0);
                        graphics.ReleaseHdc(hdcBitmap);
                        pixel = image.GetPixel(488, 275);
                    }
                }
            }
            MyMouseMove(rect.Left + 37, rect.Top + 576);
            Thread.Sleep(50);
            PlayerMove("lmb");
            Thread.Sleep(100);

            MessageBox.Show(
            "Нажмите ок, когда вкладка настроек будет целиком загружена",
            "Калибровка",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
            {
                using (var graphics = Graphics.FromImage(image))
                {
                    var hdcBitmap = graphics.GetHdc();
                    PrintWindow(hwnd, hdcBitmap, 0);
                    graphics.ReleaseHdc(hdcBitmap);
                    Settingscontrolloaded = image.GetPixel(51, 59);
                }
            }
            MyMouseMove(rect.Left + 174, rect.Top + 411);
            Thread.Sleep(50);
            PlayerMove("lmb");
            Thread.Sleep(100);

            MessageBox.Show(
            "Нажмите ок, когда вкладка с управлением учетной записью будет целиком загружена",
            "Калибровка",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
            {
                using (var graphics = Graphics.FromImage(image))
                {
                    var hdcBitmap = graphics.GetHdc();
                    PrintWindow(hwnd, hdcBitmap, 0);
                    graphics.ReleaseHdc(hdcBitmap);
                    Settingsaccountloaded = image.GetPixel(364, 128);
                }
            }
            MyMouseMove(rect.Left + 1094, rect.Top + 166);
            Thread.Sleep(50);
            PlayerMove("lmb");
            Thread.Sleep(100);

            MessageBox.Show(
            "Нажмите ок, когда вкладка данными учетной записи будет целиком загружена",
            "Калибровка",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
            {
                using (var graphics = Graphics.FromImage(image))
                {
                    var hdcBitmap = graphics.GetHdc();
                    PrintWindow(hwnd, hdcBitmap, 0);
                    graphics.ReleaseHdc(hdcBitmap);
                    Accountloaded = image.GetPixel(550, 442);
                }
            }
            PlayerMove("esc");
            Thread.Sleep(50);
            PlayerMove("esc");
            //

            //Скрин доната
            for (Color pixel = Color.FromArgb(0, 0, 0, 0); Menumarketplateloaded != pixel;)
            {
                Thread.Sleep(200);
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    using (var graphics = Graphics.FromImage(image))
                    {
                        var hdcBitmap = graphics.GetHdc();
                        PrintWindow(hwnd, hdcBitmap, 0);
                        graphics.ReleaseHdc(hdcBitmap);
                        pixel = image.GetPixel(488, 275);
                    }
                }
            }
            Thread.Sleep(50);
            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
            {
                int width = 463;
                using (var graphics = Graphics.FromImage(image))
                {
                    var hdcBitmap = graphics.GetHdc();
                    PrintWindow(hwnd, hdcBitmap, 0);
                    graphics.ReleaseHdc(hdcBitmap);
                    for (Color pixel = image.GetPixel(width, 684); pixel != SupportButton; pixel = image.GetPixel(width, 684))
                    {
                        width = width - 104;
                        if (width < 0)
                        {
                            width = 464;
                        }
                    }
                }
                MyMouseMove(rect.Left + width, rect.Top + 684);
            }
            PlayerMove("lmb");
            Thread.Sleep(100);

            MessageBox.Show(
            "Нажмите ок, когда вкладка браузера будет целиком загружена",
            "Калибровка",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
            //for (int i = 0; i < 1; i++)
            //{
            //    Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            //    Graphics graphics = Graphics.FromImage(printscreen);
            //    graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
            //    Gemloaded = printscreen.GetPixel(1145, 408);
            //}
            Thread.Sleep(100);
            //
            Settings.Default.Paimonicolog = Paimonico;
            Settings.Default.Buttonbacklog = Buttonback;
            Settings.Default.Fqualityapassivelog = Fqualityapassive;
            Settings.Default.Fqualityaactivelog = Fqualityaactive;
            Settings.Default.Bagweaponactivelog = Bagweaponactive;
            Settings.Default.Artloadedlog = Artloaded;
            Settings.Default.Scrollerbottomlog = Scrollerbottom;
            Settings.Default.Primogemlog = Primogem;
            Settings.Default.Historybuttonlog = Historybutton;
            Settings.Default.Wishhistorybacklog = Wishhistoryback;
            Settings.Default.Wishhistorytableloadedlog = Wishhistorytableloaded;
            Settings.Default.Legendarycharlog = Legendarychar;
            Settings.Default.Testpixellog = Testpixel;
            Settings.Default.Menumarketplateloadedlog = Menumarketplateloaded;
            Settings.Default.Paimonmarketloadedlog = Paimonmarketloaded;
            Settings.Default.Archiveloadedlog = Archiveloaded;
            Settings.Default.Settingscontrolloadedlog = Settingscontrolloaded;
            Settings.Default.Settingsaccountloadedlog = Settingsaccountloaded;
            Settings.Default.Accountloadedlog = Accountloaded;
            Settings.Default.SupportButtonlog = SupportButton;
            Settings.Default.Gemloadedlog = Gemloaded;
            Settings.Default.Save();

            MessageBox.Show(
            "Калибровка успешно завершена",
            "Калибровка",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
        }
    }
}
