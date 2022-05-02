using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnMananger : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject PowerUpPrefab;
    private float spawnRange = 9.0f;
    private int score;
    public int enemyCount;
    private PlayerController playerControllerScript;
    public int waveNumber = 1;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI loreHeaderText;
    public TextMeshProUGUI loreBodyText;
    public TextMeshProUGUI infoText;
    public Button restartButton;
    public Button startButton;
    private bool start = true;
    public List<GameObject> ClimateChangeSideEfects;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
       
        if (enemyCount == 0 && playerControllerScript.isDead == false && start == false)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(PowerUpPrefab, GenerateSpawnPosistion(), PowerUpPrefab.transform.rotation);
            score = score + (waveNumber * 4);
            scoreText.text = "Score: " + score;
        }
        if (playerControllerScript.isDead == true)
        {
            restartButton.gameObject.SetActive(true);
            gameOverText.gameObject.SetActive(true);
        }

    }

    void SpawnEnemyWave (int EnemiesToSpawn)
    {
        for (int i = 0; i < EnemiesToSpawn; i++)
        {
            int randomIndex = Random.Range(1, 4);
            if ( randomIndex == 1 )
            {
              Instantiate(ClimateChangeSideEfects[0], GenerateSpawnPosistion(), ClimateChangeSideEfects[0].transform.rotation);
            }
            if (randomIndex == 2)
            {
                Instantiate(ClimateChangeSideEfects[1], GenerateSpawnPosistion(), ClimateChangeSideEfects[1].transform.rotation);
            }
            if (randomIndex == 3)
            {
                Instantiate(ClimateChangeSideEfects[2], GenerateSpawnPosistion(), ClimateChangeSideEfects[2].transform.rotation);
            }
        }
    }
    private Vector3 GenerateSpawnPosistion()
    {
        float spawanPosx = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawanPosx, 0, spawnPosZ);
        return randomPos;
    }

    public void RestartGame()
    {
        start = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame()
    {
        start = false;
        startButton.gameObject.SetActive(false);
        loreHeaderText.gameObject.SetActive(false);
        loreBodyText.gameObject.SetActive(false); 
        infoText.gameObject.SetActive(false);
    }
}
