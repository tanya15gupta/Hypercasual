using System.Collections;
using UnityEngine;

namespace Hypercasual
{
	public class Bullet : MonoBehaviour
	{
		[SerializeField] private float m_BulletLifeTime;

		private void Update()
		{
			StartCoroutine(DeactivatingSelfRoutine());
		}
		private void OnCollisionEnter(Collision collision)
		{
			gameObject.SetActive(false);
		}
		private IEnumerator DeactivatingSelfRoutine()
		{
			yield return new WaitForSeconds(m_BulletLifeTime);
			gameObject.SetActive(false);
		}
		private void OnDestroy()
		{
			StopCoroutine(DeactivatingSelfRoutine());
		}
	}
}
