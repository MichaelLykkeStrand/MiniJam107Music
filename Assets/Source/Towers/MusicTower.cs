using Melanchall.DryWetMidi.MusicTheory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTower : BaseTower
{
    [SerializeField] private NoteName noteName;

    private void Awake()
    {
        MusicController.Instance.onNote += Attack;
        MusicController.Instance.IncreaseVolume((int)noteName);
    }
    private void Attack(NoteName noteName)
    {
        base.Attack();
    }
}
