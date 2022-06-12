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
            int playerStrenghtInt = 5, playerDefenseInt = 5, playerDexterityInt = 5, playerHealth, playerHealthMaxExtra, playerHealthMax, strenghtExtra, defenseExtra, dexterityExtra, playerLevel = 5, playerExp = 500;
            double expCutoff = 600;
            int enemyHealth, enemyHealthMax, enemyStrenght, enemyDefense, enemyDexterity, randomEncounterChance, enemyExp;
            int statBudget = 0, blocked, playerDamage, enemyDamage, playerHitChance, enemyHitChance, hitChance = 10, combatAnswer, distance, distanceRemaining;

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

            Console.WriteLine("Ahora vamos a crear tu personaje. Comienzas en nivel " + playerLevel + ". Deberás distribuir 15 puntos entre tu Fuerza, Defensa, y Destreza");
            Console.ReadKey();
            Console.Clear();

            do
            {
                do
                {
                    statBudget = 0;
                    do
                    {
                        Console.WriteLine("¿Cuantos puntos quieres invertir en tu Fuerza? Esto determinará cuando daño harás a los enemigos.");
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

                    playerStrenghtInt += int.Parse(playerStrenght);

                    Console.WriteLine();

                    do
                    {
                        Console.WriteLine("¿Cuantos puntos quieres invertir en tu Defensa? Esto deterimanará cuanto daño bloquearás de tus enemigos.");
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

                    playerDefenseInt += int.Parse(playerDefense);

                    Console.WriteLine();

                    do
                    {
                        Console.WriteLine("¿Cuantos puntos quieres invertir en tu Destreza? Esto influirá en tu probabilidad de golpear enemigos.");
                        playerDexterity = (Console.ReadLine());

                        if (string.IsNullOrEmpty(playerDexterity))
                        {
                            Console.Clear();
                            Console.WriteLine("Debe ingresar un valor.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    while (string.IsNullOrEmpty(playerDexterity));

                    playerDexterityInt += int.Parse(playerDexterity);

                    Console.WriteLine();

                    statBudget = playerStrenghtInt + playerDefenseInt + playerDexterityInt;

                    if (statBudget < 15)
                    {
                        Console.WriteLine("¡Te sobran " + (15 - statBudget) + " puntos! Asigna tus puntos de nuevo");
                        Console.ReadKey();
                        Console.Clear();

                    }

                    if (statBudget > 15)
                    {
                        Console.WriteLine("¡Te pasaste! Sólo tienes 18 puntos para repartir");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                while (statBudget != 30);

                Console.WriteLine("Tienes " + playerStrenght + " puntos de fuerza, " + playerDefense + " puntos de defensa, y " + playerDexterity + " puntos de destreza. ¿Es correcto? Si/No");
                playerAnswer = Console.ReadLine();
                Console.Clear();
            }
            while (playerAnswer == "No" || playerAnswer == "no");

            playerHealthMax = 30;

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
            Console.WriteLine("+4 Fuerza, +2 Defensa, +4 Destreza");

            playerStrenght += 4;
            playerDefense += 2;
            playerDexterity += 4;

            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Orco: ¿Si te diste cuenta que esto ahora es un tutorial no?");
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

                enemyHealthMax = 40;
                enemyStrenght = 10;
                enemyDexterity = 10;
                enemyDefense = 10;
                enemyExp = 100;

                enemyHealth = enemyHealthMax;
                playerHealth = playerHealthMax;
                do
                {
                    do
                    {
                        Console.WriteLine("¡Te quedan " + playerHealth + " puntos de vida! ¡Al " + enemy + " le quedan " + enemyHealth + "! ¿Que deseas hacer?");
                        Console.WriteLine();
                        Console.WriteLine("Ingresa 1 para ATACAR");
                        Console.WriteLine("Ingresa 2 para DEFENDERTE");

                        playerDamage = playerStrenghtInt + rnd.Next(1, 6) - enemyDefense + rnd.Next(1, 3);
                        enemyDamage = enemyStrenght + rnd.Next(1, 6) - playerDefenseInt + rnd.Next(1, 3);

                        playerHitChance = playerDexterityInt + rnd.Next(1, 8);
                        enemyHitChance = enemyDexterity + rnd.Next(1, 8);

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
                        if (playerHitChance < hitChance)
                        {
                            Console.WriteLine("¡Tu ataque falló!");
                        }
                        else
                        {
                            enemyHealth -= playerDamage;
                            Console.WriteLine("El " + enemy + " recibe " + playerDamage + " puntos de daño.");
                        }

                        if (enemyHitChance < hitChance)
                        {
                            Console.WriteLine("¡El ataque del " + enemy + " falló!");
                        }
                        else
                        {
                            if (enemyDamage < 0)
                            {
                                enemyDamage = 0;
                            }

                            playerHealth -= enemyDamage;
                            Console.WriteLine("Recibiste " + enemyDamage + " puntos de daño.");
                        }
                    }

                    if (playerAnswer == "2")
                    {
                        if (enemyHitChance < hitChance)
                        {
                            Console.WriteLine("¡El ataque del " + enemy + " falló!");
                        }
                        else
                        {
                            blocked = enemyDamage + playerDefenseInt;
                            playerHealth += (blocked / 2);
                            Console.WriteLine("¡Bloqueaste " + blocked + " de daño!");
                            Console.WriteLine("¡Te sanaste " + blocked / 2 + " puntos de vida!");
                            if (playerHealth > playerHealthMax)
                            {
                                Console.WriteLine("¡Estás al máximo de vida!");
                                playerHealth = playerHealthMax;
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
                    Console.WriteLine(enemy + ": ¡Buajajaja! Nada mal para tu primer combate.");
                    Console.ReadKey();
                    Console.Clear();

                    playerExp += enemyExp;

                    if (playerExp >= expCutoff)
                    {
                        playerLevel += 1;
                        expCutoff = expCutoff * 1.5;

                        Console.WriteLine("¡Subiste a nivel " + playerLevel + "!");

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

                        playerHealthMax += playerHealthMaxExtra;
                        playerStrenghtInt += strenghtExtra;
                        playerDefenseInt += defenseExtra;
                        playerDexterityInt += defenseExtra;

                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(enemy + ": Che ponéle ganas vieja. Hazte más fuerte y vuelve a retarme.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            while (playerHealth == 0 && enemyHealth != 0);

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

                    Console.WriteLine("** PARA COMPLETAR ESTA AVENTURA DEBES VISITAR LOS 3 LUGARES Y SUPERAR SUS PRUEBAS **");
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
                                do
                                {
                                    enemy = "Zombi";

                                    enemyHealth = 20;
                                    enemyStrenght = 8;
                                    enemyDexterity = 8;
                                    enemyDefense = 12;
                                    enemyExp = 60;

                                    playerHealth = playerHealthMax;
                                    do
                                    {
                                        do
                                        {
                                            Console.WriteLine("¡Te quedan " + playerHealth + " puntos de vida! ¡Al " + enemy + " le quedan " + enemyHealth + "! ¿Que deseas hacer?");
                                            Console.WriteLine();
                                            Console.WriteLine("Ingresa 1 para ATACAR");
                                            Console.WriteLine("Ingresa 2 para DEFENDERTE");

                                            playerDamage = playerStrenghtInt + rnd.Next(1, 6) - enemyDefense + rnd.Next(1, 3);
                                            enemyDamage = enemyStrenght + rnd.Next(1, 6) - playerDefenseInt + rnd.Next(1, 3);

                                            playerHitChance = playerDexterityInt + rnd.Next(1, 15);
                                            enemyHitChance = enemyDexterity + rnd.Next(1, 15);

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
                                            if (playerHitChance < hitChance)
                                            {
                                                Console.WriteLine("¡Tu ataque falló!");
                                            }
                                            else
                                            {
                                                enemyHealth -= playerDamage;
                                                Console.WriteLine("El " + enemy + " recibe " + playerDamage + " puntos de daño.");
                                            }

                                            if (enemyHitChance < hitChance)
                                            {
                                                Console.WriteLine("¡El ataque del " + enemy + " falló!");
                                            }
                                            else
                                            {
                                                playerHealth -= enemyDamage;
                                                Console.WriteLine("Recibiste " + enemyDamage + " puntos de daño.");
                                            }
                                        }

                                        if (playerAnswer == "2")
                                        {
                                            if (enemyHitChance < hitChance)
                                            {
                                                Console.WriteLine("¡El ataque del " + enemy + " falló!");
                                            }
                                            else
                                            {
                                                blocked = enemyDamage + playerDefenseInt;
                                                playerHealth += (blocked / 2);
                                                Console.WriteLine("¡Bloqueaste " + blocked + " de daño!");
                                                Console.WriteLine("¡Te sanaste " + blocked / 2 + " puntos de vida!");
                                                if (playerHealth > playerHealthMax)
                                                {
                                                    Console.WriteLine("¡Estás al máximo de vida!");
                                                    playerHealth = playerHealthMax;
                                                }
                                            }
                                        }
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                    while (enemyHealth > 0 && playerHealth > 0);

                                    if (enemyHealth <= 0)
                                    {
                                        Console.WriteLine("¡Ganaste " + enemyExp + " puntos de experiencia!");
                                        playerExp += enemyExp;


                                        if (playerExp >= expCutoff)
                                        {
                                            playerLevel += 1;
                                            expCutoff = expCutoff * 1.5;

                                            Console.WriteLine("¡Subiste a nivel " + playerLevel + "!");

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

                                            playerHealthMax += playerHealthMaxExtra;
                                            playerStrenghtInt += strenghtExtra;
                                            playerDefenseInt += defenseExtra;
                                            playerDexterityInt += defenseExtra;

                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("¡Tu historia no puede terminar así!");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                }
                                while (playerHealth == 0 && enemyHealth != 0);
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

                        Console.WriteLine("¡Encontraste el arma divina! ¡Nada podrá resistir tus ataques!");
                        Console.ReadKey();
                        Console.Clear();

                        playerStrenghtInt = playerStrenghtInt + 90;

                        Console.WriteLine("TUS STATS SE FUERON A LA CHUCHA");
                        Console.ReadKey();
                        Console.Clear();

                        do
                        {
                            enemy = "Al'Dragon";

                            enemyHealth = 60;
                            enemyStrenght = 15;
                            enemyDexterity = 15;
                            enemyDefense = 15;

                            playerHealth = 35;

                            do
                            {
                                Console.Clear();
                                Console.WriteLine("¡Te quedan " + playerHealth + " puntos de vida! ¡A " + enemy + " le quedan " + enemyHealth + "! ¿Que deseas hacer?");
                                Console.WriteLine();
                                Console.WriteLine("Ingresa 1 para ATACAR");
                                Console.WriteLine("Ingresa 2 para DEFENDERTE");

                                playerDamage = playerStrenghtInt + rnd.Next(1, 10) - enemyDefense + rnd.Next(1, 5);
                                enemyDamage = enemyStrenght + rnd.Next(1, 10) - playerDefenseInt + rnd.Next(1, 5);

                                playerHitChance = playerDexterityInt + rnd.Next(1, 13);
                                enemyHitChance = enemyDexterity + rnd.Next(1, 13);

                                if (enemyDamage < 0)
                                {
                                    enemyDamage = 0;
                                }

                                if (playerDamage < 0)
                                {
                                    playerDamage = 0;
                                }

                                combatAnswer = int.Parse(Console.ReadLine());

                                Console.Clear();

                                if (combatAnswer == 1)
                                {
                                    if (playerHitChance < hitChance)
                                    {
                                        Console.WriteLine("¡Tu ataque falló!");
                                    }
                                    else
                                    {
                                        enemyHealth -= playerDamage;
                                        Console.WriteLine("El " + enemy + " recibe " + playerDamage + " puntos de daño.");
                                    }

                                    if (enemyHitChance < hitChance)
                                    {
                                        Console.WriteLine("¡El ataque del " + enemy + " falló!");
                                    }
                                    else
                                    {
                                        playerHealth -= enemyDamage;
                                        Console.WriteLine("Recibiste " + enemyDamage + " puntos de daño.");
                                    }
                                }

                                if (combatAnswer == 2)
                                {
                                    if (enemyHitChance < hitChance)
                                    {
                                        Console.WriteLine("¡El ataque del Dragon falló!");
                                    }
                                    else
                                    {
                                        blocked = enemyDamage + playerDefenseInt;
                                        playerHealth += (blocked / 2);
                                        Console.WriteLine("¡Bloqueaste " + blocked + " de daño!");
                                        Console.WriteLine("¡Te sanaste " + blocked / 2 + " puntos de vida!");
                                        if (playerHealth > playerHealthMax)
                                        {
                                            Console.WriteLine("¡Estás al máximo de vida!");
                                            playerHealth = playerHealthMax;
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
                                Console.WriteLine("** ¿QUIERES REINTENTAR EL COMBATE? **");
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