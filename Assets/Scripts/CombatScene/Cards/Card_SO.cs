using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Cards", order = 1)]
public class Card_SO : ScriptableObject
{
    public Sprite sprite;

    public ActionType actionType;
}
