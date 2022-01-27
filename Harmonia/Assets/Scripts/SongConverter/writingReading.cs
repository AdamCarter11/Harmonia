using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class writingReading : MonoBehaviour
{
    [SerializeField]
    private TextAsset testSong;
    [SerializeField]
    private GameObject testSpawnObject;
    private int whichNote = 0;
    private string[] newNotesList;
    private int whereToSpawnX;
    public static int bpm;
    // Start is called before the first frame update
    void Start()
    {
        newNotesList = ReadFromFile(testSong);
        StartCoroutine(spawnNote());
    }

    // Update is called once per frame
    void Update()
    {
        if(whichNote >= newNotesList.Length){
            StopCoroutine(spawnNote());
        }
    }
    IEnumerator spawnNote(){
        while(true){
            yield return new WaitForSeconds(1f);
            if(int.Parse(newNotesList[whichNote]) >= 0 && int.Parse(newNotesList[whichNote]) <= 30){
                whereToSpawnX = -5;
            }
            else if(int.Parse(newNotesList[whichNote]) >= 31 && int.Parse(newNotesList[whichNote]) <= 60){
                whereToSpawnX = -3;
            }
            else if(int.Parse(newNotesList[whichNote]) >= 61 && int.Parse(newNotesList[whichNote]) <= 90){
                whereToSpawnX = -1;
            }
            else if(int.Parse(newNotesList[whichNote]) >= 91 && int.Parse(newNotesList[whichNote]) <= 120){
                whereToSpawnX = 1;
            }
            else{
                whereToSpawnX = 3;
            }
            Instantiate(testSpawnObject, new Vector3(whereToSpawnX, 5, 0), Quaternion.identity);
            whichNote++;
            print(whichNote);
        }
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
        bpm = int.Parse(notes[notes.Length-2]);
        print("BPM: " + bpm); //-2 cause there is an extra newline at the end of the file
        return notes;
    }

}
