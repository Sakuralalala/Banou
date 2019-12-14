using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[AddComponentMenu("Listener/Speaker")]
public class Speaker : MonoBehaviour
{
    public AudioSource audioSource;

    public FloatEvent onSpeak;

    [Tooltip("0 = left Channel, 1 = right Channel")]
    public int channel = 0;
    public FFTWindow fTWindow;
    public int outputFrequencyIndex = 3;
    private float[] data = new float[64];

    private void Update()
    {
        audioSource.GetSpectrumData(data, channel, fTWindow);
        onSpeak?.Invoke(data[outputFrequencyIndex]);
    }

}
