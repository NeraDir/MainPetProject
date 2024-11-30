using UnityEngine;

public class WordContainer : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _wordsObjects;

    public int _indexOfWord;

    public int _priceOfWord;

    public void SetValue() 
    {
        int randomer = Random.Range(0, 10);
        int randomchance = Random.Range(0, 100);
        if (randomer == 7)
        {
            _indexOfWord = Random.Range(0, _wordsObjects.Length - 1);
        }
        else
        {
            _indexOfWord = Random.Range(0, _wordsObjects.Length - 2);
        }

        foreach (var item in _wordsObjects)
        {
            item.SetActive(false);
        }
        _wordsObjects[_indexOfWord].SetActive(true);

        _priceOfWord = (MagicGameController.MagicBet * (_indexOfWord + 1))/6;
    }



    public void SetParagon(int value)
    {
        int randomer = value;
        _indexOfWord = randomer;

        foreach (var item in _wordsObjects)
        {
            item.SetActive(false);
        }
        _wordsObjects[_indexOfWord].SetActive(true);
        _priceOfWord = (MagicGameController.MagicBet * (_indexOfWord + 1))/6;
    }

    public int GetPrice() 
    {
        return _priceOfWord;
    }

    public int GetWordIndex() 
    {
        return _indexOfWord;
    }
}
