using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public List<GameObject> targets;
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI gameOverText;
	private float spawnRate = 1.0f;
	private int score = 0;
	private string scoreTextDef = "";
	public bool isGameActive;
	// Start is called before the first frame update
	void Start()
	{
		isGameActive = true;
		StartCoroutine(SpawnTarget());
		scoreTextDef = scoreText.text;
		UpdateScore(0);
	}

	public void GameOver()
	{
		gameOverText.gameObject.SetActive(true);
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
