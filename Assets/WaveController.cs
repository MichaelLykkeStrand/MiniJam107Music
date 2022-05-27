using Melanchall.DryWetMidi.MusicTheory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform[] spawnpoints;
    [SerializeField] private List<Wave> waves;
    MusicController musicController;
    void Start()
    {
        musicController = MusicController.Instance;
        musicController.onNote += Spawn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn(NoteName noteName)
    {

    }
}