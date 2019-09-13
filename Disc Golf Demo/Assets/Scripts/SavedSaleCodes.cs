using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


public class SavedSaleCodes : MonoBehaviour
{
    // Start is called before the first frame update

    public static string currentCode;
    public string[] acceptableCodes;
    public string[] usedCodes;
    public List<string> usedCodesList;
    public List<string> acceptableCodesList;

    //to destroy once game fully run through
    public bool nowDestroy;

    //for choosing which number to appear
    public int randomCodeNumber;

    //activates Code selection process
    public bool gameOver;

    private void Start()
    {
        if (!nowDestroy)
        {
            DontDestroyOnLoad(gameObject);
        }

        if (nowDestroy)
        {
            Destroy(gameObject);
        }

        //turning this off to prevent "replay" populating new code issue
        gameOver = false;
            
            //instantiate Arrays
            usedCodes = new string[] { };

            acceptableCodes = new string[] { "X5eR6", "FrTs9", "7OipQ", "2tHji", "3QemV" };

            //set USED array values to previously used in last game
    
            usedCodes = PlayerPrefsX.GetStringArray("usedCodes");
            
            
            //make USED Arrays into Lists
            usedCodesList = usedCodes.ToList();
            

        //Updated();
    }

    // Update is called once per frame
    void Update()
    {

        if (gameOver)
        {
            //set ACCEPTABLE array to last used values (by GETTING), and convert array to list - FIND OUT WHERE THIS IS TAKING SO LONG, HOW TO AVOID (CREATE A WAIT?)
            PlayerPrefsX.GetStringArray("acceptableCodes");
            acceptableCodesList = acceptableCodes.ToList();

            //produce a random code to remove from acceptable list, and add to used list
            randomCodeNumber = UnityEngine.Random.Range(0, acceptableCodesList.Count);
            //print(randomCodeNumber);

            //confirm not pass
            Debug.Log("gameOverSave not fully activated");

 
            //convert into LIST, add random from accaptable array
            usedCodesList.Add(acceptableCodes[randomCodeNumber]);

            //then reconvert back into array(remember that one time HPVR ?)
            usedCodes = usedCodesList.ToArray();

            acceptableCodes = acceptableCodesList.Except(usedCodesList).ToArray();

            // Displays the values of the Array.
            //Console.WriteLine("The target Array contains the following (before and after copying):");
            //PrintValues(usedCodes, ' ');

            // Copies the source Array to the target Array, starting at index 1. TRASH because copies whole array, not just 1
            //acceptableCodes.CopyTo(usedCodes, 1);

            // Displays the values of the Array.
            //PrintValues(usedCodes, ' ');


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

        //saves array
        PlayerPrefsX.SetStringArray("usedCodes", usedCodes);
    }
}