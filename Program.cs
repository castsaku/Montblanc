using System;
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
            string playerName, playerAnswer, playerStrenght, playerDefense, playerDexterity;
            int playerStrenghtInt, playerDefenseInt, playerDexterityInt;
            int orcHealth = 25, orcStrenght = 6, orcDefense = 6, orcDexterity = 9;
            int statBudget = 0, playerHealth = 20, blocked, playerDamage, orcDamage, playerHitChance, orcHitChance, combatAnswer;

            Random rnd = new Random();

            Console.WriteLine("¡Bienvenido a Montblanc! Esta aventura te enseñará como defenderte en un mundo adverso. Para avanzar los dialogos, presiona una tecla.");
            Console.ReadKey();
            Console.Clear();

            do
            {
                do
                {
                    Console.WriteLine("Primero cuentanos de ti, ¿Cual es tu nombre?");
                    playerName = Console.ReadLine();
                    Console.Clear();

                    if (string.IsNullOrEmpty(playerName))
                    {
                        Console.Clear();
                        Console.WriteLine("Debe ingresar un nombre");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                while (string.IsNullOrEmpty(playerName));

                Console.WriteLine("¿Te llamas " + playerName + "? Si/No");
                playerAnswer = Console.ReadLine();
                Console.Clear();
            }
            while (playerAnswer == "No");


            Console.WriteLine("Ahora vamos a crear tu personaje. Deberás distribuir 18 puntos entre tu Fuerza, Defensa, y Destreza");
            Console.ReadKey();
            Console.Clear();

            do
            {
                do
                {
                    statBudget = 0;
                    do
                    {
                        Console.WriteLine("¿Cuantos puntos quieres invertir en tu Fuerza?");
                        playerStrenght = (Console.ReadLine());

                        if (string.IsNullOrEmpty(playerStrenght))
                        {
                            Console.Clear();
                            Console.WriteLine("Debe ingresar un valor.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    while (string.IsNullOrEmpty(playerStrenght));

                    playerStrenghtInt = int.Parse(playerStrenght);

                    Console.WriteLine();

                    do
                    {
                        Console.WriteLine("¿Cuantos puntos quieres invertir en tu Defensa?");
                        playerDefense = (Console.ReadLine());

                        if (string.IsNullOrEmpty(playerDefense))
                        {
                            Console.Clear();
                            Console.WriteLine("Debe ingresar un valor.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    while (string.IsNullOrEmpty(playerDefense));

                    playerDefenseInt = int.Parse(playerDefense);

                    Console.WriteLine();

                    Console.WriteLine("¿Cuantos puntos quieres invertir en tu Destreza?");
                    playerDexterity = Console.ReadLine();
                    playerDexterityInt = int.Parse(playerDexterity);

                    Console.WriteLine();

                    statBudget = playerStrenghtInt + playerDefenseInt + playerDexterityInt;

                    if (statBudget < 18)
                    {
                        Console.WriteLine("¡Te sobran " + (18 - statBudget) + " puntos! Asigna tus puntos de nuevo");
                        Console.ReadKey();
                        Console.Clear();

                    }

                    if (statBudget > 18)
                    {
                        Console.WriteLine("¡Te pasaste! Sólo tienes 18 puntos para repartir");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                while (statBudget != 18);

                Console.WriteLine("Tienes " + playerStrenght + " puntos de fuerza, " + playerDefense + " puntos de defensa, y " + playerDexterity + " puntos de destreza. ¿Es correcto? Si/No");
                playerAnswer = Console.ReadLine();
                Console.Clear();
            }
            while (playerAnswer == "No" || playerAnswer == "no");

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

            playerStrenght += 2;
            playerDefense += 1;
            playerDefense += 2;

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
                orcHitChance = 25;
                playerHitChance = 20;
                do
                {
                    Console.Clear();
                    Console.WriteLine("¡Te quedan " + playerHealth + " puntos de vida! ¡Al Orco le quedan " + orcHealth + "! ¿Que deseas hacer?");
                    Console.WriteLine();
                    Console.WriteLine("Ingresa 1 para ATACAR");
                    Console.WriteLine("Ingresa 2 para DEFENDERTE");

                    playerDamage = playerStrenghtInt + rnd.Next(1, 10) - orcDefense + rnd.Next(1, 5);
                    orcDamage = orcStrenght + rnd.Next(1, 10) - playerDefenseInt + rnd.Next(1, 5);

                    playerHitChance = playerDexterityInt + rnd.Next(1, 13);
                    orcHitChance = orcDexterity + rnd.Next(1, 13);

                    combatAnswer = int.Parse(Console.ReadLine());

                    Console.Clear();

                    if (combatAnswer == 1)
                    {
                        if (playerHitChance < 13)
                        {
                            Console.WriteLine("¡Tu ataque falló!");
                        }
                        else
                        {
                            orcHealth -= playerDamage;
                            Console.WriteLine("El Orco recibe " + playerDamage + " puntos de daño.");
                        }

                        if (orcHitChance < 13)
                        {
                            Console.WriteLine("¡El ataque del Orco falló!");
                        }
                        else
                        {
                            playerHealth -= orcDamage;
                            Console.WriteLine("Recibiste " + orcDamage + " puntos de daño.");
                        }
                    }

                    if (combatAnswer == 2)
                    {
                        if (orcHitChance < 13)
                        {
                            Console.WriteLine("¡El ataque del Orco falló!");
                        }
                        else
                        {
                            blocked = orcDamage + playerDefenseInt;
                            playerHealth += (blocked / 2);
                            Console.WriteLine("¡Bloqueaste " + blocked + " de daño!");
                            Console.WriteLine("¡Te sanaste " + blocked / 2 + " puntos de vida!");
                            if (playerHealth > 20)
                            {
                                Console.WriteLine("¡Estás al máximo de vida!");
                                playerHealth = 20;
                            }
                        }
                    }
                    Console.ReadKey();
                }
                while (orcHealth > 0 && playerHealth > 0);

                if (orcHealth <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Orco: ¡Buajajaja! Nada mal para un combate en consola. ¿Sistema de fallos y bonos de daño aleatoreos? ¡Ni siquiera te han enseñado eso!");
                    Console.ReadKey();
                    Console.Clear();
                    playerAnswer = "no";
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