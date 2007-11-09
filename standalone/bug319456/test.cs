using System;
using System.Text.RegularExpressions;

class Program
{
	static string _input = "/game 4 7 @data -35,3j,4 2y,3q 2y,3x 2y,44 " +
		"2y,4c 2y,4j 35,4j 3d,4j 3k,4j 3r,4c 3r,44 3y,44 3y,3x " +
		"3r,3x 3k,3x 3d,3x 3d,44 3k,3x 3k,3q 3k,3j 3d,3j 35,3j " +
		"35,3q 2y,3x 2r,44 2r,4c 2r,4j 2k,4j 2k,4q 2k,4j 2k,4c " +
		"2k,44 2k,3x 2k,44 2d,4c 2d,4j 2d,4c 2d,44 2d,3x 2d,3q " +
		"2k,3q 2k,3j 2r,3j 2y,3j 35,3j 35,3c 3d,3c 3k,3c 3k,35 " +
		"3r,35 3y,35 45,35 4c,35 4j,35 4q,35 4q,2y 4x,2y 54,2y " +
		"5b,2y 5b,35 54,35 54,3c 4x,3c 4q,3c 4j,3c 4c,3c 45,3c " +
		"4c,3c 4j,3c 4q,3c 4x,3c 4x,3j 54,3j 5b,3j 5b,3q 5i,3q " +
		"5i,3x 5p,3x 5p,44 5p,4c 5p,4j 5p,4q 5p,4x 5i,4x 5b,4x " +
		"54,4x 4x,4q 4x,4j 4q,4j 4q,4c 4j,44 4j,3x 4c,3x 4c,3q " +
		"45,3q 3y,3q 3y,3x 3y,44 45,4c 4c,4c 4c,4j 4j,4j 4q,4j " +
		"4x,4j 4x,4c 4x,44 4q,44 4q,3x 4j,3x 4j,3q 4c,3q 4j,3q " +
		"4q,3x 4x,3x 54,44 5b,44 5b,4c 5b,4j 54,4j 4x,4j 4q,4j " +
		"4q,4c 4j,4c 4c,44 4c,4c 4c,4j 4c,4q 4c,4x 4j,5b 4j,5i " +
		"4q,5p 4q,5w 4q,5i 4j,5i 4j,54 4c,4x 45,4q 45,4j 3y,4j " +
		"3r,4q 3r,4x 3r,54 3k,4x 3k,4q 3d,4j 3d,4c 35,4c 2y,4j " +
		"2y,4q 2y,4x 2r,54 2r,5b 2r,5i 2r,5p 2r,5w 2k,5w 2k,5p " +
		"2k,5i 2d,5b 2d,54 2d,4x 26,4x 26,4q 1z,4q 1z,4x 1z,54 " +
		"1z,5b 1z,5i 1z,5b 1z,54 1z,4x 26,4q 26,4j 2d,4j 2k,4j " +
		"2r,4j 2y,4q 2y,4x 2y,54 2y,5b 2y,5i 2y,5p 35,5i 35,5b " +
		"35,54 3d,4x 3k,4x 3k,4q 3k,4j 3r,4j 3r,4q 3r,4x 3r,54 " +
		"3y,5i 3y,5p 45,5w 45,5p 45,5i 45,5b 45,54 45,4x 45,54 " +
		"45,5b 45,5i 45,5p 45,5w 45,5p 45,5i 3y,5i 3y,5b 3r,54 " +
		"3r,4x 3k,4x 3k,54 3k,5b 3d,5i 35,5p 35,63 35,6a 3d,6a " +
		"3d,6h 3k,6h 3r,6a 3y,5w 45,5p 45,5i 4c,54 4j,4x 4j,4q " +
		"4q,4q 4q,4j 4q,4q 4q,4x 4q,54 4x,5b 4x,5i 54,5i 54,5p " +
		"5b,5p 5b,5i 5b,5b 5b,54 5b,5b 5i,5i 5i,5p 5p,5p 5p,5i " +
		"5p,5b 5p,54 5p,4x 5i,4x 5i,54 5i,5b 5i,5i 5i,5p 5i,5i " +
		"5i,5b 5i,54 5i,4x 5i,54 5p,5b 5p,5i 5w,5i 5w,5p 64,5p " +
		"6b,5p 6i,5i 6i,5b 6i,54 6i,4x 6p,4x 6p,4q 6p,4j 6p,4c " +
		"6p,44 6i,4j 6i,4q 6i,4x 6i,5b 6i,5i 6i,5b 6i,54 6i,4x " +
		"6i,4q 6i,4c 6i,44 6i,3x 6i,44 6i,4c 6b,4c 6b,4q 6b,4x " +
		"6b,54 6b,5b 6b,54 6b,4x 6b,4q 64,4x 64,54 64,5b 64,54 " +
		"64,4x 64,4q 64,4j 64,4c 64,44 64,3x 6b,3q 6b,3j 6i,3j " +
		"6i,3c 6p,3c 6w,3c 73,3c 7a,3c 7h,3c 7o,3c 7v,3c 82,3c " +
		"89,3c 8g,3c 8n,3c 8n,3j 8u,3j 8u,3q 8u,3x 92,3x 92,44 " +
		"92,4c 92,4j 92,4q 92,4x 92,54 92,5b 8u,5b 8n,5i 8g,5p " +
		"5b,2y 5b,35 54,35 54,3c 4x,3c 4q,3c 4j,3c 4c,3c 45,3c " +
		"4c,3c 4j,3c 4q,3c 4x,3c 4x,3j 54,3j 5b,3j 5b,3q 5i,3q " +
		"5i,3x 5p,3x 5p,44 5p,4c 5p,4j 5p,4q 5p,4x 5i,4x 5b,4x " +
		"54,4x 4x,4q 4x,4j 4q,4j 4q,4c 4j,44 4j,3x 4c,3x 4c,3q " +
		"45,3q 3y,3q 3y,3x 3y,44 45,4c 4c,4c 4c,4j 4j,4j 4q,4j " +
		"4x,4j 4x,4c 4x,44 4q,44 4q,3x 4j,3x 4j,3q 4c,3q 4j,3q " +
		"4q,3x 4x,3x 54,44 5b,44 5b,4c 5b,4j 54,4j 4x,4j 4q,4j " +
		"4q,4c 4j,4c 4c,44 4c,4c 4c,4j 4c,4q 4c,4x 4j,5b 4j,5i " +
		"4q,5p 4q,5w 4q,5i 4j,5i 4j,54 4c,4x 45,4q 45,4j 3y,4j " +
		"3r,4q 3r,4x 3r,54 3k,4x 3k,4q 3d,4j 3d,4c 35,4c 2y,4j " +
		"2y,4q 2y,4x 2r,54 2r,5b 2r,5i 2r,5p 2r,5w 2k,5w 2k,5p " +
		"2k,5i 2d,5b 2d,54 2d,4x 26,4x 26,4q 1z,4q 1z,4x 1z,54 " +
		"1z,5b 1z,5i 1z,5b 1z,54 1z,4x 26,4q 26,4j 2d,4j 2k,4j " +
		"2r,4j 2y,4q 2y,4x 2y,54 2y,5b 2y,5i 2y,5p 35,5i 35,5b " +
		"35,54 3d,4x 3k,4x 3k,4q 3k,4j 3r,4j 3r,4q 3r,4x 3r,54 " +
		"3y,5i 3y,5p 45,5w 45,5p 45,5i 45,5b 45,54 45,4x 45,54 " +
		"45,5b 45,5i 45,5p 45,5w 45,5p 45,5i 3y,5i 3y,5b 3r,54 " +
		"3r,4x 3k,4x 3k,54 3k,5b 3d,5i 35,5p 35,63 35,6a 3d,6a " +
		"3d,6h 3k,6h 3r,6a 3y,5w 45,5p 45,5i 4c,54 4j,4x 4j,4q " +
		"4q,4q 4q,4j 4q,4q 4q,4x 4q,54 4x,5b 4x,5i 54,5i 54,5p " +
		"5b,5p 5b,5i 5b,5b 5b,54 5b,5b 5i,5i 5i,5p 5p,5p 5p,5i " +
		"5p,5b 5p,54 5p,4x 5i,4x 5i,54 5i,5b 5i,5i 5i,5p 5i,5i " +
		"5i,5b 5i,54 5i,4x 5i,54 5p,5b 5p,5i 5w,5i 5w,5p 64,5p " +
		"6b,5p 6i,5i 6i,5b 6i,54 6i,4x 6p,4x 6p,4q 6p,4j 6p,4c " +
		"6p,44 6i,4j 6i,4q 6i,4x 6i,5b 6i,5i 6i,5b 6i,54 6i,4x " +
		"6i,4q 6i,4c 6i,44 6i,3x 6i,44 6i,4c 6b,4c 6b,4q 6b,4x " +
		"6b,54 6b,5b 6b,54 6b,4x 6b,4q 64,4x 64,54 64,5b 64,54 " +
		"64,4x 64,4q 64,4j 64,4c 64,44 64,3x 6b,3q 6b,3j 6i,3j " +
		"6i,3c 6p,3c 6w,3c 73,3c 7a,3c 7h,3c 7o,3c 7v,3c 82,3c " +
		"89,3c 8g,3c 8n,3c 8n,3j 8u,3j 8u,3q 8u,3x 92,3x 92,44 " +
		"92,4c 92,4j 92,4q 92,4x 92,54 92,5b 8u,5b 8n,5i 8g,5p " +
		"5b,2y 5b,35 54,35 54,3c 4x,3c 4q,3c 4j,3c 4c,3c 45,3c " +
		"4c,3c 4j,3c 4q,3c 4x,3c 4x,3j 54,3j 5b,3j 5b,3q 5i,3q " +
		"5i,3x 5p,3x 5p,44 5p,4c 5p,4j 5p,4q 5p,4x 5i,4x 5b,4x " +
		"54,4x 4x,4q 4x,4j 4q,4j 4q,4c 4j,44 4j,3x 4c,3x 4c,3q " +
		"45,3q 3y,3q 3y,3x 3y,44 45,4c 4c,4c 4c,4j 4j,4j 4q,4j " +
		"4x,4j 4x,4c 4x,44 4q,44 4q,3x 4j,3x 4j,3q 4c,3q 4j,3q " +
		"4q,3x 4x,3x 54,44 5b,44 5b,4c 5b,4j 54,4j 4x,4j 4q,4j " +
		"4q,4c 4j,4c 4c,44 4c,4c 4c,4j 4c,4q 4c,4x 4j,5b 4j,5i " +
		"4q,5p 4q,5w 4q,5i 4j,5i 4j,54 4c,4x 45,4q 45,4j 3y,4j " +
		"3r,4q 3r,4x 3r,54 3k,4x 3k,4q 3d,4j 3d,4c 35,4c 2y,4j " +
		"2y,4q 2y,4x 2r,54 2r,5b 2r,5i 2r,5p 2r,5w 2k,5w 2k,5p " +
		"2k,5i 2d,5b 2d,54 2d,4x 26,4x 26,4q 1z,4q 1z,4x 1z,54 " +
		"1z,5b 1z,5i 1z,5b 1z,54 1z,4x 26,4q 26,4j 2d,4j 2k,4j " +
		"2r,4j 2y,4q 2y,4x 2y,54 2y,5b 2y,5i 2y,5p 35,5i 35,5b " +
		"35,54 3d,4x 3k,4x 3k,4q 3k,4j 3r,4j 3r,4q 3r,4x 3r,54 " +
		"3y,5i 3y,5p 45,5w 45,5p 45,5i 45,5b 45,54 45,4x 45,54 " +
		"45,5b 45,5i 45,5p 45,5w 45,5p 45,5i 3y,5i 3y,5b 3r,54 " +
		"3r,4x 3k,4x 3k,54 3k,5b 3d,5i 35,5p 35,63 35,6a 3d,6a " +
		"3d,6h 3k,6h 3r,6a 3y,5w 45,5p 45,5i 4c,54 4j,4x 4j,4q " +
		"4q,4q 4q,4j 4q,4q 4q,4x 4q,54 4x,5b 4x,5i 54,5i 54,5p " +
		"5b,5p 5b,5i 5b,5b 5b,54 5b,5b 5i,5i 5i,5p 5p,5p 5p,5i " +
		"5p,5b 5p,54 5p,4x 5i,4x 5i,54 5i,5b 5i,5i 5i,5p 5i,5i " +
		"5i,5b 5i,54 5i,4x 5i,54 5p,5b 5p,5i 5w,5i 5w,5p 64,5p " +
		"6b,5p 6i,5i 6i,5b 6i,54 6i,4x 6p,4x 6p,4q 6p,4j 6p,4c " +
		"6p,44 6i,4j 6i,4q 6i,4x 6i,5b 6i,5i 6i,5b 6i,54 6i,4x " +
		"6i,4q 6i,4c 6i,44 6i,3x 6i,44 6i,4c 6b,4c 6b,4q 6b,4x " +
		"6b,54 6b,5b 6b,54 6b,4x 6b,4q 64,4x 64,54 64,5b 64,54 " +
		"64,4x 64,4q 64,4j 64,4c 64,44 64,3x 6b,3q 6b,3j 6i,3j " +
		"6i,3c 6p,3c 6w,3c 73,3c 7a,3c 7h,3c 7o,3c 7v,3c 82,3c " +
		"89,3c 8g,3c 8n,3c 8n,3j 8u,3j 8u,3q 8u,3x 92,3x 92,44 " +
		"89,3c 8g,3c 8n,3c 8n,3j 8u,3j 8u,3q 8u,3x 92,3x 92,44 " +
		"92,4c 92,4j 92,4q 92,4x 92,54 92,5b 8u,5b 8n,5i 8g,5p " +
		"5b,2y 5b,35 54,35 54,3c 4x,3c 4q,3c 4j,3c 4c,3c 45,3c " +
		"4c,3c 4j,3c 4q,3c 4x,3c 4x,3j 54,3j 5b,3j 5b,3q 5i,3q " +
		"5i,3x 5p,3x 5p,44 5p,4c 5p,4j 5p,4q 5p,4x 5i,4x 5b,4x " +
		"54,4x 4x,4q 4x,4j 4q,4j 4q,4c 4j,44 4j,3x 4c,3x 4c,3q " +
		"45,3q 3y,3q 3y,3x 3y,44 45,4c 4c,4c 4c,4j 4j,4j 4q,4j " +
		"4x,4j 4x,4c 4x,44 4q,44 4q,3x 4j,3x 4j,3q 4c,3q 4j,3q " +
		"4q,3x 4x,3x 54,44 5b,44 5b,4c 5b,4j 54,4j 4x,4j 4q,4j " +
		"4q,4c 4j,4c 4c,44 4c,4c 4c,4j 4c,4q 4c,4x 4j,5b 4j,5i " +
		"4q,5p 4q,5w 4q,5i 4j,5i 4j,54 4c,4x 45,4q 45,4j 3y,4j " +
		"3r,4q 3r,4x 3r,54 3k,4x 3k,4q 3d,4j 3d,4c 35,4c 2y,4j " +
		"2y,4q 2y,4x 2r,54 2r,5b 2r,5i 2r,5p 2r,5w 2k,5w 2k,5p " +
		"2k,5i 2d,5b 2d,54 2d,4x 26,4x 26,4q 1z,4q 1z,4x 1z,54 " +
		"1z,5b 1z,5i 1z,5b 1z,54 1z,4x 26,4q 26,4j 2d,4j 2k,4j " +
		"2r,4j 2y,4q 2y,4x 2y,54 2y,5b 2y,5i 2y,5p 35,5i 35,5b " +
		"35,54 3d,4x 3k,4x 3k,4q 3k,4j 3r,4j 3r,4q 3r,4x 3r,54 " +
		"3y,5i 3y,5p 45,5w 45,5p 45,5i 45,5b 45,54 45,4x 45,54 " +
		"45,5b 45,5i 45,5p 45,5w 45,5p 45,5i 3y,5i 3y,5b 3r,54 " +
		"3r,4x 3k,4x 3k,54 3k,5b 3d,5i 35,5p 35,63 35,6a 3d,6a " +
		"3d,6h 3k,6h 3r,6a 3y,5w 45,5p 45,5i 4c,54 4j,4x 4j,4q " +
		"4q,4q 4q,4j 4q,4q 4q,4x 4q,54 4x,5b 4x,5i 54,5i 54,5p " +
		"5b,5p 5b,5i 5b,5b 5b,54 5b,5b 5i,5i 5i,5p 5p,5p 5p,5i " +
		"5p,5b 5p,54 5p,4x 5i,4x 5i,54 5i,5b 5i,5i 5i,5p 5i,5i " +
		"5i,5b 5i,54 5i,4x 5i,54 5p,5b 5p,5i 5w,5i 5w,5p 64,5p " +
		"6b,5p 6i,5i 6i,5b 6i,54 6i,4x 6p,4x 6p,4q 6p,4j 6p,4c " +
		"6p,44 6i,4j 6i,4q 6i,4x 6i,5b 6i,5i 6i,5b 6i,54 6i,4x " +
		"6i,4q 6i,4c 6i,44 6i,3x 6i,44 6i,4c 6b,4c 6b,4q 6b,4x " +
		"6b,54 6b,5b 6b,54 6b,4x 6b,4q 64,4x 64,54 64,5b 64,54 " +
		"64,4x 64,4q 64,4j 64,4c 64,44 64,3x 6b,3q 6b,3j 6i,3j " +
		"6i,3c 6p,3c 6w,3c 73,3c 7a,3c 7h,3c 7o,3c 7v,3c 82,3c " +
		"89,3c 8g,3c 8n,3c 8n,3j 8u,3j 8u,3q 8u,3x 92,3x 92,44 " +
		"92,4c 92,4j 92,4q 92,4x 92,54 92,5b 8u,5b 8n,5i 8g,5p " +
		"5b,2y 5b,35 54,35 54,3c 4x,3c 4q,3c 4j,3c 4c,3c 45,3c " +
		"4c,3c 4j,3c 4q,3c 4x,3c 4x,3j 54,3j 5b,3j 5b,3q 5i,3q " +
		"5i,3x 5p,3x 5p,44 5p,4c 5p,4j 5p,4q 5p,4x 5i,4x 5b,4x " +
		"54,4x 4x,4q 4x,4j 4q,4j 4q,4c 4j,44 4j,3x 4c,3x 4c,3q " +
		"45,3q 3y,3q 3y,3x 3y,44 45,4c 4c,4c 4c,4j 4j,4j 4q,4j " +
		"4x,4j 4x,4c 4x,44 4q,44 4q,3x 4j,3x 4j,3q 4c,3q 4j,3q " +
		"4q,3x 4x,3x 54,44 5b,44 5b,4c 5b,4j 54,4j 4x,4j 4q,4j " +
		"4q,4c 4j,4c 4c,44 4c,4c 4c,4j 4c,4q 4c,4x 4j,5b 4j,5i " +
		"4q,5p 4q,5w 4q,5i 4j,5i 4j,54 4c,4x 45,4q 45,4j 3y,4j " +
		"3r,4q 3r,4x 3r,54 3k,4x 3k,4q 3d,4j 3d,4c 35,4c 2y,4j " +
		"2y,4q 2y,4x 2r,54 2r,5b 2r,5i 2r,5p 2r,5w 2k,5w 2k,5p " +
		"2k,5i 2d,5b 2d,54 2d,4x 26,4x 26,4q 1z,4q 1z,4x 1z,54 " +
		"1z,5b 1z,5i 1z,5b 1z,54 1z,4x 26,4q 26,4j 2d,4j 2k,4j " +
		"2r,4j 2y,4q 2y,4x 2y,54 2y,5b 2y,5i 2y,5p 35,5i 35,5b " +
		"35,54 3d,4x 3k,4x 3k,4q 3k,4j 3r,4j 3r,4q 3r,4x 3r,54 " +
		"3y,5i 3y,5p 45,5w 45,5p 45,5i 45,5b 45,54 45,4x 45,54 " +
		"45,5b 45,5i 45,5p 45,5w 45,5p 45,5i 3y,5i 3y,5b 3r,54 " +
		"3r,4x 3k,4x 3k,54 3k,5b 3d,5i 35,5p 35,63 35,6a 3d,6a " +
		"3d,6h 3k,6h 3r,6a 3y,5w 45,5p 45,5i 4c,54 4j,4x 4j,4q " +
		"4q,4q 4q,4j 4q,4q 4q,4x 4q,54 4x,5b 4x,5i 54,5i 54,5p " +
		"5b,5p 5b,5i 5b,5b 5b,54 5b,5b 5i,5i 5i,5p 5p,5p 5p,5i " +
		"5p,5b 5p,54 5p,4x 5i,4x 5i,54 5i,5b 5i,5i 5i,5p 5i,5i " +
		"5i,5b 5i,54 5i,4x 5i,54 5p,5b 5p,5i 5w,5i 5w,5p 64,5p " +
		"6b,5p 6i,5i 6i,5b 6i,54 6i,4x 6p,4x 6p,4q 6p,4j 6p,4c " +
		"6p,44 6i,4j 6i,4q 6i,4x 6i,5b 6i,5i 6i,5b 6i,54 6i,4x " +
		"6i,4q 6i,4c 6i,44 6i,3x 6i,44 6i,4c 6b,4c 6b,4q 6b,4x " +
		"6b,54 6b,5b 6b,54 6b,4x 6b,4q 64,4x 64,54 64,5b 64,54 " +
		"64,4x 64,4q 64,4j 64,4c 64,44 64,3x 6b,3q 6b,3j 6i,3j " +
		"6i,3c 6p,3c 6w,3c 73,3c 7a,3c 7h,3c 7o,3c 7v,3c 82,3c " +
		"89,3c 8g,3c 8n,3c 8n,3j 8u,3j 8u,3q 8u,3x 92,3x 92,44 " +
		"4q,5p 4q,5w 4q,5i 4j,5i 4j,54 4c,4x 45,4q 45,4j 3y,4j " +
		"3r,4q 3r,4x 3r,54 3k,4x 3k,4q 3d,4j 3d,4c 35,4c 2y,4j " +
		"2y,4q 2y,4x 2r,54 2r,5b 2r,5i 2r,5p 2r,5w 2k,5w 2k,5p " +
		"2k,5i 2d,5b 2d,54 2d,4x 26,4x 26,4q 1z,4q 1z,4x 1z,54 " +
		"1z,5b 1z,5i 1z,5b 1z,54 1z,4x 26,4q 26,4j 2d,4j 2k,4j " +
		"2r,4j 2y,4q 2y,4x 2y,54 2y,5b 2y,5i 2y,5p 35,5i 35,5b " +
		"35,54 3d,4x 3k,4x 3k,4q 3k,4j 3r,4j 3r,4q 3r,4x 3r,54 " +
		"3y,5i 3y,5p 45,5w 45,5p 45,5i 45,5b 45,54 45,4x 45,54 " +
		"45,5b 45,5i 45,5p 45,5w 45,5p 45,5i 3y,5i 3y,5b 3r,54 " +
		"3r,4x 3k,4x 3k,54 3k,5b 3d,5i 35,5p 35,63 35,6a 3d,6a " +
		"3d,6h 3k,6h 3r,6a 3y,5w 45,5p 45,5i 4c,54 4j,4x 4j,4q " +
		"4q,4q 4q,4j 4q,4q 4q,4x 4q,54 4x,5b 4x,5i 54,5i 54,5p " +
		"5b,5p 5b,5i 5b,5b 5b,54 5b,5b 5i,5i 5i,5p 5p,5p 5p,5i " +
		"5p,5b 5p,54 5p,4x 5i,4x 5i,54 5i,5b 5i,5i 5i,5p 5i,5i " +
		"5i,5b 5i,54 5i,4x 5i,54 5p,5b 5p,5i 5w,5i 5w,5p 64,5p " +
		"6b,5p 6i,5i 6i,5b 6i,54 6i,4x 6p,4x 6p,4q 6p,4j 6p,4c " +
		"6p,44 6i,4j 6i,4q 6i,4x 6i,5b 6i,5i 6i,5b 6i,54 6i,4x " +
		"6i,4q 6i,4c 6i,44 6i,3x 6i,44 6i,4c 6b,4c 6b,4q 6b,4x " +
		"6b,54 6b,5b 6b,54 6b,4x 6b,4q 64,4x 64,54 64,5b 64,54 " +
		"64,4x 64,4q 64,4j 64,4c 64,44 64,3x 6b,3q 6b,3j 6i,3j " +
		"6i,3c 6p,3c 6w,3c 73,3c 7a,3c 7h,3c 7o,3c 7v,3c 82,3c " +
		"89,3c 8g,3c 8n,3c 8n,3j 8u,3j 8u,3q 8u,3x 92,3x 92,44 " +
		"4q,5p 4q,5w 4q,5i 4j,5i 4j,54 4c,4x 45,4q 45,4j 3y,4j " +
		"3r,4q 3r,4x 3r,54 3k,4x 3k,4q 3d,4j 3d,4c 35,4c 2y,4j " +
		"2y,4q 2y,4x 2r,54 2r,5b 2r,5i 2r,5p 2r,5w 2k,5w 2k,5p " +
		"2k,5i 2d,5b 2d,54 2d,4x 26,4x 26,4q 1z,4q 1z,4x 1z,54 " +
		"1z,5b 1z,5i 1z,5b 1z,54 1z,4x 26,4q 26,4j 2d,4j 2k,4j " +
		"2r,4j 2y,4q 2y,4x 2y,54 2y,5b 2y,5i 2y,5p 35,5i 35,5b " +
		"35,54 3d,4x 3k,4x 3k,4q 3k,4j 3r,4j 3r,4q 3r,4x 3r,54 " +
		"3y,5i 3y,5p 45,5w 45,5p 45,5i 45,5b 45,54 45,4x 45,54 " +
		"45,5b 45,5i 45,5p 45,5w 45,5p 45,5i 3y,5i 3y,5b 3r,54 " +
		"3r,4x 3k,4x 3k,54 3k,5b 3d,5i 35,5p 35,63 35,6a 3d,6a " +
		"3d,6h 3k,6h 3r,6a 3y,5w 45,5p 45,5i 4c,54 4j,4x 4j,4q " +
		"4q,4q 4q,4j 4q,4q 4q,4x 4q,54 4x,5b 4x,5i 54,5i 54,5p " +
		"5b,5p 5b,5i 5b,5b 5b,54 5b,5b 5i,5i 5i,5p 5p,5p 5p,5i " +
		"5p,5b 5p,54 5p,4x 5i,4x 5i,54 5i,5b 5i,5i 5i,5p 5i,5i " +
		"5i,5b 5i,54 5i,4x 5i,54 5p,5b 5p,5i 5w,5i 5w,5p 64,5p " +
		"6b,5p 6i,5i 6i,5b 6i,54 6i,4x 6p,4x 6p,4q 6p,4j 6p,4c " +
		"6p,44 6i,4j 6i,4q 6i,4x 6i,5b 6i,5i 6i,5b 6i,54 6i,4x " +
		"6i,4q 6i,4c 6i,44 6i,3x 6i,44 6i,4c 6b,4c 6b,4q 6b,4x " +
		"6b,54 6b,5b 6b,54 6b,4x 6b,4q 64,4x 64,54 64,5b 64,54 " +
		"2y,4q 2y,4x 2r,54 2r,5b 2r,5i 2r,5p 2r,5w 2k,5w 2k,5p " +
		"2k,5i 2d,5b 2d,54 2d,4x 26,4x 26,4q 1z,4q 1z,4x 1z,54 " +
		"1z,5b 1z,5i 1z,5b 1z,54 1z,4x 26,4q 26,4j 2d,4j 2k,4j " +
		"2r,4j 2y,4q 2y,4x 2y,54 2y,5b 2y,5i 2y,5p 35,5i 35,5b " +
		"35,54 3d,4x 3k,4x 3k,4q 3k,4j 3r,4j 3r,4q 3r,4x 3r,54 " +
		"3y,5i 3y,5p 45,5w 45,5p 45,5i 45,5b 45,54 45,4x 45,54 " +
		"45,5b 45,5i 45,5p 45,5w 45,5p 45,5i 3y,5i 3y,5b 3r,54 " +
		"3r,4x 3k,4x 3k,54 3k,5b 3d,5i 35,5p 35,63 35,6a 3d,6a " +
		"3d,6h 3k,6h 3r,6a 3y,5w 45,5p 45,5i 4c,54 4j,4x 4j,4q " +
		"4q,4q 4q,4j 4q,4q 4q,4x 4q,54 4x,5b 4x,5i 54,5i 54,5p " +
		"5b,5p 5b,5i 5b,5b 5b,54 5b,5b 5i,5i 5i,5p 5p,5p 5p,5i " +
		"5p,5b 5p,54 5p,4x 5i,4x 5i,54 5i,5b 5i,5i 5i,5p 5i,5i " +
		"5i,5b 5i,54 5i,4x 5i,54 5p,5b 5p,5i 5w,5i 5w,5p 64,5p " +
		"6b,5p 6i,5i 6i,5b 6i,54 6i,4x 6p,4x 6p,4q 6p,4j 6p,4c " +
		"6p,44 6i,4j 6i,4q 6i,4x 6i,5b 6i,5i 6i,5b 6i,54 6i,4x " +
		"6i,4q 6i,4c 6i,44 6i,3x 6i,44 6i,4c 6b,4c 6b,4q 6b,4x " +
		"6b,54 6b,5b 6b,54 6b,4x 6b,4q 64,4x 64,54 64,5b 64,54 " +
		"64,4x 64,4q 64,4j 64,4c 64,44 64,3x 6b,3q 6b,3j 6i,3j " +
		"6i,3c 6p,3c 6w,3c 73,3c 7a,3c 7h,3c 7o,3c 7v,3c 82,3c " +
		"89,3c 8g,3c 8n,3c 8n,3j 8u,3j 8u,3q 8u,3x 92,3x 92,44 " +
		"92,4c 92,4j 92,4q 92,4x 92,54 92,5b 8u,5b 8n,5i 8g,5p " +
		"5b,2y 5b,35 54,35 54,3c 4x,3c 4q,3c 4j,3c 4c,3c 45,3c " +
		"4c,3c 4j,3c 4q,3c 4x,3c 4x,3j 54,3j 5b,3j 5b,3q 5i,3q " +
		"5i,3x 5p,3x 5p,44 5p,4c 5p,4j 5p,4q 5p,4x 5i,4x 5b,4x " +
		"54,4x 4x,4q 4x,4j 4q,4j 4q,4c 4j,44 4j,3x 4c,3x 4c,3q " +
		"45,3q 3y,3q 3y,3x 3y,44 45,4c 4c,4c 4c,4j 4j,4j 4q,4j " +
		"4x,4j 4x,4c 4x,44 4q,44 4q,3x 4j,3x 4j,3q 4c,3q 4j,3q " +
		"4q,3x 4x,3x 54,44 5b,44 5b,4c 5b,4j 54,4j 4x,4j 4q,4j " +
		"4q,4c 4j,4c 4c,44 4c,4c 4c,4j 4c,4q 4c,4x 4j,5b 4j,5i " +
		"4q,5p 4q,5w 4q,5i 4j,5i 4j,54 4c,4x 45,4q 45,4j 3y,4j " +
		"3r,4q 3r,4x 3r,54 3k,4x 3k,4q 3d,4j 3d,4c 35,4c 2y,4j " +
		"2y,4q 2y,4x 2r,54 2r,5b 2r,5i 2r,5p 2r,5w 2k,5w 2k,5p " +
		"2k,5i 2d,5b 2d,54 2d,4x 26,4x 26,4q 1z,4q 1z,4x 1z,54 " +
		"1z,5b 1z,5i 1z,5b 1z,54 1z,4x 26,4q 26,4j 2d,4j 2k,4j " +
		"2r,4j 2y,4q 2y,4x 2y,54 2y,5b 2y,5i 2y,5p 35,5i 35,5b " +
		"35,54 3d,4x 3k,4x 3k,4q 3k,4j 3r,4j 3r,4q 3r,4x 3r,54 " +
		"3y,5i 3y,5p 45,5w 45,5p 45,5i 45,5b 45,54 45,4x 45,54 " +
		"45,5b 45,5i 45,5p 45,5w 45,5p 45,5i 3y,5i 3y,5b 3r,54 " +
		"3r,4x 3k,4x 3k,54 3k,5b 3d,5i 35,5p 35,63 35,6a 3d,6a " +
		"3d,6h 3k,6h 3r,6a 3y,5w 45,5p 45,5i 4c,54 4j,4x 4j,4q " +
		"4q,4q 4q,4j 4q,4q 4q,4x 4q,54 4x,5b 4x,5i 54,5i 54,5p " +
		"5b,5p 5b,5i 5b,5b 5b,54 5b,5b 5i,5i 5i,5p 5p,5p 5p,5i " +
		"5p,5b 5p,54 5p,4x 5i,4x 5i,54 5i,5b 5i,5i 5i,5p 5i,5i " +
		"5i,5b 5i,54 5i,4x 5i,54 5p,5b 5p,5i 5w,5i 5w,5p 64,5p " +
		"6b,5p 6i,5i 6i,5b 6i,54 6i,4x 6p,4x 6p,4q 6p,4j 6p,4c " +
		"6p,44 6i,4j 6i,4q 6i,4x 6i,5b 6i,5i 6i,5b 6i,54 6i,4x " +
		"6i,4q 6i,4c 6i,44 6i,3x 6i,44 6i,4c 6b,4c 6b,4q 6b,4x " +
		"6b,54 6b,5b 6b,54 6b,4x 6b,4q 64,4x 64,54 64,5b 64,54 " +
		"64,4x 64,4q 64,4j 64,4c 64,44 64,3x 6b,3q 6b,3j 6i,3j " +
		"6i,3c 6p,3c 6w,3c 73,3c 7a,3c 7h,3c 7o,3c 7v,3c 82,3c " +
		"89,3c 8g,3c 8n,3c 8n,3j 8u,3j 8u,3q 8u,3x 92,3x 92,44 " +
		"89,3c 8g,3c 8n,3c 8n,3j 8u,3j 8u,3q 8u,3x 92,3x 92,44 " +
		"92,4c 92,4j 92,4q 92,4x 92,54 92,5b 8u,5b 8n,5i 8g,5p " +
		"5b,2y 5b,35 54,35 54,3c 4x,3c 4q,3c 4j,3c 4c,3c 45,3c " +
		"4c,3c 4j,3c 4q,3c 4x,3c 4x,3j 54,3j 5b,3j 5b,3q 5i,3q " +
		"5i,3x 5p,3x 5p,44 5p,4c 5p,4j 5p,4q 5p,4x 5i,4x 5b,4x " +
		"54,4x 4x,4q 4x,4j 4q,4j 4q,4c 4j,44 4j,3x 4c,3x 4c,3q " +
		"45,3q 3y,3q 3y,3x 3y,44 45,4c 4c,4c 4c,4j 4j,4j 4q,4j " +
		"4x,4j 4x,4c 4x,44 4q,44 4q,3x 4j,3x 4j,3q 4c,3q 4j,3q " +
		"4q,3x 4x,3x 54,44 5b,44 5b,4c 5b,4j 54,4j 4x,4j 4q,4j " +
		"4q,4c 4j,4c 4c,44 4c,4c 4c,4j 4c,4q 4c,4x 4j,5b 4j,5i " +
		"4q,5p 4q,5w 4q,5i 4j,5i 4j,54 4c,4x 45,4q 45,4j 3y,4j " +
		"3r,4q 3r,4x 3r,54 3k,4x 3k,4q 3d,4j 3d,4c 35,4c 2y,4j " +
		"2y,4q 2y,4x 2r,54 2r,5b 2r,5i 2r,5p 2r,5w 2k,5w 2k,5p " +
		"2k,5i 2d,5b 2d,54 2d,4x 26,4x 26,4q 1z,4q 1z,4x 1z,54 " +
		"1z,5b 1z,5i 1z,5b 1z,54 1z,4x 26,4q 26,4j 2d,4j 2k,4j " +
		"2r,4j 2y,4q 2y,4x 2y,54 2y,5b 2y,5i 2y,5p 35,5i 35,5b " +
		"35,54 3d,4x 3k,4x 3k,4q 3k,4j 3r,4j 3r,4q 3r,4x 3r,54 " +
		"3y,5i 3y,5p 45,5w 45,5p 45,5i 45,5b 45,54 45,4x 45,54 " +
		"45,5b 45,5i 45,5p 45,5w 45,5p 45,5i 3y,5i 3y,5b 3r,54 " +
		"3r,4x 3k,4x 3k,54 3k,5b 3d,5i 35,5p 35,63 35,6a 3d,6a " +
		"3d,6h 3k,6h 3r,6a 3y,5w 45,5p 45,5i 4c,54 4j,4x 4j,4q " +
		"4q,4q 4q,4j 4q,4q 4q,4x 4q,54 4x,5b 4x,5i 54,5i 54,5p " +
		"5b,5p 5b,5i 5b,5b 5b,54 5b,5b 5i,5i 5i,5p 5p,5p 5p,5i " +
		"5p,5b 5p,54 5p,4x 5i,4x 5i,54 5i,5b 5i,5i 5i,5p 5i,5i " +
		"5i,5b 5i,54 5i,4x 5i,54 5p,5b 5p,5i 5w,5i 5w,5p 64,5p " +
		"6b,5p 6i,5i 6i,5b 6i,54 6i,4x 6p,4x 6p,4q 6p,4j 6p,4c " +
		"6p,44 6i,4j 6i,4q 6i,4x 6i,5b 6i,5i 6i,5b 6i,54 6i,4x " +
		"6i,4q 6i,4c 6i,44 6i,3x 6i,44 6i,4c 6b,4c 6b,4q 6b,4x " +
		"6b,54 6b,5b 6b,54 6b,4x 6b,4q 64,4x 64,54 64,5b 64,54 " +
		"64,4x 64,4q 64,4j 64,4c 64,44 64,3x 6b,3q 6b,3j 6i,3j " +
		"6i,3c 6p,3c 6w,3c 73,3c 7a,3c 7h,3c 7o,3c 7v,3c 82,3c " +
		"89,3c 8g,3c 8n,3c 8n,3j 8u,3j 8u,3q 8u,3x 92,3x 92,44 " +
		"92,4c 92,4j 92,4q 92,4x 92,54 92,5b 8u,5b 8n,5i 8g,5p " +
		"5b,2y 5b,35 54,35 54,3c 4x,3c 4q,3c 4j,3c 4c,3c 45,3c " +
		"4c,3c 4j,3c 4q,3c 4x,3c 4x,3j 54,3j 5b,3j 5b,3q 5i,3q " +
		"5i,3x 5p,3x 5p,44 5p,4c 5p,4j 5p,4q 5p,4x 5i,4x 5b,4x " +
		"54,4x 4x,4q 4x,4j 4q,4j 4q,4c 4j,44 4j,3x 4c,3x 4c,3q " +
		"45,3q 3y,3q 3y,3x 3y,44 45,4c 4c,4c 4c,4j 4j,4j 4q,4j " +
		"4x,4j 4x,4c 4x,44 4q,44 4q,3x 4j,3x 4j,3q 4c,3q 4j,3q " +
		"4q,3x 4x,3x 54,44 5b,44 5b,4c 5b,4j 54,4j 4x,4j 4q,4j " +
		"4q,4c 4j,4c 4c,44 4c,4c 4c,4j 4c,4q 4c,4x 4j,5b 4j,5i " +
		"4q,5p 4q,5w 4q,5i 4j,5i 4j,54 4c,4x 45,4q 45,4j 3y,4j " +
		"3r,4q 3r,4x 3r,54 3k,4x 3k,4q 3d,4j 3d,4c 35,4c 2y,4j " +
		"2y,4q 2y,4x 2r,54 2r,5b 2r,5i 2r,5p 2r,5w 2k,5w 2k,5p " +
		"2k,5i 2d,5b 2d,54 2d,4x 26,4x 26,4q 1z,4q 1z,4x 1z,54 " +
		"1z,5b 1z,5i 1z,5b 1z,54 1z,4x 26,4q 26,4j 2d,4j 2k,4j " +
		"2r,4j 2y,4q 2y,4x 2y,54 2y,5b 2y,5i 2y,5p 35,5i 35,5b " +
		"35,54 3d,4x 3k,4x 3k,4q 3k,4j 3r,4j 3r,4q 3r,4x 3r,54 " +
		"3y,5i 3y,5p 45,5w 45,5p 45,5i 45,5b 45,54 45,4x 45,54 " +
		"45,5b 45,5i 45,5p 45,5w 45,5p 45,5i 3y,5i 3y,5b 3r,54 " +
		"3r,4x 3k,4x 3k,54 3k,5b 3d,5i 35,5p 35,63 35,6a 3d,6a " +
		"3d,6h 3k,6h 3r,6a 3y,5w 45,5p 45,5i 4c,54 4j,4x 4j,4q " +
		"4q,4q 4q,4j 4q,4q 4q,4x 4q,54 4x,5b 4x,5i 54,5i 54,5p " +
		"5b,5p 5b,5i 5b,5b 5b,54 5b,5b 5i,5i 5i,5p 5p,5p 5p,5i " +
		"5p,5b 5p,54 5p,4x 5i,4x 5i,54 5i,5b 5i,5i 5i,5p 5i,5i " +
		"5i,5b 5i,54 5i,4x 5i,54 5p,5b 5p,5i 5w,5i 5w,5p 64,5p " +
		"6b,5p 6i,5i 6i,5b 6i,54 6i,4x 6p,4x 6p,4q 6p,4j 6p,4c " +
		"6p,44 6i,4j 6i,4q 6i,4x 6i,5b 6i,5i 6i,5b 6i,54 6i,4x " +
		"6i,4q 6i,4c 6i,44 6i,3x 6i,44 6i,4c 6b,4c 6b,4q 6b,4x " +
		"6b,54 6b,5b 6b,54 6b,4x 6b,4q 64,4x 64,54 64,5b 64,54 " +
		"64,4x 64,4q 64,4j 64,4c 64,44 64,3x 6b,3q 6b,3j 6i,3j " +
		"6i,3c 6p,3c 6w,3c 73,3c 7a,3c 7h,3c 7o,3c 7v,3c 82,3c " +
		"89,3c 8g,3c 8n,3c 8n,3j 8u,3j 8u,3q 8u,3x 92,3x 92,44 " +
		"4q,5p 4q,5w 4q,5i 4j,5i 4j,54 4c,4x 45,4q 45,4j 3y,4j " +
		"3r,4q 3r,4x 3r,54 3k,4x 3k,4q 3d,4j 3d,4c 35,4c 2y,4j " +
		"2y,4q 2y,4x 2r,54 2r,5b 2r,5i 2r,5p 2r,5w 2k,5w 2k,5p " +
		"2k,5i 2d,5b 2d,54 2d,4x 26,4x 26,4q 1z,4q 1z,4x 1z,54 " +
		"1z,5b 1z,5i 1z,5b 1z,54 1z,4x 26,4q 26,4j 2d,4j 2k,4j " +
		"2r,4j 2y,4q 2y,4x 2y,54 2y,5b 2y,5i 2y,5p 35,5i 35,5b " +
		"35,54 3d,4x 3k,4x 3k,4q 3k,4j 3r,4j 3r,4q 3r,4x 3r,54 " +
		"3y,5i 3y,5p 45,5w 45,5p 45,5i 45,5b 45,54 45,4x 45,54 " +
		"45,5b 45,5i 45,5p 45,5w 45,5p 45,5i 3y,5i 3y,5b 3r,54 " +
		"3r,4x 3k,4x 3k,54 3k,5b 3d,5i 35,5p 35,63 35,6a 3d,6a " +
		"3d,6h 3k,6h 3r,6a 3y,5w 45,5p 45,5i 4c,54 4j,4x 4j,4q " +
		"4q,4q 4q,4j 4q,4q 4q,4x 4q,54 4x,5b 4x,5i 54,5i 54,5p " +
		"5b,5p 5b,5i 5b,5b 5b,54 5b,5b 5i,5i 5i,5p 5p,5p 5p,5i " +
		"5p,5b 5p,54 5p,4x 5i,4x 5i,54 5i,5b 5i,5i 5i,5p 5i,5i " +
		"5i,5b 5i,54 5i,4x 5i,54 5p,5b 5p,5i 5w,5i 5w,5p 64,5p " +
		"6b,5p 6i,5i 6i,5b 6i,54 6i,4x 6p,4x 6p,4q 6p,4j 6p,4c " +
		"6p,44 6i,4j 6i,4q 6i,4x 6i,5b 6i,5i 6i,5b 6i,54 6i,4x " +
		"6i,4q 6i,4c 6i,44 6i,3x 6i,44 6i,4c 6b,4c 6b,4q 6b,4x " +
		"6b,54 6b,5b 6b,54 6b,4x 6b,4q 64,4x 64,54 64,5b 64,54 " +
		"64,4x 64,4q 64,4j 64,4c 64,44 64,3x 6b,3q 6b,3j 6i,3j " +
		"6i,3c 6p,3c 6w,3c 73,3c 7a,3c 7h,3c 7o,3c 7v,3c 82,3c " +
		"89,3c 8g,3c 8n,3c 8n,3j 8u,3j 8u,3q 8u,3x 92,3x 92,44 " +
		"4q,5p 4q,5w 4q,5i 4j,5i 4j,54 4c,4x 45,4q 45,4j 3y,4j " +
		"3r,4q 3r,4x 3r,54 3k,4x 3k,4q 3d,4j 3d,4c 35,4c 2y,4j " +
		"2y,4q 2y,4x 2r,54 2r,5b 2r,5i 2r,5p 2r,5w 2k,5w 2k,5p " +
		"2k,5i 2d,5b 2d,54 2d,4x 26,4x 26,4q 1z,4q 1z,4x 1z,54 " +
		"1z,5b 1z,5i 1z,5b 1z,54 1z,4x 26,4q 26,4j 2d,4j 2k,4j " +
		"2r,4j 2y,4q 2y,4x 2y,54 2y,5b 2y,5i 2y,5p 35,5i 35,5b " +
		"35,54 3d,4x 3k,4x 3k,4q 3k,4j 3r,4j 3r,4q 3r,4x 3r,54 " +
		"3y,5i 3y,5p 45,5w 45,5p 45,5i 45,5b 45,54 45,4x 45,54 " +
		"45,5b 45,5i 45,5p 45,5w 45,5p 45,5i 3y,5i 3y,5b 3r,54 " +
		"3r,4x 3k,4x 3k,54 3k,5b 3d,5i 35,5p 35,63 35,6a 3d,6a " +
		"3d,6h 3k,6h 3r,6a 3y,5w 45,5p 45,5i 4c,54 4j,4x 4j,4q " +
		"4q,4q 4q,4j 4q,4q 4q,4x 4q,54 4x,5b 4x,5i 54,5i 54,5p " +
		"5b,5p 5b,5i 5b,5b 5b,54 5b,5b 5i,5i 5i,5p 5p,5p 5p,5i " +
		"5p,5b 5p,54 5p,4x 5i,4x 5i,54 5i,5b 5i,5i 5i,5p 5i,5i " +
		"5i,5b 5i,54 5i,4x 5i,54 5p,5b 5p,5i 5w,5i 5w,5p 64,5p " +
		"6b,5p 6i,5i 6i,5b 6i,54 6i,4x 6p,4x 6p,4q 6p,4j 6p,4c " +
		"6p,44 6i,4j 6i,4q 6i,4x 6i,5b 6i,5i 6i,5b 6i,54 6i,4x " +
		"6i,4q 6i,4c 6i,44 6i,3x 6i,44 6i,4c 6b,4c 6b,4q 6b,4x " +
		"6b,54 6b,5b 6b,54 6b,4x 6b,4q 64,4x 64,54 64,5b 64,54 " +
		"64,4x 64,4q 64,4j 64,4c 64,44 64,3x 6b,3q 6b,3j 6i,3j " +
		"6i,3c 6p,3c 6w,3c 73,3c 7a,3c 7h,3c 7o,3c 7v,3c 82,3c " +
		"89,3c 8g,3c 8n,3c 8n,3j 8u,3j 8u,3q 8u,3x 92,3x 92,44 " +
		"92,4c 92,4j 92,4q 92,4x 92,54 92,5b 8u,5b 8n,5i 8g,5p ";



	static int Main ()
	{
		Regex regexCommand = new Regex (@"^/(\S+)[\s]*((?:[\S]+(?:[\s]*[\S]+)*)+)?[\s]*$");
		Match m = regexCommand.Match (_input);
		if (!m.Success)
			return 1;
		return 0;
	}
}