using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public Transform startPoint;
    public bool isAnomaly;
    public int currentHour = 0; // เริ่มตอนเที่ยงคืน
    public TextMeshProUGUI timeText;
    public GameObject winPanel;
    public GameObject startPanel;
    public AnomalyManager anomalyManager;
    public ParticleSystem winConfetti;
    public AudioSource confettiSound;
    public AudioSource menuMusic;
    public AudioSource rainSound;
    public GameObject pausePanel;
    bool isPaused = false;

    CharacterController controller;

    void GenerateAnomaly()
    {
        isAnomaly = Random.value > 0.5f;

        if (isAnomaly)
        {
            anomalyManager.SetAnomaly();
        }

        if (isAnomaly)
            Debug.Log("มี anomaly");
        else
            Debug.Log("ไม่มี anomaly");
    }

    public void StartGame()
    {
        startPanel.SetActive(false);

        rainSound.Play();
        menuMusic.Stop();

        anomalyManager.ResetObjects();
        GenerateAnomaly();

        ResetPlayer();

        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        UpdateTimeUI(); // อัพเดตเวลา
    }

    void Start()
    {
        controller = player.GetComponent<CharacterController>();

        currentHour = 0;
        UpdateTimeUI();

        GenerateAnomaly();

        Time.timeScale = 0f;

        startPanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        UpdateTimeUI(); // แสดงเวลาเริ่ม
    }

    void Update()
    {
        if (startPanel.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC pressed");
        }
    }

    public void PauseGame()
    {
        Debug.Log("PauseGame called");

        pausePanel.SetActive(true);
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        isPaused = true;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        isPaused = false;
    }

    public void ChooseCorrect()
    {
        if (isAnomaly)
        {
            Debug.Log("ถูก!");
            NextLevel();
        }
        else
        {
            Debug.Log("ผิด! ย้อนกลับ");
            ResetPlayer();
        }
    }

    public void ChooseWrong()
    {
        if (!isAnomaly)
        {
            Debug.Log("ถูก!");
            NextLevel();
        }
        else
        {
            Debug.Log("ผิด! ย้อนกลับ");
            ResetPlayer();
        }
    }

    public void NextLevel()
    {
        currentHour++;
        UpdateTimeUI();

        Debug.Log("เวลา: " + currentHour);

        // ชนะตอน 06:00
        if (currentHour >= 6)
        {
            Debug.Log("ชนะแล้ว!");

            winPanel.SetActive(true);
            Time.timeScale = 0f;

            WinGame();

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            return;
        }

        controller.enabled = false;
        player.position = startPoint.position;
        controller.enabled = true;

        anomalyManager.ResetObjects();
        GenerateAnomaly();
    }

    public void WinGame()
    {
        winConfetti.Play();
        confettiSound.Play();
    }

    public void ResetPlayer()
    {
        currentHour = 0; // รีเซ็ตกลับเที่ยงคืน
        Debug.Log("เริ่มใหม่ เวลา: 00");

        UpdateTimeUI();

        controller.enabled = false;
        player.position = startPoint.position;
        controller.enabled = true;

        anomalyManager.ResetObjects();
        GenerateAnomaly();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        currentHour = 0;

        winPanel.SetActive(false);

        anomalyManager.ResetObjects();
        ResetPlayer();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void BackToMenu()
    {
        winPanel.SetActive(false);
        startPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    void UpdateTimeUI()
    {
        timeText.text = currentHour.ToString("00") + ":00";
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}