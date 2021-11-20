using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager singleton;

    public static GameManager Singleton
    {
        get
        {
            if (singleton == null)
            {
                singleton = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
            }
            return singleton;
        }
    }

    [SerializeField] private float sensitivity;
    [SerializeField] private TMP_Text xInputText;
    [SerializeField] private TMP_Text yInputText;
    [SerializeField] private TMP_Text sensitivityText;
    [SerializeField] private TMP_Text optionsText;
    [SerializeField] private Canvas pauseCanvas;
    [SerializeField] private Slider sensitivitySlider;
    [SerializeField] private Slider orbSizeSlider;
    [SerializeField] private TMP_Text orbSizeText;
    [SerializeField] private bool paused;

    public bool Paused => paused;
    public float Sensitivity => sensitivity;
    private bool PauseKeyPressedWhileUnpaused => Input.GetKeyDown(KeyCode.P) && !paused && Cursor.lockState == CursorLockMode.Locked;
    private bool ResumeKeyPressedWhilePaused => Input.GetKeyDown(KeyCode.O) && paused && Cursor.lockState == CursorLockMode.None;
    private string CurrentOptionsText => paused ? "Press O to resume." : "Press P to pause.";

    private void PauseGame() => paused = true;
    private void ResumeGame() => paused = false;
    private void LockCursor() => Cursor.lockState = CursorLockMode.Locked;
    private void UnlockCursor() => Cursor.lockState = CursorLockMode.None;
    private void SetPauseMenuVisibility() => pauseCanvas.enabled = paused;
    private void SetXInputText() => xInputText.text = Input.GetAxisRaw("Mouse X").ToString();
    private void SetYInputText() => yInputText.text = Input.GetAxisRaw("Mouse Y").ToString();
    private void SetSensitivityText() => sensitivityText.text = sensitivity.ToString("0.00");
    private void SetOrbSizeText() => orbSizeText.text = orbSizeSlider.value.ToString();
    private void SetOptionsText() => optionsText.text = CurrentOptionsText;
    private void SetSensitivityToSliderValue() => sensitivity = sensitivitySlider.value;
    public void ResetGame() => SceneManager.LoadScene(0);
    public void QuitGame() => Application.Quit();

    private void Start()
    {
        LockCursor();
    }

    void Update()
    {
        if (PauseKeyPressedWhileUnpaused)
        {
            UnlockCursor();

            PauseGame();

        }

        if (ResumeKeyPressedWhilePaused)
        {
            LockCursor();

            ResumeGame();
        }

        SetPauseMenuVisibility();

        SetXInputText();

        SetYInputText();

        SetSensitivityText();

        SetOrbSizeText();

        SetOptionsText();

        SetSensitivityToSliderValue();
    }
}
