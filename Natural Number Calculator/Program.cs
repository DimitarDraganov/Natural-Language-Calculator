﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Natural_Number_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            StartCalculator();


        }

        private static void StartCalculator()
        {
            while (true)
            {
                List<string> firstOrderlist = new List<string>();
                firstOrderlist.Add("divide");
                firstOrderlist.Add("multiply");

                List<string> secondOrderlist = new List<string>();
                secondOrderlist.Add("plus");
                secondOrderlist.Add("minus");


                double finalResult;

                string firstNumStr;
                string secondNumStr;

                double firstNumDb;
                double secondNumDb;


                Console.WriteLine("Enter calculation:");
                string toCalculate = Console.ReadLine();


                if (toCalculate.Equals("quit"))
                {
                    break;
                }



                List<string> list = switchNumbers(toCalculate, firstOrderlist, secondOrderlist);

                int i = 0;
                while (i < list.Count)
                {
                    if (firstOrderlist.Contains(list[i]))
                    {
                        firstNumStr = list[i - 1];
                        secondNumStr = list[i + 1];

                        firstNumDb = Convert.ToDouble(firstNumStr);
                        secondNumDb = Convert.ToDouble(secondNumStr);


                        if (list[i] == "divide")
                        {
                            finalResult = (double)firstNumDb / (double)secondNumDb;

                            list[i] = finalResult.ToString();
                            list.RemoveAt(i - 1);
                            list.RemoveAt(i);

                            i = 0;
                        }
                        else
                        {
                            finalResult = (double)firstNumDb * (double)secondNumDb;

                            list[i] = finalResult.ToString();
                            list.RemoveAt(i - 1);
                            list.RemoveAt(i);

                            i = 0;
                        }

                    }
                    i++;

                }


                i = 0;
                while (i < list.Count)
                {
                    if (secondOrderlist.Contains(list[i]))
                    {
                        firstNumStr = list[i - 1];
                        secondNumStr = list[i + 1];

                        firstNumDb = Convert.ToDouble(firstNumStr);
                        secondNumDb = Convert.ToDouble(secondNumStr);

                        if (list[i] == "minus")
                        {
                            finalResult = (double)firstNumDb - (double)secondNumDb;

                            list[i] = finalResult.ToString();
                            list.RemoveAt(i - 1);
                            list.RemoveAt(i);

                            i = 0;
                        }
                        else
                        {
                            finalResult = (double)firstNumDb + (double)secondNumDb;

                            list[i] = finalResult.ToString();
                            list.RemoveAt(i - 1);
                            list.RemoveAt(i);

                            i = 0;
                        }
                    }
                    i++;
                }

                Console.WriteLine(list[0]);
            }
            Console.WriteLine("Is over");
            Console.ReadLine();
        }

        private static List<string> switchNumbers(string toCalculate, List<string> firstOrderlist, List<string> secondOrderlist)
        {
            Dictionary<string, int> numberChange = new Dictionary<string, int>();
            numberChange.Add("zero", 0);
            numberChange.Add("one", 1);
            numberChange.Add("two", 2);
            numberChange.Add("three", 3);
            numberChange.Add("four", 4);
            numberChange.Add("five", 5);
            numberChange.Add("six", 6);
            numberChange.Add("seven", 7);
            numberChange.Add("eight", 8);
            numberChange.Add("nine", 9);

            string[] words = toCalculate.Split(' ');

            for (int u = 0; u < words.Length; u++)
            {
                if (!firstOrderlist.Contains(words[u]) && !secondOrderlist.Contains(words[u]))
                {
                    words[u] = numberChange[words[u]].ToString();
                }
            }

            List<string> list = new List<string>(words);
            return list;
        }
    }
}
