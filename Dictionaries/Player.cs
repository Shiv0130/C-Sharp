using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ════════════════════════════════════════════════════════════
//  EXERCISE 3 - Gaming Leaderboard
//  Data Structure used:
//      Dictionary<string, Player>
//      KEY   = username  (e.g. "Shivaar")
//      VALUE = a Player object holding their username and score
//
//  Think of it like this:
//      "Shivaar"  → Player { Username="Shivaar",  Score=9999 }
//      "ProGamer" → Player { Username="ProGamer", Score=8200 }
//      "NightOwl" → Player { Username="NightOwl", Score=3100 }
//      "CodeKing" → Player { Username="CodeKing", Score=7650 }
//
//  Username is the KEY because:
//    - Usernames are unique per player (no two players share one)
//    - We will look up and update players BY their username
// ════════════════════════════════════════════════════════════

namespace Dictionaries
{
    // ── Player class ─────────────────────────────────────────
    // Blueprint for every player on the leaderboard.
    // Each player has a Username and a Score (int, whole number).
    public class Player
    {
        public string Username { get; set; }  // e.g. "Shivaar"
        public int Score { get; set; }  // e.g. 9999

        // Constructor – runs when you do new Player(...)
        // Stores the username and starting score in the properties above
        public Player(string username, int score)
        {
            Username = username;
            Score = score;
        }
    }
}