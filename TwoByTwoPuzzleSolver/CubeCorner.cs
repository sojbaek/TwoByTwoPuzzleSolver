using System;
using System.Collections;

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

namespace TwoByTwoPuzzleSolver
{
    public class CubeCorner
    {
        public static int[] cornerValue = new int[]
        {
            0,0,0,4,1,2 //   U, R, F, D, L, B
        };

        public static Corner calcCornerCode(FaceCube cube, int i, int j, int k)
        {
            return ((Corner)(cornerValue[(int)cube.f[i]] + cornerValue[(int)cube.f[j]] + cornerValue[(int)cube.f[k]]));
        }

        public static Corner[] Cube2Corners(FaceCube cube)
        {
            Corner[] corner = new Corner[8];
            corner[0] = calcCornerCode(cube, 3, 4, 9);
            corner[1] = calcCornerCode(cube, 2, 8, 17);
            corner[2] = calcCornerCode(cube, 1, 5, 20);
            corner[3] = calcCornerCode(cube, 0, 16, 21);
            corner[4] = calcCornerCode(cube, 6, 11, 13);
            corner[5] = calcCornerCode(cube, 10, 12, 19);
            corner[6] = calcCornerCode(cube, 7, 15, 22);
            corner[7] = calcCornerCode(cube, 14, 18, 23);
            return corner;
        }


        public Corner[] f = new Corner[8];

        
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public CubeCorner()
        {
            for (int i = 0; i < 8; i++)
            {
                f[i] = (Corner) i;
            }
        }

        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // Construct a facelet cube from a string
        public CubeCorner(FaceCube cube)
        {
            this.f = Cube2Corners(cube);
        }

        public CubeCorner(Corner[] f)
        {
            this.f = f;
        }
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // Gives string representation of a facelet cube
        public string to_fc_String()
        {
            string s = "";
            for (int i = 0; i < 8; i++)
                s += f[i].ToString() + " ";
            return s;
        }

        public override int GetHashCode()
        {
            int result = 0;
            int shift = 0;
            for (int i = 0; i < f.Length; i++)
            {
                shift = (shift + 11) % 21;
                result ^= ((int)f[i] + 1024) << shift;
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as CubeCorner);
        }

        public bool Equals(CubeCorner other)
        {
            for (int i = 0; i < 8; i++)
            {
                if (other.f[i] != this.f[i]) return false;
            }
            return true;
        }
    }
}