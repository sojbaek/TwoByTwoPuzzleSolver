using System;
using System.Collections;

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//Cube on the facelet level

namespace TwoByTwoPuzzleSolver
{
    public class FaceCube
    {
        public CubeColor[] f = new CubeColor[24];

        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // Map the corner positions to facelet positions. cornerFacelet[URF.ordinal()][0] e.g. gives the position of the
        // facelet in the URF corner position, which defines the orientation.<br>
        // cornerFacelet[URF.ordinal()][1] and cornerFacelet[URF.ordinal()][2] give the position of the other two facelets
        // of the URF corner (clockwise).
        
        public static Facelet[][] cornerFacelet = new Facelet[][] {
            new Facelet[] { Facelet.U4, Facelet.R1, Facelet.F2 },   // 1->1, 3->2, 7->3, 9->4
            new Facelet[] { Facelet.U3, Facelet.F1, Facelet.L2 },
            new Facelet[] { Facelet.U1, Facelet.L1, Facelet.B2 },
            new Facelet[] { Facelet.U2, Facelet.B1, Facelet.R2 },
            new Facelet[] { Facelet.D2, Facelet.F4, Facelet.R3 },
            new Facelet[] { Facelet.D1, Facelet.L4, Facelet.F3 },
            new Facelet[] { Facelet.D3, Facelet.B4, Facelet.L3 },
            new Facelet[] { Facelet.D4, Facelet.R4, Facelet.B3 }
            };

        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // Map the corner positions to facelet CubeColors.
        public static CubeColor[][] cornerColor = new CubeColor[][]{
            new CubeColor[] { CubeColor.U, CubeColor.R, CubeColor.F },
            new CubeColor[] { CubeColor.U, CubeColor.F, CubeColor.L },
            new CubeColor[] { CubeColor.U, CubeColor.L, CubeColor.B },
            new CubeColor[] { CubeColor.U, CubeColor.B, CubeColor.R },
            new CubeColor[] { CubeColor.D, CubeColor.F, CubeColor.R },
            new CubeColor[] { CubeColor.D, CubeColor.L, CubeColor.F },
            new CubeColor[] { CubeColor.D, CubeColor.B, CubeColor.L },
            new CubeColor[] { CubeColor.D, CubeColor.R, CubeColor.B }
        };


        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public FaceCube()
        {
            string s = "UUUURRRRFFFFDDDDLLLLBBBB";
            for (int i = 0; i < 24; i++)
            {
                CubeColor col = (CubeColor)Enum.Parse(typeof(CubeColor), s[i].ToString());
                f[i] = col;
            }
        }

        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // Construct a facelet cube from a string
        public FaceCube(string cubeString)
        {
            for (int i = 0; i < cubeString.Length; i++)
            {
                CubeColor col = (CubeColor)Enum.Parse(typeof(CubeColor), cubeString[i].ToString());
                f[i] = col;
            }

        }

        public FaceCube(CubeColor[] f)
        {
            this.f = f;
        }
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // Gives string representation of a facelet cube
        public string to_fc_String()
        {
            string s = "";
            for (int i = 0; i < 24; i++)
                s += f[i].ToString();
            return s;
        }

        public override int GetHashCode()
        {
            int result = 0;
            int shift = 0;
            for (int i = 0; i < f.Length; i++)
            {
                shift = (shift + 11) % 21;
                result ^= ((int) f[i] + 1024) << shift;
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as FaceCube);
        }

        public bool Equals(FaceCube other)
        {
            for (int i = 0; i <24; i++)
            {
                if (other.f[i] == CubeColor.W || this.f[i] == CubeColor.W) continue;
                if (other.f[i] != this.f[i]) return false;
            }
            return true;
        }
    }
}