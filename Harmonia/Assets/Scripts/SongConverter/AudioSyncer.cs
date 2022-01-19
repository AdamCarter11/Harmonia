using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncer : MonoBehaviour
{
    public float bias;
	public float timeStep;
	public float timeToBeat;
	public float restSmoothTime;

	private float m_previousAudioValue;
	private float m_audioValue;
	private float m_timer;

	protected bool m_isBeat;

    [SerializeField]
    private float maxVal = 0;

    public virtual void OnBeat(){
        //Debug.Log("beat");
        m_timer = 0;
        m_isBeat = true;
    }
    public virtual void OnUpdate(){
        m_previousAudioValue = m_audioValue;
		m_audioValue = SongReader.spectrumVal;
        //print("M prev audio: " + m_previousAudioValue + " Audio val: " + m_audioValue);

        if(maxVal < m_previousAudioValue){
            maxVal = m_previousAudioValue;
            print(maxVal);
        }

		// if audio value went below the bias during this frame
		if (m_previousAudioValue > bias &&
			m_audioValue <= bias)
		{
			// if minimum beat interval is reached
			if (m_timer > timeStep)
				OnBeat();
		}

		// if audio value went above the bias during this frame
		if (m_previousAudioValue <= bias &&
			m_audioValue > bias)
		{
			// if minimum beat interval is reached
			if (m_timer > timeStep)
				OnBeat();
		}

		m_timer += Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        OnUpdate();
    }
}
