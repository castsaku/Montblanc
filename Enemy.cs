using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montblanc
{
    internal class Enemy
    {
        private int enemyHealth, enemyHealthMax, enemyStrenght, enemyDefense, enemyDexterity, enemyExp;
        private string enemyName, defeatMessage, victoryMessage;

        public Enemy()
        {

        }

        public int EnemyHealth { get => enemyHealth; set => enemyHealth = value; }
        public int EnemyHealthMax { get => enemyHealthMax; set => enemyHealthMax = value; }
        public int EnemyStrenght { get => enemyStrenght; set => enemyStrenght = value; }
        public int EnemyDefense { get => enemyDefense; set => enemyDefense = value; }
        public int EnemyDexterity { get => enemyDexterity; set => enemyDexterity = value; }
        public int EnemyExp { get => enemyExp; set => enemyExp = value; }
        public string EnemyName { get => enemyName; set => enemyName = value; }
        public string DefeatMessage { get => defeatMessage; set => defeatMessage = value; }
        public string VictoryMessage { get => victoryMessage; set => victoryMessage = value; }

        public void crearOrco()
        {
            enemyHealth = 40;
            enemyHealthMax = enemyHealth;
            enemyStrenght = 10;
            enemyDefense = 10;
            enemyDexterity = 10;
            enemyExp = 100;

            enemyName = "Orco";
            defeatMessage = "¡Buajaja! Nada mal para tu primer combate";
            victoryMessage = "Che vieja ponele ganas";
        }

        public void crearZombi()
        {
            enemyHealth = 20;
            enemyHealthMax = enemyHealth;
            enemyStrenght = 8;
            enemyDefense = 8;
            enemyDexterity = 8;
            enemyExp = 60;

            enemyName = "Zombi";
            defeatMessage = "GANE UGH";
            victoryMessage = "PERDI UGH";
        }
    }
}
