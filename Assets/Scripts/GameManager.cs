using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public List<GameObject> targets;
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI gameOverText;
	public Button restartButton;
	private float spawnRate = 1.0f;
	private int score = 0;
	private string scoreTextDef = "";
	public bool isGameActive;

	public GameObject titleScreen;

	void Start()
	{

	}

	public void StartGame(int difficulty)
	{
		spawnRate /= difficulty;
		isGameActive = true;
		score = 0;
		StartCoroutine(SpawnTarget());
		UpdateScore(0);
		titleScreen.SetActive(false);
	}

	public void GameOver()
	{
		gameOverText.gameObject.SetActive(true);
		restartButton.gameObject.SetActive(true);
		isGameActive = false;
	}

	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	IEnumerator SpawnTarget()
	{
		while (isGameActive)
		{
			yield return new WaitForSeconds(spawnRate);
			int index = Random.Range(0, targets.Count);
			Instantiate(targets[index]);
			UpdateScore(5);
		}
	}

	public void UpdateScore(int scoreToAdd)
	{
		score += scoreToAdd;
		scoreText.text = scoreTextDef + score;
	}

	// Update is called once per frame
	void Update()
	{

	}
}
