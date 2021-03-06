using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
	public List<GameObject> targets;
	public TextMeshProUGUI scoreText;
	private float spawnRate = 1.0f;
	private int score = 0;
	private string scoreTextDef = "";
	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(SpawnTarget());
		scoreTextDef = scoreText.text;
		UpdateScore(0);
	}

	IEnumerator SpawnTarget()
	{
		while (true)
		{
			yield return new WaitForSeconds(spawnRate);
			int index = Random.Range(0, targets.Count);
			Instantiate(targets[index]);
			UpdateScore(5);
		}
	}

	private void UpdateScore(int scoreToAdd)
	{
		score += scoreToAdd;
		scoreText.text = scoreTextDef + score;
	}

	// Update is called once per frame
	void Update()
	{

	}
}
