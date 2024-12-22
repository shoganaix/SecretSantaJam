using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealScene : MonoBehaviour
{
    public int MoreHeal;
    public GameObject player;
    public GameObject imageFade;

    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Level6_2")
        {
            GameController.Instance.mapPos = 11;
        }
        StartCoroutine(healCoroutine());
    }

    private IEnumerator healCoroutine()
    {
        float elapsedTime = 0f;
        SpriteRenderer image = imageFade.GetComponent<SpriteRenderer>(); 
        image.color = new Color(image.color.r, image.color.g, image.color.b, 255);
        while (elapsedTime < 1.5f)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / 1.5f);
            image.color = new Color( image.color.r, image.color.g, image.color.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
        yield return new WaitForSeconds(1.5f);

        player.GetComponent<CharacterStats>().Heal(100);
        yield return new WaitForSeconds(1.5f);

        elapsedTime = 0f;
        while (elapsedTime < 1.5f)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / 1.5f);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        image.color = new Color(image.color.r, image.color.g, image.color.b, 255);
        changeScene();
    }

    public void changeScene()
    {
        GameController.Instance.PlayerMaxLife += MoreHeal;
        GameController.Instance.PlayerLife = GameController.Instance.PlayerMaxLife;
        SceneManager.LoadScene("Map");
    }
}
