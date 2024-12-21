using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetCardScene : MonoBehaviour
{
    public GameObject imageFade;

    void Start()
    {
        StartCoroutine(initCoroutine());
    }

    private IEnumerator initCoroutine()
    {
        float elapsedTime = 0f;
        SpriteRenderer image = imageFade.GetComponent<SpriteRenderer>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 255);
        while (elapsedTime < 1.5f)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / 1.5f);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }


    private IEnumerator LastCoroutine()
    {
        float elapsedTime = 0f;
        SpriteRenderer image = imageFade.GetComponent<SpriteRenderer>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
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
        GameController.Instance.mapPos++;
        SceneManager.LoadScene("Map");
    }
}
