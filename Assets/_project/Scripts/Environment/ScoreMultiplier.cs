using TMPro; 
using UnityEngine;

namespace Hypercasual
{
	public class ScoreMultiplier : MonoBehaviour
	{
		[SerializeField] private int m_Min;
		[SerializeField] private int m_Max;
		[SerializeField] private TextMeshPro m_ScoreText;
		public int Multiplier { get;private set; }

		private void Start()
		{
			Multiplier = (int)Random.Range(m_Min, m_Max);
			m_ScoreText.text = Multiplier.ToString() + "x";
		}
	}
}
