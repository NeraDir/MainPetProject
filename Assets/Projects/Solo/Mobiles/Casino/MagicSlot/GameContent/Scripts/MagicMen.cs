using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMen : MonoBehaviour
{
    [SerializeField]
    private WordContainer[] words;

    [SerializeField]
    private WordContainer[] FreeSpinswWords;

    [SerializeField]
    private GameObject _effect;

    [SerializeField]
    private Transform _spawnPosition;

    [SerializeField]
    private Animator _magAnimator;

    public void SetRandomWild()
    {
        int randomer = Random.Range(1, MagicData.MaxValueChangers);
        for (int i = 0; i < randomer; i++)
        {
            FreeSpinswWords[Random.Range(0, words.Length)].SetParagon(3);
        }
        GameObject spawned = Instantiate(_effect, _spawnPosition);
        spawned.SetActive(true);
        _magAnimator.SetBool("Casting", true);
        Invoke(nameof(SetDefault), 1);
    }

    private void SetDefault() 
    {
        _magAnimator.SetBool("Casting", false);
    }

    public void SetOneRandomWild() 
    {
        words[Random.Range(0, words.Length)].SetParagon(3);
        GameObject spawned = Instantiate(_effect, _spawnPosition);
        spawned.SetActive(true);
        _magAnimator.SetBool("Casting", true);
        Invoke(nameof(SetDefault), 1);
    }
}
