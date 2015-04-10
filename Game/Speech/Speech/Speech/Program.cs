using System;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;
using System.Speech.Recognition;

class Program
{
    static void Main()
    {
        SpeechSynthesizer say = new SpeechSynthesizer();
        say.Rate = -2;
        say.SetOutputToDefaultAudioDevice();
        say.Volume = 50;        
        say.Speak("Hello");       
    }
}