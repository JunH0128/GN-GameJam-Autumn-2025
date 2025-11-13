using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveUIManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private Button startWaveButton;
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private TextMeshProUGUI buttonText;

    private void Start()
    {
        // Make sure button is set up
        if (startWaveButton != null)
        {
            startWaveButton.onClick.AddListener(OnStartWaveClicked);
        }
        
        UpdateUI();
    }

    private void Update()
    {
        UpdateUI();
    }

    private void OnStartWaveClicked()
    {
        if (enemySpawner != null)
        {
            enemySpawner.StartNextWave();
        }
    }

    private void UpdateUI()
    {
        if (enemySpawner == null) return;

        // Update wave text
        if (waveText != null)
        {
            if (enemySpawner.IsWaitingToStart())
            {
                waveText.text = "Wave " + enemySpawner.GetCurrentWave();
            }
            else
            {
                waveText.text = "Wave " + enemySpawner.GetCurrentWave();
            }
        }

        // Show/hide button based on wave state
        if (startWaveButton != null)
        {
            startWaveButton.gameObject.SetActive(enemySpawner.IsWaitingToStart());
            
            // Update button text
            if (buttonText != null)
            {
                buttonText.text = "Start Wave ";
            }
        }
    }
}