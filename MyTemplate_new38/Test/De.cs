using System.IO;

class De
{
    static StreamWriter sw;

    static De()
    {
        sw = new StreamWriter("output.txt");
    }

    public static void WriteLine()
    {
        sw.WriteLine();
        sw.Flush();
    }

    public static void WriteLine(object o)
    {
        sw.WriteLine(o);
        sw.Flush();
    }
}