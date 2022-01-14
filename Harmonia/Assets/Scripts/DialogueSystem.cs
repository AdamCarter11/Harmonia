using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DialogueSystem : MonoBehaviour
{
    private void Awake() {
        StartCoroutine(dialogueSequence());
    }

    private IEnumerator dialogueSequence(){
        for(int i = 0; i < transform.childCount; i++){
            Deactivate();
            transform.GetChild(i).gameObject.SetActive(true);
            yield return new WaitUntil(()=>transform.GetChild(i).GetComponent<TalkingScene>().finished);
        }
    }

    private void Deactivate(){
        for(int i = 0; i < transform.childCount; i++){
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}