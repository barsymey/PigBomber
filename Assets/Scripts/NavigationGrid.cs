using UnityEngine;

public class NavigationGrid : MonoBehaviour
{
    private static Grid grid;

    void Awake()
    {
        grid = GetComponent<Grid>();
    }

    public static Grid MainGrid
    {
        get
        {
            return grid;
        }
    }
}
