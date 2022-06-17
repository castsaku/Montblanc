using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Montblanc.Player;

namespace Montblanc
{
    internal class Program
    {
        static string playerAnswer, playerStrenght, playerDefense, playerDexterity;
        static int playerStrenghtInt = 5, playerDefenseInt = 5, playerDexterityInt = 5, playerHealth, playerHealthMaxExtra, playerHealthMax, strenghtExtra, defenseExtra, dexterityExtra;
        static int randomEncounterChance;
        static int statBudget = 0, blocked, playerDamage, enemyDamage, playerHitChance, enemyHitChance, hitChance = 10, distance, distanceRemaining;

        static int decision, GHCompletion = 0, BSCompletion = 0, RPCompletion = 0, adventureCompletion = 0, GHID = 1, BSID = 2, RPID = 3;
        static string ubicacionActual = "MONTBLANC";
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            Player player = new Player();

            DisplayDialogue("¡Bienvenido a Montblanc! Esta aventura te enseñará como defenderte en un mundo adverso.Para avanzar los diálogos, presiona una tecla.");
            do
            {
                do
                {
                    player.PlayerName = Question("Primero cuentanos de ti, ¿Cual es tu nombre?");

                    if (string.IsNullOrEmpty(player.PlayerName))
                    {
                        ErrorMessage("Debe ingresar un nombre");
                    }
                }
                while (string.IsNullOrEmpty(player.PlayerName));

                playerAnswer = Question("¿Te llamas " + player.PlayerName + "? Si / No");
            }
            while (playerAnswer == "No" || playerAnswer == "NO" || playerAnswer == "no");

            DisplayDialogue("Ahora vamos a crear tu personaje. Comienzas en nivel 5. Deberás distribuir 15 puntos entre tu Fuerza, Defensa, y Destreza");

            do
            {
                do
                {
                    statBudget = 0;

                    StatAsign("¿Cuantos puntos quieres invertir en tu fuerza?", playerStrenght, player.PlayerStrenght);
                    StatAsign("¿Cuantos puntos quieres invertir en tu defensa?", playerDefense, playerDefenseInt);
                    StatAsign("¿Cuantos puntos quieres invertir en tu destreza?", playerDexterity, playerDexterityInt);

                    statBudget = player.PlayerStrenght + player.PlayerDefense + player.PlayerDexterity;

                    StatBudgetValidation();
                }
                while (statBudget != 15);

                playerAnswer = Question("Tienes " + player.PlayerStrenght + "de fuerza, " + player.PlayerDefense + "de defensa, y " + player.PlayerDexterity + " de destreza, ¿Es correcto?");

            }
            while (playerAnswer == "No" || playerAnswer == "no");

            player.PlayerHealthMax = 30;

            DisplayDialogue("¡Perfecto! Con esto ya podemos-");
            DisplayDialogue("¡Oh no! ¡Se acerca un Orco! Vas a tener que luchar");
            DisplayDialogue("Toma esta espada, debería ayudar en el combate");
            DisplayDialogue("Recibiste: Espada Corta. \n+4 Fuerza, +2 Defensa, +4 Destreza.");

            player.PlayerStrenght += 4;
            player.PlayerDefense += 2;
            player.PlayerDexterity += 4;

            DisplayDialogue("Orco: ¿Si te diste cuenta que esto ahora es un tutorial no?");
            DisplayDialogue("Orco: Bueno, es igual para mi, ¡Me estás dando la oportunidad de matarte!");

            CombatTutorial();

            Enemy orco = new Enemy();
            orco.crearOrco();

            Combate(player, orco);

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

                    ThreeQuests();

                    Console.WriteLine();

                    decision = int.Parse(Console.ReadLine());
                    Console.Clear();

                    distance = rnd.Next(6, 12);

