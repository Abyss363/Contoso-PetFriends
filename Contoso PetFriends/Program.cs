namespace Contoso_PetFriends
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
                // the ourAnimals array will store the following: 
                string animalSpecies = "";
                string animalID = "";
                string animalAge = "";
                string animalPhysicalDescription = "";
                string animalPersonalityDescription = "";
                string animalNickname = "";

                // variables that support data entry
                int maxPets = 8;
                int petAge;
                bool validEntry = false;
                int assigned = 0;
                string? readResult;
                string? readResult2;
                string menuSelection = "";

                // array used to store runtime data, there is no persisted data
                string[,] ourAnimals = new string[maxPets, 6];

                // create some initial ourAnimals array entries
                for (int i = 0; i < maxPets; i++)
                {
                    switch (i)
                    {
                        case 0:
                            animalSpecies = "dog";
                            animalID = "d1";
                            animalAge = "2";
                            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
                            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
                            animalNickname = "lola";
                            break;

                        case 1:
                            animalSpecies = "dog";
                            animalID = "d2";
                            animalAge = "9";
                            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
                            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
                            animalNickname = "loki";
                            break;

                        case 2:
                            animalSpecies = "cat";
                            animalID = "c3";
                            animalAge = "1";
                            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
                            animalPersonalityDescription = "friendly";
                            animalNickname = "Puss";
                            break;

                        case 3:
                            animalSpecies = "cat";
                            animalID = "c4";
                            animalAge = "";
                            animalPhysicalDescription = "";
                            animalPersonalityDescription = "";
                            animalNickname = "";
                            break;

                        default:
                            animalSpecies = "";
                            animalID = "";
                            animalAge = "";
                            animalPhysicalDescription = "";
                            animalPersonalityDescription = "";
                            animalNickname = "";
                            break;

                    }


                    ourAnimals[i, 0] = "ID #: " + animalID;
                    ourAnimals[i, 1] = "Species: " + animalSpecies;
                    ourAnimals[i, 2] = "Age: " + animalAge;
                    ourAnimals[i, 3] = "Nickname: " + animalNickname;
                    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
                    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
                    Console.WriteLine();
                }

                do
                {
                    // display the top-level menu options

                    Console.Clear();

                    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
                    Console.WriteLine(" 1. List all of our current pet information");
                    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
                    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
                    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
                    Console.WriteLine(" 5. Edit an animal’s age");
                    Console.WriteLine(" 6. Edit an animal’s personality description");
                    Console.WriteLine(" 7. Display all cats with a specified characteristic");
                    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
                    Console.WriteLine();
                    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        menuSelection = readResult.ToLower();
                    }

                    /* Console.WriteLine($"You selected menu option {menuSelection}.");
                    Console.WriteLine("Press the Enter key to continue");

                    // pause code execution
                    readResult = Console.ReadLine(); */

                    switch (menuSelection)
                    {
                        case "1":
                            //List all of our current pet information
                            for (int i = 0; i < maxPets; i++)
                            {
                                if (ourAnimals[i, 0] != "ID #: ")
                                {
                                    for (int j = 0; j < 6; j++)
                                    {
                                        Console.WriteLine(ourAnimals[i, j]);
                                    }
                                }
                            }
                            Console.WriteLine("Press Enter to Continue");
                            readResult = Console.ReadLine();
                            break;

                        case "2":
                            //Add a new animal friend to the ourAnimals array
                            string anotherPet = "y";
                            int petCount = 0;

                            for (int i = 0; i < maxPets; i++)
                            {
                                if (ourAnimals[i, 0] != "ID #: ")
                                {
                                    petCount++;
                                }

                            }

                            if (petCount < maxPets)
                            {
                                Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {maxPets - petCount} more.");
                            }

                            while (anotherPet == "y" && petCount < maxPets)
                            {


                                do
                                {
                                    Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                                    readResult = Console.ReadLine();

                                    if (readResult != "null")
                                    {
                                        animalSpecies = readResult.ToLower();
                                        if (animalSpecies != "dog" && animalSpecies != "cat")
                                        {
                                            validEntry = false;
                                        }
                                        else
                                        {
                                            validEntry = true;
                                        }
                                    }


                                }
                                while (validEntry == false);

                                animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

                                do
                                {

                                    Console.WriteLine("Enter the pet's age or '?' if unknown");
                                    readResult = Console.ReadLine();

                                    if (readResult != null)
                                    {
                                        animalAge = readResult;
                                        if (animalAge != "?")
                                        {
                                            validEntry = int.TryParse(animalAge, out petAge);
                                        }
                                        else
                                        {
                                            validEntry = true;
                                        }
                                    }

                                }
                                while (validEntry == false);

                                do
                                {
                                    Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                                    readResult = Console.ReadLine();

                                    if (readResult != null)
                                    {
                                        animalPhysicalDescription = readResult.ToLower();
                                        if (animalPhysicalDescription == "")
                                        {
                                            animalPhysicalDescription = "tbd";
                                        }
                                    }
                                }
                                while (animalPhysicalDescription == "");

                                do
                                {
                                    Console.WriteLine("Enter a description of the pet's personality (likes, dislikes, tricks, energy level)");
                                    readResult = Console.ReadLine();

                                    if (readResult != null)
                                    {
                                        animalPersonalityDescription = readResult.ToLower();
                                        if (animalPersonalityDescription == "")
                                        {
                                            animalPersonalityDescription = "tbd";
                                        }
                                    }
                                }
                                while (animalPersonalityDescription == "");

                                do
                                {
                                    Console.WriteLine("Enter a nickname for the pet");
                                    readResult = Console.ReadLine();

                                    if (readResult != null)
                                    {
                                        animalNickname = readResult.ToLower();
                                        if (animalNickname == "")
                                        {
                                            animalNickname = "tbd";
                                        }
                                    }
                                }
                                while (animalNickname == "");

                                ourAnimals[petCount, 0] = "ID #: " + animalID;
                                ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                                ourAnimals[petCount, 2] = "Age: " + animalAge;
                                ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                                ourAnimals[petCount, 4] = "Physical Description: " + animalPhysicalDescription;
                                ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;

                                petCount++;

                                if (petCount < maxPets)
                                {
                                    Console.WriteLine("Do you want to add another pet? (y/n)");

                                    do
                                    {
                                        readResult = Console.ReadLine();
                                        if (readResult != null)
                                        {
                                            anotherPet = readResult.ToLower();
                                        }
                                    }
                                    while (anotherPet != "y" && anotherPet != "n");
                                }
                            }

                            if (petCount >= maxPets)
                            {
                                Console.WriteLine("We have reached the limits on the number of pets we can manage.");
                                Console.WriteLine("Press Enter to Continue");
                                readResult = Console.ReadLine();
                            }

                            break;

                        case "3":
                            //Ensure animal ages and physical descriptions are complete
                            for (int i = 0; i < maxPets; i++)
                            {
                                if (ourAnimals[i, 0] != "ID #: ")
                                {
                                    if (ourAnimals[i, 2] == "Age: " && ourAnimals[i, 4] == "Physical description: ")
                                    {
                                        assigned++;
                                        Console.WriteLine($"{ourAnimals[i, 0]} has not been assigned age and physical description.");

                                        do
                                        {
                                            do
                                            {
                                                Console.WriteLine("PLease enter value for age:");
                                                readResult = Console.ReadLine();

                                                if (readResult != null)
                                                {
                                                    animalAge = readResult.Trim().ToLower();
                                                    if (int.TryParse(animalAge, out petAge))
                                                    {
                                                        validEntry = true;
                                                        ourAnimals[i, 2] = "Age: " + animalAge;
                                                    }
                                                    else
                                                    {
                                                        validEntry = false;
                                                    }

                                                }
                                            }
                                            while (validEntry == false);

                                            do
                                            {
                                                Console.WriteLine("Please enter physical description");
                                                readResult2 = Console.ReadLine();

                                                if (readResult2 != null && readResult2.Length != 0)
                                                {
                                                    assigned--;
                                                    animalPhysicalDescription = readResult2;
                                                    validEntry = true;
                                                    ourAnimals[i, 4] = "Physical Description: " + animalPhysicalDescription;
                                                }
                                                else
                                                {
                                                    validEntry = false;
                                                }
                                            }
                                            while (validEntry == false);
                                        }
                                        while (validEntry == false);

                                    }
                                    else if (ourAnimals[i, 2] == "Age: ")
                                    {
                                        assigned++;
                                        do
                                        {
                                            Console.WriteLine("PLease enter value for age:");
                                            readResult = Console.ReadLine();

                                            if (readResult != null)
                                            {
                                                animalAge = readResult.Trim().ToLower();
                                                if (int.TryParse(animalAge, out petAge))
                                                {
                                                    assigned--;
                                                    validEntry = true;
                                                    ourAnimals[i, 2] = "Age: " + animalAge;
                                                }
                                                else
                                                {
                                                    validEntry = false;
                                                }

                                            }
                                        }
                                        while (validEntry == false);
                                    }
                                    else if (ourAnimals[i, 4] == "Physical description: ")
                                    {
                                        assigned++;
                                        do
                                        {
                                            Console.WriteLine("Please enter physical description");
                                            readResult2 = Console.ReadLine();

                                            if (readResult2 != null && readResult2.Length != 0)
                                            {
                                                assigned--;
                                                animalPhysicalDescription = readResult2;
                                                validEntry = true;
                                                ourAnimals[i, 4] = "Physical Description: " + animalPhysicalDescription;
                                            }
                                            else
                                            {
                                                validEntry = false;
                                            }
                                        }
                                        while (validEntry == false);
                                    }
                                }


                            }

                            if (assigned == 0)
                            {
                                Console.WriteLine("All data requirements have been met.");
                            }

                            Console.WriteLine("Press Enter to Continue");
                            readResult = Console.ReadLine();
                            break;

                        case "4":
                            //Ensure animal nicknames and personality descriptions are complete
                            for (int i = 0; i < maxPets; i++)
                            {
                                if (ourAnimals[i, 0] != "ID #: ")
                                {
                                    if (ourAnimals[i, 3] == "Nickname: " && ourAnimals[i, 5] == "Personality: ")
                                    {
                                        assigned++;
                                        Console.WriteLine($"{ourAnimals[i, 0]} has not been assigned nickname and personality description.");

                                        do
                                        {
                                            do
                                            {
                                                Console.WriteLine("PLease enter nickname:");
                                                readResult = Console.ReadLine();

                                                if (readResult != null && readResult.Length != 0)
                                                {
                                                    assigned--;
                                                    animalNickname = readResult.Trim();
                                                    validEntry = true;
                                                    ourAnimals[i, 3] = "Nickname: " + animalNickname;
                                                }
                                                else
                                                {
                                                    validEntry = false;
                                                }
                                            }
                                            while (validEntry == false);

                                            do
                                            {
                                                Console.WriteLine("Please enter personality description");
                                                readResult2 = Console.ReadLine();

                                                if (readResult2 != null && readResult2.Length != 0)
                                                {
                                                    animalPersonalityDescription = readResult2.Trim();
                                                    validEntry = true;
                                                    ourAnimals[i, 5] = "Personality Description: " + animalPersonalityDescription;
                                                }
                                                else
                                                {
                                                    validEntry = false;
                                                }
                                            }
                                            while (validEntry == false);
                                        }
                                        while (validEntry == false);

                                    }
                                    else if (ourAnimals[i, 3] == "Nickname: ")
                                    {
                                        assigned++;
                                        do
                                        {
                                            Console.WriteLine("PLease enter nickname:");
                                            readResult = Console.ReadLine();

                                            if (readResult != null && readResult.Length != 0)
                                            {
                                                assigned--;
                                                animalNickname = readResult.Trim();
                                                validEntry = true;
                                                ourAnimals[i, 3] = "Nickname: " + animalNickname;
                                            }
                                            else
                                            {
                                                validEntry = false;
                                            }
                                        }
                                        while (validEntry == false);
                                    }
                                    else if (ourAnimals[i, 5] == "Personality: ")
                                    {
                                        assigned++;
                                        do
                                        {
                                            Console.WriteLine("Please enter personality description");
                                            readResult2 = Console.ReadLine();

                                            if (readResult2 != null && readResult2.Length != 0)
                                            {
                                                assigned--;
                                                animalPersonalityDescription = readResult2.Trim();
                                                validEntry = true;
                                                ourAnimals[i, 5] = "Personality Description: " + animalPersonalityDescription;
                                            }
                                            else
                                            {
                                                validEntry = false;
                                            }
                                        }
                                        while (validEntry == false);
                                    }
                                }


                            }

                            if (assigned == 0)
                            {
                                Console.WriteLine("All data requirements have been met.");
                            }

                            Console.WriteLine("Press Enter to Continue");
                            readResult = Console.ReadLine();
                            break;

                        case "5":
                            //Edit an animals age

                            for (int i = 0; i < maxPets; i++)
                            {
                                if (ourAnimals[i, 0] != "ID #: ")
                                {
                                    Console.WriteLine(ourAnimals[i, 0]);
                                    Console.WriteLine(ourAnimals[i, 2]);
                                }
                            }
                            Console.WriteLine("PLease enter the ID of the pet who's age you want to change");
                            readResult = Console.ReadLine();
                            petAge = 0;


                            if (readResult != null && readResult.Length == 2)
                            {
                                for (int i = 0; i < maxPets; i++)
                                {
                                    if (ourAnimals[i, 0].Contains(readResult))
                                    {
                                        Console.WriteLine($"Please enter the new age for ID: {ourAnimals[i, 0]}");
                                        readResult = Console.ReadLine();

                                        if (readResult != null && int.TryParse(readResult, out petAge))
                                        {
                                            animalAge = readResult;
                                            ourAnimals[i, 2] = "Age: " + animalAge;
                                        }
                                    }
                                }
                            }

                            Console.WriteLine("Press Enter to Continue");
                            readResult = Console.ReadLine();
                            break;

                        case "6":
                            //Edit an animal's personality description
                            for (int i = 0; i < maxPets; i++)
                            {
                                if (ourAnimals[i, 0] != "ID #: ")
                                {
                                    Console.WriteLine(ourAnimals[i, 0]);
                                    Console.WriteLine(ourAnimals[i, 5]);
                                }
                            }
                            Console.WriteLine("PLease enter the ID of the pet who's age you want to change");
                            readResult = Console.ReadLine();


                            if (readResult != null && readResult.Length == 2)
                            {
                                for (int i = 0; i < maxPets; i++)
                                {
                                    if (ourAnimals[i, 0].Contains(readResult))
                                    {
                                        Console.WriteLine($"Please enter the new personality description for ID: {ourAnimals[i, 0]}");
                                        readResult = Console.ReadLine();

                                        if (readResult != null)
                                        {
                                            animalPersonalityDescription = readResult;
                                            ourAnimals[i, 5] = "Personality Description: " + animalPersonalityDescription;
                                        }
                                    }
                                }
                            }
                            Console.WriteLine("Press Enter to Continue");
                            readResult = Console.ReadLine();
                            break;

                        case "7":
                            //Display all cats with a specific characteristics

                            Console.WriteLine("Please enter the characteristics you want to search for (cats):");
                            readResult = Console.ReadLine();


                            for (int i = 0; i < maxPets; i++)
                            {
                                if (ourAnimals[i, 4].Contains(readResult) || ourAnimals[i, 5].Contains(readResult))
                                {
                                    if (ourAnimals[i, 1].Contains("cat"))
                                    {
                                        for (int j = 0; j < 6; j++)
                                        {
                                            Console.WriteLine(ourAnimals[i, j]);
                                        }
                                    }

                                }
                            }

                            Console.WriteLine("Press Enter to Continue");
                            readResult = Console.ReadLine();
                            break;

                        case "8":
                            //Display all dogs with a specified characteristics
                            Console.WriteLine("Please enter the characteristics you want to search for (dogs):");
                            readResult = Console.ReadLine();


                            for (int i = 0; i < maxPets; i++)
                            {
                                if (ourAnimals[i, 4].Contains(readResult) || ourAnimals[i, 5].Contains(readResult))
                                {
                                    if (ourAnimals[i, 1].Contains("dog"))
                                    {
                                        for (int j = 0; j < 6; j++)
                                        {
                                            Console.WriteLine(ourAnimals[i, j]);
                                        }
                                    }

                                }
                            }
                            Console.WriteLine("Press Enter to Continue");
                            readResult = Console.ReadLine();
                            break;
                    }
                }
                while (menuSelection != "exit");
            }
        };
        }
  
