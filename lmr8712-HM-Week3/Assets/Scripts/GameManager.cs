using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //create variables
    public static GameManager instance;             //static variable that will hold Singleton
    public Text text;                               // place to store text
    private int score = 0;                          //variable to keep score
    private int highScore = -1;                     //variable to keep track of the high score
    int targetScore = 3;                            //variable that set and stores target score
    int currentLevel = 0;                           //variable for the current level of the game
    
    // Create Constance
    private const string DIR_LOGS = "/Logs";                                    
    private const string FILE_SCORES = DIR_LOGS + "/highScore.txt";             
    private string FILE_PATH_HIGH_SCORES;                                       
    private const string PREF_KEY_HIGH_SCORE = "HighScoreKey";                  
   
    // Allows other places to access and modify the score variable
    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            
            if (score > HighScore)
            {
                HighScore = score;
            }
        }
    }

    // Allows other places to access and modify the highScore variable
    public int HighScore
    {
        get 
        {
            if (highScore < 0)
            {
                if (File.Exists(FILE_PATH_HIGH_SCORES))
                {
                    string fileContents = File.ReadAllText(FILE_PATH_HIGH_SCORES);
                    highScore = Int32.Parse(fileContents);
                }
                else
                {
                    highScore = 1;
                }
            }
            return highScore;
        }
        set
        {
            highScore = value;
            
            if (!File.Exists(FILE_PATH_HIGH_SCORES))
            {
                Directory.CreateDirectory(Application.dataPath + DIR_LOGS);
            }
            File.WriteAllText(FILE_PATH_HIGH_SCORES, highScore + "");
        }
    }
    
    // Called when script instance is being loaded
    void Awake() {   
        // Make a Singleton to prevent more than one instance of an object
        if (instance == null) {                 //if instance hasn't been set
            DontDestroyOnLoad(gameObject);      //don't destroy object when loading new scene
            instance = this;                    //set instance to this object 
        }
        
        else {                                  //if instance is set to an object
            Destroy(gameObject);                //destroy this object
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //Find the path where the highscore data is going to be stored
        FILE_PATH_HIGH_SCORES = Application.dataPath + FILE_SCORES; 
    }

    // Update is called once per frame
    void Update()
    {
        // Modify the text
        text.text = "Score: " + score + "" +
                    "\nHigh Score: " + HighScore;
        
        // Check score to change level
        if (score == targetScore) {                                     //if score equals target score
            currentLevel++;                                             //change the level
            SceneManager.LoadScene(sceneBuildIndex: currentLevel);      //load the scene corresponding to the level
            targetScore += targetScore + targetScore/2;                 //set a new target score
        }
    }
}
