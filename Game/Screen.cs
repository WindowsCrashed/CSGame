using System;
using System.IO;
using Game.Characters;
using Game.Characters.Inventory;
using Game.Miscellaneous;
using Game.GameLogic.Enums;

namespace Game
{
    class Screen      // Class containing screen related functions (EVENTUALLY MAKE AN INTERNAL SCREEN FUNCTION)
    {
        private Directories _directories = new Directories();
        private Character _opponent;
        private Player _player;

        public Screen(Player player, Character enemy)
        {
            _opponent = enemy;
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
        public void PrintSprite(string spriteName)  // (MAY BECOME USELESS) Prints any sprite in main directory
        {
            try
            {
                string[] lines = File.ReadAllLines(_directories.GetSpritePath(spriteName));

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
        public void PrintAttackSprite(Animation animation, Character user, string spriteName)  // Prints attack sprites only
        {
            try
            {
                string[] lines = File.ReadAllLines(_directories.GetAttackSpritePath(animation.ToString(), user.GetType().Name, spriteName));

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
        public void PrintDefenceSprite(string spriteName)  // Prints defence sprites only
        {
            try
            {
                string[] lines = File.ReadAllLines(_directories.GetDefenceSpritePath(spriteName));

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
        public void IdleDefencePoseLogic(string alternativeSprite)   // (WIP) Prints different idle defence sprites according to the given conditions
        {
            if (_player.ShieldUp && !_opponent.ShieldUp)
            {
                PrintSprite("DefencePosePlayer");
            } else if (!_player.ShieldUp && _opponent.ShieldUp)
            {
                PrintSprite("DefencePoseEnemy");
            }
            else if (_player.ShieldUp && _opponent.ShieldUp)
            {
                PrintSprite("DefencePoseBoth");
            } else
            {
                PrintSprite(alternativeSprite);
            }
        }
        public void PreparePoseLogic(Character user, int pos)   // Prints different prepare sprites according to the given conditions
        {
            if (user.Opponent.ShieldUp)
            {
                PrintAttackSprite(user.MoveSet[pos].Animation, user, "PrepareES"); // ES == Enemy Shield
            }
            else
            {
                PrintAttackSprite(user.MoveSet[pos].Animation, user, "Prepare");
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
        public void Idle()        // (LEAVE HERE WHILE SPRITES ARE WORK IN PROGRESS) Prints the standard position of the characters
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
        public void Encounter()     // Prints the encounter message and decisions 
        {
            PrintSprite("Encounter");
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
            IdleDefencePoseLogic("Idle");
            HealthBar();
            DottedLine();
            CenterText("What is going to be your next move?\n\n");
            DottedLine();
            CenterText("[1] ATTACK    [2] DEFEND\n");
            CenterText("[3] INVENTORY    [4] FLEE\n\n");
        }
        public void PlayerAttackMenu()     // Prints the Attack Choice UI
        {
            IdleDefencePoseLogic("Idle");
            HealthBar();
            DottedLine();
            CenterText("Which attack are you going to use?\n\n");
            DottedLine();
            CenterText($"[1] {_player.MoveSet[0].Name}    [2] {_player.MoveSet[1].Name}     [0] RETURN\n");
            CenterText($"[3] {_player.MoveSet[2].Name}    [4] {_player.MoveSet[3].Name}\n\n");
        }
        public void PrepareAttack(Character user, int pos)  // Prints attack preparation UI
        {
            PreparePoseLogic(user, pos);
            HealthBar();
            DottedLine();
            CenterText($"{user.MoveSet[pos].Name.ToUpper()} INCOMING!!!\n\n");
            DottedLine();
        }
        public void MakeAttack(Character user, int pos)    // Prints damage output UI
        {
            PrintAttackSprite(user.MoveSet[pos].Animation, user, "Strike");
            HealthBar();
            Damage(user, pos);
        }
        public void EnemyTurn()   // Prints the Enemy Turn UI
        {
            IdleDefencePoseLogic("Idle");
            HealthBar();
            DottedLine();
            CenterText($"The {_opponent.Name} is preparing to move...\n\n");
            DottedLine();
        }
        public void EnemyAttack(int pos)   // Prints the Enemy Attack UI
        {
            IdleDefencePoseLogic("Idle");
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
            IdleDefencePoseLogic(null);  // No alternative
            HealthBar();
            DottedLine();
            CenterText("Shield raised!!!\n\n");
            DottedLine();
        }
        public void EnemyDefence()     // Prints Enemy Shield Status
        {
            IdleDefencePoseLogic(null);  // No alternative
            HealthBar();
            DottedLine();
            CenterText($"The {_opponent.Name} raised his shield!!!\n\n");
            DottedLine();
        }
        public void BlockAttack(Character defender)    // Prints block message
        {
            PrintDefenceSprite(defender.GetType().Name + "Block");
            HealthBar();
            DottedLine();
            CenterText("ATTACK BLOCKED!!!\n\n");
            DottedLine();
        }
        public void PlayerInventory(CharInventory inventory)     // Prints Inventory choice UI
        {
            IdleDefencePoseLogic("Idle");
            HealthBar();
            DottedLine();
            CenterText("Which item are you going to use?\n\n");
            DottedLine();
            CenterText($"[1] {inventory.CheckItemSlot(0)}    [2] {inventory.CheckItemSlot(1)}     [0] RETURN\n");
            CenterText($"[3] {inventory.CheckItemSlot(2)}    [4] {inventory.CheckItemSlot(3)}\n\n");
        }
        public void UseItem(CharInventory inventory, int pos)   // Prints Used item message
        {
            IdleDefencePoseLogic("Idle");
            HealthBar();
            DottedLine();
            CenterText($"{inventory.Owner.Name} have used {inventory.Items[pos].Name}!!!\n\n");
            DottedLine();
        }
        public void HealthPotion(int healingPoints)   // Prints health potion message
        {
            IdleDefencePoseLogic("Idle");
            HealthBar();
            DottedLine();
            CenterText($"{healingPoints} HEALTH POINTS RESTORED!!!\n\n");
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
