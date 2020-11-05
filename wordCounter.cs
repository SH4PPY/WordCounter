using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;//used for uploading a file
//for pop-up window PLEASE NOTE Project Reference "System.Windows.Forms" may have to be added//using System.Windows.Forms;//Forms doesn't seem to work in Mono/mcs compiler...
// Version 1
namespace WordCounter
{
	class Program
	{
		// Version 1
		//Function to exit counter
		static void exitFunction()
		{
			Console.WriteLine("Thank you for using the text analyser, have a nice day!");
			Environment.Exit(0);
		}
		//Function for processing the text
		static void processText(string userText)
		{
			int numberChar = 0, wordCount = 1, numberSentence = 0, numberPhrase = 0, numberLines = 1;
			decimal op1, op2, averageWord1, averageWord2;
			//Caracter Count
			foreach (char c in userText)
			{
				if (c != ' ' && c != '\'' && c != '"' && c != ',' && c != '.' && c != '?' && c != '!' && c != ';' && c != ':')
					numberChar++;
				//Console.WriteLine("Count characters loop test: {0}", numberChar);
			}
			Console.WriteLine("\nNumber of characters: {0}", numberChar);
			//Word Count
			foreach (char c in userText)
			{
				string s1 = c.ToString();
				if (c == ' ' || s1 == "\n")
					wordCount++;
				//Console.WriteLine("Count word loop test: {0}", wordCount);
			}
			Console.WriteLine("\nNumber of words: {0}", wordCount);
			//Sentence Count
			foreach (char c in userText)
			{
				if (c == '.' || c == '?' || c == '!')
					numberSentence++;
				//Console.WriteLine("Count sentence loop test: {0}", numberSentence);
			}
			Console.WriteLine("\nThe number of sentences is: {0}", numberSentence);
			//Phrase Count
			foreach (char c in userText)
			{
				if (c == ',' || c == '.' || c == '?' || c == '!' || c == ';' || c == ':')
					numberPhrase++;
				//Console.WriteLine("Count phrase loop test: {0}", numberPhrase);
			}
			Console.WriteLine("\nThe number of Phrases or clauses is: {0}", numberPhrase);
			//Line Count
			foreach (char c in userText)
			{
				string s2 = c.ToString();
				if (s2 == "\n")
					numberLines++;
				//Console.WriteLine("Count lines loop test: {0}", numberLines);
			}
			Console.WriteLine("\nThe number of Lines is: {0}", numberLines);

			//Calculate average word length
			op1 = numberChar;
			op2 = wordCount;
			averageWord1 = (op1 / op2);
			averageWord2 = Decimal.Round(averageWord1, 2);
			Console.WriteLine("\nThe average word length is: {0} letters", averageWord2);
			//Writing to a text file
			//Words longer than 7 letters would be filtered out here...
			//or not...
		}
		static void Main(string[] args)
		{
			//Introducing the global variables
			string userOption = "", tryAgain = "", userText = "", fileToUse = "";

			//Start point and intro to the program...
			Console.WriteLine("\n-----------------------------------------------");
			Console.WriteLine("|----------------Text Analyser----------------|");
			Console.WriteLine("-----------------------------------------------");
		begin1:
			Console.WriteLine("\nDo you want to enter the text or upload a file?");
			Console.WriteLine("\n\nEnter 1 for typing the text yourself\n\n\tOR\n\nEnter 2 to upload preselected text");
			Console.WriteLine("\n\tOR\n\nEnter 3 to upload your own file");
			Console.WriteLine("\n\nEnter Q at any time to quit\n");
			userOption = Console.ReadLine();

			//Begin Switch Statement for selecting text...
			switch (userOption)
			{
				//Self entered text here...
				#region
				case "1":
					//Local variables
					//string userText1 = "";
					//user entered text intro
					Console.WriteLine("\nPlease type you text that you want to be analysed");
					Console.WriteLine("\nThe text will be saved in a file called \"countableTextUserOutput.txt\" in this location -\n\t\"..\\countableTextUserOutput.txt\"");
					Console.WriteLine("\nPlease end a sentence with either\n a full stop \".\",\n a question mark \"?\"\n or an exclamation mark \"!\"\n");
					//user enters text...
					userText = (Console.ReadLine());
					if (userText == "Q" || userText == "q")
					{
						exitFunction();
					}
					else
					//Counting words and removing non-essential characters and punctuation etc...
					{
						processText(userText);
						//Writing to a text file
						File.WriteAllText(@"countableTextUserOutput.txt", userText);
					}
					break;
					#endregion
				//Pre-selected text here...
				#region
				case "2":
				begin2:
					//Local variables
					//string userText2 = "", fileToUse;
					//If the user uploads the preselected text file
					Console.WriteLine("You chose the preselected text:");
					try
					{
						fileToUse = @"countableTextPreselectedFile.txt";
						userText = File.ReadAllText(fileToUse);
					}
					catch (Exception NoFileFound)
					{
						//MessageBox.Show(NoFileFound.Message,
						//	"Error Found - Incorrect File Location",
						//	MessageBoxButtons.OK,
						//	MessageBoxIcon.Error);
						//Console.WriteLine("\nPlease Re-enter file location");
						Console.WriteLine(NoFileFound.Message, "Error Found - Incorrect File Location");
						Console.WriteLine("\nPlease Re-enter file location");
						goto begin2;
					}
					Console.WriteLine("\nThe text will be saved in a file called \"countableTextPreselectedFileOutput.txt\" in this location -\n\t\"..\\countableTextPreselectedFileOutput.txt\"");
					Console.WriteLine("Contents of uploaded file is:\n");
					Console.WriteLine("-----------------------------\n");
					Console.WriteLine("{0}", userText);
					Console.WriteLine("\n-----------------------------");
					//Counting words and removing non-essential characters and punctuation etc...
					{
						processText(userText);
						//Writing to a text file
						File.WriteAllText(@"countableTextPreselectedFileOutput.txt", userText);
						//Words longer than 7 letters would be filtered out and saved in the following file here...
						//or not
					}
					break;
					#endregion
				//The following is an outline of what would be used for inputing a user selected file...
				#region
				case "3":
					//Local variables
					//string userText3 = "", fileToUse;
				//If the user uploads their own file text file
				begin3:
					Console.WriteLine("Please enter the location of the file that you want to upload\n\nEnter Q to quit\n\nEnter R to return to the beginning\n");
					try
					{
						fileToUse = Console.ReadLine();
						if (fileToUse == "Q" || fileToUse == "q")
						{
							Environment.Exit(0);
						}
						else if (fileToUse == "R" || fileToUse == "r")
						{
							goto begin1;
						}
						else
							userText = File.ReadAllText(fileToUse);
					}
					catch (Exception NoFileFound)
					{
						//MessageBox.Show(NoFileFound.Message,
						//	"Error Found - Incorrect File Location",
						//	MessageBoxButtons.OK,
						//	MessageBoxIcon.Error);
						//Console.WriteLine("\nPlease Re-enter file location");
						Console.WriteLine(NoFileFound.Message, "Error Found - Incorrect File Location");
						Console.WriteLine("\nPlease Re-enter file location");
						goto begin3;
					}
					Console.WriteLine("\nThe text will be saved in a file called \"countableTextUserChosenFileOutPut.txt\" in this location -\n\t\"..\\countableTextUserChosenFileOutput.txt\"");
					Console.WriteLine("Contents of uploaded file is: \n{0}", userText);
					//Counting words and removing non-essential characters and punctuation etc...
					{
						processText(userText);
						//Writing to a text file
						File.WriteAllText(@"countableTextUserChosenFileOutput.txt", userText);
						//Words longer than 7 letters would be filtered out and saved in the following file here...
						//or not
					}
					break;
					#endregion
				//Exit options...
				#region
				case "Q":
				case "q":
					exitFunction();
					break;
				//If the user doesn't select 1 or 2 or 3 or Q...
				default:
					//Tell user they're an idiot...
					Console.WriteLine("Incorrect input\nPlease try again...\n");
					goto begin1;
				#endregion
				//Start again
			}
			//Switch to ask the user to try again...
			#region
		begin4:
			Console.WriteLine("\nDo you want to try again? Enter Y or N\n");
			tryAgain = Console.ReadLine();			
			switch (tryAgain)
			{
				//lots of options to exit the program...
				case "Q":
				case "q":
				case "N":
				case "n":
				case "":
					exitFunction();
					break;
				//Try again options...
				case "Y":
					goto begin1;
				case "y":
					goto begin1;
				//If the user didn't select Y or N (or indeed y or n)
				default:
					//Tell the user they're an idiot... ...again...
					Console.WriteLine("Incorrect input\nPlease try again...\n");
					goto begin4;
		#endregion
			}
		}
	}
}