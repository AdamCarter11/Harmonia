using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkingScene : MonoBehaviour
{
    public AudioSource Pop;
    public bool finished {get; private set;}
    protected IEnumerator WriteText(string input, Text textHolder, float delay){
        Pop.volume = PlayerPrefs.GetFloat("EffectsValue");
        for(int i = 0; i < input.Length; i++){
            textHolder.text += input[i];
            if(Pop != null){
                Pop.Play();
            }
            yield return new WaitForSeconds(delay);

        }
        finished = true;
    }
}
