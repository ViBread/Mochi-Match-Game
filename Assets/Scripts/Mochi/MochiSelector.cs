using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class MochiSelector : MonoBehaviour
{
    public static MochiSelector instance;

    public GameObject[] Mochi;
    public GameObject[] NoPhysicsMochi;
    public int HighestStartingIndex = 3;

    [SerializeField] private Image _nextMochiImage;
    [SerializeField] private Sprite[] _mochiSprites;
    
    public GameObject NextMochi { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        PickNextMochi();
    }

    public GameObject PickRandomMochiForThrow()
    {
        int randomIndex = Random.Range(0, HighestStartingIndex + 1);

        if (randomIndex < NoPhysicsMochi.Length)
        {
            GameObject randomMochi = NoPhysicsMochi[randomIndex];
            return randomMochi;
        }

        return null;
    }

    public void PickNextMochi()
    {
        int randomIndex = Random.Range(0, HighestStartingIndex + 1);

        if(randomIndex < Mochi.Length)
        {
            GameObject nextMochi = NoPhysicsMochi[randomIndex];
            NextMochi = nextMochi;

            _nextMochiImage.sprite = _mochiSprites[randomIndex];
        }
    }
}
