
using System;
using System.Text.RegularExpressions;

public class Avivity37
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Ingrese UBICACION de los caballos:");
        string? cabInput = Console.ReadLine();

    
        string cab = Regex.Replace(cabInput ?? string.Empty, "[^A-H1-8a-h]", "")
                          .ToUpperInvariant();

        int[,] tab = new int[8, 8];   
        int[,] pos = new int[64, 2];  

       
        int x = cab.Length;
        int i = 0;
        int tope = 0;

        while (i < x)
        {
            char col = cab[i++];
            if (i >= x) break; 
            char fil = cab[i++];

            int r = ef(fil);
            int c = ec(col);

            if (r >= 0 && c >= 0)
            {
                tab[r, c] = 1;
                pos[tope, 0] = r;
                pos[tope, 1] = c;
                tope++;
            }
        }

        //show(tab);

        for (i = 0; i < tope; i++)
        {
            Console.Write($"Analizando Caballo en {eFInv(pos[i, 0])}{ecInv(pos[i, 1])} => ");

            int fil, col;

            // UL
            fil = pos[i, 0] - 2; col = pos[i, 1] - 1;
            if (inBoard(fil, col) && tab[fil, col] == 1)
                Console.Write($"Conflicto con {eFInv(fil)}{ecInv(col)}\t");

            // UR
            fil = pos[i, 0] - 2; col = pos[i, 1] + 1;
            if (inBoard(fil, col) && tab[fil, col] == 1)
                Console.Write($"Conflicto con {eFInv(fil)}{ecInv(col)}\t");

            // LU
            fil = pos[i, 0] - 1; col = pos[i, 1] - 2;
            if (inBoard(fil, col) && tab[fil, col] == 1)
                Console.Write($"Conflicto con {eFInv(fil)}{ecInv(col)}\t");

            // LD
            fil = pos[i, 0] + 1; col = pos[i, 1] - 2;
            if (inBoard(fil, col) && tab[fil, col] == 1)
                Console.Write($"Conflicto con {eFInv(fil)}{ecInv(col)}\t");

            // RU
            fil = pos[i, 0] - 1; col = pos[i, 1] + 2;
            if (inBoard(fil, col) && tab[fil, col] == 1)
                Console.Write($"Conflicto con {eFInv(fil)}{ecInv(col)}\t");

            // RD
            fil = pos[i, 0] + 1; col = pos[i, 1] + 2;
            if (inBoard(fil, col) && tab[fil, col] == 1)
                Console.Write($"Conflicto con {eFInv(fil)}{ecInv(col)}\t");

            // DL
            fil = pos[i, 0] + 2; col = pos[i, 1] - 1;
            if (inBoard(fil, col) && tab[fil, col] == 1)
                Console.Write($"Conflicto con {eFInv(fil)}{ecInv(col)}\t");

            // DR
            fil = pos[i, 0] + 2; col = pos[i, 1] + 1;
            if (inBoard(fil, col) && tab[fil, col] == 1)
                Console.Write($"Conflicto con {eFInv(fil)}{ecInv(col)}\t");

            Console.WriteLine();
        }
    }

    public static void show(int[,] tab)
    {
        Console.WriteLine("  0 1 2 3 4 5 6 7");
        for (int i = 0; i < 8; i++)
        {
            Console.Write(i + " ");
            for (int j = 0; j < 8; j++)
            {
                Console.Write(tab[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static bool inBoard(int f, int c) => f >= 0 && f <= 7 && c >= 0 && c <= 7;

    public static int ef(char f) => f switch
    {
        '8' => 0,
        '7' => 1,
        '6' => 2,
        '5' => 3,
        '4' => 4,
        '3' => 5,
        '2' => 6,
        '1' => 7,
        _ => -1
    };

    public static char eFInv(int f) => f switch
    {
        0 => '8',
        1 => '7',
        2 => '6',
        3 => '5',
        4 => '4',
        5 => '3',
        6 => '2',
        _ => '1'
    };

    public static int ec(char f) => f switch
    {
        'A' => 0,
        'B' => 1,
        'C' => 2,
        'D' => 3,
        'E' => 4,
        'F' => 5,
        'G' => 6,
        'H' => 7,
        _ => -1
    };

    public static char ecInv(int f) => f switch
    {
        0 => 'A',
        1 => 'B',
        2 => 'C',
        3 => 'D',
        4 => 'E',
        5 => 'F',
        6 => 'G',
        _ => 'H'
    };
}
