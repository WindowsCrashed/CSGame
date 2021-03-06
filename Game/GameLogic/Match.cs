﻿using System;
using Game.Characters;

namespace Game.GameLogic
{
    class Match         // Manages match related logic (for now just the end)
    {
        public bool MatchInProgress { get; private set; }
        private Screen _screen;

        public Match(Screen screen)
        {
            _screen = screen;
            MatchInProgress = true;
        }

        public void SetUpFight(Player player, Character opponent)     // Used for setting up Screen class inside characaters for animations
        {  
            player.SetOpponent(opponent);  
            opponent.SetOpponent(player);
            player.SetScreen(_screen);
            opponent.SetScreen(_screen);
            player.SetInventory();
        }
        public void EndMatch()         // Finishes the match
        {
            MatchInProgress = false;
        }
        public void Victory(Character enemy)      // You win the fight
        {
            if (enemy.Hp <= 0)
            {
                Console.Clear();
                _screen.Victory();
                EndMatch();
            }
        }
        public void Defeat(Player player)     // You lose the fight
        {
            if (player.Hp <= 0)
            {
                Console.Clear();
                _screen.Defeat();
                EndMatch();
            }
        }
    }
}
