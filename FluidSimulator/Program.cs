namespace FluidSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                "  ______ _       _     _  _____ _                 _       _             \r\n" +
                " |  ____| |     (_)   | |/ ____(_)               | |     | |            \r\n" +
                " | |__  | |_   _ _  __| | (___  _ _ __ ___  _   _| | __ _| |_ ___  _ __ \r\n" +
                " |  __| | | | | | |/ _` |\\___ \\| | '_ ` _ \\| | | | |/ _` | __/ _ \\| '__|\r\n" +
                " | |    | | |_| | | (_| |____) | | | | | | | |_| | | (_| | || (_) | |   \r\n" +
                " |_|    |_|\\__,_|_|\\__,_|_____/|_|_| |_| |_|\\__,_|_|\\__,_|\\__\\___/|_|   "
                );

            FluidSimulator fluidSimulator = new FluidSimulator();

            fluidSimulator.Run();
        }
    }
}
