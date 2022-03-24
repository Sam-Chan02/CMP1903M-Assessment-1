using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class Report
    {
        //Handles the reporting of the analysis
        //Maybe have different methods for different formats of output?
        //eg.   public void outputConsole(List<int>)
        public void outputConsole(List<int> parameters)
        {
            //Outputs a list of all stats of the text
            Console.WriteLine("\n*TestData:\nSentences:\t\t{0}\nTotal Characters:\t{1}\nVowels:\t\t\t{2}\nConsonants:\t\t{3}\nUpper Case:\t\t{4}\nLower Case:\t\t{5}\nCharacter Frequency:", parameters[0], parameters[1] + parameters[2], parameters[1], parameters[2], parameters[3], parameters[4]);
            //Itterates through all the character counts that is after the other stats in the parameter list
            for (int i = 5; i < parameters.Count; i++)
            {
                //Outputs the character using the index to get the character from ASCII code with the frequency of that character
                Console.Write("{0}:{1} ", Convert.ToChar(i + 60).ToString(), parameters[i]);
            }
        }
    }
}
