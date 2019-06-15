using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public GameObject cardBack;
    private int id;
    public GameContoller gc;
    private void OnMouseDown()
    {
        if (cardBack.activeSelf && gc.getSegunda() == null)
        {
            cardBack.SetActive(false);
            gc.revelaCarta(this);
        }
    }
    public void virar()
    {
        cardBack.SetActive(true);
    }
    public int getID()
    {
        return id;
    }
    public void changeSprite(int id, Sprite img)
    {
        this.id = id;
        GetComponent<SpriteRenderer>().sprite = img;
    }
}
