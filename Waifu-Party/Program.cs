using System;

namespace Waifu_Party
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {

        private static WaifuParty waifuParty;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            waifuParty = new WaifuParty();
            waifuParty.Run();
            waifuParty.Dispose();
        }

        public static WaifuParty GetWaifuParty()
        {
            return waifuParty;
        }
    }
}
