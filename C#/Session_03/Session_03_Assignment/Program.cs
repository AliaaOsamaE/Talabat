using System;
using System.ComponentModel.Design;
using System.Numerics;
using System.Threading.Channels;
using System.Transactions;

namespace Session_03_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region 1
            /* --- Remove the following Comment to run the function -----*/

            // divisbleBy3and4();
            void divisbleBy3and4()
            {
                Console.WriteLine("Enter number : ");
                int num = int.Parse(Console.ReadLine());
                if (num % 3 == 0 && num % 4 == 0)
                    Console.WriteLine("Yes");
                else
                    Console.WriteLine("No");
            }
            #endregion
            #region 2
            /* --- Remove the following Comment to run the function -----*/

            // positive_negative();
            void positive_negative()
            {
                Console.WriteLine("Enter number : ");
                int num = int.Parse(Console.ReadLine());
                if (num < 0)
                    Console.WriteLine("negative");
                else if (num > 0)
                    Console.WriteLine("positive");
                else
                    Console.WriteLine("Zero");
            }
            #endregion
            #region 3
            /* --- Remove the following Comment to run the function -----*/

            // MinMax();
            void MinMax()
            {
                int max, min;
                Console.WriteLine("Enter 3 numbers : ");
                Console.WriteLine("num 1 = ");
                int num1 = int.Parse(Console.ReadLine());
                Console.WriteLine("num 2 = ");
                int num2 = int.Parse(Console.ReadLine());
                Console.WriteLine("num 3 = ");
                int num3 = int.Parse(Console.ReadLine());
                if (num1 <= num2 && num1 <= num3)
                {
                    min = num1;
                    if (num2 <= num3)
                        max = num3;
                    else
                        max = num2;
                }
                else if (num2 <= num1 && num2 <= num3)
                {
                    min = num2;
                    if (num1 <= num3)
                        max = num3;
                    else
                        max = num2;
                }
                else
                {
                    min = num3;
                    if (num1 <= num2)
                        max = num2;
                    else
                        max = num1;
                }
                Console.WriteLine($"minimum number = {min} , maximum number = {max}");

            }

            #endregion
            #region 4
            /* --- Remove the following Comment to run the function -----*/

            //EvenOdd();
            void EvenOdd()
            {
                int num;
                Console.WriteLine("Enter number : ");
                num = int.Parse(Console.ReadLine());

                if (num % 2 == 0)
                    Console.WriteLine($"{num} is even number");
                else
                    Console.WriteLine($"{num} is odd number");

            }
            #endregion
            #region 5
            /* --- Remove the following Comment to run the function -----*/
            //isVowel();
            void isVowel()
            {
                Console.WriteLine("Enter Char : ");
                char c = char.Parse(Console.ReadLine());
                bool isVowel = false;
                switch (c)
                {
                    case 'a':
                        isVowel = true;
                        break;
                    case 'e':
                        isVowel = true;
                        break;
                    case 'i':
                        isVowel = true;
                        break;
                    case 'u':
                        isVowel = true;
                        break;
                    case 'o':
                        isVowel = true;
                        break;
                    default:
                        break;

                }
                if (isVowel)
                    Console.WriteLine("vowel");
                else
                    Console.WriteLine("consonant");
            }
            
            #endregion
            #region 6
            /* --- Remove the following Comment to run the function -----*/

            //allNum();
            void allNum()
            {

                Console.WriteLine("Input number : ");
                int e = int.Parse(Console.ReadLine());

                for (int i = 1; i <= e; i++)
                {

                    Console.WriteLine($"{i}");
                }
            }
            #endregion
            #region 7
            /* --- Remove the following Comment to run the function -----*/

            //mulTable();
            void mulTable()
            {

                Console.WriteLine("Input number : ");
                int e = int.Parse(Console.ReadLine());

                for (int i = 1; i <= 12; i++)
                {
                    
                        Console.WriteLine($"{e*i}");
                }
            }
            #endregion
            #region 8
            /* --- Remove the following Comment to run the function -----*/

            // Even();
            void Even()
            {
              
                Console.WriteLine("Input ending number of range : ");
                int e = int.Parse(Console.ReadLine());

                for (int i = 1; i <= e; i++)
                {
                    if (i % 2 == 0)
                        Console.WriteLine($"{i}");
                }
            }
            #endregion
            #region 9
            /* --- Remove the following Comment to run the function -----*/

            // pow
            void pow()
            {
                int num1, num2, result = 1;

                Console.WriteLine("Please Enter base :");
                num1 = int.Parse(Console.ReadLine());


                Console.WriteLine("Please Enter power :");
                num2 = int.Parse(Console.ReadLine());
                for (int i = 0; i < num2; i++)
                {
                    result *= num1;
                }
                Console.WriteLine($"The result = {result}");
            }

            #endregion
            #region 10
            /* --- Remove the following Comment to run the function -----*/

            //statistics();
            void statistics()
            {
                int sum = 0;
                Console.WriteLine("Enter Marks of five subjects:");
                for (int i = 0;  i < 5;  i++)
                {
                    int s = int.Parse(Console.ReadLine());
                    sum += s;
                }
                double avg = sum / 5;
                Console.WriteLine($"Total marks = {sum}\nAverage Marks = {avg}\nPercentage = {avg}\n");
            }
            #endregion
            #region 12
            /* --- Remove the following Comment to run the function -----*/

            //calculator();
            void calculator()
            {
                int num1, num2, result=0;
                char op;
                Console.WriteLine("Please Enter num1 :");
                num1 = int.Parse(Console.ReadLine());

                Console.WriteLine("Please Enter the operation char :");
                op=char.Parse(Console.ReadLine());
                
                Console.WriteLine("Please Enter num2 :");
                num2 = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case '+':
                        result = num1 + num2;
                        break;
                    case '-':
                        result = num1 + num2;
                        break;
                    case '*':
                        result = num1 + num2;
                        break;
                    case '/':
                        if(num2 != 0)
                            result = num1 + num2;
                        break;
                    default:
                        Console.WriteLine("Please Enter Valid operation char");
                        break;
                }
                Console.WriteLine($"The result = {result}");
            }
            #endregion
            #region 13
            /* --- Remove the following Comment to run the function -----*/

           // reverseStr();
            void reverseStr()
            {
                string s, rs="";
                Console.WriteLine("Enter string :");
                s = Console.ReadLine();

                

                for (int i = 0; i < s.Length; i++)
                {
                    rs += s[s.Length-i-1];
                    s.Remove(s.Length - i-1);


                }
                Console.WriteLine($"The reversed string is {rs}");

            }
            #endregion
            #region 14
            /* --- Remove the following Comment to run the function -----*/

            //reverseInt();
            void reverseInt()
            {
                int num, reversed = 0;
                Console.WriteLine("Enter number :");
                num = int.Parse(Console.ReadLine());

                int p = num.ToString().Length - 1;

                for (int i = 0; i <= num.ToString().Length; i++)
                {
                    int digit = num % 10;
                    num /= 10;
                    reversed += digit * (int)Math.Pow(10, p);
                    p -= 1;


                }
                Console.WriteLine($"The reversed num = {reversed}");

            }

            #endregion
            #region 15
            /* --- Remove the following Comment to run the function -----*/

            //prime();
            void prime()
            {
                Console.WriteLine("Input starting number of range: ");
                int s = int.Parse(Console.ReadLine());
                Console.WriteLine("Input ending number of range : ");
                int e = int.Parse(Console.ReadLine());
                
                for(int i = s; i <= e; i++)
                {
                   bool isPrime = true;
                   for (int j = 2; j < i; j++)
                   {
                        if (i % j == 0)
                        {
                            isPrime = false;
                            break;
                        }
                   }
                   if(isPrime)
                        Console.WriteLine(i);

                }
            }
            #endregion
            #region 16

            /* --- Remove the following Comment to run the function -----*/
            // toBinary();
            void toBinary()
            {
                Console.WriteLine("Enter a number to convert :");
                int num = int.Parse(Console.ReadLine());
                string s = Convert.ToString(num,2);
                Console.WriteLine($"The Binary of {num} is {s}.");
            }
            #endregion


        }
    }
}
