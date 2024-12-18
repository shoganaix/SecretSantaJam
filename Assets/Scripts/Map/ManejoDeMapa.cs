using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejoDeMapa : MonoBehaviour
{
    public GameObject jugador;
    public GameObject pos0;
    public GameObject pos1;
    public GameObject pos2_1;
    public GameObject pos2_2;
    public GameObject pos3_1;
    public GameObject pos3_2;
    public GameObject pos4_1;
    public GameObject pos4_2;
    public GameObject pos4_3;
    public GameObject pos5_1;
    public GameObject pos5_2;
    public GameObject pos5_3;

    public int posicionmapa = 0;

    void Start()
    {
        switch (posicionmapa)
        {
            case 0:
                if (jugador != null && pos0 != null)
                {
                    jugador.transform.position = pos0.transform.position;
                }
                DesactivarBotonesPorTag("lvl2");
                DesactivarBotonesPorTag("lvl3");
                DesactivarBotonesPorTag("lvl4");
                DesactivarBotonesPorTag("lvl5");
                break;

            case 1:
                if (jugador != null && pos1 != null)
                {
                    jugador.transform.position = pos1.transform.position;
                }
                DesactivarBotonesPorTag("lvl1");
                DesactivarBotonesPorTag("lvl3");
                DesactivarBotonesPorTag("lvl4");
                DesactivarBotonesPorTag("lvl5");
                break;
            case 2:
                if (jugador != null && pos2_1 != null)
                {
                    jugador.transform.position = pos2_1.transform.position;
                }
                DesactivarBotonesPorTag("lvl2");
                DesactivarBotonesPorTag("lvl1");
                DesactivarBotonesPorTag("lvl4");
                DesactivarBotonesPorTag("lvl5");
                break;
            case 3:
                if (jugador != null && pos2_2 != null)
                {
                    jugador.transform.position = pos2_2.transform.position;
                }
                DesactivarBotonesPorTag("lvl2");
                DesactivarBotonesPorTag("lvl1");
                DesactivarBotonesPorTag("lvl4");
                DesactivarBotonesPorTag("lvl5");
                break;
            case 4:
                if (jugador != null && pos3_1 != null)
                {
                    jugador.transform.position = pos3_1.transform.position;
                }
                DesactivarBotonesPorTag("lvl2");
                DesactivarBotonesPorTag("lvl3");
                DesactivarBotonesPorTag("lvl1");
                DesactivarBotonesPorTag("lvl5");
                break;
            case 5:
                if (jugador != null && pos3_2 != null)
                {
                    jugador.transform.position = pos3_2.transform.position;
                }
                DesactivarBotonesPorTag("lvl2");
                DesactivarBotonesPorTag("lvl3");
                DesactivarBotonesPorTag("lvl1");
                DesactivarBotonesPorTag("lvl5");
                break;
            case 6:
                if (jugador != null && pos4_1 != null)
                {
                    jugador.transform.position = pos4_1.transform.position;
                }
                DesactivarBotonesPorTag("lvl2");
                DesactivarBotonesPorTag("lvl3");
                DesactivarBotonesPorTag("lvl4");
                DesactivarBotonesPorTag("lvl1");
                break;
            case 7:
                if (jugador != null && pos4_2 != null)
                {
                    jugador.transform.position = pos4_2.transform.position;
                }
                DesactivarBotonesPorTag("lvl2");
                DesactivarBotonesPorTag("lvl3");
                DesactivarBotonesPorTag("lvl4");
                DesactivarBotonesPorTag("lvl1");
                break;
            case 8:
                if (jugador != null && pos4_3 != null)
                {
                    jugador.transform.position = pos4_3.transform.position;
                }
                DesactivarBotonesPorTag("lvl2");
                DesactivarBotonesPorTag("lvl3");
                DesactivarBotonesPorTag("lvl4");
                DesactivarBotonesPorTag("lvl1");
                break;
            case 9:
                if (jugador != null && pos5_1 != null)
                {
                    jugador.transform.position = pos5_1.transform.position;
                }
                DesactivarBotonesPorTag("lvl2");
                DesactivarBotonesPorTag("lvl3");
                DesactivarBotonesPorTag("lvl4");
                DesactivarBotonesPorTag("lvl5");
                DesactivarBotonesPorTag("lvl1");
                break;
            case 11:
                if (jugador != null && pos5_2 != null)
                {
                    jugador.transform.position = pos5_2.transform.position;
                }
                DesactivarBotonesPorTag("lvl2");
                DesactivarBotonesPorTag("lvl3");
                DesactivarBotonesPorTag("lvl4");
                DesactivarBotonesPorTag("lvl5");
                DesactivarBotonesPorTag("lvl1");
                break;
            case 12:
                if (jugador != null && pos5_3 != null)
                {
                    jugador.transform.position = pos5_3.transform.position;
                }
                DesactivarBotonesPorTag("lvl2");
                DesactivarBotonesPorTag("lvl3");
                DesactivarBotonesPorTag("lvl4");
                DesactivarBotonesPorTag("lvl5");
                DesactivarBotonesPorTag("lvl1");
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
}

