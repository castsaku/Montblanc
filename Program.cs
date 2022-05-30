﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montblanc
{
    internal class Program
{
    static void Main(string[] args)
    {
        string playerName, playerAnswer;
        int str = 0, def = 0, dex = 0, statBudget = 0, hpp = 20, pdmg, odmg, phitchance, ohitchance;
        int hpo = 25, stro = 6, defo = 6, dexo = 9;
        int blocked, combatAnswer;
        Random rnd = new Random();

        Console.WriteLine("¡Bienvenido a Montblanc! Esta aventura te enseñará como defenderte en un mundo adverso. Para avanzar los dialogos, presiona una tecla.");
        Console.ReadKey();
        Console.Clear();

        do
        {
            Console.WriteLine("Primero cuentanos de ti, ¿Cual es tu nombre?");
            playerName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("¿Te llamas " + playerName + "? Si/No");
            playerAnswer = Console.ReadLine();
            Console.Clear();
        }
        while (playerAnswer == "No" || playerAnswer == "no");

        Console.WriteLine("Ahora vamos a crear tu personaje. Deberás distribuir 18 puntos entre tu Fuerza, Defensa, y Destreza");
        Console.ReadKey();
        Console.Clear();

        do {
            statBudget = 0;
            do {
                do {
                    Console.WriteLine("¿Cuantos puntos quieres invertir en tu Fuerza?");
                    str = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    if (statBudget + str > 18)
                    {
                        Console.WriteLine("Disculpa, pero te excediste en Fuerza. Vuelve a intentarlo");
                    }
                } while (statBudget + str > 18);
                statBudget += str;
                if (statBudget == 18) break;

                do {
                    Console.WriteLine("¿Cuantos puntos quieres invertir en tu Defensa?");
                    def = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    if (statBudget + def > 18) {
                        Console.WriteLine("Disculpa, pero te excediste en Defensa. Vuelve a intentarlo");
                    }
                } while (statBudget + def > 18);
                statBudget += def;
                if (statBudget == 18) break;

                do {
                    Console.WriteLine("¿Cuantos puntos quieres invertir en tu Destreza?");
                    dex = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    if (statBudget + dex > 18) {
                        Console.WriteLine("Disculpa, pero te excediste en Destreza. Vuelve a intentarlo");
                    }
                } while (statBudget + dex > 18);
                statBudget += dex;
                if (statBudget == 18) break;

                if (statBudget < 18)
                {
                    Console.WriteLine("¡Te sobran " + (18 - statBudget) + " puntos! Asigna el resto donde quieras");
                    Console.ReadKey();
                    Console.Clear();
                }
                if (statBudget > 18)
                {
                    Console.WriteLine("¡Te pasaste! Sólo tienes 18 puntos para repartir");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (statBudget < 18);

            Console.WriteLine($"Tienes {str} puntos de fuerza, {def} puntos de defensa, y {dex} puntos de destreza. ¿Es correcto? Si/No");
            playerAnswer = Console.ReadLine();
            Console.Clear();
        } while (playerAnswer == "No" || playerAnswer == "no");

        Console.Clear();
        Console.WriteLine("¡Perfecto! Con esto ya podemos-");
        Console.ReadKey();
        Console.Clear();

        Console.WriteLine("¡Oh no! ¡Se acerca un Orco! Vas a tener que luchar");
        Console.ReadKey();
        Console.Clear();

        Console.WriteLine("Toma esta espada, debería ayudar en el combate");
        Console.ReadKey();
        Console.Clear();

        Console.WriteLine("Recibiste: Espada Corta");
        Console.WriteLine("+2 Fuerza, +1 Defensa, +2 Destreza");

        str = str + 2;
        def = def + 1;
        dex = dex + 2;

        Console.ReadKey();
        Console.Clear();

        Console.WriteLine("Orco: ¿De verdad se esforzaron tanto en este programa como para incluir un enemigo y un combate?");
        Console.ReadKey();
        Console.Clear();

        Console.WriteLine("Orco: Bueno, es igual para mi, ¡Me estás dando la oportunidad de matarte!");
        Console.ReadKey();
        Console.Clear();

        Console.WriteLine("** COMIENZA EL COMBATE **");
        Console.WriteLine("PARA LUCHAR EN ESTE JUEGO DEBERAS ATACAR O DEFENDERTE DEPENDIENDO DE LA NECESIDAD DE TU PERSONAJE");
        Console.WriteLine("CADA TURNO TU PERSONAJE RECUPERARÁ LA MITAD DEL DAÑO BLOQUEADO AL DEFENDERTE");
        Console.ReadKey();

        do
        {
            hpo = 25;
            hpp = 20;
            do
            {
                Console.Clear();
                Console.WriteLine("¡Te quedan " + hpp + " puntos de vida! ¡Al Orco le quedan " + hpo + "! ¿Que deseas hacer?");
                Console.WriteLine();
                Console.WriteLine("Ingresa 1 para ATACAR");
                Console.WriteLine("Ingresa 2 para DEFENDERTE");

                pdmg = str + rnd.Next(1, 10) - defo + rnd.Next(1, 5);
                odmg = stro + rnd.Next(1, 10) - def + rnd.Next(1, 5);

                phitchance = dex + rnd.Next(1, 13);
                ohitchance = dexo + rnd.Next(1, 13);

                combatAnswer = int.Parse(Console.ReadLine());

                Console.Clear();

                if (combatAnswer == 1)
                {
                    if (phitchance < 13)
                    {
                        Console.WriteLine("¡Tu ataque falló!");
                    }
                    else
                    {
                        hpo = hpo - pdmg;
                        Console.WriteLine("El Orco recibe " + pdmg + " puntos de daño.");
                    }
                   
                }
                if (ohitchance < 13)
                {
                    Console.WriteLine("¡El ataque del Orco falló!");
                }
                else
                {
                    if (combatAnswer == 1){
                        hpp = hpp - odmg;
                        Console.WriteLine("Recibiste " + odmg + " puntos de daño.");
                    }
                    if (combatAnswer == 2)
                    {
                        blocked = odmg + def;
                        hpp = hpp + (blocked / 2);
                        Console.WriteLine("¡Bloqueaste " + blocked + " de daño!");
                        Console.WriteLine("¡Te sanaste " + blocked / 2 + " puntos de vida!");
                        if (hpp > 20)
                        {
                            Console.WriteLine("¡Estás al máximo de vida!");
                            hpp = 20;
                        }
                    }
                }
                Console.ReadKey();
            }
            while (hpo > 0 && hpp > 0);

            if (hpo <= 0)
            {
                Console.Clear();
                Console.WriteLine("Orco: ¡Buajajaja! Nada mal para un combate en consola. ¿Sistema de fallos y bonos de daño aleatoreos? ¡Ni siquiera te han enseñado eso!");
                Console.ReadKey();
                Console.Clear();
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Orco: Che ponéle ganas vieja. Hazte más fuerte y vuelve a retarme.");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("** ¿QUIERES REINTENTAR EL COMBATE? NO PODRÁS CAMBIAR TUS ESTADISTICAS**");
                playerAnswer = Console.ReadLine();
                Console.Clear();
            }
        }
        while (playerAnswer == "si" || playerAnswer == "Si");

        Console.Clear();

        Console.WriteLine("** FIN DE LA AVENTURA **");
        Console.ReadKey();
    }
}
}