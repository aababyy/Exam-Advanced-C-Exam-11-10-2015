using System;
using System.Collections.Generic;
using System.Linq;

class AM
{
    static void Main()
    {
        List<int> data = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        string line = Console.ReadLine();
        while (line != "end")
        {
            string[] l = line.Split(' ');
            string com = l[0];

            if (com == "exchange")
            {
                long index = long.Parse(l[1]);
                if ((index < 0) || (index > data.Count - 1))
                {
                    Console.WriteLine("Invalid index");
                }
                else
                {
                    int i = (int)index;
                    int[] s = data.GetRange(i + 1, data.Count - (i + 1)).ToArray();
                    data.RemoveRange(i + 1, data.Count - (i + 1));
                    data.InsertRange(0, s);
                }
            }

            else if (com == "max")
            {
                if (l[1] == "even")
                {
                    var even = from d in data
                               where d % 2 == 0
                               select d;
                    if (even.Count() == 0)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        int ind = data.LastIndexOf(even.Max());
                        Console.WriteLine(ind);
                    }
                }
                else //if (l[1] == "odd")
                {
                    var odd = from d in data
                              where d % 2 != 0
                              select d;
                    if (odd.Count() == 0)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        int ind = data.LastIndexOf(odd.Max());
                        Console.WriteLine(ind);
                    }
                }
            }

            else if (com == "min")
            {
                if (l[1] == "even")
                {
                    var even = from d in data
                               where d % 2 == 0
                               select d;
                    if (even.Count() == 0)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        int ind = data.LastIndexOf(even.Min());
                        Console.WriteLine(ind);
                    }
                }
                else //if (l[1] == "odd")
                {
                    var odd = from d in data
                              where d % 2 != 0
                              select d;
                    if (odd.Count() == 0)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        int ind = data.LastIndexOf(odd.Min());
                        Console.WriteLine(ind);
                    }
                }
            }

            else if (com == "first")
            {
                long count = long.Parse(l[1]);
                if ((count < 0) || (count > data.Count))
                {
                    Console.WriteLine("Invalid count");
                }
                else
                {
                    int c = (int)count;

                    if (l[2] == "even")
                    {
                        var even = from d in data
                                   where d % 2 == 0
                                   select d;
                        if (even.Count() == 0)
                        {
                            Console.WriteLine("[]");
                        }
                        else if (even.Count() < c)
                        {
                            Console.WriteLine("[" + String.Join(", ", even) + "]");
                        }
                        else
                        {
                            List<int> s = even.ToList();
                            int[] ss = s.GetRange(0, c).ToArray();
                            Console.WriteLine("[" + String.Join(", ", ss) + "]");
                        }
                    }
                    else //if (l[2] == "odd")
                    {
                        var odd = from d in data
                                  where d % 2 != 0
                                  select d;
                        if (odd.Count() == 0)
                        {
                            Console.WriteLine("[]");
                        }
                        else if (odd.Count() < c)
                        {
                            Console.WriteLine("[" + String.Join(", ", odd) + "]");
                        }
                        else
                        {
                            List<int> s = odd.ToList();
                            int[] ss = s.GetRange(0, c).ToArray();
                            Console.WriteLine("[" + String.Join(", ", ss) + "]");
                        }
                    }
                }
            }

            else //if (com == "last")
            {
                long count = long.Parse(l[1]);
                if ((count < 0) || (count > data.Count))
                {
                    Console.WriteLine("Invalid count");
                }
                else
                {
                    int c = (int)count;

                    if (l[2] == "even")
                    {
                        var even = from d in data
                                   where d % 2 == 0
                                   select d;
                        if (even.Count() == 0)
                        {
                            Console.WriteLine("[]");
                        }
                        else if (even.Count() < c)
                        {
                            Console.WriteLine("[" + String.Join(", ", even) + "]");
                        }
                        else
                        {
                            List<int> s = even.ToList();
                            int[] ss = s.GetRange(even.Count() - c, c).ToArray();
                            Console.WriteLine("[" + String.Join(", ", ss) + "]");
                        }
                    }
                    else //if (l[2] == "odd")
                    {
                        var odd = from d in data
                                  where d % 2 != 0
                                  select d;
                        if (odd.Count() == 0)
                        {
                            Console.WriteLine("[]");
                        }
                        else if (odd.Count() < c)
                        {
                            Console.WriteLine("[" + String.Join(", ", odd) + "]");
                        }
                        else
                        {
                            List<int> s = odd.ToList();
                            int[] ss = s.GetRange(odd.Count() - c, c).ToArray();
                            Console.WriteLine("[" + String.Join(", ", ss) + "]");
                        }
                    }
                }
            }
            line = Console.ReadLine();
        }
        Console.WriteLine("[" + String.Join(", ", data) + "]");
    }
}
