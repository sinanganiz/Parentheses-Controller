using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parentheses_Compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] satirlar = new string[500];
            string dosya_adi;
            Stack parantezler = new Stack();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Dosya adını uzantısıyla birlikte giriniz: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            dosya_adi =Console.ReadLine();

            FileStream fs = new FileStream(dosya_adi, FileMode.Open, FileAccess.Read);
            StreamReader sw =new StreamReader(fs);
            int sayac = -1;
            do
            {
                sayac++;
                satirlar[sayac] = sw.ReadLine();
            }
            while (satirlar[sayac] != null);

            int durum = 0; //Durum 0 ise  başarılı, 1 ise istenen durum oluşmamıştır.
            for (int i=0;i<sayac;i++)
            {
                for (int j = 0; j < satirlar[i].Length; j++)
                {
                    if (satirlar[i][j] == '('  || satirlar[i][j] == '{' || satirlar[i][j] == '[' )
                    {
                        parantezler.Push(satirlar[i][j]);
                    }
                    else if (satirlar[i][j] == ')')
                    {
                        
                        if (parantezler.Count!=0 && (char)parantezler.Peek() == '(')
                            parantezler.Pop();

                        else
                            durum = 1;
                    }
                    else if (satirlar[i][j] == '}')
                    {
                        if (parantezler.Count != 0 && (char)parantezler.Peek() == '{')
                            parantezler.Pop();

                        else
                            durum = 1;
                    }
                    else if (satirlar[i][j] == ']')
                    {
                        if (parantezler.Count != 0 && (char)parantezler.Peek() == '[')
                            parantezler.Pop();

                        else
                            durum = 1;
                    }
                    if (durum==1)
                    {
                        break;
                    }
                }
                if (durum == 1)
                    break;
            }
            if (parantezler.Count != 0)
                durum = 1;

            if (durum == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Derleme Başarılı!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Derleme Başarısız!");
            }
            Console.ReadKey();
        }
    }
}
