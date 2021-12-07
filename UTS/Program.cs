using System;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;

namespace UTS
{
    class Program
    {
        static void Main(string[] args)
        {
            var ourWindow = new NativeWindowSettings()
            {
                Size = new Vector2i(2000, 1000),
                Title = "Proyek UTS"
            };

            using (var win = new Window(GameWindowSettings.Default, ourWindow))
            {
                win.Run();
            };
        }
    }
}
