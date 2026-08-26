using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyguidePractice
{
    public class MusicPlayer: IPlayable
    {
        public void Play()
        {
            Console.WriteLine("Playing music...");
        }
        public void Pause() 
        {
            Console.WriteLine("Music paused.");
        }
    }
}
