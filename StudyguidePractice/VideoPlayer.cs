using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyguidePractice
{
    public class VideoPlayer: IPlayable
    {
        public void Play() 
        {
            Console.WriteLine("Video is playing");
        }
        public void Pause() 
        {
            Console.WriteLine("Video is paused");
        }
    }
}
