using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{

    [SerializeField]
    [Range(0.1f, 10f)]
    public float gameSpeed = 1f;

    [SerializeField]
    public int pointsPerBlockDestroyed = 0;

    [SerializeField]
    public TextMeshProUGUI scoreText;

    [SerializeField]
    public int currentScore = 0;


    private void Awake()
    {
        int count = FindObjectsOfType<GameSession>().Length;
        if (count > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void ResetScore()
    {
        Destroy(gameObject);
    }
}
