using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public GameObject cardBack;
    private int id;
    private void OnMouseDown()
    {
        if (cardBack.activeSelf)
        {
            cardBack.SetActive(false);
        }
    }
    public void changeSprite(int id, Sprite img)
    {
        this.id = id;
        GetComponent<SpriteRenderer>().sprite = img;
    }
}
