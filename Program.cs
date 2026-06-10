using SubiectLicenta1;

Time t1 = new Time();
Time t2 = new Time(1, 20, 30);
Console.WriteLine("Hello World!");
try
{
    Time t3 = new Time(-1, 20, 30);
} catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
Console.WriteLine(t1.ToString());
Console.WriteLine(t2.ToString());
Time t4 = new Time(1, 59, 59) + new Time(0, 0, 1);
Console.WriteLine(t4.ToString());