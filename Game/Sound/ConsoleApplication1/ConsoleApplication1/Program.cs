using System.IO;
using System.Media;
using System;
using System.Text;
using System.Threading;

class Program
{
    static void Main()
    {
        
       // Create new SoundPlayer in the using statement.
        using (SoundPlayer player = new SoundPlayer("C:\\Sound.wav"))
        {
            // Use PlaySync to load and then play the sound.
            // ... The program will pause until the sound is complete.
            player.PlaySync();
        }
         FileStream fs = new FileStream(@"c:\Sound2.wav",FileMode.Open, FileAccess.Read);
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer(fs);
            sp.PlaySync();

    }
}