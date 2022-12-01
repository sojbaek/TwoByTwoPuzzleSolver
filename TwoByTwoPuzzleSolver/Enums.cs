using System;

namespace TwoByTwoPuzzleSolver
{
    /**
      * <pre>
      * The names of the facelet positions of the cube
      *         |********|
      *         |*U1**U2*|
      *         |********|
      *         |*U3**U4*|
      *         |********|
      * ********|********|********|********|
      * *L1**L2*|*F1**F2*|*R1**R2*|*B1**B2*|
      * ********|********|********|********|
      * *L3**L4*|*F3**F4*|*R3**R4*|*B3**B4*|
      * ********|********|********|********|
      *         |********|
      *         |*D1**D2*|
      *         |********|
      *         |*D3**D4*|
      *         |********|
      * </pre>
      * 
      * A cube definition string "UBL..." means for example: In position U1 we have the U-color, in position U2 we have the
      * B-color, in position U3 we have the L color etc. according to the order  U1, U2, U3, U4,  R1, R2, R3, R4, F1, F2, 
      * F3, F4,  D1, D2, D3, D4, L1, L2, L3, L4,  B1, B2, B3, B4  of the enum constants.
      */
    public enum Facelet
    {
        U1, U2, U3, U4,  R1, R2, R3, R4, F1, F2, F3, F4,  D1, D2, D3, D4, L1, L2, L3, L4,  B1, B2, B3, B4
    }

    //++++++++++++++++++++++++++++++ Names the colors of the cube facelets ++++++++++++++++++++++++++++++++++++++++++++++++
    public enum CubeColor
    {
        U, R, F, D, L, B, W
    }

    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    //The names of the corner positions of the cube. Corner URF e.g., has an U(p), a R(ight) and a F(ront) facelet
    public enum Corner
    {
       // URF, UFL, ULB, UBR, DFR, DLF, DBL, DRB
       UFR, UFL, UBR, UBL, DFR, DFL, DBR, DBL
    }

    public enum Rotate
    {
        U, Uprime,U2, R, Rprime, R2, F, Fprime, F2, D, Dprime, D2, L, Lprime, L2, B, Bprime, B2, None
    }
}