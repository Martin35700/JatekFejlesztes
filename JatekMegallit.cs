using UnityEngine;
using UnityEngine.SceneManagement;

public class JatekMegallit : MonoBehaviour
{
	public GameObject SzunetMenu;

	private void Start()
	{
		SzunetMenu.SetActive(value: false);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			AllapotAtallit();
		}
	}

	public void AllapotAtallit()
	{
		SzunetMenu.SetActive(!SzunetMenu.activeSelf);
		if (SzunetMenu.activeSelf)
		{
			Time.timeScale = 0f;
		}
		else
		{
			Time.timeScale = 1f;
		}
	}

	public void UjraKezdes()
	{
		AllapotAtallit();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void MenuBetolt()
	{
		SceneManager.LoadScene("fomenu");
	}
}
