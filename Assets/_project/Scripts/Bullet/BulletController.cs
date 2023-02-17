using TMPro;
using UnityEngine;

namespace Hypercasual
{
	public class BulletController : MonoBehaviour
	{
		[SerializeField] private int m_InintBulletCount;
		[SerializeField] private int m_BulletCount;
		[SerializeField] private float m_BulletSpeed;
		[SerializeField] private GameObject m_BulletPrefab;
		[SerializeField] private Transform m_BulletSpawnPoint;
		[SerializeField] private TextMeshProUGUI m_BulletCountText;
		private void Start()
		{
			m_BulletCount = m_InintBulletCount;
			UpdateBulletCount();
		}

		private void Update()
		{
			if(Input.GetMouseButtonDown(0) && m_BulletCount > 0)
			{
				Shoot();
				UpdateBulletCount();
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.TryGetComponent<ScoreMultiplier>(out ScoreMultiplier score))
			{
				m_BulletCount *= score.Multiplier;
				UpdateBulletCount();
			}
		}

		private void Shoot()
		{
			GameObject bullet = BulletPoolService.Instance.GetPooledBullet();
			m_BulletCount--;
			bullet.transform.position = m_BulletSpawnPoint.position;
			bullet.transform.rotation = m_BulletSpawnPoint.rotation;
			bullet.SetActive(true);
			bullet.GetComponent<Rigidbody>().AddForce(Vector3.forward * m_BulletSpeed, ForceMode.Impulse);
		}

		private void UpdateBulletCount()
		{
			m_BulletCountText.text = m_BulletCount.ToString();
		}
	}
}