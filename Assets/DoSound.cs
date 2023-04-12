using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoSound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource source;
    public float semitone_offset = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            playSound();
        }
        
    }
    void playSound()
    {
        source.pitch = Mathf.Pow(2f, semitone_offset / 12.0f);
        source.Play();
    }
}
