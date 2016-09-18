using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace comienzo
{
    class TerceraPart
    {

        public void imprimir(string[] operacion)
        {
           
            Console.SetCursorPosition(18, 12); Console.WriteLine("=======================");
            Console.SetCursorPosition(18, 11); Console.WriteLine("))  Resultado = " + operacion[1]+"   ((");
            Console.SetCursorPosition(18, 10); Console.WriteLine("=======================");
            Console.ReadKey();
        }

    }

    class Secpart
    {


        public void EspParentesis(byte p, byte value, string[] operacion)
        {
            string cambio;
            p -= 2;

            for (; value <= p; value++) 
            {
                if (operacion[value] == " ")
                {
                   value += 2;
                    cambio = operacion[value];
                   value -= 2;
                    operacion[value] = cambio;
                   value += 2;
                    operacion[value] = " ";
                   value -= 2;
                }
            }



           

        }


        public void Quitbla(byte p, byte value, string[] operacion)
        {
            byte ultimo = 0; string cambiar; byte b = 0;
            p = 19;
            while (p >= 1)
            {
                ultimo = p;
                while (ultimo >= 1)
                {
                    b = Convert.ToByte(ultimo - 1);
                    if (b != 255)
                    {
                        while (((b != 255) && (b >= 0)) && (operacion[b] == " "))
                        {
                            cambiar = operacion[ultimo];
                            operacion[b] = cambiar;
                            operacion[ultimo] = " ";
                           b--;
                        }
                    }
                    ultimo--;

                }     

                p--;
            }

          
        }


        public void Signos(string[] operacion, byte pfin)
        {
            byte abierto = 0, p = 0, value = 0, a, b, k, contar; 
            double x = 0, y = 0, Total = 0;
            Secpart organizar = new Secpart();
            Secpart acomodar = new Secpart();

            while (abierto == 0)
            {
                for (byte i = 0; i <= pfin; i++)
                {
                    if ((operacion[i] == "(") )
                    {
                        value = i; p = i; p += 1;
                        while ((operacion[p] != "(") && (operacion[p] != ")"))
                        {
                            p += 1;
                        }

                        if (operacion[p] != "(")
                        {
                            byte j = Convert.ToByte(value + 1);
                            for (; j <= p; j++)
                            {
                                if (operacion[j] == "*")
                                {
                                    a = j; b = j;
                                    a -= 1; b += 1;
                                    x = Convert.ToDouble(operacion[a]); y = Convert.ToDouble(operacion[b]);
                                  Total = x * y;

                                   
                                    a = j; b = j;                                            
                                                                                             
                                    a -= 1; b += 1;                                          
                                                                                            
                                    operacion[a] = Convert.ToString(Total);            
                                                                                           
                                    operacion[j] = " "; operacion[b] = " ";              
                                 
                                    j = a;
                                    organizar.EspParentesis(p, value, operacion);
                                    acomodar.Quitbla(p, value, operacion);
                                    p -= 2;
                                }
                                else
                                {
                                    if (operacion[j] == "/")
                                    {
                                        a = j; b = j;
                                        a -= 1; b += 1;
                                        x = Convert.ToDouble(operacion[a]); y = Convert.ToDouble(operacion[b]);
                                      Total = x / y;

                                      
                                        a = j; b = j;                                           
                                                                                                  
                                        a -= 1; b += 1;                                          
                                                                                                
                                        operacion[a] = Convert.ToString(Total);             
                                                                                                
                                        operacion[j] = " "; operacion[b] = " ";             
                                       
                                        j = a;
                                        organizar.EspParentesis(p, value, operacion);
                                        acomodar.Quitbla(p,value, operacion);

                                        p -= 2;
                                    }

                                }


                            }
                            j = Convert.ToByte(value + 1);
                            for (; j <= p; j++)
                            {
                                if (operacion[j] == "+")
                                {
                                    a = j; b = j;
                                    a -= 1; b += 1;
                                    x = Convert.ToDouble(operacion[a]); y = Convert.ToDouble(operacion[b]);
                                 Total = x + y;

                                   
                                    a = j; b = j;
                                  
                                    a -= 1; b += 1;                                         
                                                                                             
                                    operacion[a] = Convert.ToString(Total);             
                                                                                          
                                    operacion[j] = " "; operacion[b] = " ";                
                                 
                                    j = a;
                                    organizar.EspParentesis(p, value, operacion);
                                    acomodar.Quitbla(p, value, operacion);
                                    p -= 2;
                                }
                                else
                                {
                                    if (operacion[j] == "-")
                                    {
                                        a = j; b = j;
                                        a -= 1; b += 1;
                                        x = Convert.ToDouble(operacion[a]); y = Convert.ToDouble(operacion[b]);
                                        Total = x - y;

                                       
                                        a = j; b = j;                                             
                                                                                                  
                                        a -= 1; b += 1;                                         
                                                                                                 
                                        operacion[a] = Convert.ToString(Total);             
                                                                                               
                                        operacion[j] = " "; operacion[b] = " ";                
                                      
                                        j = a;
                                        organizar.EspParentesis(p, value, operacion);
                                        acomodar.Quitbla(p, value, operacion);
                                        p -= 2;
                                    }

                                }


                            }
                            


                           
                            if (value >= 1)
                            {
                                k = Convert.ToByte(value - 1);
                                if (operacion[k] == "+" || operacion[k] == "(" || operacion[k] == ")" || operacion[k] == "-" || operacion[k] == "*" || operacion[k] == "/")
                                {
                                    operacion[value] = " "; operacion[p] = " ";
                                    acomodar.Quitbla(p, value, operacion);

                                }
                                else
                                {
                                    operacion[value] = "*"; operacion[p] = " ";
                                    acomodar.Quitbla(p, value, operacion);
                                }
                            }

                           
                            contar = 0;
                            for (int z = 0; z <= 19; z++)
                            {
                                if (operacion[z] == "(")
                                {
                                    contar++;
                                }
                            }

                            if (contar == 1) abierto = 1;

                        }


                        

                    }
                }
            }

        }

    }

    class PrimeraParte
    {
        static void Main(string[] args)
        {
            Console.Title = ("Calculadora");
            Console.SetCursorPosition(30, 1); Console.WriteLine("---------------");
            Console.SetCursorPosition(30, 2); Console.WriteLine("!!Calculadora!!");
            Console.SetCursorPosition(30, 3); Console.WriteLine("---------------");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Ingrese la operacion:");
            Console.WriteLine("");
            string[] operacion = new string[23];
            byte pos = 1, pfin = 0;
            string t1, t2 = " ";
            Secpart enviar = new Secpart();
            TerceraPart final = new TerceraPart();

            operacion[0] = "("; operacion[19] = ")";

            do
            {
                t1 = Convert.ToString(Console.ReadKey().KeyChar);

                if (t1 != "\r")
                {
                    if (t2 == " ")
                    {

                        if (t1 == "+" || t1 == "(" || t1 == ")" || t1 == "-" || t1 == "*" || t1 == "/")
                        {
                            operacion[pos] = t1;
                            pos++;

                        }
                        else
                        {
                            operacion[pos] = operacion[pos] + t1;
                        }

                    }
                    else
                    {
                        if (t1 == "+" || t1 == "(" || t1 == ")" || t1 == "-" || t1 == "*" || t1 == "/")
                        {
                            if (t2 == "+" || t2 == "(" || t2 == ")" || t2 == "-" || t2 == "*" || t2 == "/")
                            {
                                operacion[pos] = t1;
                                pos++;
                            }
                            else
                            {
                                pos++; operacion[pos] = t1; pos++;
                            }

                        }
                        else
                        {
                            operacion[pos] = operacion[pos] + t1;
                        }
                    }


                }
                else
                {
                    pfin = pos;
                }

                t2 = Convert.ToString(Console.ReadKey().KeyChar);
                if (t2 != "\r")
                {
                    if (t2 == "+" || t2 == "(" || t2 == ")" || t2 == "-" || t2 == "*" || t2 == "/")
                    {
                        if (t1 == "+" || t1 == "(" || t1 == ")" || t1 == "-" || t1 == "*" || t1 == "/")
                        {
                            operacion[pos] = t2;
                            pos++;
                        }
                        else
                        {
                            pos++; operacion[pos] = t2; pos++;
                        }

                    }
                    else
                    {
                        operacion[pos] = operacion[pos] + t2;
                    }


                }
                else
                {
                    pfin = pos;
                }

            } while ((pos < 19) && (t1 != "\r") && (t2 != "\r"));

           

            enviar.Signos(operacion, pfin);
            final.imprimir(operacion);

            Console.Clear();
            byte posx = 5;
            for (int m = 0; m <= 19; m++)
            {
                Console.SetCursorPosition(posx, 6); Console.WriteLine(operacion[m]);
                posx += 1;
            }
           
        }
    }
}
