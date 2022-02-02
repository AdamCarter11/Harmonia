using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class writingReading : MonoBehaviour
{
    [SerializeField]
    private TextAsset songText;
    [SerializeField] //private GameObject testSpawnObject; //if you don't want to test spawning, comment this out
    private int whichNote = 0;
    private string[] newNotesList;
    private float whereToSpawnX;
    public Transform whereToSpawnX1;
    public Transform whereToSpawnX2;
    public Transform whereToSpawnX3;
    public Transform whereToSpawnX4;
    public Transform whereToSpawnX5;
    private GameObject whatToSpawn;
    public GameObject Note1;
    public GameObject Note2;
    public GameObject Note3;
    public GameObject Note4;
    public GameObject Note5;
    public static int bpm;
    private float BPM;
    // Start is called before the first frame update
    public void setUp(TextAsset text, float val)
    {
        newNotesList = ReadFromFile(text);
        BPM = val;
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
            if(int.Parse(newNotesList[whichNote]) >= 0 && int.Parse(newNotesList[whichNote]) <= 62){
                whereToSpawnX = whereToSpawnX1.position.x;
                whatToSpawn = Note1;
            }
            else if(int.Parse(newNotesList[whichNote]) >= 63 && int.Parse(newNotesList[whichNote]) <= 68){
                whereToSpawnX = whereToSpawnX2.position.x;
                whatToSpawn = Note2;
            }
            else if(int.Parse(newNotesList[whichNote]) >= 69 && int.Parse(newNotesList[whichNote]) <= 74){
                whereToSpawnX = whereToSpawnX3.position.x;
                whatToSpawn = Note3;
            }
            else if(int.Parse(newNotesList[whichNote]) >= 75 && int.Parse(newNotesList[whichNote]) <= 80){
                whereToSpawnX = whereToSpawnX4.position.x;
                whatToSpawn = Note4;
            }
            else{
                whereToSpawnX = whereToSpawnX5.position.x;
                whatToSpawn = Note5;
            }
            GameObject newObject = Instantiate(whatToSpawn, new Vector3(whereToSpawnX, 6, 0), Quaternion.identity);
            newObject.GetComponent<HitNotes>().setBPM(BPM);
            whichNote++;
            print(whichNote);
        }
    }

    public static void WriteToFile(string whatToWrite){
        //string nameOfMidi = MidiPlayerTK.MidiFileLoader.MPTK_MidiName.midiNameToPlay;
        //print(MidiPlayerTK.MidiFileLoader.MPTK_MidiName);
        string nameToWriteTo = MidiPlayerTK.MidiFileLoader.nameOfMidi;
        //print(nameToWriteTo);
        string nameToWrite = "firstFile";
            string path = "Assets/" + nameToWriteTo + ".txt";

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
