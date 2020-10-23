using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GAME_MANAGER : MonoBehaviour
{
    #region Singletone
    public static GAME_MANAGER instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    private int _score;

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        SetStartScore();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            Retry();
    }

    public int GetScore()
    {
        return _score;
    }

    public int GetBestScore()
    {
        return PlayerPrefs.GetInt("BestScore", 0);
    }

    public void SetBestScore(int amount)
    {
        PlayerPrefs.SetInt("BestScore", amount);
    }

    private void SetStartScore()
    {
        _score = 0;
        scoreText.text = "SCORE: " + _score.ToString();
    }

    public void AddScore(int amount)
    {
        _score += amount;
        scoreText.text = "SCORE: " + _score.ToString();
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
