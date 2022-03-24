using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class Analyse
    {
        //Handles the analysis of text

        //Method: analyseText
        //Arguments: string
        //Returns: list of integers
        //Calculates and returns an analysis of the text
        public List<int> analyseText(string input)
        {
            //List of integers to hold the first five measurements:
            //1. Number of sentences
            //2. Number of vowels
            //3. Number of consonants
            //4. Number of upper case letters
            //5. Number of lower case letters
            List<int> values = new List<int>();
            List<int> charCount = new List<int>();
            //Initialise all the values in the list to '0'
            for(int i = 0; i<5; i++)
            {
                values.Add(0);
            }
            //Initialise all the values in the list to '0'
            for(int i = 0; i<26; i++)
            {
                charCount.Add(0);
            }
            //Initialise word and longWords
            string word = "";
            string longWords = "";
            //Itterates through each character in the text
            foreach(char c in input)
            {
                //Checks if the character is a fullstop and adds a sentence if it is
                if (c == '.')
                {
                    values[0] += 1;
                }
                //Checks if the character is in the string of vowels
                if ("aeiou".Contains(c.ToString().ToLower()))
                {
                    values[1] += 1;
                }
                //If character is not a vowel but is a letter, it is a consonant
                else if (char.IsLetter(c))
                {
                    values[2] += 1;
                }
                //Checks if the character is uppercase
                if (char.IsUpper(c))
                {
                    values[3] += 1;
                }
                //If character is not uppercase but is a letter, it is lowercase
                else if (char.IsLetter(c))
                {
                    values[4] += 1;
                }
                //If the character is a letter
                if (char.IsLetter(c))
                {
                    //Adds one to the character count list, using the ASCII code of the character to index
                    charCount[Encoding.Default.GetBytes(c.ToString().ToUpper())[0]-65] += 1;
                    //Adds the character to the current word
                    word += c;
                }
                else 
                {
                    //If the current word ends and it is longer than 7 characters it is added to the longword string
                    if (word.Length >= 7)
                    {
                        longWords += " " + word;
                    }
                    //Word is reset to empty
                    word = "";
                }

            }
            //If there are long words to write to the file
            if(longWords.Length > 0)
            {
                //Sets the file name to LongWords relative to the exe file
                string fileName = "../../../LongWords.txt";
                //Checks if the file already exists
                if (!File.Exists(fileName))
                {
                    //If it doesn't it creates the file and closes it
                    var file = File.Create(fileName);
                    file.Close();
                }
                //Writes all the long words to the file and removes the leading space
                File.WriteAllText(fileName, longWords.Remove(0, 1));
            }
            //Adds the character counts to the values so it can all be returned at once
            values.AddRange(charCount);
            return values;
        }
    }
}