                    for (int steps = 0; steps < distance; steps++)
                    {
                        distanceRemaining = distance - steps;
                        Console.WriteLine("Estás a " + distanceRemaining + " metros de distancia de tu destino");
                        Console.ReadKey();
                        Console.Clear();

                        randomEncounterChance = rnd.Next(1, 10);
                        if (randomEncounterChance <= 2)
                        {
                            Console.WriteLine("¡Se acerca un enemigo!");
                            Console.ReadKey();
                            Console.Clear();

                            if (randomEncounterChance <= 2)
                            {
                                Enemy zombi = new Enemy();
                                zombi.crearZombi();

                                Combate(player, zombi);
                            }
                        }
                    }

                    if (decision == GHID && GHCompletion != 1)
                    {
                        ubicacionActual = "GREENHILLS";

                        Console.WriteLine("Te encuentras en " + ubicacionActual + ".");
                        Console.ReadKey();
                        Console.Clear();

                        Console.WriteLine("???: Un viajero.");
                        Console.ReadKey();
                        Console.Clear();

                        Console.WriteLine("Una mujer con una túnica blanca se acerca a ti. Parece tener un resplandor divino dificil de exlplicar.");
                        Console.ReadKey();
                        Console.Clear();

                        Console.WriteLine("???: Soy el oráculo de los paramos. Para superar mi prueba, debes responder un acertijo");
                        Console.ReadKey();
                        Console.Clear();

                        Console.WriteLine("Oráculo: No temas, no es nada del otro mundo. La respuesta es una única palabra");
                        Console.ReadKey();
                        Console.Clear();

                        do
                        {
                            Console.WriteLine("Oráculo: ¿Qué ser camina con cuatro patas al alba, dos patas al mediodía y tres patas al atardecer?");
                            Console.ReadKey();
                            Console.Clear();

                            playerAnswer = Console.ReadLine();

                            if (playerAnswer != "Humano" && playerAnswer != "humano")
                            {
                                Console.WriteLine("Oráculo: No es correcto. Recuerd que es sólo una palabra.");
                                Console.ReadKey();
                                Console.Clear();
                            }

                        }
                        while (playerAnswer != "Humano" && playerAnswer != "humano");

                        Console.WriteLine("Oráculo: ¡Correcto! Ustedes humanos, nacen caminando en 4 patas, crecen para andar en 2 y necesitan apoyarse al envejecer.");
                        Console.ReadKey();
                        Console.Clear();

                        Console.WriteLine("Oráculo: Suerte en tu aventura viajero, que la luz de la diosa guíe tus pasos");
                        Console.ReadKey();
                        Console.Clear();

                        GHCompletion = 1;
                    }

                    if (decision == BSID && BSCompletion != 1)
                    {
                        ubicacionActual = "BLUESTEEPS";
                        BSCompletion = 1;
                    }

                    if (decision == RPID && RPCompletion != 1)
                    {
                        ubicacionActual = "REDPLAINS";

                        Console.WriteLine("Te encuentras en " + ubicacionActual + ".");
                        Console.ReadKey();
                        Console.Clear();

                        RPCompletion = 1;
                    }

