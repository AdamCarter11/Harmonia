using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FreqReader : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float[] spectrum = new float[1024];
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        for (int i = 1; i < spectrum.Length - 1; i++)
        {
            Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
            Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
            //print(spectrum[i]);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.blue);
        }
        print(spectrum[50]);        

        /*
        float[] curSpectrum = new float[1024];
	    AudioListener.GetSpectrumData (curSpectrum, 0, FFTWindow.BlackmanHarris);

	    float targetFrequency = 234f;
	    float hertzPerBin = (float)AudioSettings.outputSampleRate / 2f / 1024;
	    int targetIndex = (int)(targetFrequency / hertzPerBin);

	    string outString = "";
	    for (int i = targetIndex - 3; i <= targetIndex + 3; i++) {
		    //outString += string.Format("| Bin {0} : {1}Hz : {2} |   ", i, i * hertzPerBin, curSpectrum[i]);
            print("HTZ: " + i*hertzPerBin);
	    }
        //Debug.Log (outString);
        */
    }
}
