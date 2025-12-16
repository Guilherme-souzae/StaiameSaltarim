using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public static PointsManager Instance;
    
    public int Lives = 3;
    public int Bombs = 3;

    public int Score = 0;
    public int Graze = 0;
    public int Points = 0;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
