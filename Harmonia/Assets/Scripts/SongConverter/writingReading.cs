using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class writingReading : MonoBehaviour
{
    [SerializeField]
    private TextAsset testSong;
    [SerializeField] private GameObject testSpawnObject; //if you don't want to test spawning, comment this out
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
            yield return new WaitForSeconds(.5f);
            if(int.Parse(newNotesList[whichNote]) >= 0 && int.Parse(newNotesList[whichNote]) <= 50){
                whereToSpawnX = -5;
            }
            else if(int.Parse(newNotesList[whichNote]) >= 51 && int.Parse(newNotesList[whichNote]) <= 60){
                whereToSpawnX = -3;
            }
            else if(int.Parse(newNotesList[whichNote]) >= 61 && int.Parse(newNotesList[whichNote]) <= 70){
                whereToSpawnX = -1;
            }
            else if(int.Parse(newNotesList[whichNote]) >= 71 && int.Parse(newNotesList[whichNote]) <= 80){
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
        //string nameOfMidi = MidiPlayerTK.MidiFileLoader.MPTK_MidiName.midiNameToPlay;
        //print(MidiPlayerTK.MidiFileLoader.MPTK_MidiName);
        //string nameToWriteTo = MidiPlayerTK.MidiFileLoader.nameOfMidi;
        //print("Ran write to file function");
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