                    if (decision != 1 && decision != 2 && decision != 3)
                    {
                        InvalidValue();
                    }
                }
                while (decision != 1 && decision != 2 && decision != 3);
                adventureCompletion = GHCompletion + BSCompletion + RPCompletion;
            }
            while (adventureCompletion != 3);

            Console.WriteLine("** FIN DE LA AVENTURA **");

            Console.ReadKey();
        }

        static void Combate(Player player, Enemy enemy)
        {
            do
            {
                player.PlayerHealth = player.PlayerHealthMax;
                enemy.EnemyHealth = enemy.EnemyHealthMax;

                do
                {
                    do
                    {

                        Console.WriteLine("¡Te quedan " + player.PlayerHealth + " puntos de vida! ¡Al " + enemy.EnemyName + " le quedan " + enemy.EnemyHealth + "! ¿Que deseas hacer?");
                        Console.WriteLine();
                        Console.WriteLine("Ingresa 1 para ATACAR");
                        Console.WriteLine("Ingresa 2 para DEFENDERTE");

                        playerDamage = player.PlayerStrenght + rnd.Next(1, 6) - enemy.EnemyDefense + rnd.Next(1, 3);
                        enemyDamage = enemy.EnemyStrenght + rnd.Next(1, 6) - player.PlayerDefense + rnd.Next(1, 3);

                        playerHitChance = player.PlayerDexterity + rnd.Next(1, 8);
                        enemyHitChance = enemy.EnemyDexterity + rnd.Next(1, 8);

                        if (enemyDamage < 0)
                        {
                            enemyDamage = 0;
                        }

                        if (playerDamage < 0)
                        {
                            playerDamage = 0;
                        }

                        playerAnswer = Console.ReadLine();
                        Console.Clear();

                        if (playerAnswer != "1" && playerAnswer != "2")
                        {
                            Console.WriteLine("Su elección no es válida");
                            Console.ReadKey();
                            Console.Clear();
                        }

                        if (string.IsNullOrEmpty(playerAnswer))
                        {
                            Console.WriteLine("Debe ingresar una opcón.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    while (playerAnswer != "1" && playerAnswer != "2" && string.IsNullOrEmpty(playerAnswer));

                    if (playerAnswer == "1")
                    {
                        Attack(player, enemy);
                    }

                    if (playerAnswer == "2")
                    {
                        Defend(player, enemy);
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
                while (enemy.EnemyHealth > 0 && player.PlayerHealth > 0);

                if (enemy.EnemyHealth <= 0)
                {
                    Console.Clear();
                    Console.WriteLine(enemy.EnemyName + ": " + enemy.VictoryMessage);
                    Console.ReadKey();
                    Console.Clear();

                    Console.WriteLine("Ganaste " + enemy.EnemyExp + " puntos de experiencia");

                    player.PlayerExp += enemy.EnemyExp;

                    if (player.PlayerExp >= player.ExpCutoff)
                    {
                        LevelUp(player);
                    }
                }
                else
                {
                    Console.WriteLine(enemy.EnemyName + ": " + enemy.DefeatMessage);
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            while (player.PlayerHealth <= 0 && enemy.EnemyHealth > 0);
        }

        static void LevelUp(Player player)
        {
            player.PlayerLevel += 1;
            player.ExpCutoff = player.ExpCutoff * 1.5;

            Console.WriteLine("¡Subiste a nivel " + player.PlayerLevel + "!");
            Console.ReadKey();

            playerHealthMaxExtra = rnd.Next(2, 5);
            Console.WriteLine("¡Tu vida máxima ha aumentado en " + playerHealthMaxExtra + " puntos!");
            Console.ReadKey();

            strenghtExtra = rnd.Next(2, 5);
            Console.WriteLine("¡Ganaste " + strenghtExtra + " puntos de fuerza!");
            Console.ReadKey();

            defenseExtra = rnd.Next(2, 5);
            Console.WriteLine("¡Ganaste " + defenseExtra + " puntos de defensa!");
            Console.ReadKey();

            dexterityExtra = rnd.Next(2, 5);
            Console.WriteLine("¡Ganaste " + dexterityExtra + " puntos de destreza!");
            Console.ReadKey();

            player.PlayerHealthMax += playerHealthMaxExtra;
            player.PlayerStrenght += strenghtExtra;
            player.PlayerDefense += defenseExtra;
            player.PlayerDexterity += dexterityExtra;
        }

        static void Defend(Player player, Enemy enemy)
        {
            if (enemyHitChance < hitChance)
            {
                Console.WriteLine("¡El ataque del " + enemy.EnemyName + " falló!");
            }
            else
            {
                blocked = enemyDamage + player.PlayerDefense;
                player.PlayerHealth += (blocked / 2);
                Console.WriteLine("¡Bloqueaste " + blocked + " de daño!");
                Console.WriteLine("¡Te sanaste " + blocked / 2 + " puntos de vida!");
                if (player.PlayerHealth > player.PlayerHealthMax)
                {
                    Console.WriteLine("¡Estás al máximo de vida!");
                    player.PlayerHealth = player.PlayerHealthMax;
                }
            }
        }

        static void Attack(Player player, Enemy enemy)
        {
            if (playerHitChance < hitChance)
            {
                Console.WriteLine("¡Tu ataque falló!");
            }
            else
            {
                enemy.EnemyHealth -= playerDamage;
                Console.WriteLine("El " + enemy.EnemyName + " recibe " + playerDamage + " puntos de daño.");
            }

            if (enemyHitChance < hitChance)
            {
                Console.WriteLine("¡El ataque del " + enemy.EnemyName + " falló!");
            }
            if (enemyHitChance >= hitChance)
            {
                if (enemyDamage < 0)
                {
                    enemyDamage = 0;
                }

                if (enemy.EnemyHealth <= 0)
                {
                    Console.WriteLine("¡El " + enemy.EnemyName + " ha sido derrotado!");
                }
                else
                {
                    player.PlayerHealth -= enemyDamage;
                    Console.WriteLine("Recibiste " + enemyDamage + " puntos de daño.");
                }
            }
        }

        static void DisplayDialogue(string dialogue)
        {
            Console.WriteLine(dialogue);
            Console.ReadKey();
            Console.Clear();
        }

        static void InvalidValue()
        {
            Console.WriteLine("Debes ingresar alguno de los valores válidos");
        }

        static void ErrorMessage(string texto)
        {
            Console.WriteLine(texto);
            Console.ReadKey();
            Console.Clear();
        }

        static string Question(string question)
        {
            Console.WriteLine(question);
            string answer = Console.ReadLine();
            Console.Clear();
            return answer;
        }

        static void StatAsign(string texto, string stat, int statint)
        {
            do
            {
                Console.WriteLine(texto);
                stat = Console.ReadLine();

                {
                    if (string.IsNullOrEmpty(stat))
                    {
                        Console.WriteLine("Debe ingresar un valor.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        if (int.Parse(stat) < 0)
                        {
                            Console.WriteLine("Debe ingresar un valor mayor a 0.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                }
            }
            while (string.IsNullOrEmpty(stat) || int.Parse(stat) < 0);

            statint += int.Parse(stat);
        }

        static void StatBudgetValidation()
        {
            if (statBudget < 15)
            {
                Console.WriteLine("¡Te sobran " + (15 - statBudget) + " puntos! Asigna tus puntos de nuevo");
                Console.ReadKey();
                Console.Clear();

            }

            if (statBudget > 15)
            {
                Console.WriteLine("¡Te pasaste! Sólo tienes 15 puntos para repartir");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void CombatTutorial()
        {
            Console.WriteLine("** COMIENZA EL COMBATE **");
            Console.WriteLine("PARA LUCHAR EN ESTE JUEGO DEBERAS ATACAR O DEFENDERTE DEPENDIENDO DE LA NECESIDAD DE TU PERSONAJE");
            Console.WriteLine("CADA TURNO TU PERSONAJE RECUPERARÁ LA MITAD DEL DAÑO BLOQUEADO AL DEFENDERTE");

            Console.ReadKey();
            Console.Clear();
        }

        static void ThreeQuests()
        {
            DisplayDialogue("** PARA COMPLETAR ESTA AVENTURA DEBES VISITAR LOS 3 LUGARES Y SUPERAR SUS PRUEBAS **\n");
            Console.WriteLine();
            Console.WriteLine("Te encuentras en " + ubicacionActual + " y te quedan " + (3 - adventureCompletion) + " pruebas por superar. ¿Donde quieres ir?");
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
        }
    }
}