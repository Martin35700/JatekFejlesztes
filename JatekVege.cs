using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JatekVege : MonoBehaviour
{
	public Text korokSzama;

	private void OnEnable()
	{
		korokSzama.text = UjKor.aktualisKor.ToString();
	}

	public void UjJatek()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		Time.timeScale = 1f;
	}

	public void MenuBetolt()
	{
		SceneManager.LoadScene("fomenu");
	}
}
