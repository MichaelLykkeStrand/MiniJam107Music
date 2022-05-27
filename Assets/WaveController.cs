using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector3[] spawnpoints;
    MusicController musicController;
    void Start()
    {
        musicController = MusicController.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
