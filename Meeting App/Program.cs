using System;
using System.Collections.Generic;
using System.Linq;

namespace Meeting_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Connect con = new Connect(); 
            Console.WriteLine("Hello World!");
            Console.WriteLine("meny");
            Console.WriteLine("(C)reate");
            Console.WriteLine("(R)ead");
            Console.WriteLine("(U)pdate");
            Console.WriteLine("(D)elete");
            Console.WriteLine("(L)ist");
            Console.WriteLine("(Q)uit");

            String input = "";
            while(input != "q")
            {
                switch (input)
                {
                    case "c":
                        Create(con.GetList(), con);
                        break;
                    case "r":
                        Read(con.GetList());
                        break;
                    case "u":
                        Update(con.GetList(), con);
                        break;
                    case "d":
                        Delete(con.GetList(), con);
                        break;
                    case "l":
                        Console.WriteLine("list");
                        List(con.GetList());

                        break;
                    default:
                        break;
                }
                input = Console.ReadLine();
            }
            
        }
        static void Create(List<modelokaler> modelokalers, Connect con)
        {
            Console.WriteLine("opret mødelokale");
            Console.WriteLine("Indtast id(int):");//dette kan gøres automatisk
            String input = Console.ReadLine();

            int i = Convert.ToInt32(input);
            if(modelokalers.Where(g => g.Id == i).Any() )
            {
                Console.WriteLine("id er i brug");
                return;
            }

            Console.WriteLine("Indtast navn(string):");
            String n = Console.ReadLine();

            Console.WriteLine("Indtast lokation(string):");
            String l = Console.ReadLine();

            Console.WriteLine("Indtast antal pladser(int):");
            String p = Console.ReadLine();

            con.AddToServer(new modelokaler(i,n,l,Convert.ToInt32(p)));
            
        }
        static void List(List<modelokaler> modelokalers)
        {
            Console.WriteLine("antal mødelokaler:" + modelokalers.Count);
            foreach (modelokaler item in modelokalers)
            {
                Console.WriteLine("id:" + item.Id + " navn:" + item.Navn + " lokation:" + item.Lokation + " plads antal:" + item.Pladsantal);
            }
        }
        static void Read(List<modelokaler> modelokalers)
        {
            Console.WriteLine("angiv id for den onskede lokale(int):");
            String input = Console.ReadLine();
            int i = Convert.ToInt32(input);

            modelokaler reading = modelokalers.Where(g => g.Id == i).First();
            Console.WriteLine("id:" + reading.Id + " navn:" + reading.Navn + " lokation:" + reading.Lokation + " plads antal:" + reading.Pladsantal);

        }
        static void Update(List<modelokaler> modelokalers, Connect con)
        {
            Console.WriteLine("angiv id for den onskede lokale(int):");
            String input = Console.ReadLine();
            int i = Convert.ToInt32(input);

            modelokaler reading = modelokalers.Where(g => g.Id == i).First();
            Console.WriteLine("id:" + reading.Id + " navn:" + reading.Navn + " lokation:" + reading.Lokation + " plads antal:" + reading.Pladsantal);

            Console.WriteLine("Indtast nyt navn(string):");
            String n = Console.ReadLine();

            Console.WriteLine("Indtast nyt lokation(string):");
            String l = Console.ReadLine();

            Console.WriteLine("Indtast nye antal pladser(int):");
            String p = Console.ReadLine();

            con.UpdateServer(new modelokaler(i, n, l, Convert.ToInt32(p)));
        }

        static void Delete(List<modelokaler> modelokalers, Connect con)
        {
            Console.WriteLine("angiv id for den der skal slettes(int):");
            String input = Console.ReadLine();
            int i = Convert.ToInt32(input);

            modelokaler reading = modelokalers.Where(g => g.Id == i).First();
            Console.WriteLine("id:" + reading.Id + " navn:" + reading.Navn + " lokation:" + reading.Lokation + " plads antal:" + reading.Pladsantal);

            Console.WriteLine("sikker y/n");
            if(Console.ReadLine() == "y")
            {
                con.DeleteServer(i);
            }
            
        }

    }
}
