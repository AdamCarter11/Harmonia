using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fade : MonoBehaviour
{
    public GameObject mozart;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeOut(15f));
    }

    IEnumerator FadeOut(float speed)
    {
        Renderer renderer = mozart.transform.GetComponent<Renderer>();
        Color matColor = renderer.material.color;
        float alpha = renderer.material.color.a;

        while (renderer.material.color.a > 0f)
        {
            alpha -= Time.deltaTime / speed;
            renderer.material.color = new Color(matColor.r, matColor.g, matColor.b, alpha);
            yield return null;
        }
        renderer.material.color = new Color(matColor.r, matColor.g, matColor.b, 0f);
    }
}
