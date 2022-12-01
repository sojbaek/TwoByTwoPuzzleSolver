using System;
using System.Collections.Generic;

namespace TwoByTwoPuzzleSolver
{
    public class Search
    {
        public static readonly int[][] ctransform = new int[][]{
             new int[]  {2,0,3,1,4,5,6,7} //U
            , new int[]  {1,3,0,2,4,5,6,7} //U'
            , new int[]  {3,2,1,0,4,5,6,7} //U2
            , new int[]  {4,1,0,3,6,5,2,7} //R
            , new int[]  {2,1,6,3,0,5,4,7} //R'
            , new int[]  {6,1,4,3,2,5,0,7} //R2
            , new int[]  {1,5,2,3,0,4,6,7} //F
            , new int[]  {4,0,2,3,5,1,6,7} //F'
            , new int[]  {5,4,2,3,1,0,6,7} //F2
            , new int[]  {0,1,2,3,5,7,4,6} //D
            , new int[]  {0,1,2,3,6,4,7,5} //D'
            , new int[]  {0,1,2,3,7,6,5,4} //D2
            , new int[]  {0,3,2,7,4,1,6,5} //L
            , new int[]  {0,5,2,1,4,7,6,3} //L'
            , new int[]  {0,7,2,5,4,3,6,1} //L2,
            , new int[]  {0,1,6,2,4,5,7,3} //B
            , new int[]  {0,1,3,7,4,5,2,6} //B'
            , new int[]  {0,1,7,6,4,5,3,2} //B2
            };

        public static readonly int[][] transform =
            new int[][]{ new int[]  {2,0,3,1,20,21,6,7,4,5,10,11,12,13,14,15,8,9,18,19,16,17,22,23} //U
                , new int[]  {1,3,0,2,8,9,6,7,16,17,10,11,12,13,14,15,20,21,18,19,4,5,22,23} //U'
                , new int[]  {3,2,1,0,16,17,6,7,20,21,10,11,12,13,14,15,4,5,18,19,8,9,22,23} //U2
                , new int[]  {0,9,2,11,6,4,7,5,8,13,10,15,12,22,14,20,16,17,18,19,3,21,1,23} //R
                , new int[]  {0,22,2,20,5,7,4,6,8,1,10,3,12,9,14,11,16,17,18,19,15,21,13,23} //R'
                , new int[]  {0,13,2,15,7,6,5,4,8,22,10,20,12,1,14,3,16,17,18,19,11,21,9,23} //R2
                , new int[]  {0,1,19,17,2,5,3,7,10,8,11,9,6,4,14,15,16,12,18,13,20,21,22,23} //F
                , new int[]  {0,1,4,6,13,5,12,7,9,11,8,10,17,19,14,15,16,3,18,2,20,21,22,23} //F'
                , new int[]  {0,1,13,12,19,5,17,7,11,10,9,8,3,2,14,15,16,6,18,4,20,21,22,23} //F2
                , new int[]  {0,1,2,3,4,5,10,11,8,9,18,19,14,12,15,13,16,17,22,23,20,21,6,7} //D
                , new int[]  {0,1,2,3,4,5,22,23,8,9,6,7,13,15,12,14,16,17,10,11,20,21,18,19} //D'
                , new int[]  {0,1,2,3,4,5,18,19,8,9,22,23,15,14,13,12,16,17,6,7,20,21,10,11} //D2
                , new int[]  {23,1,21,3,4,5,6,7,0,9,2,11,8,13,10,15,18,16,19,17,20,14,22,12} //L
                , new int[]  {8,1,10,3,4,5,6,7,12,9,14,11,23,13,21,15,17,19,16,18,20,2,22,0} //L'
                , new int[]  {12,1,14,3,4,5,6,7,23,9,21,11,0,13,2,15,19,18,17,16,20,10,22,8} //L2
                , new int[]  {5,7,2,3,4,15,6,14,8,9,10,11,12,13,16,18,1,17,0,19,22,20,23,21} //B
                , new int[]  {18,16,2,3,4,0,6,1,8,9,10,11,12,13,7,5,14,17,15,19,21,23,20,22} //B'
                , new int[]  {15,14,2,3,4,18,6,16,8,9,10,11,12,13,1,0,7,17,5,19,23,22,21,20} //B2
                };


