using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public Player player;

    public StartPoint startPoint;
    public EndPoint endPoint;

    public Text starCountText;

    int starCount = 0;

    void Awake()
    {
        StartGame();
    }

	void Start () {
        Instance = this;
	}
	
	void Update () {
	
	}

    void StartGame()
    {
        player.transform.position = startPoint.transform.position;
    }

    public void EndGame()
    {
        Application.LoadLevel(0);
    }

    public void RewardStar()
    {
        starCount++;
        starCountText.text = "Stars: " + starCount;
    }
}
