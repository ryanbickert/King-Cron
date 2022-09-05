using UnityEngine;

public class ReturnJSON : MonoBehaviour
{
    public string playerName;
    public int score;

    public string ConvertToJSON(string player, int scr)
    {
        return JsonUtility.ToJson(this);
    }
}
