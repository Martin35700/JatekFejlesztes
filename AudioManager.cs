using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public Zene hang;

	public static AudioManager hivatkozas;

	private void Awake()
	{
		hang.forras = base.gameObject.AddComponent<AudioSource>();
		hang.forras.clip = hang.zene;
		hang.forras.volume = hang.hangero;
		hang.forras.pitch = hang.hangmagassag;
		hang.forras.loop = hang.loop;
		hang.forras.Play();
		if (!(hivatkozas != null))
		{
			hivatkozas = this;
		}
	}

	public void HangeroModosit(float hangEro)
	{
		hang.forras.volume = hangEro;
	}
}
