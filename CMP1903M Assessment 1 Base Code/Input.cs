using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class Input
    {
        //Handles the text input for Assessment 1
        string text = "";
        
        //Method: manualTextInput
        //Arguments: none
        //Returns: string
        //Gets text input from the keyboard
        public string manualTextInput()
        {
            //Initialises text
            text = " ";
            //Asks the user to input sentences
            Console.WriteLine("\nPlease enter one or more sentences of text, one at a time.\nEach sentence should end with '.' and the last sentence should end with '.*':");
            //While the user does not have a * at the end it takes the user's input
            while (text[text.Length-1] != '*')
            {
                text += " " + Console.ReadLine();
            }
            //Removes the leading spaces that were added earlier and returns the text
            text = text.Remove(0, 2);
            Console.WriteLine("\n" + text);
            return text;
        }

        //Method: fileTextInput
        //Arguments: string (the file path)
        //Returns: string
        //Gets text input from a .txt file
        public string fileTextInput(string fileName)
        {
            //Checks if the file exists with this name
            while (!File.Exists("../../../" + fileName + ".txt"))
            {
                //If not it asks the user to input again
                Console.WriteLine("File not found, please try again: ");
                fileName = Console.ReadLine();
            }
            //Gets the text from the file and returns it
            text = File.ReadAllText("../../../" + fileName + ".txt");
            Console.WriteLine("\n" + text);
            return text;
        }

        //Method: whichTextInput
        //Arguments: none
        //Returns: string
        //Gets users choice for what input method to use
        public string whichTextInput()
        {
            //Initialises valid as false so the loop is entered
            bool valid = false;
            //Asks user what input mode they want to use
            Console.WriteLine("Which mode (1/2):\n1.Do you want to enter the text via the keyboard?\n2.Do you want to read in the text from a file?");
            string which = Console.ReadLine();
            //Runs while to input is not valid
            while (!valid)
            {
                //If the user chooses 1 it runs manualTextInput
                if (which == "1")
                {
                    return manualTextInput();
                }
                //If the user chooses 2 it runs fileTextInput after asking for the file name
                else if (which == "2")
                {
                    Console.WriteLine("\nPlease enter the file name (without file name extension):");
                    return fileTextInput(Console.ReadLine());
                }
                //If the input is invalid it asks again and will go through the loop again
                else
                {
                    Console.WriteLine("Invalid response, please re-enter (must be 1 or 2)");
                    which = Console.ReadLine();
                }
            }
            //Incase the loop is somehow exited makes sure the method is exited
            return "";
        }
    }
}
