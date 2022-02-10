using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class writingReading : MonoBehaviour
{
    private int whichNote;
    private string[] newNotesList;
    private float[] sequence;
    private float prev;
    private float current;
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
    private TextAsset songText;
    private TextAsset sequenceText;
    public static int bpm;
    private float BPM;
    private bool dontSpawn;
    private float prevVal;
    private float max;
    private float min;
    private float interval;
    // Start is called before the first frame update
    public void setUp(TextAsset text, TextAsset seq, float val)
    {
        whichNote = 0;
        newNotesList = ReadFromFile(text);
        sequence = ReadFromFile2(seq);
        BPM = val;
        max = getMax(newNotesList);
        min = getMin(newNotesList);
        interval = (max - min) / 5;
        StartCoroutine(spawnNote());
    }
    
    public float getMax(string[] seq)
    {
        float maxVal = float.Parse(seq[0]);
        for (int i = 0; i < seq.Length; i++)
        {
            if (float.Parse(seq[i]) > maxVal)
            {
                maxVal = float.Parse(seq[i]);
            }
        }
        return maxVal;
    }

    public float getMin(string[] seq)
    {
        float minVal = float.Parse(seq[0]);
        for (int i = 0; i < seq.Length; i++)
        {
            if (float.Parse(seq[i]) < minVal)
            {
                minVal = float.Parse(seq[i]);
            }
        }
        return minVal;
    }

    IEnumerator spawnNote()
    {
        while (whichNote <= newNotesList.Length)
        {
            if (whichNote == 0)
            {
                dontSpawn = false;
                prevVal = sequence[whichNote];
                yield return new WaitForSeconds(sequence[whichNote]);
            }
            else if (whichNote < newNotesList.Length)
            {
                if (sequence[whichNote] == sequence[whichNote - 1])
                {
                    dontSpawn = true;
                }
                else if (sequence[whichNote] - sequence[whichNote - 1] < 0.1 && dontSpawn == false)
                {
                    if (float.Parse(newNotesList[whichNote]) - float.Parse(newNotesList[whichNote - 1]) < interval)
                    {
                        dontSpawn = true;
                    }
                    else
                    {
                        dontSpawn = false;
                    }
                }
                else
                {
                    dontSpawn = false;
                    yield return new WaitForSeconds(sequence[whichNote] - prevVal);
                    prevVal = sequence[whichNote];
                }
            }
            else if (whichNote >= newNotesList.Length)
            {
                dontSpawn = true;
            }

            if (!dontSpawn)
            {
                if (int.Parse(newNotesList[whichNote]) >= min && int.Parse(newNotesList[whichNote]) < min + interval)
                {
                    whereToSpawnX = whereToSpawnX1.position.x;
                    whatToSpawn = Note1;
                }
                else if (int.Parse(newNotesList[whichNote]) >= min + interval && int.Parse(newNotesList[whichNote]) < min + (interval * 2))
                {
                    whereToSpawnX = whereToSpawnX2.position.x;
                    whatToSpawn = Note2;
                }
                else if (int.Parse(newNotesList[whichNote]) >= min + (interval * 2) && int.Parse(newNotesList[whichNote]) < min + (interval * 3))
                {
                    whereToSpawnX = whereToSpawnX3.position.x;
                    whatToSpawn = Note3;
                }
                else if (int.Parse(newNotesList[whichNote]) >= min + (interval * 3) && int.Parse(newNotesList[whichNote]) < min + (interval * 4))
                {
                    whereToSpawnX = whereToSpawnX4.position.x;
                    whatToSpawn = Note4;
                }
                else
                {
                    whereToSpawnX = whereToSpawnX5.position.x;
                    whatToSpawn = Note5;
                }
                GameObject newObject = Instantiate(whatToSpawn, new Vector3(whereToSpawnX, 6, 0), Quaternion.identity);
                newObject.GetComponent<HitNotes>().setBPM(BPM);
            }
            whichNote++;
            print(whichNote);
        }
    }

    public static void WriteToFile(string whatToWrite)
    {
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
    public static string[] ReadFromFile(TextAsset path)
    {
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
        bpm = int.Parse(notes[notes.Length - 2]);
        print("BPM: " + bpm); //-2 cause there is an extra newline at the end of the file
        return notes;
    }

    public static float[] ReadFromFile2(TextAsset path)
    {
        string[] seq1 = path.text.Split('\n');
        float[] seq = new float[seq1.Length];
        for (int i = 0; i < seq1.Length; i++)
        {
            Debug.Log(float.Parse(seq1[i]));
            seq[i] = float.Parse(seq1[i]);
        }
        return seq;
    }

    public void endCoroutine()
    {
        StopAllCoroutines();
    }
}
