using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSound : MonoBehaviour
{
    // Start is called before the first frame update
    AudioClip _clip;
    public float frequency = 440;
    void Start()
    {
         
        int samplerate = 44100;
       

        _clip = AudioClip.Create("A440", samplerate, 1, samplerate, false);
        CreateClip(_clip, samplerate, frequency);

        var audioSource = GetComponent<AudioSource>();
        audioSource.clip = _clip;
        audioSource.loop = true;
        audioSource.Play();
    }
    public void PlayClip()
    {
        var audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(_clip);
    }
    public void CancelNoise()
    {
        frequency = 0;
    }

    private void CreateClip(AudioClip clip, int samplerate, float frequency)
    {
        var size = clip.frequency * (int)Mathf.Ceil(clip.length);
        float[] data = new float[size];
        int count = 0;
        while (count < data.Length)
        {
            data[count] = Mathf.Sin(2 * Mathf.PI * frequency * count / samplerate);
            count++;
        }
        clip.SetData(data, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
