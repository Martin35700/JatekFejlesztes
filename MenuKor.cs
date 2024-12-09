using System.Collections;
using UnityEngine;

public class MenuKor : MonoBehaviour
{
	public Transform EllenfelEgy;

	private float idozito = 3f;

	private void Start()
	{
		Time.timeScale = 1f;
		Time.fixedDeltaTime = 0.02f;
	}

	private void Update()
	{
		if (idozito <= 0f)
		{
			StartCoroutine(KorInditas());
			idozito = 3f;
		}
		else
		{
			idozito -= Time.deltaTime;
			idozito = Mathf.Clamp(idozito, 0f, float.PositiveInfinity);
		}
	}

	private IEnumerator KorInditas()
	{
		UjEllenfel();
		yield return new WaitForSeconds(3f);
	}

	private void UjEllenfel()
	{
		Object.Instantiate(EllenfelEgy, new Vector3(3f, 2.26f, 5f), IranyjelzokScript.iranyjelzok[0].rotation);
	}
}
