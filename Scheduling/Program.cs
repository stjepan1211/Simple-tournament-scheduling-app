using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling
{
    class Program
    {
        /// <summary>
        /// 
        /// league schedule algorithm is based on nrich.maths.org/1443 this example
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //////////////////////////////////////////////
            //ovaj dio se mijenja pri unosu
            int brojTimova = 5;
            int[] timovi = new int[] { 1, 2, 3, 4 , 5}; //u ovom slucaju timovi ce se zadati eksplicitno brojevima
            ////////////////////////////////////////////////
            int brojRundi;
            if (brojTimova % 2 == 0)
            {
                int zadnjiTim = timovi[timovi.Length - 1];  //zadnji tim je potrebno odvojiti jer je on fiksan
                                                            // sve timove prije zadnjeg treba rotirati, vidi gornji link
                Array.Resize(ref timovi, timovi.Length - 1);//skidanje zadnjeg elementa s niza
                int[] demo = new int[timovi.Length];        //instanciranje novog niza, bit ce potreban kod rotiranja elemenata
                //ako je broj timova paran broj rundi je br timova - 1
                brojRundi = brojTimova - 1;
                //ovaj brojac ce biti potreban za sparivanje timova
                //prvi mec ce bit fiksiran tim i nulti element
                //ostala ce biti elementi [1] sa zadnjim elementom niza, [2] s predzadnjim
                int brojacDole = timovi.Length - 1;
                //prolazak kroz runde, za svaku rundu generiranje parova
                for (int i = 0; i < brojRundi; i++)
                {
                    brojacDole = timovi.Length - 1;
                    Console.WriteLine("Runda: " + (i + 1));
                    int brojPreostalihMeceva = brojTimova / 2; 
                    Console.Write(timovi[0] + " vs. " + zadnjiTim + "\t");
                    for(int j = 1; j < brojPreostalihMeceva; j ++)
                    {
                        Console.Write(timovi[j] + " vs. " + timovi[brojacDole--] + "\t");
                    }
                    //for petlja koja sifta elemente niza za 1 u desno
                    for (int k = 0; k < timovi.Length; k++)
                    {
                        demo[(k + 1) % demo.Length] = timovi[k];
                    }
                    //na kraju potrebno prebaciti siftani niz u niz timova
                    for (int k = 0; k < timovi.Length; k++)
                    {
                        timovi[k] = demo[k];
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                //algoritam je slican kao i gore, samo onaj tim koji je bio povezan
                //s fiksiranim timom(ovdje nema fiksiranog) bude slobodan svako kolo
                brojRundi = brojTimova;
                int brojacDole = timovi.Length - 1;
                int[] demo = new int[timovi.Length];
                for (int i = 0; i < brojRundi; i++)
                {
                    brojacDole = timovi.Length - 1;
                    Console.WriteLine("Runda: " + (i + 1));
                    int brojPreostalihMeceva = (brojTimova / 2) + 1;
                    for (int j = 1; j < brojPreostalihMeceva; j++)
                    {
                        Console.Write(timovi[j] + " vs. " + timovi[brojacDole--] + "\t");
                    }
                    //for petlja koja sifta elemente niza za 1 u desno
                    for (int k = 0; k < timovi.Length; k++)
                    {
                        demo[(k + 1) % demo.Length] = timovi[k];
                    }
                    //na kraju potrebno prebaciti siftani niz u niz timova
                    for (int k = 0; k < timovi.Length; k++)
                    {
                        timovi[k] = demo[k];
                    }
                    Console.WriteLine();
                }
            }

            Console.ReadLine();
        }
    }
}
