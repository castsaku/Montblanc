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
            string playerName, playerAnswer, playerStrenght, playerDefense, playerDexterity, enemy;
            int playerStrenghtInt, playerDefenseInt, playerDexterityInt;
            int enemyHealth, enemyStrenght, enemyDefense, enemyDexterity;
            int statBudget = 0, playerHealth = 20, blocked, playerDamage, orcDamage, playerHitChance, orcHitChance, combatAnswer;

            int decision, GHCompletion = 0, BSCompletion = 0, RPCompletion = 0, adventureCompletion = 0, GHID = 1, BSID = 2, RPID = 3;
            string ubicacionActual = "MONTBLANC";

            Random rnd = new Random();

            Console.WriteLine("¡Bienvenido a Montblanc! Esta aventura te enseñará como defenderte en un mundo adverso. Para avanzar los diálogos, presiona una tecla.");
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
            while (playerAnswer == "No" || playerAnswer == "NO" || playerAnswer == "no" || playerAnswer == "nO");

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
            Console.Clear();

            do
            {
                enemy = "Orco";

                enemyHealth = 25;
                enemyStrenght = 4;
                enemyDexterity = 4;
                enemyDefense = 4;

                playerHealth = 20;
                do
                {
                    Console.WriteLine("¡Te quedan " + playerHealth + " puntos de vida! ¡Al " + enemy + " le quedan " + enemyHealth + "! ¿Que deseas hacer?");
                    Console.WriteLine();
                    Console.WriteLine("Ingresa 1 para ATACAR");
                    Console.WriteLine("Ingresa 2 para DEFENDERTE");

                    playerDamage = playerStrenghtInt + rnd.Next(1, 10) - enemyDefense + rnd.Next(1, 5);
                    orcDamage = enemyStrenght + rnd.Next(1, 10) - playerDefenseInt + rnd.Next(1, 5);

                    playerHitChance = playerDexterityInt + rnd.Next(1, 13);
                    orcHitChance = enemyDexterity + rnd.Next(1, 13);

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
                            enemyHealth -= playerDamage;
                            Console.WriteLine("El " + enemy + " recibe " + playerDamage + " puntos de daño.");
                        }

                        if (orcHitChance < 10)
                        {
                            Console.WriteLine("¡El ataque del " + enemy + " falló!");
                        }
                        else
                        {
                            playerHealth -= orcDamage;
                            Console.WriteLine("Recibiste " + orcDamage + " puntos de daño.");
                        }
                    }

                    if (combatAnswer == 2)
                    {
                        if (orcHitChance < 10)
                        {
                            Console.WriteLine("¡El ataque del " + enemy + " falló!");
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
                    Console.Clear();
                }
                while (enemyHealth > 0 && playerHealth > 0);

                if (enemyHealth <= 0)
                {
                    Console.Clear();
                    Console.WriteLine(enemy + ": ¡Buajajaja! Nada mal para un combate en consola. ¿Sistema de fallos y bonos de daño aleatoreos? ¡Ni siquiera te han enseñado eso!");
                    Console.ReadKey();
                    Console.Clear();
                    playerAnswer = "no";
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(enemy + ": Che ponéle ganas vieja. Hazte más fuerte y vuelve a retarme.");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("** ¿QUIERES REINTENTAR EL COMBATE? NO PODRÁS CAMBIAR TUS ESTADISTICAS**");
                    playerAnswer = Console.ReadLine();
                    Console.Clear();
                }
            }
            while (playerAnswer == "si" || playerAnswer == "Si");

            Console.Clear();

            do
            {
                do
                {
                    if (GHCompletion == 1 && BSCompletion == 0 && RPCompletion == 0)
                    {
                        BSID = 1;
                        RPID = 2;
                    }

                    if (GHCompletion == 0 && BSCompletion == 1 && RPCompletion == 0)
                    {
                        RPID = 2;
                    }

                    if (GHCompletion == 1 && BSCompletion == 1 && RPCompletion == 0)
                    {
                        RPID = 1;
                    }

                    if (GHCompletion == 1 && BSCompletion == 0 && RPCompletion == 1)
                    {
                        BSID = 1;
                    }

                    Console.WriteLine("** PARA COMPLETAR ESTA AVENTURA DEBES VISITAR LOS 3 LUGARES **");
                    Console.WriteLine();
                    Console.WriteLine("Te encuentras en " + ubicacionActual + ", ¿Donde quieres ir?");
                    Console.WriteLine();

                    if (GHCompletion == 0)
                    {
                        Console.WriteLine(GHID + " GREENHILLS");
                    }

                    if (BSCompletion == 0)
                    {
                        Console.WriteLine(BSID + " BLUESTEEPS");
                    }

                    if (RPCompletion == 0)
                    {
                        Console.WriteLine(RPID + " REDPLAINS");
                    }

                    Console.WriteLine();

                    decision = int.Parse(Console.ReadLine());
                    Console.Clear();

                    if (decision == GHID && GHCompletion != 1)
                    {
                        ubicacionActual = "GREENHILLS";
                        GHCompletion = 1;
                        adventureCompletion += GHCompletion;
                    }

                    if (decision == BSID && BSCompletion != 1)
                    {
                        ubicacionActual = "BLUESTEEPS";
                        BSCompletion = 1;
                        adventureCompletion += BSCompletion;
                    }

                    if (decision == RPID && RPCompletion != 1)
                    {
                        ubicacionActual = "REDPLAINS";
                        adventureCompletion += RPCompletion;

                        Console.WriteLine("Te encuentras en " + ubicacionActual + ".");
                        Console.ReadKey();
                        Console.Clear();

                        Console.WriteLine("¡Encontraste el arma divina! ¡Nada podrá resistir tus ataques!");
                        Console.ReadKey();
                        Console.Clear();

                        playerStrenghtInt = playerStrenghtInt + 90;

                        Console.WriteLine("TUS STATS SE FUERON A LA CHUCHA");
                        Console.ReadKey();
                        Console.Clear();

                        do
                        {
                            enemy = "Dragon";

                            enemyHealth = 60;
                            enemyStrenght = 12;
                            enemyDexterity = 12;
                            enemyDefense = 12;

                            playerHealth = 35;

                            do
                            {
                                Console.Clear();
                                Console.WriteLine("¡Te quedan " + playerHealth + " puntos de vida! ¡Al" + enemy + " le quedan " + enemyHealth + "! ¿Que deseas hacer?");
                                Console.WriteLine();
                                Console.WriteLine("Ingresa 1 para ATACAR");
                                Console.WriteLine("Ingresa 2 para DEFENDERTE");

                                playerDamage = playerStrenghtInt + rnd.Next(1, 10) - enemyDefense + rnd.Next(1, 5);
                                orcDamage = enemyStrenght + rnd.Next(1, 10) - playerDefenseInt + rnd.Next(1, 5);

                                playerHitChance = playerDexterityInt + rnd.Next(1, 13);
                                orcHitChance = enemyDexterity + rnd.Next(1, 13);

                                combatAnswer = int.Parse(Console.ReadLine());

                                Console.Clear();

                                if (combatAnswer == 1)
                                {
                                    if (playerHitChance < 10)
                                    {
                                        Console.WriteLine("¡Tu ataque falló!");
                                    }
                                    else
                                    {
                                        enemyHealth -= playerDamage;
                                        Console.WriteLine("El " + enemy + " recibe " + playerDamage + " puntos de daño.");
                                    }

                                    if (orcHitChance < 10)
                                    {
                                        Console.WriteLine("¡El ataque del " + enemy + " falló!");
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
                                        Console.WriteLine("¡El ataque del Dragon falló!");
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
                            while (enemyHealth > 0 && playerHealth > 0);

                            if (enemyHealth <= 0)
                            {
                                Console.Clear();
                                Console.WriteLine("Se murio el dragon we");
                                Console.ReadKey();
                                Console.Clear();
                                playerAnswer = "no";
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Te moriste we");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("** ¿QUIERES REINTENTAR EL COMBATE? NO PODRÁS CAMBIAR TUS ESTADISTICAS**");
                                playerAnswer = Console.ReadLine();
                                Console.Clear();
                            }
                        }
                        while (playerAnswer == "si" || playerAnswer == "Si");

                        RPCompletion = 1;
                    }

                    if (decision != 1 && decision != 2 && decision != 3)
                    {
                        Console.WriteLine("Debes ingresar alguno de los valores válidos");
                    }
                }
                while (decision != 1 && decision != 2 && decision != 3);
                adventureCompletion = GHCompletion + BSCompletion + RPCompletion;
            }
            while (adventureCompletion != 3);

            Console.WriteLine("** FIN DE LA AVENTURA **");

            Console.ReadKey();
        }
    }
}