        static int[][] case1 = new int[][] { new int[] { 21, 2, 9, 5 }, new int[] { 17, 3, 5, 21 }, new int[] { 9, 1, 21, 17 }, new int[] { 5, 0, 17, 9 } };
        static int[][] case2 = new int[][] { new int[] { 1, 16, 8, 4 }, new int[] { 0, 8, 4, 20 }, new int[] { 2, 4, 20, 16 }, new int[] { 3, 20, 16, 8 } };
        static int[][] case3 = new int[][] { new int[] { 8, 9, 20, 21 }, new int[] { 5, 4, 16, 17 } };
        static int[][] case4 = new int[][] { new int[] { 1, 3, 16, 17 }, new int[] { 0, 2, 5, 4 }, new int[] { 0, 1, 8, 9 }, new int[] { 2, 3, 20, 21 } };
        static int[][] case5 = new int[][] { new int[] { 16, 17, 20, 9 }, new int[] { 5, 4, 21, 8 }, new int[] { 8, 9, 16, 5 }, new int[] { 21, 20, 17, 4 } };
        static int[][] case6 = new int[][] { new int[] { 0, 2, 20, 9 }, new int[] { 0, 1, 17, 4 }, new int[] { 1, 3, 21, 8 }, new int[] { 3, 2, 5, 16 } };
        static int[][] case7 = new int[][] { new int[] { 0, 3, 17 }, new int[] { 1, 2, 21 }, new int[] { 0, 3, 5 }, new int[] { 1, 2, 9 } };

        static int[][][] Step2Cases = new int[][][] { case1, case2, case3, case4, case5, case6, case7 };

        static List<Rotate> command1 = new List<Rotate>() { Rotate.R, Rotate.U, Rotate.Rprime, Rotate.U, Rotate.R, Rotate.U2, Rotate.Rprime }; // "R U R' U R U2 R'";
        static List<Rotate> command2 = new List<Rotate>() { Rotate.R, Rotate.U2, Rotate.Rprime, Rotate.Uprime, Rotate.R, Rotate.Uprime, Rotate.Rprime }; // "R U2 R' U' R U' R'";
        static List<Rotate> command3 = new List<Rotate>() { Rotate.R, Rotate.U, Rotate.Rprime, Rotate.U, Rotate.R,
                                                            Rotate.Uprime, Rotate.Rprime, Rotate.U, Rotate.R, Rotate.U2, Rotate.Rprime };
        //"R U R' U R    U' R' U R U2 R'";
        static List<Rotate> command4 = new List<Rotate>() { Rotate.F, Rotate.R, Rotate.U, Rotate.Rprime, Rotate.Uprime, Rotate.Fprime }; // "F R U R' U' F'";
        static List<Rotate> command5 = new List<Rotate>() { Rotate.R, Rotate.U2, Rotate.R2, Rotate.Uprime, Rotate.R2, Rotate.Uprime, Rotate.R2, Rotate.U2, Rotate.R };
        //"R U2 R2 U' R2 U' R2 U2 R";
        static List<Rotate> command6 = new List<Rotate>() { Rotate.Lprime, Rotate.Uprime, Rotate.L, Rotate.U, Rotate.R, Rotate.Uprime, Rotate.Rprime, Rotate.F };
        //"L' U' L U R U' R' F";
        static List<Rotate> command7 = new List<Rotate>() { Rotate.Lprime, Rotate.Uprime, Rotate.Lprime, Rotate.U, Rotate.R, Rotate.Uprime, Rotate.L, Rotate.U,
                                                            Rotate.Rprime, Rotate.L }; // "L' U' L' U R U' L U R' L";
        static List<Rotate>[] Step2Commands = new List<Rotate>[] { command1, command2, command3, command4, command5, command6, command7 };

        static Rotate[][] PreRotation = new Rotate[][]
        {
           new Rotate[] { Rotate.None, Rotate.U, Rotate.U2, Rotate.Uprime }, //  c("","U","U2","U'"),
           new Rotate[] { Rotate.None, Rotate.U, Rotate.U2, Rotate.Uprime }, //  c("","U","U2","U'"),
           new Rotate[] { Rotate.U, Rotate.U2 },                             //  c("U","U2"),
           new Rotate[] { Rotate.None, Rotate.U2, Rotate.U, Rotate.Uprime }, //  c("","U2","U","U'"),
           new Rotate[] { Rotate.None, Rotate.U2, Rotate.U, Rotate.Uprime }, //  c("","U2","U","U'"),
           new Rotate[] { Rotate.None, Rotate.Uprime, Rotate.U2, Rotate.U }, //  c("","U'","U2","U"),
           new Rotate[] { Rotate.None, Rotate.Uprime, Rotate.U2, Rotate.U }  //  c("","U'","U2","U"));
        };

        static FaceCube SolutionCube = new FaceCube("UUUURRRRFFFFDDDDLLLLBBBB");

        static FaceCube FixSecondLayer(FaceCube cube, List<Rotate> sol)
        {
            FaceCube outCube = cube;
            Rotate rot = Rotate.None;
            if (cube.f[10] == CubeColor.L)
                rot = Rotate.Dprime;
            else if (cube.f[10] == CubeColor.B)
                rot = Rotate.D2;
            else if (cube.f[10] == CubeColor.R)
                rot = Rotate.D;

            if (rot != Rotate.None)
            {
                sol.Add(rot);
                outCube = RotateCube(cube, rot);
            }
            return outCube;
        }

