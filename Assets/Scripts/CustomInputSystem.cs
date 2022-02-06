using UnityEngine;

public class CustomInputSystem : MonoBehaviour
{
    public static int horizontal;
    public static int vertical;
    public static bool action;

    public static void SetHorizontal(int set)
    {
        horizontal = set;
    }

    public static void SetVertical(int set)
    {
        vertical = set;
    }

    public static void SetAction(bool set)
    {
        action = set;
    }
}
