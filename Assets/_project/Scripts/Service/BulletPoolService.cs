using System.Collections.Generic;
using UnityEngine;

namespace Hypercasual
{
	public class BulletPoolService : MonoSingleton<BulletPoolService>
	{
		[SerializeField] private List<GameObject> m_PooledBullets = new List<GameObject>();
		[SerializeField] private GameObject m_PooledBullet;
		GameObject bulletInstantiated;

		private void Start()
		{
			for(int i = 0; i < m_PooledBullets.Count; i++)
			{
				CreateBullet();
			}
		}
		public GameObject GetPooledBullet()
		{
			for (int i = 0; i < m_PooledBullets.Count; i++)
			{
				if (!m_PooledBullets[i].activeInHierarchy)
				{
					return m_PooledBullets[i];
				}
			}
			CreateBullet();
			return m_PooledBullets[m_PooledBullets.Count-1];
		}
		private void CreateBullet()
		{
			bulletInstantiated = Instantiate(m_PooledBullet);
			bulletInstantiated.SetActive(false);
			m_PooledBullets.Add(bulletInstantiated);
		}
	}
}
