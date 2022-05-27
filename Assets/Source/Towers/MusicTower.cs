using Melanchall.DryWetMidi.MusicTheory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTower : BaseTower
{
    [SerializeField] private NoteName noteName;
    [SerializeField] private int soundKey;

    private void Awake()
    {
        MusicController.Instance.onNote += Attack;
        MusicController.Instance.IncreaseVolume(soundKey);
    }
}
