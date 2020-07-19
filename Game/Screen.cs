﻿using System;
using System.IO;
using Game.Characters;
using Game.Miscellaneous;

namespace Game
{
    class Screen      // Class containing screen related functions
    {
        private Directories _directories = new Directories();
        private Character _opponent;
        private Player _player;

        public Screen(Character opponent, Player player)
        {
            _opponent = opponent;
            _player = player;
        }


        // ---------- LOGIC FUNCTIONS ----------------

        public void CenterText(string text)     // Used for centering messages
        {
            for (int i = 0; i < 53 - (text.Length / 2); i++)
            {
                Console.Write(" ");
            }
            Console.Write(text);
        }
        public void HealthBarLogic(Character c)  // Used for calculating the health bar length
        {
            int relativeHP = c.Hp * 2;      // Used for the printing

            for (int i = 1; i <= 20; i++)
            {
                if (relativeHP - i < 0)
                {
                    Console.Write("-");
                }
                else
                {
                    Console.Write("H");
                }
            }
        }


        // ---------- PRINTING FUNCTIONS -------------

        public void DottedLine()      // Prints those lines
        {
            for (int i = 0; i < 106; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("\n");
        }
        public void Idle()        // Prints the standard position of the characters
        {
            try
            {
                string[] lines = File.ReadAllLines(_directories.GetSpritePath("Idle"));

                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR 404");
                Console.WriteLine(e.Message);
            }
        }
        public void Welcome()       // Just for testing
        {
            DottedLine();

            CenterText("WELCOME TO THE FIRST GAME PROJECT!!!\n\n");
            CenterText("GOOD LUCK, WINDOWSCRASHED!!!(you'll need it...)\n\n");

            DottedLine();
        }
        public void Encounter()     // Prints the encounter message and decisions 
        {
            DottedLine();
            CenterText($"A {_opponent.Name.ToUpper()} STEPS INTO YOUR PATH!!!\n\n");
            DottedLine();

            CenterText("What are you going to do?\n\n");
            CenterText("[1] FIGHT    [2] TURN BACK\n\n");
        }
        public void PrepareFight()      // Prints the first option's message
        {
            DottedLine();
            CenterText("Taking the sword and preparing to fight!\n\n");
            DottedLine();
        }
        public void Flee()     // Prints the exit message
        {
            DottedLine();
            CenterText("Turning back and seeking another path...\n\n");
            DottedLine();
        }
        public void PlayerTurn()     // Prints the main UI
        {
            Idle();
            HealthBar();
            DottedLine();
            CenterText("What is going to be your next move?\n\n");
            DottedLine();
            CenterText("[1] ATTACK    [2] DEFEND\n");
            CenterText("[3] INVENTORY    [4] FLEE\n\n");
        }
        public void PlayerAttack()     // Prints the Attack Choice UI
        {
            Idle();
            HealthBar();
            DottedLine();
            CenterText("Which attack are you going to use?\n\n");
            DottedLine();
            CenterText($"[1] {_player.MoveSet[0].Name}    [2] {_player.MoveSet[1].Name}\n");
            CenterText($"[3] {_player.MoveSet[2].Name}    [4] {_player.MoveSet[3].Name}\n\n");
        }
        public void EnemyTurn()   // Prints the Enemy Turn UI
        {
            Idle();
            HealthBar();
            DottedLine();
            CenterText($"The {_opponent.Name} is preparing to move...\n\n");
            DottedLine();
        }
        public void EnemyAttack(int pos)   // Prints the Enemy Attack UI
        {
            Idle();
            HealthBar();
            DottedLine();
            CenterText($"{_opponent.MoveSet[pos].Name.ToUpper()} INCOMING!!!\n\n");
            DottedLine();
        }
        public void Damage(Character c, int pos)    // Prints damage screen
        {
            DottedLine();
            CenterText($"{c.MoveSet[pos].Damage} DAMAGE!!!\n\n");
            DottedLine();
        }
        public void PlayerDefence()     // Prints Player Shield Status
        {
            Idle();
            HealthBar();
            DottedLine();
            CenterText("Shield raised!!!\n\n");
            DottedLine();
        }
        public void EnemyDefence()     // Prints Enemy Shield Status
        {
            Idle();
            HealthBar();
            DottedLine();
            CenterText($"The {_opponent.Name} raised his shield!!!\n\n");
            DottedLine();
        }
        public void BlockAttack()    // Prints block message
        {
            Idle();
            HealthBar();
            DottedLine();
            CenterText("ATTACK BLOCKED!!!\n\n");
            DottedLine();
        }
        public void HealthBar()   // Prints the health bars of player and opponent
        {
            Console.WriteLine();

            for (int i = 0; i < 14; i++)
            {
                Console.Write(" ");
            }

            HealthBarLogic(_player);

            for (int i = 0; i < 36; i++)
            {
                Console.Write(" ");
            }

            HealthBarLogic(_opponent);

            Console.WriteLine("\n");
        }
        public void Victory()   // Prints the victory message
        {
            DottedLine();
            CenterText("Enemy defeated!\n");
            CenterText("YOU WIN!!!\n\n");
            DottedLine();
        }
        public void Defeat()    // Prints the defeat message
        {
            DottedLine();
            CenterText("You've been defeated...\n");
            CenterText("YOU LOSE...\n\n");
            DottedLine();
        }
    }
}
