using UnityEngine;
using TMPro;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;
    public TextMeshProUGUI pauseText;
    
    void Start()
    {
        
        if (pauseText != null)
        {
            pauseText.gameObject.SetActive(false);
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    
    void PauseGame()
{
    Time.timeScale = 0f;
    isPaused = true;

    if (pauseText != null)
    {
        pauseText.gameObject.SetActive(true);
    }
}

    
    void ResumeGame()
{
    Time.timeScale = 1f;
    isPaused = false;

    if (pauseText != null)
    {
        pauseText.gameObject.SetActive(false);
    }
}

}