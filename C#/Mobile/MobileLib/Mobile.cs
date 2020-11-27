using System;

namespace TekTutor
{
    public class Mobile
    {
        private ICamera camera;

        public Mobile(ICamera camera) //Constructor Dependency Injection
        {
            this.camera = camera;  //Aggregation - Shared ownership
        }

        public bool powerOn()
        {
            if ( camera.on() ) //dependency
            {
                //camera.on();
                Console.WriteLine("Mobile - powerOn Positive code path ...");
                return true;
            }


            Console.WriteLine("Mobile - powerOn Negative code path ...");
            return false;
        }
    }
}
