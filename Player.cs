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
        private int playerStrenghtInt, playerDefenseInt, playerDexterityInt, playerHealth, playerHealthMax, playerLevel, playerExp;
        private double expCutoff;

        public Player (string playerName_, int playerStrenght_, int playerDefense_, int playerDexterity_)
        {
            PlayerName = playerName_;
            playerStrenghtInt = playerStrenght_;
            playerDefenseInt = playerDefense_;
            playerDexterityInt = playerDexterity_;
            playerHealthMax = 30;
            playerHealth = playerHealthMax;
            playerLevel = 5;
            playerExp = 500;
            expCutoff = 600;
        }

        public string PlayerName { get => playerName; set => playerName = value; }
        public int PlayerStrenghtInt { get => playerStrenghtInt; set => playerStrenghtInt = value; }
        public int PlayerDefenseInt { get => playerDefenseInt; set => playerDefenseInt = value; }
        public int PlayerDexterityInt { get => playerDexterityInt; set => playerDexterityInt = value; }
        public int PlayerHealth { get => playerHealth; set => playerHealth = value; }
        public int PlayerHealthMax { get => playerHealthMax; set => playerHealthMax = value; }
        public int PlayerLevel { get => playerLevel; set => playerLevel = value; }
        public int PlayerExp { get => playerExp; set => playerExp = value; }
        public double ExpCutoff { get => expCutoff; set => expCutoff = value; }
    }
}