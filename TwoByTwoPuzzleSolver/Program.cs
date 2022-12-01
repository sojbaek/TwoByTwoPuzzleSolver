using System;
using System.Collections.Generic;
namespace TwoByTwoPuzzleSolver
{


    class Program
    {

        

        static void Main(string[] args)
        {
            FaceCube cube = new FaceCube("UUUURRRRFFFFDDDDLLLLBBBB");

            FaceCube testcube = new FaceCube("UFBULRRRRBFFDDDDFULLULBB");

            FaceCube shuffled = cube;
            Random r = new Random();
            for (int ii = 0; ii < 10; ii++)
            {
                int rot = r.Next(0, 18);
                shuffled = Search.RotateCube(shuffled, (TwoByTwoPuzzleSolver.Rotate)rot);
            }
            
            Console.WriteLine(value: "shuffled cube=" + shuffled.to_fc_String());

            string info;
            List<Rotate> sol = Search.solution(shuffled.to_fc_String(), out info);
            FaceCube scube = Search.MultiRotCube(shuffled, sol);
            Console.WriteLine(value: "solved cube=" + scube.to_fc_String());
            Console.WriteLine("Solution=" + info);
            Console.WriteLine("Solution=" + Search.SolutionToString(sol));
            Console.ReadKey();

        }
    }
}


