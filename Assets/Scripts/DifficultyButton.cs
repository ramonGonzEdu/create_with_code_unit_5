using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
	private Button button;
	private GameManager gameManager;
	public int difficulty;
	private void Start()
	{
		button = GetComponent<Button>();
		button.onClick.AddListener(SetDifficulty);
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	void SetDifficulty()
	{
		gameManager.StartGame(difficulty);
	}
}