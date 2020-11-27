using System;
using System.Collections.Generic;
using System.Text;

namespace TekTutor
{
    public class Camera : ICamera
    {
        virtual public bool on()
        {
            Console.WriteLine("Camera - on method interacts with camera hardware");
            return true;
        }
    }
}
