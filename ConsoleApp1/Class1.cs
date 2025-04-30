using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Class1
    {
        
         public double Calculate(string input)
        {
            bool good = true;
            foreach (char c in input) 
            {
                if (char.IsLetter(c))
                {
                    good = false; break;
                    
                }
            }
            if (input is string && !String.IsNullOrEmpty(input)&&good)
            {
                string output = GetExpression(input);
                double result = Counting(output);
                result = Math.Round(result, 2, MidpointRounding.AwayFromZero);
                if (double.IsInfinity(result))
                {
                    return -1;
                }
                else
                {
                    return result;
                }
                    
            }
            else 
            {
                throw new FormatException("Неверный ввод");
            }
            
        }
        static private string GetExpression(string input)
        {
            string output = string.Empty; 
            Stack<char> operStack = new Stack<char>(); 

            for (int i = 0; i < input.Length; i++) 
            {
                
                if (IsDelimeter(input[i]))
                    continue; 

                
                if (Char.IsDigit(input[i])) 
                {
                    
                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        output += input[i]; 
                        i++; 

                        if (i == input.Length) break; 
                    }

                    output += " "; 
                    i--; 
                }

                
                if (IsOperator(input[i])) 
                {
                    if (input[i] == '(') 
                        operStack.Push(input[i]); 
                    else if (input[i] == ')') 
                    {
                        
                        char s = operStack.Pop();

                        while (s != '(')
                        {
                            output += s.ToString() + ' ';
                            s = operStack.Pop();
                        }
                    }
                    else 
                    {
                        if (operStack.Count > 0) 
                            if (GetPriority(input[i]) <= GetPriority(operStack.Peek())) 
                                output += operStack.Pop().ToString() + " "; 

                        operStack.Push(char.Parse(input[i].ToString())); 

                    }
                }
            }

            
            while (operStack.Count > 0)
                output += operStack.Pop() + " ";

            return output; 
        }
        static private double Counting(string input)
        {
            double result = 0; 
            Stack<double> temp = new Stack<double>(); 

            for (int i = 0; i < input.Length; i++) 
            {
                
                if (Char.IsDigit(input[i]))
                {
                    string a = string.Empty;

                    while (!IsDelimeter(input[i]) && !IsOperator(input[i])) 
                    {
                        a += input[i]; 
                        i++;
                        if (i == input.Length) break;
                    }
                    foreach(char d in a)
                    {
                        if (d == ',')
                        {
                            a = a.Replace(',','.');
                        }
                    }
                    temp.Push(double.Parse(a,CultureInfo.InvariantCulture)); 
                    i--;
                }
                else if (IsOperator(input[i])) 
                {
                    
                    double a = temp.Pop();
                    double b = temp.Pop();
                    
                    switch (input[i]) 
                    {
                        case '+': result = b + a; break;
                        case '-': result = b - a; break;
                        case '*': 
                            result = b * a; 
                            break;
                        case '/':
                            if (a == 0)
                            {
                                throw new DivideByZeroException("На ноль делить неляьзя");
                            }
                            else
                            {
                                result = b / a;
                              
                            }
                                break;
                        case '^': result = double.Parse(Math.Pow(double.Parse(b.ToString()), double.Parse(a.ToString())).ToString()); break;
                    }
                    
                    temp.Push(result);
                }
            }
            return temp.Peek(); 
        }
        static private bool IsDelimeter(char c)
        {
            if ((" =".IndexOf(c) != -1))
                return true;
            return false;
        }
        static private bool IsOperator(char с)
        {
            if (("+-/*^()".IndexOf(с) != -1))
                return true;
            return false;
        }
        static private byte GetPriority(char s)
        {
            switch (s)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 3;
                case '*': return 4;
                case '/': return 4;
                case '^': return 5;
                default: return 6;
            }
        }

    }
}
