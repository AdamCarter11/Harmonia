using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class writingReading : MonoBehaviour
{
    [SerializeField]
    private TextAsset testSong;
    // Start is called before the first frame update
    void Start()
    {
        string[] newNotesList = ReadFromFile(testSong);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void WriteToFile(string whatToWrite){
        print("Ran write to file function");
            string path = "Assets/test.txt";

            //Write some text to the test.txt file
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine(whatToWrite);
            writer.Close();
    }
    public static string[] ReadFromFile(TextAsset path){
        /*
        print("Called reader function");
        StreamReader reader = new StreamReader(path); 
        Debug.Log(reader.ReadToEnd());
        reader.Close();
        */
        //print(path.text);
        string[] notes = path.text.Split('\n');
        print("notes length: " + notes.Length);
        print("First note: " + notes[0]);
        print("BPM: " + notes[notes.Length-2]); //-2 cause there is an extra newline at the end of the file
        return notes;
    }

}