        static FaceCube FixFirstLayer(FaceCube cube, List<Rotate> sol)
        {
            FaceCube outCube = cube;
            Rotate rot = Rotate.None;
            if (cube.f[8] == CubeColor.L)
                rot = Rotate.U;
            else if (cube.f[8] == CubeColor.B)
                rot = Rotate.U2;
            else if (cube.f[8] == CubeColor.R)
                rot = Rotate.Uprime;

            if (rot != Rotate.None)
            {
                sol.Add(rot);
                outCube = RotateCube(cube, rot);
            }
            return outCube;
        }

        static int CountFacesInSameColorInFirstLayer(FaceCube cube)
        {
            return ((cube.f[20] == cube.f[21]) ? 1 : 0) + ((cube.f[16] == cube.f[17]) ? 1 : 0) +
                ((cube.f[8] == cube.f[9]) ? 1 : 0) + ((cube.f[5] == cube.f[4]) ? 1 : 0);
        }

        static FaceCube MakeTwoIdenticalFacesFaceBack(FaceCube cube, out bool success, List<Rotate> sol)
        {
            FaceCube outCube = cube;
            Rotate rot = Rotate.None;
            if (cube.f[16] == cube.f[17])
                rot = Rotate.U;
            else if (cube.f[4] == cube.f[5])
                rot = Rotate.Uprime;
            else if (cube.f[8] == cube.f[9])
                rot = Rotate.U2;

            if (rot != Rotate.None)
            {
                sol.Add(rot);
                outCube = RotateCube(cube, rot);
                success = true;
            }
            else
            {
                success = false;
            }
            return outCube;
        }

        static Tuple<int, int> FindMatchingStep2(FaceCube cube)
        {

            int casei = -1;
            int matchj = 0;
            for (int casenum = 0; casenum < 7; casenum++)
            {
                int[][] cases = Step2Cases[casenum];
                for (int jj = 0; jj < cases.Length; jj++)
                {
                    bool found = true;
                    for (int kk = 0; kk < cases[jj].Length; kk++)
                    {
                        if (cube.f[cases[jj][kk]] != CubeColor.U)
                        {
                            found = false;
                            matchj = -1;
                            break;
                        }
                        matchj = jj;
                    }
                    if (found)
                    {
                        casei = casenum;
                        return Tuple.Create(casei, matchj);
                    }
                }
            }
            return Tuple.Create(-1, 0);
        }

        public static FaceCube Step2AndStep3(FaceCube cube, List<Rotate> sol)
        {
            Tuple<int, int> cmatch = FindMatchingStep2(cube);
            FaceCube scube = new FaceCube();

            List<Rotate> step3command = new List<Rotate>()
            {
                Rotate.Lprime, Rotate.U, Rotate.Rprime, Rotate.D2, Rotate.R,
                Rotate.Uprime, Rotate.Rprime, Rotate.D2, Rotate.R2, Rotate.B,
                Rotate.Rprime, Rotate.L //"L' U R' D2 R U' R' D2 R2 B R' L";
            };

            if (cmatch.Item1 >= 0)
            {
                List<Rotate> step2command = new List<Rotate>(Step2Commands[cmatch.Item1]);
                step2command.Insert(0, PreRotation[cmatch.Item1][cmatch.Item2]);
                scube = MultiRotCube(cube, step2command);
                sol.AddRange(step2command);
            }
            else
            {
                scube.f = cube.f;
            }

            scube = FixSecondLayer(scube, sol);
            Console.WriteLine(value: "after fixing second layer, cube=" + scube.to_fc_String());
            bool success = false;

            if (CountFacesInSameColorInFirstLayer(scube) < 4)
            {
                while (success != true)
                {
                    scube = MakeTwoIdenticalFacesFaceBack(scube, out success, sol);
                    sol.AddRange(step3command);
                    scube = MultiRotCube(scube, step3command);
                    Console.WriteLine("MakeTwoIdenticalFacesFaceBack:" + success);
                    Console.WriteLine("cube=" + scube.to_fc_String());
                    scube = MakeTwoIdenticalFacesFaceBack(scube, out success, sol);
                    Console.WriteLine("MakeTwoIdenticalFacesFaceBack:" + success);
                }
            }

            scube = FixFirstLayer(scube, sol);
            if (!scube.Equals(SolutionCube))
            {
                bool s = scube.Equals(SolutionCube);
                Console.WriteLine("Finding solution is failed." + s);
            }
            else
            {
                Console.WriteLine("Success!");
            }
            return scube;
        }

