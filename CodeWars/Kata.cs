using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWars
{

    class Kata
    {

        public static int[] Snail(int[][] array)
        {
            int[] result = new int[array.Length * array.Length];
            int arrInd = 0;

            array[0].CopyTo(result, arrInd);
            arrInd = array.Length;

            int[] tempArray = new int[array.Length];
            array[^1].CopyTo(tempArray, 0);
            Array.Reverse(tempArray);


            if (array.Length > 1)
            {
                for (int i = 1; i < array.Length - 1; i++)
                {
                    Console.WriteLine($"-- In Loop -- {array[^1][i]} ");
                    result[arrInd] = array[i][array.Length - 1];
                    arrInd++;
                }
            }

            tempArray.CopyTo(result, arrInd);
            arrInd += tempArray.Length;
            Console.WriteLine($"Array index is: {arrInd}");

            if (array.Length > 1)
            {
                for (int i = array.Length - 2; i > 0 ; i--)
                {
                    Console.WriteLine($"-- In Loop -- {array[^1][i]} ");
                    result[arrInd] = array[i][0];
                    arrInd++;
                }
            }

            // TU TRZEBA ZAIMPLEMENTOWAĆ REKURENCJĘ I WRZUCANIE MAŁEJ TABLICY 
            int[][] passArray = new int[array.Length - 2][];
            try
            {

                for (int item = 0; item < passArray.Length; item++)
                {
                    Array.Copy(array[item + 1], 1, passArray[item], 0, passArray.Length);
                }
                Console.WriteLine("Gora Try'a");
                Array.Copy(Snail(passArray), result, passArray.Length * passArray.Length);


            } catch
            {
                if (array.Length % 2 == 1)
                {
                    result[arrInd] = array[1][1];
                    Console.WriteLine("a moze bylem nizej");
                }
                
            }

            foreach (var item in result)
            {
                Console.Write($"{item.ToString()} | ");
            }
            return result;
        }




        public static string StringFunc(string s, long x)
        {

            // This is working and returning good values, but! input data is to big to process this way. Need to optimize.


            StringBuilder result = new StringBuilder();
            string text = s;
            long step = 0;
            Console.WriteLine($"Step: {step} \t= {text}");
            List<string> possibilities = new List<string>();

            while (step < x)
            {
                char[] ordered = text.ToCharArray();
                char[] reversed = text.ToCharArray();
                Array.Reverse(reversed);

                    for (int i = 0; i < s.Length / 2; i++)
                    {
                        result.Append(reversed[i]);
                        result.Append(ordered[i]);
                    }

                    if (text.Length % 2 == 1) result.Append(reversed[text.Length / 2]);
                    
                step++;
                text = result.ToString();
                possibilities.Add(text);
                Console.WriteLine($"Step: {step} \t= {text}");

                if (step < x)
                {
                    result.Clear();
                }
                if (s == text && x != 0 )
                {
                    text = possibilities[(int)(x % step)];
                    break;
                }
            }
            return text;
        }
        public static int[] nbMonths(int startPriceOld, int startPriceNew, int savingPerMonth, double percentLossByMonth)
        {
            return null;
        }

        #region PassedKata
        public static int RectangleRotation(int y, int x)
        {
            double more = Math.Ceiling(y / Math.Sqrt(2)) * Math.Ceiling(x / Math.Sqrt(2)) + Math.Floor(y / Math.Sqrt(2)) * Math.Floor(x / Math.Sqrt(2));
            double less = Math.Ceiling(y / Math.Sqrt(2)) * Math.Floor(x / Math.Sqrt(2)) + Math.Floor(y / Math.Sqrt(2)) * Math.Ceiling(x / Math.Sqrt(2));

            double factorX = (x / 2) / Math.Sqrt(2);
            double factorY = (y / 2) / Math.Sqrt(2);

            Console.WriteLine($"x = {factorX}, y = {factorY}");

            if (factorX - Math.Floor(factorX) < 0.5)
            {
                if (factorY - Math.Floor(factorY) < 0.5)
                {
                    Console.WriteLine("Option 1");
                    return (int)more;
                }
                else
                {
                    Console.WriteLine("Option 2");
                    return (int)less;
                }

            }
            else
            {
                if (factorY - Math.Floor(factorY) > 0.5)
                {
                    Console.WriteLine("Option 3");
                    return (int)more;
                }
                else
                {
                    Console.WriteLine("Option 4");
                    return (int)less;
                }
            }
        }
        public static String funReverse(String s)
        {
            StringBuilder result = new StringBuilder();
            char[] ordered = s.ToCharArray();       // 012345
            char[] reversed = s.ToCharArray();      // 543210
            Array.Reverse(reversed);

            for (int i = 0; i < s.Length / 2; i++)
            {
                result.Append(reversed[i]);
                result.Append(ordered[i]);
            }

            if (s.Length % 2 == 1) result.Append(reversed[s.Length / 2]);

            return result.ToString();
        }
        public static int GrowingPlant(int UpSpeed, int DownSpeed, int DesiredHeight)
        {
            int result = 0;
            while (true)
            {
                result++;
                DesiredHeight -= UpSpeed;
                if (DesiredHeight <= 0) return result;
                DesiredHeight += DownSpeed;
            }
        }
        public static string StripComments(string text, string[] commentSymbols)
        {
            List<string> linesOfText = new List<string>();
            StringBuilder result = new StringBuilder();
            linesOfText.AddRange(text.Split("\n", StringSplitOptions.None));

            for (int item = 0; item < linesOfText.Count; item++)
            {
                foreach (var splitter in commentSymbols)
                {
                    try
                    {
                        linesOfText[item] = linesOfText[item].Remove(linesOfText[item].IndexOf(splitter)).TrimEnd();
                    }
                    catch
                    {
                        linesOfText[item] = linesOfText[item].TrimEnd();
                    }
                }
                if (item == linesOfText.Count - 1)
                {
                    result.Append(linesOfText[item]);
                }
                else
                {
                    result.AppendLine(linesOfText[item]);
                }
            }
            return result.ToString();
        }
        public static int Solve(string s)
        {
            StringBuilder text = new StringBuilder();
            List<char> vowels = new List<char> { 'a', 'e', 'i', 'o', 'u' };
            List<int> results = new List<int>();
            int index = 0;

            foreach (char item in s)
                if (char.IsLetter(item) && !vowels.Contains(item)) text.Append(item); else text.Append('-');

            foreach (string element in text.ToString().Split('-', StringSplitOptions.RemoveEmptyEntries))
            {
                results.Add(0);
                foreach (char item in element) results[index] += (char.ToUpper(item) - 64);
                index++;
            }
            results.Sort();
            try { return results[index - 1]; } catch { return 0; }
        }
        public static string[] dirReduc(String[] arr)
        {
            List<string> directions = new List<string>(arr);
            Dictionary<string, string> dirs = new Dictionary<string, string> { { "SOUTH", "NORTH" }, { "NORTH", "SOUTH" }, { "EAST", "WEST" }, { "WEST", "EAST" } };
            bool flag = true;

            while (flag)
            {
                for (int i = 0; i < directions.Count - 1; i++)
                {
                    try { if (dirs[directions[i]] == directions[i + 1]) { directions[i] = "-"; directions[i + 1] = "-"; } } catch { }
                }
                flag = directions.Contains("-");
                directions.RemoveAll(x => x == "-");
            }
            return directions.ToArray();
        }
        public static bool Hero(int bullets, int dragons) => bullets >= dragons * 2 ? true : false;
        public static string reverseAndCombineText(string text)
        {
            List<string> sentence = new List<string>();
            StringBuilder result = new StringBuilder(text);

            while (result.ToString().TrimEnd().Contains(" "))
            {
                sentence.Clear();
                sentence.AddRange(result.ToString().Split(' ', StringSplitOptions.RemoveEmptyEntries));
                result.Clear();
                Console.ReadLine();
                for (int i = 0; i < sentence.Count; i++)
                {
                    char[] temp = sentence[i].ToCharArray();
                    Array.Reverse(temp);
                    sentence[i] = new string(temp);
                    Console.WriteLine(sentence[i]);
                    if (i % 2 == 1) result.Append(sentence[i] + " "); else result.Append(sentence[i]);
                }
            }
            return result.ToString().TrimEnd();
        }
        public static bool Divide(int weight) => weight == 2 ? false : (weight % 2) % 2 == 0;
        public static int[] DeleteNth(int[] arr, int x)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            List<int> result = new List<int>();
            foreach (var item in arr)
            {
                try { dict[item]++; } catch { dict[item] = 0; }
                if (dict[item] <= x) result.Add(item);
            }
            return result.ToArray();
        }
        public static Dictionary<string, int> Interpret(string[] program)
        {
            Dictionary<string, int> memory = new Dictionary<string, int>();
            List<string[]> instructions = new List<string[]>();
            int step = 0;

            foreach (var item in program) instructions.Add(item.Split(' ', StringSplitOptions.RemoveEmptyEntries));

            while (step < instructions.Count)
            {
                switch (instructions[step][0])
                {
                    case "mov":
                        if (int.TryParse(instructions[step][2], out int temp))
                        {
                            memory[instructions[step][1]] = temp;
                        }
                        else { memory[instructions[step][1]] = memory[instructions[step][2]]; }

                        step++;
                        break;
                    case "inc":
                        memory[instructions[step][1]]++;
                        step++;
                        break;
                    case "dec":
                        memory[instructions[step][1]]--;
                        step++;
                        break;
                    case "jnz":
                        if (int.TryParse(instructions[step][1], out int temp2))
                        {
                            step += int.Parse(instructions[step][2]);
                            break;
                        }
                        if (memory[instructions[step][1]] != 0)
                        {
                            step += int.Parse(instructions[step][2]);
                            break;
                        }
                        step++;
                        break;
                    default:
                        step++;
                        break;
                }
            }
            return memory;
        }
        public static int BreakChocolate(int n, int m) => m * n != 0 ? ((m * n) - 1) : 0;
        public static int find_it(int[] seq)
        {
            List<int> sequence = new List<int>(seq);
            sequence.Sort();

            foreach (var item in sequence) if ((sequence.LastIndexOf(item) - sequence.IndexOf(item)) % 2 == 0) return item;

            return -1;
        }
        public static int JosSurvivor(int n, int k)
        {
            if (n == 1) return 1;
            else return (JosSurvivor(n - 1, k) + k - 1) % (n - 1);
        }
        public static string Decode(string morseCode)
        {
            StringBuilder value = new StringBuilder();
            morseCode = morseCode.Replace("   ", " + ");

            #region MorseDictionary
            // Originally provided by KATA

            Dictionary<string, string> MorseCode = new Dictionary<string, string>
            {
                // Letters
                { ".-", "A" },
                { "-...", "B" },
                { "-.-.", "C" },
                { "-..", "D" },
                { ".", "E" },
                { "..-.", "F" },
                { "--.", "G" },
                { "....", "H" },
                { "..", "I" },
                { ".---", "J" },
                { "-.-", "K" },
                { ".-..", "L" },
                { "--", "M" },
                { "-.", "N" },
                { "---", "O" },
                { ".--.", "P" },
                { "--.-", "Q" },
                { ".-.", "R" },
                { "...", "S" },
                { "-", "T" },
                { "..-", "U" },
                { "...-", "V" },
                { ".--", "W" },
                { "-..-", "X" },
                { "-.--", "Y" },
                { "--..", "Z" },
                // Numbers
                { "-----", "0" },
                { ".----", "1" },
                { "..---", "2" },
                { "...--", "3" },
                { "....-", "4" },
                { ".....", "5" },
                { "-....", "6" },
                { "--...", "7" },
                { "---..", "8" },
                { "----.", "9" },
                // Punctuation

                // Space
                { "+", " " }
            };

            #endregion

            foreach (string item in morseCode.Split(' ', StringSplitOptions.None))
            {
                if (item != "+")
                {
                    value.Append(MorseCode[item]);
                }
                else { value.Append(" "); }
            }
            return value.ToString().Trim();
        }
        public static double Index(int[] array, int n)
        {
            if (array.Length > n)
            {
                return Math.Pow(array[n], n);
            }
            return -1;
        }
        public static int[] MenFromBoys(int[] a)
        {
            List<int> people = new List<int>();
            List<int> temp = new List<int>();
            HashSet<int> men = new HashSet<int>();
            foreach (var item in a)
            {
                if (item % 2 == 0)
                {
                    people.Add(item);
                }
                else
                {
                    temp.Add(item);
                }
            }
            int[] peopleSorted = people.ToArray();
            Array.Sort(peopleSorted);
            int[] tempReversed = temp.ToArray();
            Array.Sort(tempReversed);
            Array.Reverse(tempReversed);
            people.Clear();
            foreach (var item in peopleSorted)
            {
                men.Add(item);
            }
            foreach (var item in tempReversed)
            {
                men.Add(item);
            }
            List<int> result = new List<int>();
            result.AddRange(men);

            return result.ToArray();
        }
        public static int Past(int h, int m, int s) => (s + m * 60 + h * 3600) * 1000;
        public string Pattern(int n)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    sb.Append(i.ToString());
                }
                sb.AppendLine();
            }
            return sb.ToString().TrimEnd();
        }
        public static int SumOfMinimums(int[,] numbers)
        {
            int result = 0;
            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                int[] temp = new int[numbers.GetLength(1)];
                for (int n = 0; n < temp.Length; n++)
                {
                    temp[n] = numbers[i, n];
                }
                Array.Sort(temp);
                result += temp[0];
            }
            return result;
        }
        public static bool ZeroFuel(uint distanceToPump, uint mpg, uint fuelLeft) => (distanceToPump <= mpg * fuelLeft);
        public static int[] TwoOldestAges(int[] ages)
        {
            List<int> sorting = new List<int>(ages);
            sorting.Sort();
            return new int[] { sorting[^1], sorting[^2] };
        }
        public static string HackMyTerminal(int passLength, string machineCode)
        {
            List<char[]> candidates = new List<char[]>();
            List<int> points = new List<int>();

            foreach (char item in machineCode)
                { if (!char.IsLetterOrDigit(item)) { machineCode = machineCode.Replace(item, '-'); } }
            
            foreach (string item in machineCode.Split('-', StringSplitOptions.RemoveEmptyEntries))
                { if (item.Length == passLength) { candidates.Add(item.ToCharArray()); points.Add(0); } }

            foreach (var elem in candidates) Console.WriteLine(new string(elem));

            for (int k = 0; k < candidates.Count; k++)
            {
                for (int j = 0; j < candidates.Count; j++)
                {
                    if (j != k)
                    {
                        char[] tem1 = candidates[j];
                        char[] tem2 = candidates[k];

                        for (int i = 0; i < passLength; i++)
                        {
                            if (tem1[i] == tem2[i])
                            {
                                points[k]++;
                            }
                        }
                    }
                }
            }
            foreach (var item in points) Console.WriteLine(item.ToString());
            if (candidates.Count > 0)
            {

            string result = new string(candidates[points.FindIndex(x => x == 0)]);
            return result;
            }
            return null;
        }
        public static int[] NoOdds(int[] values)
        {
            List<int> result = new List<int>();
            foreach (int element in values) { if (element % 2 == 0) { result.Add(element); } }
            return result.ToArray();
        }
        public static int DuplicateCount(string str)
        {
            int result = 0;
            str = str.ToLower();
            foreach (char element in str)
            {
                if (char.IsLetterOrDigit(element) && str.IndexOf(element) != str.LastIndexOf(element)) { result += 1; }
                str = str.Replace(element, '-');
                Console.WriteLine(str);
            }
            return result;
        }
        public static int ThirstyIn(int water, int[] ageOfDweller)
        {
            double result = 0;
            if (ageOfDweller.Length == 0) result = -1;
            else
            {
                foreach (int dwellerAge in ageOfDweller)
                {
                    if (dwellerAge <= 18) result += 1; else if (dwellerAge >= 50) result += 1.5; else result += 2;
                }
                result = water / result;
            }
            return (int)result;
        }
        public class MysteryFunction
        {
            public static long Mystery(long n) => n ^ (n >> 1);

            public static long MysteryInv(long n)
            {
                long g = 0;
                for (long i = 0; i < n; n >>= 1) { g ^= n; };

                return g;
            }

            public static string NameOfMystery()
            {
                return "Travelling salesman problem";
            }
        }
        public static string AlphabetPosition(string text)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char item in text)
            {
                if (char.IsLetter(item))
                {
                    sb.Append((char.ToUpper(item) - 64).ToString() + " ");
                }
            }
            if (sb.Length > 0)
            {
                sb.Remove(sb.Length - 1, 1);
            }
            return sb.ToString();
        }
        public static string HowMuch(int m, int n)
        {
            StringBuilder output = new StringBuilder();

            output.Append("[");

            if (n >= 0 && m >= 0)
            {
                if (m > n) { (n, m) = (m, n); };

                for (int f = m; f <= n; f++)
                {
                    if (f % 9 == 1 && f % 7 == 2)
                    {
                        output.Append($"[M: {f} B: {(f-2)/7} C: {(f - 1) / 9}]");
                    }
                }
            }
            output.Append("]");
            return output.ToString();
        }
        public static List<long[]> RemovNb(long n)
        {
            List<long[]> result = null;
            long sum = n * (n + 1) / 2;
            for (long i = 1; i <= n; i++)
            {
                if ((sum - i) % (i + 1) == 0)
                {
                    long secNumb = (sum - i) / (i + 1);
                    if (secNumb <= n)
                    {
                        Console.WriteLine($"item1 = {i} \t item2 = {secNumb}, \t product = {i * secNumb}, \t sum = {sum}");
                        result.AddRange(new List<long[]>() { new long[] { i, secNumb } });
                    }
                }
            }
            if (result.Count != 0)
            {
                return result;
            }
            else
            {
                return new List<long[]>();
            }
        }
        public static string WhitespaceNumber(int n)
        {
            string result = "";
            if (n > 0)
            {
                result = " ";
            }
            if (n < 0)
            {
                result = "\t";
                n = -n;
            }
            string temp = Convert.ToString(n, 2).Replace("0", " ");

            return (result + temp.Replace("1", "\t") + "\n");
        }
        public static bool IsPangram(string str)
        {
            HashSet<char> alphabet = new HashSet<char>();

            foreach (char item in str.ToLower())
            {
                if (char.IsLetter(item))
                {
                    alphabet.Add(item);
                }
            }
            if (alphabet.Count == 26)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool IsPangram2(string str)
        {
            string sentence = str.ToLower();
            char[] alpha = "abcdefghijklmnoprstquvwyxz".ToCharArray();

            List<char> alphabet = new List<char>();

            foreach (var item in alpha)
            {
                alphabet.Add(item);
            }


            foreach (char item in sentence)
            {
                try
                {
                    if (alphabet.Contains(item))
                    {
                        alphabet.Remove(item);
                    }
                }
                catch
                {
                    Console.WriteLine($"No char {item} in collection");
                }
            }
            if (alphabet.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        #endregion
    }
}
