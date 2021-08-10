using System;
using System.Collections.Generic;

namespace Multiton
{
    class Program
    {
        static void Main(string[] args)
        {
            Camera camera = Camera.GetCamera("NIKON");
            Camera camera1 = Camera.GetCamera("CANON");
            Camera camera2 = Camera.GetCamera("CANON");
            Console.WriteLine(camera1.Id);
            Console.WriteLine(camera.Id);
            Console.WriteLine(camera2.Id);
            Console.ReadLine();
        }
    }

    class Camera
    {
        private static Dictionary<string, Camera> _cameras = new Dictionary<string, Camera>();
        private static object _lock = new object();

        public Guid Id { get; set; }

        private string brand;
        private Camera()
        {
            Id = Guid.NewGuid();
        }

        public static Camera GetCamera(string brand)
        {
            lock (_lock)
            {
                if (!_cameras.ContainsKey(brand))
                {
                    _cameras.Add(brand,new Camera());
                }
            }

            return _cameras[brand];
        }
    }
}