        public static void BFS(FaceCube start, FaceCube end, List<Rotate> sol)
        {
            List<FaceCube> facecubes = new List<FaceCube>();
            List<int> parentArray = new List<int>();
            List<Rotate> rotHistory = new List<Rotate>();
            HashSet<FaceCube> visited = new HashSet<FaceCube>();
            // Create a queue for BFS
            int queueindex;
            // Stack<Rotate> rotstack = new Stack<Rotate>();

            Rotate[] rots = new Rotate[] {
                Rotate.U, Rotate.Uprime,Rotate.U2, Rotate.R, Rotate.Rprime, Rotate.R2,
                Rotate.F, Rotate.Fprime,Rotate.F2, Rotate.D, Rotate.Dprime, Rotate.D2,
                Rotate.L, Rotate.Lprime,Rotate.L2, Rotate.B, Rotate.Bprime, Rotate.B2
            };
            facecubes.Add(start);
            parentArray.Add(0);
            rotHistory.Add(Rotate.U);  // 0
            visited.Add(start);
            queueindex = 0;
            int numRejected = 0;
            int total = 0;
            Console.WriteLine(queueindex + ":" + facecubes[queueindex].to_fc_String());
            while (queueindex < facecubes.Count)
            {
                FaceCube s = facecubes[queueindex];
                //Console.WriteLine(s);
                foreach (Rotate rot in rots)
                {
                    FaceCube newCube = RotateCube(s, rot);
                    total++;
                    if (!visited.Contains(newCube))
                    {
                        facecubes.Add(newCube);
                        parentArray.Add(queueindex);
                        rotHistory.Add(rot);
                        visited.Add(newCube);
                        //     Console.Write(queueindex +":" + facecubes[queueindex].to_fc_String());
                        //     Console.WriteLine("----" + rot.ToString() + "-->" + (facecubes.Count-1) + newCube.to_fc_String() );
                    }
                    else
                    {
                        numRejected++;
                    }
                    if (newCube.Equals(end))
                    {
                        Console.WriteLine("Problem solved!");
                        int parent = facecubes.Count - 1;
                        while (parent > 0)
                        {
                            Console.WriteLine(parent + ":" + facecubes[parent].to_fc_String());
                            Console.WriteLine("<---" + rotHistory[parent].ToString() + "---");
                            sol.Insert(0, rotHistory[parent]);
                            parent = parentArray[parent];
                        }
                        Console.WriteLine(parent + ":" + facecubes[parent].to_fc_String());
                        Console.WriteLine("Total Trial=" + total + " numRejected=" + numRejected);
                        return;
                    }
                }
                queueindex++;
            }

        }


        public static FaceCube RotateCube(FaceCube cube, Rotate rot)
        {
            CubeColor[] outCube = new CubeColor[24];

            if (rot == Rotate.None)
            {
                return new FaceCube(cube.f);
            }

            int[] tr = transform[(int)rot];
            for (int ii = 0; ii < 24; ii++)
            {
                outCube[ii] = cube.f[tr[ii]];
            }
            return new FaceCube(outCube);
        }

        public static FaceCube MultiRotCube(FaceCube cube, List<Rotate> rots)
        {
            FaceCube icube = new FaceCube();
            FaceCube outCube = new FaceCube();
            Array.Copy(cube.f, icube.f, 24);
            foreach (Rotate rot in rots)
            {
                outCube = RotateCube(icube, rot);
                icube.f = outCube.f;
            }
            return outCube;
        }

        public static string SolutionToString(List<Rotate> rots)
        {
            List<string> sol = new List<string>();
            foreach (Rotate rot in rots)
            {
                switch (rot)
                {
                    case Rotate.Rprime:
                        sol.Add("R'"); break;
                    case Rotate.Uprime:
                        sol.Add("U'"); break;
                    case Rotate.Fprime:
                        sol.Add("F'"); break;
                    case Rotate.Bprime:
                        sol.Add("B'"); break;
                    case Rotate.Dprime:
                        sol.Add("D'"); break;
                    case Rotate.Lprime:
                        sol.Add("L'"); break;
                    case Rotate.None:
                        break;
                    default:
                        sol.Add(rot.ToString());
                        break;
                }
            }
            return string.Join(" ", sol);
        }

        public static List<Rotate> solution(string moveString, out string info)
        {
            List<Rotate> sol = new List<Rotate>();
            FaceCube icube = new FaceCube(moveString);
            FaceCube interm = new FaceCube("WWWWWWRRWWFFDDDDWWLLWWBB");
            BFS(icube, interm, sol);
            FaceCube scube = MultiRotCube(icube, sol);
            scube = Step2AndStep3(scube, sol);
            info = SolutionToString(sol);
            return sol;
        }
    }

}


