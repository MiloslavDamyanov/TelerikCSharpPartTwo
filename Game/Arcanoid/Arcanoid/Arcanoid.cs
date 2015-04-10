using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Arcanoid
{
    const int MaxHeight = 30;
    const int MaxWidth = 37;
    static void RemoveScrollBars()
    {
        Console.BufferHeight = Console.WindowHeight = MaxHeight;
        Console.BufferWidth = Console.WindowWidth = MaxWidth;
    }

    private static void DrawEnemy()
    {
        char[,] enemy = new char[,] { 
                                    { ' ','#', '#', '#', '#',' ', '$', '$', '$' }, {'$',' ', '#', '#', '#', '#',' ', '&', '&' }, 
                                    {'&', '&',' ', '#', '#', '#', '#',' ', '$'  }, {'$', '$', '$',' ', '#', '#', '#', '#',' ' }
                                    };
        for (int newRow = 0; newRow < 4; newRow++)
        {
            Console.WriteLine();
            if (newRow == 2)
            {
                Console.WriteLine();
            }
            for (int row = 0; row < enemy.GetLength(0); row++)
            {
                for (int col = 0; col < enemy.GetLength(1); col++)
                {
                    Console.Write("{0}", enemy[row, col]);
                }
            }
        }
        Console.WriteLine();
    }
    
    static void Main()
    {        
        RemoveScrollBars();
        DrawEnemy();             
    }
}

/*
		        Arcanoid	

1UP 		    HIGH SCORE
1890		       5000
 .......................................
|  #### $$$$ #### &&&& #### $$$$ ####	|		
|  #### $$$$ #### &&&& #### $$$$ ####	|
|					                    |
|  #### $$$$ #### &$&& #### $$$$ ####	|
|  #### $$$$ #### &&&& #### $$$$ ####	|
|  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@	|
|	    				                |
|	      *				                |
|					                    |
|					                    |
|					                    |
|					                    |		
|		 			                    |
|		         ^=^			        |
|^=^ ^=^				                |

*/