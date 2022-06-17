using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montblanc
{
    internal class Player
    {
        private string playerName;
        private int playerStrenght, playerDefense, playerDexterity, playerHealth, playerHealthMax, playerLevel, playerExp;
        private double expCutoff;

        public Player ()
        {
            playerName = "";
            playerStrenght = 5;
            playerDefense = 5;
            playerDexterity = 5;
            playerHealthMax = 30;
            playerHealth = playerHealthMax;
            playerLevel = 5;
            playerExp = 500;
            expCutoff = 600;
        }

        public string PlayerName { get => playerName; set => playerName = value; }
        public int PlayerStrenght { get => playerStrenght; set => playerStrenght = value; }
        public int PlayerDefense { get => playerDefense; set => playerDefense = value; }
        public int PlayerDexterity { get => playerDexterity; set => playerDexterity = value; }
        public int PlayerHealth { get => playerHealth; set => playerHealth = value; }
        public int PlayerHealthMax { get => playerHealthMax; set => playerHealthMax = value; }
        public int PlayerLevel { get => playerLevel; set => playerLevel = value; }
        public int PlayerExp { get => playerExp; set => playerExp = value; }
        public double ExpCutoff { get => expCutoff; set => expCutoff = value; }
    }
}