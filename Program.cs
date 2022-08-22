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
        static string playerAnswer;
        static int randomEncounterChance;
        static int statBudget = 0, blocked, playerDamage, enemyDamage, playerHitChance, enemyHitChance, hitChance = 10, distance, distanceRemaining;

        static int decision, GHCompletion = 0, BSCompletion = 0, RPCompletion = 0, adventureCompletion = 0, GHID = 1, BSID = 2, RPID = 3;
        static string ubicacionActual = "MONTBLANC";
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            Player player = new Player();

            DisplayDialogue("*** PARA AVANZAR LOS DIALOGOS, PRESIONA UNA TECLA ***");
            DisplayDialogue("Antes de comenzar, por favor asigna tus estadisticas.\nTienes 15 puntos para distribuir entre tu fuerza, defensa y destreza.");

            do
            {
                do
                {
                    statBudget = 0;
                    player.PlayerStrenght = 5;
                    player.PlayerDefense = 5;
                    player.PlayerDexterity = 5;

                    player.PlayerStrenght += StatAsign("¿Cuantos puntos quieres invertir en tu fuerza?\nEsto determinará cuanto daño harás con tus ataques.");
                    player.PlayerDefense += StatAsign("\n¿Cuantos puntos quieres invertir en tu defensa?\nEsto determinará cuanto bloquearás de tus enemigos.");
                    player.PlayerDexterity += StatAsign("\n¿Cuantos puntos quieres invertir en tu destreza?\nEsto determinará la probabilidad de que tu ataques acierten.");

                    statBudget = player.PlayerStrenght + player.PlayerDefense + player.PlayerDexterity;

                    StatBudgetValidation();
                }
                while (statBudget != 30);

                playerAnswer = Question("\nTienes " + (player.PlayerStrenght - 5) + " de fuerza, " + (player.PlayerDefense - 5) + " de defensa, y " + (player.PlayerDexterity - 5) + " de destreza, ¿Es correcto?\n\nSI / NO\n");

            }
            while (playerAnswer == "No" || playerAnswer == "no");

            player.PlayerHealthMax = 30;

            DisplayDialogue("???: ¡Oh, gracias a la Diosa, al fin despiertas! ¿Recuerdas tu nombre?");

            do
            {
                player.PlayerName = Console.ReadLine();
                do
                {
                    if (string.IsNullOrEmpty(player.PlayerName))
                    {
                        ErrorMessage("Debe ingresar un nombre.");
                    }
                }
                while (string.IsNullOrEmpty(player.PlayerName));

                playerAnswer = Question("¿Te llamas " + player.PlayerName + "? Si / No");
            }
            while (playerAnswer == "No" || playerAnswer == "NO" || playerAnswer == "no");

            DisplayDialogue("???: Es un buen comienzo, Yo soy la hermana Kalishta.");
            DisplayDialogue("Kalishta: Te encontramos moribundo a las afueras de la ciudad, tus heridas eran muy graves, estuviste durmiendo al rededor de 3 días.");
            DisplayDialogue("Kalishta: Llevabas esto contigo, pero repararla puede resultar difícil, dado los pocos recursos que contamos para otorgarte en el monasterio,");
            DisplayDialogue("Kalishta: por lo que te insto a hablar con el armero o el viejo mago que vive en la torre; cualquiera sea tu elección.");

            DisplayDialogue("Hermana: ¿Recuerdas como luchar no? Si lo deseas, puedes prácticar con los muñecos mágicos que hay en el jardín.");

            do
            {
                playerAnswer = Question("Este combate será tu tutorial. Si ya entiendes las mecánicas lo puedes ignorar. ¿Recuerdas como luchar? Si / No");
                if (string.IsNullOrEmpty(playerAnswer))
                {
                    ErrorMessage("Debe elegir una opción.");
                }
            }
            while (string.IsNullOrEmpty(playerAnswer));

            if (playerAnswer == "No" || playerAnswer == "no" || playerAnswer == "nO")
            {
                CombatTutorial();

                Enemy orco = new Enemy();
                orco.crearOrco();

                Combate(player, orco);
            }

            DisplayDialogue("A lo lejos divisas una torre que se alza al este de la ciudad.");
            DisplayDialogue("Convencido de que el armero te puede ayudar, te diriges hacia la torre.");
            DisplayDialogue("Llegas a una casa completamente ordinaria. Desde dentro puedes escuchar el resonar de un martillo contra acero");
            DisplayDialogue("Con decisión, entras a la casa para encontrar al herrero, haciendo sonar una campanilla sobre la puerta");

            DisplayDialogue("???: ¡Un momento por favor");

            DisplayDialogue("Desde el fondo de la casa aparece un hombre alto y robusto, con una tupída barba y canosa barba adornando su reostro.");

            playerAnswer = Question("Hombre: ¡Muy buenos días! ¿Eres un aventurero? SI/NO");

            if(playerAnswer == "No" || playerAnswer == "NO" || playerAnswer == "no")
            {
                DisplayDialogue("Hombre: ¡Vaya! ¿Es en serio? Pues tienes toda la pinta de ser uno...");
            }

            DisplayDialogue("Herrero: Bueno, si has venido por servicios de herrería, estás en el lugar correcto");

            DisplayDialogue("Con cuidado, tomas la espada de su empuñadura para jalarla de su funda. El movimiento te hace sentir nostálgico.");

            DisplayDialogue("Herrero: ¡Oh! Traes una espada dañada. Déjame revisarla.");

            DisplayDialogue("El herrero revisa tu arma con sumo detenimiento, casi como si pudiera leer la historia de la hoja");

            DisplayDialogue("Herrero: Es una muy buena hoja, pero parece que tuvo mejores días. lastima.");
            DisplayDialogue("Herrero: Hmm... Es una lástima porque hasta diría que fue mágica en un pasado. Déjame ver que puedo hacer por ti.");

            DisplayDialogue("El Herrero tomó la hoja, y la llevo a lo que solo puedes suponer es su taller de trabajo");
            DisplayDialogue("Al cabo de un rato, el Herrero regresa ante ti");

            DisplayDialogue("Herrero: ¡Vaya! Que espada tan peculiar. Definitivamente albergó algún pode mágico en algún punto");
            DisplayDialogue("Herrero: ¡Realmente es una lástima! No tengo idea de magia como para restaurarla completamente, pero\nya debería ser útil para defenderte.");
            DisplayDialogue("Herrero: Tómalo como un favor de la casa, estoy seguro que volverás si necesitas algo más.");

            player.PlayerStrenght += 4;
            player.PlayerDefense += 2;
            player.PlayerDexterity += 4;

            do
            {
                do
                {
                    OptionNumberAssign();

                    ThreeQuests();

                    decision = int.Parse(Console.ReadLine());
                    Console.Clear();

                    RandomEncounter(player);

                    if (decision == GHID && GHCompletion != 1)
                    {
                        ubicacionActual = "GREENHILLS";

                        DisplayDialogue("Te encuentras en " + ubicacionActual + ".");
                        DisplayDialogue("???: Un viajero.");
                        DisplayDialogue("Una mujer con una túnica blanca se acerca a ti. Parece tener un resplandor divino dificil de exlplicar.");
                        DisplayDialogue("???: Soy el oráculo de los paramos. Para superar mi prueba, debes responder un acertijo");
                        DisplayDialogue("Oráculo: No temas, no es nada del otro mundo. La respuesta es una única palabra");

                        Riddle("Oráculo: ¿Qué ser camina con cuatro patas al alba, dos patas al mediodía y tres patas al atardecer?", "Humano", "humano");

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
                    DisplayDialogue(enemy.EnemyName + ": " + enemy.VictoryMessage);
                    DisplayDialogue("Ganaste " + enemy.EnemyExp + " puntos de experiencia");

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

            StatIncrease("vida máxima", player.PlayerHealth);
            StatIncrease("ataque", player.PlayerStrenght);
            StatIncrease("defensa", player.PlayerDefense);
            StatIncrease("destreza", player.PlayerDexterity);
            Console.Clear();
        }

        static void StatIncrease(string stat, int statint)
        {
            int statextra = rnd.Next(2, 5);
            Console.WriteLine("¡Tu " + stat + " ha aumentado en " + statextra + " puntos!");
            Console.ReadKey();
            Console.WriteLine(statint + " -> " + (statint + statextra));
            statint += statextra;
            Console.ReadKey();
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

        static int StatAsign(string texto)
        {
            string stat;
            do
            {
                Console.WriteLine(texto + "\n");
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

            int statint = int.Parse(stat);
            return statint;
        }

        static void StatBudgetValidation()
        {
            if (statBudget < 30)
            {
                Console.WriteLine("¡Te sobran " + (30 - statBudget) + " puntos! Asigna tus puntos de nuevo");
                Console.ReadKey();
                Console.Clear();

            }

            if (statBudget > 30)
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
            Console.WriteLine("** PARA COMPLETAR ESTA AVENTURA DEBES VISITAR LOS 3 LUGARES Y SUPERAR SUS PRUEBAS **\n");
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

        static void OptionNumberAssign()
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
        }

        static void RandomEncounter(Player player)
        {
            distance = rnd.Next(6, 12);

            for (int steps = 0; steps < distance; steps++)
            {
                distanceRemaining = distance - steps;
                Console.WriteLine("Estás a " + distanceRemaining + " de distancia de tu destino");
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
        }

        static void Riddle(string riddle, string ans1, string ans2)
        {
            do
            {
                Console.WriteLine(riddle);
                playerAnswer = Console.ReadLine();

                if (playerAnswer != "Humano" && playerAnswer != "humano")
                {
                    Console.WriteLine("Oráculo: No es correcto. Recuerda que es sólo una palabra.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            while (playerAnswer != ans1 && playerAnswer != ans2);
            Console.Clear();
        }
    }
}