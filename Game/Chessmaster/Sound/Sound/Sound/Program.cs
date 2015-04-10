using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;


class Speech
{
    public static void SayMove()
    {
        using (SpeechSynthesizer say = new SpeechSynthesizer())
        {
            say.SetOutputToDefaultAudioDevice();
            say.Rate = -2;
            say.SelectVoiceByHints(VoiceGender.NotSet);// !!!!!!!!!
            say.Speak("A dictionary is stored as a sequence of text lines containing words and their explanations. Write a program that enters a word and translates it by using the dictionary. Sample dictionary:");
        }
    }

    static void Main()
    {
        SayMove();
    }
}