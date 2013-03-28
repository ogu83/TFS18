using System;

namespace BounceBall_PC
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (BounceBallGame game = new BounceBallGame())
            {
                game.Run();
            }
        }
    }
#endif
}

