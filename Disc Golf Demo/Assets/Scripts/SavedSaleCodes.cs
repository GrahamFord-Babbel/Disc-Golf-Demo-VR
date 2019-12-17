using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


public class SavedSaleCodes : MonoBehaviour
{

    public static SavedSaleCodes instance;

    public static string currentCode;
    public string[] acceptableCodes;
    public string[] usedCodes;
    public List<string> usedCodesList;
    public List<string> acceptableCodesList;

    //for choosing which number to appear
    public int randomCodeNumber;

    //activates Code selection process
    public bool gameOver;

    private void Awake()
    {
            //check if this is the first instance of this script, it not, destroy itself
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this.gameObject);
                print("Codes Destroyed");
                return;
            }

        DontDestroyOnLoad(this.gameObject);

    }

    private void Start()
    {
        //turning this off to prevent "replay" populating new code issue
        gameOver = false;
            
            //instantiate Arrays
            usedCodes = new string[] { };

            acceptableCodes = new string[] { "Vulture1", "Innova2", "Dynamic3", "Latitude645","Discmania6","Gateway7","Westside8", "Millenium9","Legacy10","Prodigy11","MVP12","Discraft13","Legacy14","Vibram15","Pridiscus16","ABC17","DGA18","Daredevil19","Ching20","Crosslap21","UB22","Aerobie23","RIP24","Discwing25","Lightning26","DGK27","Kastaplast28","Wham-O27","Quest28","Salient29","MVP30" }; //make these codes into names of frisbees? 1 2 3 - old style: "3QemV" 

        //set USED array values to previously used in last game
        usedCodes = PlayerPrefsX.GetStringArray("usedCodes");
            
            
            //make USED Arrays into Lists
            usedCodesList = usedCodes.ToList();
           
    }

    // Update is called once per frame
    void Update()
    {
        //gameOver is activated in the scripts: ReplayButton or DiscRespawn
        if (gameOver)
        {
            //set ACCEPTABLE array to last used values (by GETTING), and convert array to list 
            acceptableCodes = PlayerPrefsX.GetStringArray("acceptableCodes"); // justed added the first part, lets see if that messes things up 9.21
            acceptableCodesList = acceptableCodes.ToList();

            //produce a random code to remove from acceptable list, and add to used list
            randomCodeNumber = UnityEngine.Random.Range(0, acceptableCodesList.Count);

            //convert into LIST, add random from accaptable array
            usedCodesList.Add(acceptableCodes[randomCodeNumber]);

            //then reconvert back into array(remember that one time HPVR ?)
            usedCodes = usedCodesList.ToArray();

            acceptableCodes = acceptableCodesList.Except(usedCodesList).ToArray();

            //save the new arrays
            PlayerPrefsX.SetStringArray("acceptableCodes", acceptableCodes);
            PlayerPrefsX.SetStringArray("usedCodes", usedCodes);

            //confirm pass
            foreach (string i in usedCodes)
            {
                print(i);
            }
            Debug.Log("gameOverSave fully activated");
          

            //disable this, so it only happens once
            gameOver = false;

        }
        
    }

public static void PrintValues(Array myArr, char mySeparator)
    {
        IEnumerator myEnumerator = myArr.GetEnumerator();
        int i = 0;
        int cols = myArr.GetLength(myArr.Rank - 1);
        while (myEnumerator.MoveNext())
       {
        if (i < cols)
         {
            i++;
         }
        else
         {
            Console.WriteLine();
            i = 1;
         }
        Console.Write("{0}{1}", mySeparator, myEnumerator.Current);
       }
    Console.WriteLine();
    }

    public void ClearCodes()
    {
        //resets array to 0
        usedCodes = new string[] { };
        usedCodesList.Clear();

        //refill acceptable Codes
        acceptableCodes = new string[] { "Vulture1", "Innova2", "Dynamic3", "Latitude645", "Discmania6", "Gateway7", "Westside8", "Millenium9", "Legacy10", "Prodigy11", "MVP12", "Discraft13", "Legacy14", "Vibram15", "Pridiscus16", "ABC17", "DGA18", "Daredevil19", "Ching20", "Crosslap21", "UB22", "Aerobie23", "RIP24", "Discwing25", "Lightning26", "DGK27", "Kastaplast28", "Wham-O27", "Quest28", "Salient29", "MVP30" }; //if above edited, edit this too


        //reset the high score
        PlayerPrefs.SetFloat("highScore", 0);

        //saves arrays
        PlayerPrefsX.SetStringArray("usedCodes", usedCodes);
        PlayerPrefsX.SetStringArray("acceptableCodes", acceptableCodes);
    }
}