using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using AccCheck.Construct;
using AccCheck.Properties;

namespace AccCheck
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button2.Text = Settings.Default["Buttonlog"].ToString();
            button3.Text = Settings.Default["Buttonpass"].ToString();
            textBox1.Text = Settings.Default["Textboxlog"].ToString();
            SetConf.Paimonico = Settings.Default.Paimonicolog;
            SetConf.Buttonback = Settings.Default.Buttonbacklog;
            SetConf.Fqualityapassive = Settings.Default.Fqualityapassivelog;
            SetConf.Fqualityaactive = Settings.Default.Fqualityaactivelog;
            SetConf.Bagweaponactive = Settings.Default.Bagweaponactivelog;
            SetConf.Artloaded = Settings.Default.Artloadedlog;
            SetConf.Scrollerbottom = Settings.Default.Scrollerbottomlog;
            SetConf.Primogem = Settings.Default.Primogemlog;
            SetConf.Historybutton = Settings.Default.Historybuttonlog;
            SetConf.Wishhistoryback = Settings.Default.Wishhistorybacklog;
            SetConf.Wishhistorytableloaded = Settings.Default.Wishhistorytableloadedlog;
            SetConf.Legendarychar = Settings.Default.Legendarycharlog;
            SetConf.Testpixel = Settings.Default.Testpixellog;
            SetConf.Menumarketplateloaded = Settings.Default.Menumarketplateloadedlog;
            SetConf.Paimonfirstmarketloaded = Settings.Default.Paimonfirstmarketloadedlog;
            SetConf.Paimonmarketloaded = Settings.Default.Paimonmarketloadedlog;
            SetConf.Archiveloaded = Settings.Default.Archiveloadedlog;
            SetConf.Settingscontrolloaded = Settings.Default.Settingscontrolloadedlog;
            SetConf.Settingsaccountloaded = Settings.Default.Settingsaccountloadedlog;
            SetConf.Accountloaded = Settings.Default.Accountloadedlog;
            SetConf.SupportButton = Settings.Default.SupportButtonlog;
            SetConf.Gemloaded = Settings.Default.Gemloadedlog;
        }

        private static System.Timers.Timer aTimer;

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
        //Общие переменные
        public static bool MousePressed = false;
        public static int ButtonPanelState = 1;
        public static bool TwoMenuActive = false;
        public static int Timerended = 0;
        private static string Pass;
        private static string Log;

        //Доп проверки
        public static bool fey = false;
        public static bool arch = false;
        public static bool art = false;
        public static bool resin = false;
        public static bool exp = false;
        public static bool support = false;
        public static bool banner = false;
        private void label2_Click(object sender, EventArgs e)
        {

        }

        public static void GlobalBody()
        {
            if (MousePressed == true)
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
                //Configuration
                string CPU = "";
                string HARD = "";

                string folder = "";
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        folder = fbd.SelectedPath;
                    }
                    else
                    {
                        MessageBox.Show(
                        "Не был выбран путь для сохранения скриншотов проверки",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
                        return;
                    }
                }

                if (CPU == CPU)
                {
                    if (HARD == HARD)
                    {
                        var hwnd = process.MainWindowHandle;
                        GetWindowRect(hwnd, out var rect);
                        string result = "Проверка завершена:" + "\n";
                        int imagenum = 1;
                        MyMouseMove(rect.Left + 643, rect.Top + 374);
                        PlayerMove("lmb");

                        //Скрин комманды
                        Color white = Color.FromArgb(255, 255, 255, 255);
                        Color black = Color.FromArgb(0, 0, 0, 0);
                        for (Color pixel = Color.FromArgb(0, 0, 0, 0); SetConf.Paimonico != pixel && white != pixel;)
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
                        PlayerMove("l");
                        Thread.Sleep(1500);
                        for (Color pixel = Color.FromArgb(0, 0, 0, 0); SetConf.Buttonback != pixel;)
                        {
                            Thread.Sleep(200);
                            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                            {
                                using (var graphics = Graphics.FromImage(image))
                                {
                                    var hdcBitmap = graphics.GetHdc();
                                    PrintWindow(hwnd, hdcBitmap, 0);
                                    graphics.ReleaseHdc(hdcBitmap);
                                    pixel = image.GetPixel(959, 689);
                                }
                            }
                        }
                        Thread.Sleep(600);
                        MyMouseMove(rect.Left + 901, rect.Top + 709);
                        PlayerMove("lmb");
                        for (Color pixel = Color.FromArgb(0, 0, 0, 0); SetConf.Buttonback != pixel;)
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
                        for (Color pixel = Color.FromArgb(0, 0, 0, 0); SetConf.Fqualityapassive != pixel && SetConf.Fqualityaactive != pixel;)
                        {
                            Thread.Sleep(200);
                            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                            {
                                using (var graphics = Graphics.FromImage(image))
                                {
                                    var hdcBitmap = graphics.GetHdc();
                                    PrintWindow(hwnd, hdcBitmap, 0);
                                    graphics.ReleaseHdc(hdcBitmap);
                                    pixel = image.GetPixel(264, 120);
                                }
                            }
                        }
                        MyMouseMove(rect.Left + 222, rect.Top + 125);
                        PlayerMove("lmb");
                        using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                        {
                            Thread.Sleep(200);
                            using (var graphics = Graphics.FromImage(image))
                            {
                                var hdcBitmap = graphics.GetHdc();
                                PrintWindow(hwnd, hdcBitmap, 0);
                                graphics.ReleaseHdc(hdcBitmap);
                            }
                            image.Save(folder + @"\" + imagenum + @".png", ImageFormat.Png);
                            imagenum++;
                        }
                        PlayerMove("esc");
                        Thread.Sleep(50);
                        PlayerMove("esc");
                        //

                        //Скрин оружия
                        for (Color pixel = Color.FromArgb(0, 0, 0, 0); SetConf.Paimonico != pixel && white != pixel;)
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
                        for (Color pixel = Color.FromArgb(0, 0, 0, 0); SetConf.Bagweaponactive != pixel; MyMouseMove(rect.Left + 387, rect.Top + 60), PlayerMove("lmb"))
                        {
                            Thread.Sleep(200);
                            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                            {
                                using (var graphics = Graphics.FromImage(image))
                                {
                                    var hdcBitmap = graphics.GetHdc();
                                    PrintWindow(hwnd, hdcBitmap, 0);
                                    graphics.ReleaseHdc(hdcBitmap);
                                    pixel = image.GetPixel(393, 89);
                                    Color Outtimeditems = image.GetPixel(656, 518);
                                    if (Outtimeditems == Color.FromArgb(255, 236, 229, 216))
                                    {
                                        MyMouseMove(rect.Left + 656, rect.Top + 518);
                                        PlayerMove("lmb");
                                    }
                                }
                            }
                        }
                        for (Color pixel = Color.FromArgb(0, 0, 0, 0); SetConf.Buttonback != pixel;)
                        {
                            Thread.Sleep(200);
                            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                            {
                                using (var graphics = Graphics.FromImage(image))
                                {
                                    var hdcBitmap = graphics.GetHdc();
                                    PrintWindow(hwnd, hdcBitmap, 0);
                                    graphics.ReleaseHdc(hdcBitmap);
                                    pixel = image.GetPixel(1161, 697);
                                }
                            }
                        }
                        using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                        {
                            Thread.Sleep(200);
                            using (var graphics = Graphics.FromImage(image))
                            {
                                var hdcBitmap = graphics.GetHdc();
                                PrintWindow(hwnd, hdcBitmap, 0);
                                graphics.ReleaseHdc(hdcBitmap);
                            }
                            image.Save(folder + @"\" + imagenum + @".png", ImageFormat.Png);
                            imagenum++;
                        }
                        //

                        //Скрин артефактов
                        if (art == true)
                        {
                            MyMouseMove(rect.Left + 452, rect.Top + 60);
                            PlayerMove("lmb");
                            for (Color pixel = Color.FromArgb(0, 0, 0, 0); SetConf.Artloaded != pixel;)
                            {
                                Thread.Sleep(200);
                                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                                {
                                    using (var graphics = Graphics.FromImage(image))
                                    {
                                        var hdcBitmap = graphics.GetHdc();
                                        PrintWindow(hwnd, hdcBitmap, 0);
                                        graphics.ReleaseHdc(hdcBitmap);
                                        pixel = image.GetPixel(162, 648);
                                    }
                                    if (SetConf.Artloaded == pixel)
                                    {
                                        image.Save(folder + @"\" + imagenum + @".png", ImageFormat.Png);
                                        imagenum++;
                                    }
                                }
                            }
                            MyMouseMove(rect.Left + 863, rect.Top + 653);
                            for (int i = 0; i != 49; PlayerMove("wld"), i++);
                            for (Color pixel = Color.FromArgb(0, 0, 0, 0); SetConf.Scrollerbottom != pixel && white != pixel; imagenum++)
                            {
                                Thread.Sleep(200);
                                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                                {
                                    using (var graphics = Graphics.FromImage(image))
                                    {
                                        var hdcBitmap = graphics.GetHdc();
                                        PrintWindow(hwnd, hdcBitmap, 0);
                                        graphics.ReleaseHdc(hdcBitmap);
                                        pixel = image.GetPixel(862, 650);
                                    }
                                    image.Save(folder + @"\" + imagenum + @".png", ImageFormat.Png);

                                    for (int i = 0; i != 49; PlayerMove("wld"), i++) ;
                                }
                            }
                        }
                        //

                        //Скрин карт опыта
                        if (exp == true)
                        {
                            MyMouseMove(rect.Left + 518, rect.Top + 60);
                            PlayerMove("lmb");
                            for (Color pixel = Color.FromArgb(0, 0, 0, 0); SetConf.Primogem != pixel;)
                            {
                                Thread.Sleep(200);
                                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                                {
                                    using (var graphics = Graphics.FromImage(image))
                                    {
                                        var hdcBitmap = graphics.GetHdc();
                                        PrintWindow(hwnd, hdcBitmap, 0);
                                        graphics.ReleaseHdc(hdcBitmap);
                                        pixel = image.GetPixel(117, 710);
                                    }
                                }
                            }
                            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                            {
                                Thread.Sleep(400);
                                using (var graphics = Graphics.FromImage(image))
                                {
                                    var hdcBitmap = graphics.GetHdc();
                                    PrintWindow(hwnd, hdcBitmap, 0);
                                    graphics.ReleaseHdc(hdcBitmap);
                                }
                                image.Save(folder + @"\" + imagenum + @".png", ImageFormat.Png);
                                imagenum++;
                            }
                        }
                        //

                        //Скрин фей
                        if (fey == true)
                        {
                            MyMouseMove(rect.Left + 709, rect.Top + 60);
                            PlayerMove("lmb");
                            for (Color pixel = Color.FromArgb(0, 0, 0, 0); SetConf.Primogem != pixel;)
                            {
                                Thread.Sleep(200);
                                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                                {
                                    using (var graphics = Graphics.FromImage(image))
                                    {
                                        var hdcBitmap = graphics.GetHdc();
                                        PrintWindow(hwnd, hdcBitmap, 0);
                                        graphics.ReleaseHdc(hdcBitmap);
                                        pixel = image.GetPixel(117, 710);
                                    }
                                }
                            }
                            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                            {
                                Thread.Sleep(400);
                                using (var graphics = Graphics.FromImage(image))
                                {
                                    var hdcBitmap = graphics.GetHdc();
                                    PrintWindow(hwnd, hdcBitmap, 0);
                                    graphics.ReleaseHdc(hdcBitmap);
                                }
                                image.Save(folder + @"\" + imagenum + @".png", ImageFormat.Png);
                                imagenum++;
                            }
                        }
                        //

                        //Скрин смолы
                        if (resin == true)
                        {
                            MyMouseMove(rect.Left + 837, rect.Top + 60);
                            PlayerMove("lmb");
                            for (Color pixel = Color.FromArgb(0, 0, 0, 0); SetConf.Primogem != pixel;)
                            {
                                Thread.Sleep(200);
                                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                                {
                                    using (var graphics = Graphics.FromImage(image))
                                    {
                                        var hdcBitmap = graphics.GetHdc();
                                        PrintWindow(hwnd, hdcBitmap, 0);
                                        graphics.ReleaseHdc(hdcBitmap);
                                        pixel = image.GetPixel(117, 710);
                                    }
                                }
                            }
                            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                            {
                                Thread.Sleep(400);
                                using (var graphics = Graphics.FromImage(image))
                                {
                                    var hdcBitmap = graphics.GetHdc();
                                    PrintWindow(hwnd, hdcBitmap, 0);
                                    graphics.ReleaseHdc(hdcBitmap);
                                }
                                image.Save(folder + @"\" + imagenum + @".png", ImageFormat.Png);
                                imagenum++;
                            }
                        }
                        PlayerMove("esc");
                        //




                        //Скрин баннера
                        if (banner == true)
                        {
                            for (Color pixel = Color.FromArgb(0, 0, 0, 0); SetConf.Paimonico != pixel && white != pixel;)
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
                            Thread.Sleep(200);
                            for (Color pixel = Color.FromArgb(0, 0, 0, 0); SetConf.Historybutton != pixel;)
                            {
                                Thread.Sleep(200);
                                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                                {
                                    using (var graphics = Graphics.FromImage(image))
                                    {
                                        var hdcBitmap = graphics.GetHdc();
                                        PrintWindow(hwnd, hdcBitmap, 0);
                                        graphics.ReleaseHdc(hdcBitmap);
                                        pixel = image.GetPixel(337, 706);
                                    }
                                }
                            }
                            MyMouseMove(rect.Left + 360, rect.Top + 705);
                            PlayerMove("lmb");
                            for (Color pixel = Color.FromArgb(0, 0, 0, 0); SetConf.Wishhistoryback != pixel;)
                            {
                                Thread.Sleep(200);
                                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                                {
                                    using (var graphics = Graphics.FromImage(image))
                                    {
                                        var hdcBitmap = graphics.GetHdc();
                                        PrintWindow(hwnd, hdcBitmap, 0);
                                        graphics.ReleaseHdc(hdcBitmap);
                                        pixel = image.GetPixel(620, 180);
                                    }
                                }
                            }
                            MyMouseMove(rect.Left + 1010, rect.Top + 550);
                            for (Color pixel = Color.FromArgb(0, 0, 0, 0); SetConf.Wishhistorytableloaded != pixel;)
                            {
                                Thread.Sleep(200);
                                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                                {
                                    using (var graphics = Graphics.FromImage(image))
                                    {
                                        var hdcBitmap = graphics.GetHdc();
                                        PrintWindow(hwnd, hdcBitmap, 0);
                                        graphics.ReleaseHdc(hdcBitmap);
                                        pixel = image.GetPixel(567, 547);
                                    }
                                }
                            }
                            for (int i = 0; i != 20; PlayerMove("wld"), i++) ;
                            Color pixell = Color.FromArgb(0, 0, 0, 0);
                            int width = 499;
                            int height = 314;
                            Bitmap screen = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top);
                            for (int i = 0; i != 19; i++)
                            {
                                for (var frame = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top); frame == screen;)
                                {
                                    SetTimer();
                                    using (screen = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                                    {
                                        using (var graphics = Graphics.FromImage(screen))
                                        {
                                            var hdcBitmap = graphics.GetHdc();
                                            PrintWindow(hwnd, hdcBitmap, 0);
                                            graphics.ReleaseHdc(hdcBitmap);
                                        }
                                    }
                                    if (Timerended == 1)
                                    {
                                        break;
                                    }
                                }
                                if (Timerended == 1)
                                {
                                    break;
                                }
                                Thread.Sleep(50);
                                for (; height != 574; height += 52)
                                {
                                    for (; width != 554; width += 5)
                                    {
                                        using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                                        {
                                            using (var graphics = Graphics.FromImage(image))
                                            {
                                                var hdcBitmap = graphics.GetHdc();
                                                PrintWindow(hwnd, hdcBitmap, 0);
                                                graphics.ReleaseHdc(hdcBitmap);
                                                SetConf.Testpixel = image.GetPixel(width, height);
                                            }
                                            if (SetConf.Legendarychar != SetConf.Testpixel && SetConf.Legendarychar != black)
                                            {
                                                SetConf.Testpixel = image.GetPixel(width - 26, height + 9);
                                            }
                                        }

                                        if (SetConf.Legendarychar == SetConf.Testpixel)
                                        {
                                            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                                            {
                                                using (var graphics = Graphics.FromImage(image))
                                                {
                                                    var hdcBitmap = graphics.GetHdc();
                                                    PrintWindow(hwnd, hdcBitmap, 0);
                                                    graphics.ReleaseHdc(hdcBitmap);
                                                }
                                            }
                                            break;
                                        }
                                    }
                                    if (SetConf.Legendarychar == SetConf.Testpixel)
                                    {
                                        break;
                                    }
                                    width = 499;
                                }
                                if (SetConf.Legendarychar == SetConf.Testpixel)
                                {
                                    break;
                                }
                                height = 314;
                                MyMouseMove(rect.Left + 698, rect.Top + 579);
                                PlayerMove("lmb");
                            }
                            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                            {
                                using (var graphics = Graphics.FromImage(image))
                                {
                                    var hdcBitmap = graphics.GetHdc();
                                    PrintWindow(hwnd, hdcBitmap, 0);
                                    graphics.ReleaseHdc(hdcBitmap);
                                }
                                image.Save(folder + @"\" + imagenum + @".png", ImageFormat.Png);
                                imagenum++;
                            }

                            PlayerMove("esc");
                            Thread.Sleep(200);
                            PlayerMove("esc");
                        }
                        //

                        //Скрин менюшки 
                        for (Color pixel = Color.FromArgb(0, 0, 0, 0); SetConf.Paimonico != pixel && white != pixel;)
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
                        for (Color pixel = Color.FromArgb(0, 0, 0, 0); SetConf.Menumarketplateloaded != pixel;)
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
                                if (SetConf.Menumarketplateloaded == pixel)
                                {
                                    image.Save(folder + @"\" + imagenum + @".png", ImageFormat.Png);
                                    imagenum++;
                                }
                            }
                        }
                        //

                        //Скрин магазина кристаллов
                        MyMouseMove(rect.Left + 135, rect.Top + 303);
                        PlayerMove("lmb");
                        for (Color pixel = Color.FromArgb(0, 0, 0, 0); SetConf.Paimonfirstmarketloaded != pixel;)
                        {
                            Thread.Sleep(200);
                            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                            {
                                using (var graphics = Graphics.FromImage(image))
                                {
                                    var hdcBitmap = graphics.GetHdc();
                                    PrintWindow(hwnd, hdcBitmap, 0);
                                    graphics.ReleaseHdc(hdcBitmap);
                                    pixel = image.GetPixel(302, 120);
                                }
                            }
                        }
                        MyMouseMove(rect.Left + 110, rect.Top + 376);
                        PlayerMove("lmb");
                        for (Color pixel = Color.FromArgb(0, 0, 0, 0); SetConf.Paimonmarketloaded != pixel;)
                        {
                            Thread.Sleep(200);
                            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                            {
                                using (var graphics = Graphics.FromImage(image))
                                {
                                    var hdcBitmap = graphics.GetHdc();
                                    PrintWindow(hwnd, hdcBitmap, 0);
                                    graphics.ReleaseHdc(hdcBitmap);
                                    pixel = image.GetPixel(696, 500);
                                }
                            }
                        }
                        using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                        {
                            using (var graphics = Graphics.FromImage(image))
                            {
                                var hdcBitmap = graphics.GetHdc();
                                PrintWindow(hwnd, hdcBitmap, 0);
                                graphics.ReleaseHdc(hdcBitmap);

                                Color cristal60 = image.GetPixel(335, 147);
                                Color cristal300 = image.GetPixel(617, 110);
                                Color cristal980 = image.GetPixel(845, 110);
                                Color cristal1980 = image.GetPixel(1073, 110);
                                Color cristal3280 = image.GetPixel(390, 328);
                                Color cristal6480 = image.GetPixel(617, 328);

                                Color Checkdon = Color.FromArgb(255, 255, 255, 255);

                                if (cristal60 != Checkdon) { result = result + "Куплен пак 60 кристаллов" + "\n"; }
                                if (cristal300 != Checkdon) { result = result + "Куплен пак 300 кристаллов" + "\n"; }
                                if (cristal980 != Checkdon) { result = result + "Куплен пак 980 кристаллов" + "\n"; }
                                if (cristal1980 != Checkdon) { result = result + "Куплен пак 1980 кристаллов" + "\n"; }
                                if (cristal3280 != Checkdon) { result = result + "Куплен пак 3280 кристаллов" + "\n"; }
                                if (cristal6480 != Checkdon) { result = result + "Куплен пак 6480 кристаллов" + "\n"; }
                            }
                            image.Save(folder + @"\" + imagenum + @".png", ImageFormat.Png);
                            imagenum++;
                        }
                        PlayerMove("esc");
                        //

                        //Проверка архива
                        if (arch == true)
                        {
                            for (Color pixel = Color.FromArgb(0, 0, 0, 0); SetConf.Menumarketplateloaded != pixel;)
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
                            for (Color pixel = Color.FromArgb(0, 0, 0, 0); SetConf.Archiveloaded != pixel;)
                            {
                                Thread.Sleep(200);
                                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                                {
                                    using (var graphics = Graphics.FromImage(image))
                                    {
                                        var hdcBitmap = graphics.GetHdc();
                                        PrintWindow(hwnd, hdcBitmap, 0);
                                        graphics.ReleaseHdc(hdcBitmap);
                                        pixel = image.GetPixel(53, 55);
                                    }
                                }
                            }
                            MyMouseMove(rect.Left + 642, rect.Top + 369);
                            PlayerMove("lmb");
                            for (Color pixel = Color.FromArgb(0, 0, 0, 0); SetConf.Buttonback != pixel;)
                            {
                                Thread.Sleep(200);
                                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                                {
                                    using (var graphics = Graphics.FromImage(image))
                                    {
                                        var hdcBitmap = graphics.GetHdc();
                                        PrintWindow(hwnd, hdcBitmap, 0);
                                        graphics.ReleaseHdc(hdcBitmap);
                                        pixel = image.GetPixel(460, 698);
                                    }
                                }
                            }
                            Thread.Sleep(200);
                            MyMouseMove(rect.Left + 527, rect.Top + 609);
                            int i = 0;
                            for (; i != 73; PlayerMove("wld"), i++)
                            {
                            }
                            i = 0;
                            Thread.Sleep(300);
                            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                            {
                                using (var graphics = Graphics.FromImage(image))
                                {
                                    var hdcBitmap = graphics.GetHdc();
                                    PrintWindow(hwnd, hdcBitmap, 0);
                                    graphics.ReleaseHdc(hdcBitmap);
                                }
                                image.Save(folder + @"\" + imagenum + @".png", ImageFormat.Png);
                                imagenum++;
                            }
                            for (; i != 45; PlayerMove("wld"), i++)
                            {
                            }
                            i = 0;
                            Thread.Sleep(300);
                            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                            {
                                using (var graphics = Graphics.FromImage(image))
                                {
                                    var hdcBitmap = graphics.GetHdc();
                                    PrintWindow(hwnd, hdcBitmap, 0);
                                    graphics.ReleaseHdc(hdcBitmap);
                                }
                                image.Save(folder + @"\" + imagenum + @".png", ImageFormat.Png);
                                imagenum++;
                            }
                            for (; i != 45; PlayerMove("wld"), i++)
                            {
                            }
                            i = 0;
                            Thread.Sleep(300);
                            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                            {
                                using (var graphics = Graphics.FromImage(image))
                                {
                                    var hdcBitmap = graphics.GetHdc();
                                    PrintWindow(hwnd, hdcBitmap, 0);
                                    graphics.ReleaseHdc(hdcBitmap);
                                }
                                image.Save(folder + @"\" + imagenum + @".png", ImageFormat.Png);
                                imagenum++;
                            }
                            PlayerMove("esc");
                            for (Color pixel = Color.FromArgb(0, 0, 0, 0); SetConf.Archiveloaded != pixel;)
                            {
                                Thread.Sleep(200);
                                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                                {
                                    using (var graphics = Graphics.FromImage(image))
                                    {
                                        var hdcBitmap = graphics.GetHdc();
                                        PrintWindow(hwnd, hdcBitmap, 0);
                                        graphics.ReleaseHdc(hdcBitmap);
                                        pixel = image.GetPixel(53, 55);
                                    }
                                }
                            }
                            PlayerMove("esc");
                        }
                        //

                        //Скрин Привязок
                        for (Color pixel = Color.FromArgb(0, 0, 0, 0); SetConf.Menumarketplateloaded != pixel;)
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
                        for (Color pixel = Color.FromArgb(0, 0, 0, 0); SetConf.Settingscontrolloaded != pixel;)
                        {
                            Thread.Sleep(200);
                            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                            {
                                using (var graphics = Graphics.FromImage(image))
                                {
                                    var hdcBitmap = graphics.GetHdc();
                                    PrintWindow(hwnd, hdcBitmap, 0);
                                    graphics.ReleaseHdc(hdcBitmap);
                                    pixel = image.GetPixel(51, 59);
                                }
                            }
                        }
                        MyMouseMove(rect.Left + 174, rect.Top + 411);
                        Thread.Sleep(50);
                        PlayerMove("lmb");
                        for (Color pixel = Color.FromArgb(0, 0, 0, 0); SetConf.Settingsaccountloaded != pixel && white != pixel;)
                        {
                            Thread.Sleep(200);
                            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                            {
                                using (var graphics = Graphics.FromImage(image))
                                {
                                    var hdcBitmap = graphics.GetHdc();
                                    PrintWindow(hwnd, hdcBitmap, 0);
                                    graphics.ReleaseHdc(hdcBitmap);
                                    pixel = image.GetPixel(364, 128);
                                }
                            }
                        }
                        MyMouseMove(rect.Left + 1094, rect.Top + 166);
                        Thread.Sleep(50);
                        PlayerMove("lmb");
                        for (Color pixel = Color.FromArgb(0, 0, 0, 0); SetConf.Accountloaded != pixel && white != pixel;)
                        {
                            Thread.Sleep(200);
                            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                            {
                                using (var graphics = Graphics.FromImage(image))
                                {
                                    var hdcBitmap = graphics.GetHdc();
                                    PrintWindow(hwnd, hdcBitmap, 0);
                                    graphics.ReleaseHdc(hdcBitmap);
                                    pixel = image.GetPixel(550, 442);
                                }
                            }
                        }
                        using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                        {
                            using (var graphics = Graphics.FromImage(image))
                            {
                                var hdcBitmap = graphics.GetHdc();
                                PrintWindow(hwnd, hdcBitmap, 0);
                                graphics.ReleaseHdc(hdcBitmap);
                            }
                            image.Save(folder + @"\" + imagenum + @".png", ImageFormat.Png);
                            imagenum++;
                        }
                        PlayerMove("esc");
                        Thread.Sleep(50);
                        PlayerMove("esc");
                        //

                        //Скрин доната
                        for (Color pixel = Color.FromArgb(0, 0, 0, 0); SetConf.Menumarketplateloaded != pixel;)
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
                            int width = 464;
                            using (var graphics = Graphics.FromImage(image))
                            {

                                var hdcBitmap = graphics.GetHdc();
                                PrintWindow(hwnd, hdcBitmap, 0);
                                graphics.ReleaseHdc(hdcBitmap);
                                for (Color pixel = image.GetPixel(width, 684); pixel != SetConf.SupportButton; pixel = image.GetPixel(width, 684))
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
                        for (Color image = Color.FromArgb(0, 0, 0, 0); SetConf.Gemloaded != image;)
                        {
                            Thread.Sleep(200);
                            Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                            Graphics graphics = Graphics.FromImage(printscreen);
                            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
                            image = printscreen.GetPixel(1145, 408);
                            if (SetConf.Gemloaded != image)
                            {
                                image = printscreen.GetPixel(1145, 368);
                            }
                        }
                        MyMouseMove(1145, 408);
                        Thread.Sleep(100);
                        PlayerMove("lmb");
                        Thread.Sleep(100);
                        PlayerMove("lmb");
                        Thread.Sleep(3000);
                        Bitmap print = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                        Graphics graph = Graphics.FromImage(print);
                        graph.CopyFromScreen(0, 0, 0, 0, print.Size);
                        print.Save(folder + @"\" + imagenum + @".png", ImageFormat.Png);
                        //

                        MessageBox.Show(
                        result,
                        "AccCheck",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
                    }
                }
            }
            MousePressed = false;
            return;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Создателем программы является @Sansenskiy",
                "",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            
        }

        private void switchPanel1_Click(object sender, EventArgs e)
        {
            if (TwoMenuActive == true)
            {
                button1.Enabled = true;
                button1.Visible = true;
                button2.Enabled = true;
                button2.Visible = true;
                button3.Enabled = true;
                button3.Visible = true;
                button4.Enabled = true;
                button4.Visible = true;
                textBox1.Enabled = true;
                textBox1.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                pictureBox3.Visible = true;

            }
            if (TwoMenuActive == false)
            {
                button1.Enabled = false;
                button1.Visible = false;
                button2.Enabled = false;
                button2.Visible = false;
                button3.Enabled = false;
                button3.Visible = false;
                button4.Enabled = false;
                button4.Visible = false;
                textBox1.Enabled = false;
                textBox1.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                pictureBox3.Visible = false;

            }
            Invalidate();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                Log = textBox1.Text;
                button2.Text = Log;
            }
            GeneratePass();
            Invalidate();
            Settings.Default["Buttonlog"] = button2.Text;
            Settings.Default["Buttonpass"] = button3.Text;
            Settings.Default["Textboxlog"] = textBox1.Text;
            Settings.Default.Save();
        }
        private void GeneratePass()
        {
            string iPass = "";
            string[] arr = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "B", "C", "D", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "V", "W", "X", "Z", "b", "c", "d", "f", "g", "h", "j", "k", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "z", "A", "E", "U", "Y", "a", "e", "i", "o", "u", "y" };
            Random rnd = new Random();
            for (int i = 0; i < 8; i = i + 1)
            {
                iPass = iPass + arr[rnd.Next(0, 57)];
            }
            Pass = iPass;
            button3.Text = Pass;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text != null)
            {

                Clipboard.SetText(button2.Text);
            }
            else
            {
                Clipboard.Clear();
            }
            Invalidate();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text != null)
            {
                Clipboard.SetText(button3.Text);
            }
            else
            {
                Clipboard.Clear();
            }
            Invalidate();
        }

        private static void SetTimer()
        {
            if (Timerended == 0)
            {
                // Create a timer with a two second interval.
                aTimer = new System.Timers.Timer(1000);
                // Hook up the Elapsed event for the timer. 
                aTimer.Elapsed += OnTimedEvent;
                aTimer.AutoReset = false;
                aTimer.Enabled = true;
            }
        }

        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            Timerended = 1;

        }

        void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.End)
            {
                MessageBox.Show(
                "Программа принудительно остановлена!",
                "Нажата клавиша END",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                Application.Exit();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "Убедитесь, что все дополнительные проверки включены! В противном случае калибровка будет проведена некорректно",
            "Внимание",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
            SetConf.PixValue();
        }
    }
}
