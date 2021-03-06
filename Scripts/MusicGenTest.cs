﻿using UnityEngine;
using System.Collections;

//Require audio to create the animation
[RequireComponent(typeof(AudioSource))]
public class MusicGenTest : MonoBehaviour
{
    //Offset of the bars, greater than 1 for a gap.
    public float offset = 0.1f;
    //Need this value to be a power of 2 because it gets information from spectrogram
    public int powerof2 = 512;
    //How many audio bars to display
    public int LinesToDisplay = 64;
    //multiplier for audio bars
    public float multi;
    //Object you want to be a bar
    public GameObject bar;
    //array of the bars for use later
    private GameObject[] barArray;
    //Start vector
    public Vector3 start = new Vector3(0, 0, 0);
    //private for transform position whilst keeping original coords
    private Vector3 startCopy = new Vector3(0,0,0);
    //choose color
    public Color color = new Color(0, 1, 0);
    //Quartinon for rotation
    public Quaternion barRotate = new Quaternion(0,0,0,0);

    void Start()
    {
        //Init bars
        for (int i = 0; i < LinesToDisplay; i++)
        {
            Instantiate(bar, startCopy, Quaternion.identity);
            startCopy.x += offset;
        }
        //fill array with the bars
        barArray = GameObject.FindGameObjectsWithTag ("AudioBar");
    }

    void Update()
    {
        //get info from audio
        float[] spectrum = new float[powerof2];
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        //reset start vector
        startCopy = start;       

        for (int i = 0; i < LinesToDisplay; i++)
        {
            //change color based on value
            color.r = spectrum[i];
            //Transform position
            barArray[i].transform.position = startCopy;
            //Tranform scale
            barArray[i].transform.localScale = new Vector3(1, spectrum[i] * multi, 0.1f);
            //rotate bar
            barArray[i].transform.rotation = barRotate;
            //color bar
            barArray[i].GetComponent<Renderer>().material.color = color;
            //Offset for position uses
            startCopy.x += offset;
        }
    }
}

