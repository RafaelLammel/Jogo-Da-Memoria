using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContoller : MonoBehaviour
{
    public GameObject original;
    public Sprite[] imgs;
    // Start is called before the first frame update
    void Start()
    {
        int[] ids = { 0, 0, 1, 1, 2, 2, 3, 3 };
        ids = ShuffleArray(ids);
        original.GetComponent<Card>().changeSprite(ids[0], imgs[ids[0]]);
        for (int i = 1; i < 4; i++)
        {
            GameObject novaCarta = Instantiate(original);
            novaCarta.GetComponent<Card>().changeSprite(ids[i], imgs[ids[i]]);
            novaCarta.transform.position = new Vector3(original.transform.position.x+(i*3),original.transform.position.y,original.transform.position.z);
        }
        for(int i = 0; i < 4; i++)
        {
            GameObject novaCarta = Instantiate(original);
            novaCarta.GetComponent<Card>().changeSprite(ids[i+4], imgs[ids[i+4]]);
            novaCarta.transform.position = new Vector3(original.transform.position.x + (i * 3), original.transform.position.y+6, original.transform.position.z);
        }
    }

    private int[] ShuffleArray(int[] ids)
    {
        int[] shuffled = ids;
        for (int i = 0; i < shuffled.Length; i++)
        { 
            int tmp = shuffled[i];
            int r = Random.Range(i, shuffled.Length);
            shuffled[i] = shuffled[r];
            shuffled[r] = tmp;
        }
        return shuffled;
    }
}
