using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoodColor : MonoBehaviour
{
    public void UpdateGameMood(Globals.GameMood mood)
    {
        this.GetComponent<TextMeshProUGUI>().color = mood == Globals.GameMood.Day || mood == Globals.GameMood.Fire
            ? new Color(13f / 255f, 84f / 255f, 72f / 255f)
            : new Color(255f / 255f, 255f / 255f, 255f / 255f);
    }
}
