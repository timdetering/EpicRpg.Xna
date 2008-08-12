using System;

namespace EpicRPG
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (EpicRPG game = new EpicRPG())
            {
                game.Run();
            }
        }
    }
}

