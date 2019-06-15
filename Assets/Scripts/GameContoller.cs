using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameContoller : MonoBehaviour
{
    public GameObject original;
    public Sprite[] imgs;
    private Card primeira, segunda;
    public TextMeshProUGUI scoreTexto, tentativasTexto;
    private int score, tentativas;
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
            novaCarta.transform.position = new Vector3(original.transform.position.x + (i * 3), original.transform.position.y+5, original.transform.position.z);
        }
    }

    public void revelaCarta(Card carta)
    {
        if(primeira == null)
        {
            primeira = carta;
        }
        else
        {
            segunda = carta;
            tentativas++;
            tentativasTexto.text = "Tentativas: " + tentativas;
            StartCoroutine(verificaPar());
        }
    }

    public IEnumerator verificaPar()
    {
        if(primeira.getID() == segunda.getID())
        {
            score++;
            scoreTexto.text = "Score: " + score;
            yield return new WaitForSeconds(1f);
            if(score == 4)
            {
                PlayerPrefs.SetInt("Tentativas", tentativas);
                PlayerPrefs.SetInt("Score", score);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        else
        {
            yield return new WaitForSeconds(1f);
            primeira.virar();
            segunda.virar();
        }
        primeira = null;
        segunda = null;
    }

    public Card getSegunda()
    {
        return segunda;
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
