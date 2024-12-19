using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EndGame : MonoBehaviour
{
    public List<GameObject> endGameObjects;
    public int currentlevel = 1;

    private void Awake()
    {
        endGameObjects.ForEach(i => i.SetActive(false));
    }

    private void OnTriggerEnter(Collider other)
    {
        Player p = other.transform.GetComponent<Player>();
        if( p != null)
        {
            SaveManager.Instance.SaveLastLevel(currentlevel);
            Debug.Log("Entrou no Collider do save");
            ShowEndGame();
        }        
    }

    private void ShowEndGame()
    {
        endGameObjects.ForEach(i => i.SetActive(true));
        foreach (var i in endGameObjects)
        {
            i.SetActive(true);
            i.transform.DOScale(0, .2f).SetEase(Ease.OutBack).From();
        }
    }


}
