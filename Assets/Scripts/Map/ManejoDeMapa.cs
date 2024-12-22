using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejoDeMapa : MonoBehaviour
{
    public GameObject player;
    public GameObject clouds;
    public GameObject pos0;
    public GameObject pos1;
    public GameObject pos2;
    public GameObject pos3_1;
    public GameObject botonLvl3_1;
    public GameObject pos3_2;
    public GameObject botonLvl3_2;
    public GameObject pos4_1;
    public GameObject botonLvl4_1;
    public GameObject pos4_2;
    public GameObject botonLvl4_2;
    public GameObject pos5_1;
    public GameObject botonLvl5_1;
    public GameObject pos5_2;
    public GameObject botonLvl5_2;
    public GameObject pos5_3;
    public GameObject botonLvl5_3;
    public GameObject pos6_1;
    public GameObject botonLvl6_1;
    public GameObject pos6_2;
    public GameObject botonLvl6_2;
    public GameObject pos6_3;
    public GameObject botonLvl6_3;
    public GameObject posboss;
    public GameObject botonboss;


    public int posicionmapa = 0;

    void Start()
    {
        //posicionmapa = 0;
        posicionmapa = GameController.Instance.mapPos;
        switch (posicionmapa)
        {
                case 0:
                if (player != null && pos0 != null)
                {
                    player.transform.position = pos0.transform.position;
                    MoverClouds();
                }
                DesactivarBotonesPorTag("lvl2");
                DesactivarBotonesPorTag("lvl3");
                DesactivarBotonesPorTag("lvl4");
                DesactivarBotonesPorTag("lvl5");
                DesactivarBotonesPorTag("lvl6");
                DesactivarBotonesPorTag("boss");
                break;

            case 1:
                if (player != null && pos1 != null)
                {
                    player.transform.position = pos1.transform.position;
                    MoverClouds();
                }
                DesactivarBotonesPorTag("lvl1");
                DesactivarBotonesPorTag("lvl3");
                DesactivarBotonesPorTag("lvl4");
                DesactivarBotonesPorTag("lvl5");
                DesactivarBotonesPorTag("lvl6");
                DesactivarBotonesPorTag("boss");
                break;
            case 2:
                if (player != null && pos2 != null)
                {
                    player.transform.position = pos2.transform.position;
                    MoverClouds();

                }
                DesactivarBotonesPorTag("lvl1");
                DesactivarBotonesPorTag("lvl2");
                DesactivarBotonesPorTag("lvl4");
                DesactivarBotonesPorTag("lvl5");
                DesactivarBotonesPorTag("lvl6");
                DesactivarBotonesPorTag("boss");
                break;
            case 3:
                if (player != null && pos3_1 != null)
                {
                    player.transform.position = pos3_1.transform.position;
                    MoverClouds();

                }
                DesactivarBotonesPorTag("lvl1");
                DesactivarBotonesPorTag("lvl2");
                DesactivarBotonesPorTag("lvl3");
                DesactivarBotonesPorTag("lvl5");
                DesactivarBotonesPorTag("lvl6");
                DesactivarBotonesPorTag("boss");
                //Specifically deactivates the other route
                if (botonLvl4_2 != null)
                {
                    botonLvl4_2.SetActive(false);
                }
                break;
            case 4:
                if (player != null && pos3_2 != null)
                {
                    player.transform.position = pos3_2.transform.position;
                    MoverClouds();
                }
                DesactivarBotonesPorTag("lvl1");
                DesactivarBotonesPorTag("lvl2");
                DesactivarBotonesPorTag("lvl3");
                DesactivarBotonesPorTag("lvl5");
                DesactivarBotonesPorTag("lvl6");
                DesactivarBotonesPorTag("boss");
                //Specifically deactivates the other route
                if (botonLvl4_1 != null)
                {
                    botonLvl4_1.SetActive(false);
                }
                break;
            case 5:
                if (player != null && pos4_1 != null)
                {
                    player.transform.position = pos4_1.transform.position;
                    MoverClouds();
                }
                DesactivarBotonesPorTag("lvl1");
                DesactivarBotonesPorTag("lvl2");
                DesactivarBotonesPorTag("lvl3");
                DesactivarBotonesPorTag("lvl4");
                DesactivarBotonesPorTag("lvl6");
                DesactivarBotonesPorTag("boss");
                //Specifically deactivates the other route
                if (botonLvl5_3 != null)
                {
                    botonLvl5_3.SetActive(false);
                }
                break;
            case 6:
                if (player != null && pos4_2 != null)
                {
                    player.transform.position = pos4_2.transform.position;
                    MoverClouds();
                }
                DesactivarBotonesPorTag("lvl1");
                DesactivarBotonesPorTag("lvl2");
                DesactivarBotonesPorTag("lvl3");
                DesactivarBotonesPorTag("lvl4");
                DesactivarBotonesPorTag("lvl6");
                DesactivarBotonesPorTag("boss");
                //Specifically deactivates the other route
                if (botonLvl5_1 != null)
                {
                    botonLvl5_1.SetActive(false);
                }
                break;
            case 7:
                if (player != null && pos5_1 != null)
                {
                    player.transform.position = pos5_1.transform.position;
                    MoverClouds();
                }
                DesactivarBotonesPorTag("lvl1");
                DesactivarBotonesPorTag("lvl2");
                DesactivarBotonesPorTag("lvl3");
                DesactivarBotonesPorTag("lvl4");
                DesactivarBotonesPorTag("lvl5");
                DesactivarBotonesPorTag("boss");
                //Specifically deactivates the other route
                if (botonLvl6_2 != null)
                {
                    botonLvl6_2.SetActive(false);
                }
                //Specifically deactivates the other route
                if (botonLvl6_3 != null)
                {
                    botonLvl6_3.SetActive(false);
                }
                break;
            case 8:
                if (player != null && pos5_2 != null)
                {
                    player.transform.position = pos5_2.transform.position;
                    MoverClouds();
                }
                DesactivarBotonesPorTag("lvl1");
                DesactivarBotonesPorTag("lvl2");
                DesactivarBotonesPorTag("lvl3");
                DesactivarBotonesPorTag("lvl4");
                DesactivarBotonesPorTag("lvl5");
                DesactivarBotonesPorTag("boss");
                //Specifically deactivates the other route
                if (botonLvl6_1 != null)
                {
                    botonLvl6_1.SetActive(false);
                }
                //Specifically deactivates the other route
                if (botonLvl6_3 != null)
                {
                    botonLvl6_3.SetActive(false);
                }
                break;
            case 9:
                if (player != null && pos5_3 != null)
                {
                    player.transform.position = pos5_3.transform.position;
                    MoverClouds();
                }
                DesactivarBotonesPorTag("lvl1");
                DesactivarBotonesPorTag("lvl2");
                DesactivarBotonesPorTag("lvl3");
                DesactivarBotonesPorTag("lvl4");
                DesactivarBotonesPorTag("lvl5");
                DesactivarBotonesPorTag("boss");
                          //Specifically deactivates the other route
                if (botonLvl6_2 != null)
                {
                    botonLvl6_2.SetActive(false);
                }
                //Specifically deactivates the other route
                if (botonLvl6_1 != null)
                {
                    botonLvl6_1.SetActive(false);
                }
                break;
            case 10:
                if (player != null && pos6_1 != null)
                {
                    player.transform.position = pos6_1.transform.position;
                    clouds.SetActive(false);
                }
                DesactivarBotonesPorTag("lvl1");
                DesactivarBotonesPorTag("lvl2");
                DesactivarBotonesPorTag("lvl3");
                DesactivarBotonesPorTag("lvl4");
                DesactivarBotonesPorTag("lvl5");
                DesactivarBotonesPorTag("lvl6");
                break;
            case 11:
                if (player != null && pos6_2 != null)
                {
                    player.transform.position = pos6_2.transform.position;
                    clouds.SetActive(false);
                }
                DesactivarBotonesPorTag("lvl1");
                DesactivarBotonesPorTag("lvl2");
                DesactivarBotonesPorTag("lvl3");
                DesactivarBotonesPorTag("lvl4");
                DesactivarBotonesPorTag("lvl5");
                DesactivarBotonesPorTag("lvl6");

                break;
            case 12:
                if (player != null && pos6_3 != null)
                {
                    player.transform.position = pos6_3.transform.position;
                    clouds.SetActive(false);
                }
                DesactivarBotonesPorTag("lvl1");
                DesactivarBotonesPorTag("lvl2");
                DesactivarBotonesPorTag("lvl3");
                DesactivarBotonesPorTag("lvl4");
                DesactivarBotonesPorTag("lvl5");
                DesactivarBotonesPorTag("lvl6");
                break;
        }
    }

    void DesactivarBotonesPorTag(string tag)
    {
        GameObject[] botones = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject boton in botones)
        {
            boton.SetActive(false);
        }
    }

void MoverClouds()
{
    Vector3 playerPos = player.transform.position;

    Vector3 cloudsnewpos = clouds.transform.position;
    cloudsnewpos.x = playerPos.x;

    clouds.transform.position = cloudsnewpos;

    Debug.Log($"PlayerPos: {playerPos}");
    Debug.Log($"CloudPos: {clouds.transform.position}");
}

}

