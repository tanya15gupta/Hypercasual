using TMPro;
using UnityEngine;

namespace Hypercasual
{
	public class ObstacleCubeController : MonoBehaviour
	{
		[SerializeField] private int m_ObstacleHealth;
		[SerializeField] private int m_MinHealth;
		[SerializeField] private int m_MaxHealth;
		[SerializeField] private TextMeshPro m_ObstacleText;

		private void Start()
		{
			m_ObstacleHealth = (int)Random.Range(m_MinHealth, m_MaxHealth);
			UpdateHealthText();
		}

		private void OnCollisionEnter(Collision collision)
		{
			if(collision.gameObject.TryGetComponent<Bullet>(out Bullet bullet))
			{
				ReceivedHit();
			}
		}

		private void ReceivedHit()
		{
			m_ObstacleHealth--;
			if (m_ObstacleHealth <= 0)
			{
				Destroy(gameObject);
			}
			UpdateHealthText();
		}

		private void UpdateHealthText()
		{
			m_ObstacleText.text = m_ObstacleHealth.ToString();
		}

	}
}