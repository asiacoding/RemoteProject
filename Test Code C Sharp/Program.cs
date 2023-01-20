using System;

namespace Test_Code_C_Sharp
{
    class Program
    {

        class MyClassObject
        {
            public string Prope1 { set; get; }
            public string Prope2 { set; get; }
            public string Prope3 { set; get; }
        }

        static void Main(string[] args)
        {
            //Print
            //Type CheckType = typeof(MyClassObject);
            //
            //Print(string.Format("Name :{0}", CheckType.Name));
            //Print(string.Format("FullName :{0}", CheckType.FullName));
            //Print(string.Format("ScopeName :{0}", CheckType.Module.ScopeName));
            //
            //Print(string.Format(" :{0}", CheckType));



            Print("Press any key to stop");
            do
            {

                ConsoleKeyInfo cki;
                while (!Console.KeyAvailable)
                {
       
                    Print("Press any key to stop");
                    // Do something
                    cki = Console.ReadKey();

                    if(cki.Key == ConsoleKey.LeftArrow)
                    {
                        //Do Endter Left
                        Console.Write("Are tap :");
                        Print(">");
                    }

                    if (cki.Key == ConsoleKey.Escape)
                        break;

                 
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }







        static void Print(string Text)
        {
            Console.WriteLine(Text);
        }
    }
}
