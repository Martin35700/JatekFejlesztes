using UnityEngine;

public class Utkozes : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		Debug.Log(collision.transform.tag);
	}
}
