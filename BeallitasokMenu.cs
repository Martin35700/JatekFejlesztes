using UnityEngine;
using UnityEngine.UI;

public class BeallitasokMenu : MonoBehaviour
{
	public GameObject beallitasMenu;

	public Slider hangeroSlider;

	public AudioManager manager;

	public static float jelenlegiHangero;

	private Resolution[] felbontasok;

	private void Awake()
	{
		manager = AudioManager.hivatkozas;
		felbontasok = Screen.resolutions;
		for (int i = 0; i < felbontasok.Length; i++)
		{
			if (felbontasok[i].width >= 1366 && felbontasok[i].width <= 1920)
			{
				_ = felbontasok[i].width + " x " + felbontasok[i].height;
				if (felbontasok[i].width == Screen.currentResolution.width)
				{
					_ = felbontasok[i].height;
					_ = Screen.currentResolution.height;
				}
			}
		}
		GrafikaBeallit(0);
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) && beallitasMenu.activeSelf)
		{
			beallitasMenu.SetActive(value: false);
		}
	}

	public void GrafikaBeallit(int grafikaIndex)
	{
		QualitySettings.SetQualityLevel(grafikaIndex);
	}

	public void TeljesKepernyo(bool teljesKepernyos)
	{
		Screen.fullScreen = teljesKepernyos;
	}

	public void FelbontasAllit(int felbontasIndex)
	{
		Resolution resolution = felbontasok[felbontasIndex];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
	}

	public void HangeroBeallit()
	{
		manager.HangeroModosit(hangeroSlider.value * 0.1f);
		jelenlegiHangero = hangeroSlider.value * 0.1f;
	}
}
