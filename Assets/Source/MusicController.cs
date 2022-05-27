using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MidiFile midiFile;
    private List<double> timeStamps = new List<double>();
    [SerializeField] private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        Debug.Log("Starting game!");
        var notes = midiFile.GetNotes();
        var array = new Note[midiFile.GetNotes().Count];
        notes.CopyTo(array, 0);
        nodeController.SetTimeStamps(array);
        ResumeGame();

        Invoke(nameof(StartAudio), songDelayInSeconds);
    }
    public void SetTimeStamps(Note[] notes)
    {
        for (int i = 0; i < notes.Length; i++)
        {
            Note note = notes[i];

            if (note.NoteName == noteRestriction)
            {
                var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, midiFile.GetTempoMap());
                timeStamps.Add((double)metricTimeSpan.Minutes * 60f + metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f);
                catch (Exception) { }
            }
        }
    }

    public void StartAudio()
    {
        audioSource.Play();
    }
    public double GetAudioSourceTime()
    {
        return (double)audioSource.time;
    }
}
