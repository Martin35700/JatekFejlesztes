using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FoMenu : MonoBehaviour
{
	public GameObject Menu;

	public Dropdown felbontasDropdown;

	public AudioManager manager;

	private Resolution[] felbontasok;

	public void Start()
	{
		manager = AudioManager.hivatkozas;
		BeallitasokMenu.jelenlegiHangero = manager.hang.hangero;
		felbontasok = Screen.resolutions;
		felbontasDropdown.ClearOptions();
		List<string> list = new List<string>();
		int num = 0;
		for (int i = 0; i < felbontasok.Length; i++)
		{
			if (felbontasok[i].width >= 1366 && felbontasok[i].width <= 1920)
			{
				string item = felbontasok[i].width + " x " + felbontasok[i].height;
				if (!list.Contains(item))
				{
					list.Add(item);
				}
				if (felbontasok[i].width == 1920 && felbontasok[i].height == 1080)
				{
					num = i;
				}
			}
		}
		felbontasDropdown.AddOptions(list);
		felbontasDropdown.value = num;
		felbontasDropdown.RefreshShownValue();
		Resolution resolution = felbontasok[num];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
	}

	public void Jatek()
	{
		SceneManager.LoadScene("palya1");
	}

	public void Kilep()
	{
		Application.Quit();
	}

	public void Beallit()
	{
		Menu.SetActive(!Menu.activeSelf);
	}
}