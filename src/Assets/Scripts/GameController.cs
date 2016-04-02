using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public PlayerController player;


	protected static GameController _instance;
	public static GameController Instance
	{
		get
		{
			if (!_instance)
			{
				_instance = Component.FindObjectOfType<GameController>();
			}

			return _instance;
		}
	}

	public GameObject winPanel;
	public GameObject losePanel;

	void Start ()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	public void CheckForWinCondition ()
	{
		EnemyController[] enemies = FindObjectsOfType<EnemyController>();

		if (enemies.Length == 1)
		{
			Win();
		}
	}

	public void UnlockCursor ()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	public void Win ()
	{
		UnlockCursor();
		winPanel.SetActive(true);
	}

	public void Lose ()
	{
		UnlockCursor();
		losePanel.SetActive(true);
	}

	public void Reset ()
	{
		SceneManager.LoadScene(0);
	}
}