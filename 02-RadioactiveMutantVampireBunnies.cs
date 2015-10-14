using System;
using System.Linq;

class RadioactiveMutantVampireBunnies
{
    static int[] p = new int[2];
    static string result = string.Empty;

    static void Main()
    {
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        char[,] lair = FillTheLair(numbers);
        string com = Console.ReadLine();

        for (int ii = 0; ii < com.Length; ii++)
        {
            lair = SpreadBunnies(MovePlayer(lair, com[ii]));
            if (result != string.Empty)
            {
                break;
            }
        }

        for (int i = 0; i < lair.GetLength(0); i++)
        {
            for (int j = 0; j < lair.GetLength(1); j++ )
            {
                Console.Write((char)lair[i, j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine(result + ": " + p[0] + " " + p[1]);
    }

    static char[,] FillTheLair(int[] n)
    {
        char[,] l = new char[n[0], n[1]];
        for (int i = 0; i < n[0]; i++)
        {
            string line = Console.ReadLine();
            for (int j = 0; j < n[1]; j++)
            {
                l[i, j] = line[j];
                if (line[j] == 'P')
                {
                    p[0] = i;
                    p[1] = j;
                }
            }
        }
        return l;
    }

    static char[,] MovePlayer(char[,] l, char c)
    {
        switch(c)
        {
            case ('R'):
                {
                    l[p[0], p[1]] = '.';
                    if ((p[1] + 1) > (l.GetLength(1) - 1))
                    {
                        result = "won";
                    }
                    else if (l[p[0], p[1] + 1] == 'B')
                    {
                        result = "dead";
                        p[1] = p[1] + 1;
                    }
                    else
                    {
                        p[1] = p[1] + 1;
                        l[p[0], p[1]] = 'P';
                    }
                    break;
                }
            case ('L'):
                {
                    l[p[0], p[1]] = '.';
                    if ((p[1] - 1) < 0)
                    {
                        result = "won";
                    }
                    else if (l[p[0], p[1] - 1] == 'B')
                    {
                        result = "dead";
                        p[1] = p[1] - 1;
                    }
                    else
                    {
                        p[1] = p[1] - 1;
                        l[p[0], p[1]] = 'P';
                    }
                    break;
                }
            case ('U'):
                {
                    l[p[0], p[1]] = '.';
                    if ((p[0] - 1) < 0)
                    {
                        result = "won";
                    }
                    else if (l[p[0] - 1, p[1]] == 'B')
                    {
                        result = "dead";
                        p[0] = p[0] - 1;
                    }
                    else
                    {
                        p[0] = p[0] - 1;
                        l[p[0], p[1]] = 'P';
                    }
                    break;
                }
            case ('D'):
                {
                    l[p[0], p[1]] = '.';
                    if ((p[0] + 1) > (l.GetLength(0) - 1))
                    {
                        result = "won";
                    }
                    else if (l[p[0] + 1, p[1]] == 'B')
                    {
                        result = "dead";
                        p[0] = p[0] + 1;
                    }
                    else
                    {
                        p[0] = p[0] + 1;
                        l[p[0], p[1]] = 'P';
                    }
                    break;
                }
            default: break;
        }
        return l;
    }

    static char[,] SpreadBunnies (char[,] l)
    {
        char[,] lTemp = new char[l.GetLength(0),l.GetLength(1)];

        for (int i = 0; i < l.GetLength(0); i++)
        {
            for (int j = 0; j < l.GetLength(1); j++)
            {
                lTemp[i, j] = l[i, j];
            }
        }

        for (int i = 0; i < l.GetLength(0); i++)
        {
            for (int j = 0; j < l.GetLength(1); j++)
            {
                if (l[i, j] == 'B')
                {
                    if ((i - 1) >= 0)
                    {
                        if (l[(i - 1), j] == 'P')
                        {
                            result = "dead";
                            p[0] = i - 1;
                            p[1] = j;
                        }
                        lTemp[(i - 1), j] = 'B';
                    }
                    if ((i + 1) < l.GetLength(0))
                    {
                        if (l[(i + 1), j] == 'P')
                        {
                            result = "dead";
                            p[0] = i + 1;
                            p[1] = j;
                        }
                        lTemp[(i + 1), j] = 'B';
                    }
                    if ((j - 1) >= 0)
                    {
                        if (l[i, (j - 1)] == 'P')
                        {
                            result = "dead";
                            p[0] = i;
                            p[1] = j - 1;
                        }
                        lTemp[i, (j - 1)] = 'B';
                    }
                    if ((j + 1) < l.GetLength(1))
                    {
                        if (l[i, (j + 1)] == 'P')
                        {
                            result = "dead";
                            p[0] = i;
                            p[1] = j + 1;
                        }
                        lTemp[i, (j + 1)] = 'B';
                    }
                }
            }
        }
        for (int i = 0; i < l.GetLength(0); i++)
        {
            for (int j = 0; j < l.GetLength(1); j++)
            {
                l[i, j] = lTemp[i, j];
            }
        }
        return l;
    }
}
