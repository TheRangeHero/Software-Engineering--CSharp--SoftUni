using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomComparator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> successfulLocationCount = new Dictionary<string, int>();


            Dictionary<string, int> locationTileArea = new Dictionary<string, int>()
            {
                { "Sink",40},
                { "Oven",50},
                { "Countertop",60},
                { "Wall",70}
            };



            int[] whiteTilesArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            int[] greyTilesArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();


            Queue<int> greyTiles = new Queue<int>(greyTilesArr);


            Stack<int> whiteTiles = new Stack<int>(whiteTilesArr);




            while (true)
            {

                if (!greyTiles.Any() || !whiteTiles.Any())
                {
                    break;
                }

                int targetedWhiteTile = whiteTiles.Peek();
                int targertedGreyTile = greyTiles.Peek();
                bool isFitting = false;

                if (targertedGreyTile == targetedWhiteTile)
                {
                    int totalArea = targertedGreyTile + targetedWhiteTile;
                    foreach (var item in locationTileArea)
                    {
                        if (item.Value == totalArea)
                        {
                            if (!successfulLocationCount.ContainsKey(item.Key))
                            {
                                successfulLocationCount.Add(item.Key, 1);
                            }
                            else
                            {
                                successfulLocationCount[item.Key]++;
                            }
                            isFitting = true;
                            break;
                        }
                    }

                    if (!isFitting)
                    {
                        if (!successfulLocationCount.ContainsKey("Floor"))
                        {
                            successfulLocationCount.Add("Floor", 1);
                        }
                        else
                        {
                            successfulLocationCount["Floor"]++;
                        }
                    }

                    if (whiteTiles.Any())
                    {
                        whiteTiles.Pop();
                    }
                    if (greyTiles.Any())
                    {
                        greyTiles.Dequeue();
                    }

                }
                else
                {
                    if (whiteTiles.Any())
                    {
                        whiteTiles.Push(whiteTiles.Pop() / 2);
                    }
                    if (greyTiles.Any())
                    {
                        greyTiles.Enqueue(greyTiles.Dequeue());
                    }
                }
            }


            //firstline
            if (!whiteTiles.Any())
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
            }

            //secondLine
            if (!greyTiles.Any())
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
            }

            var printTiles = successfulLocationCount.Where(x => x.Value > 0);

            foreach (var item in printTiles.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

        }
    }
}


