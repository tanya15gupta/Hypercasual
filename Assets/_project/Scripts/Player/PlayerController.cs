using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hypercasual
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private float m_PlayerSpeed;
		[SerializeField] private float m_PlayerSnapping;
		[SerializeField] private float m_HorizontalInput;
		[SerializeField] private Vector3 m_Bounds;
		[SerializeField] private UIService m_UiService;
		private void Start()
		{
			m_UiService = UIService.Instance;
		}
		private void Update()
		{
			MoveForward();
			if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
			{
				m_HorizontalInput = -1;
				HorizontalMovement(-1);
			}
			else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
			{
				m_HorizontalInput = 1;
				HorizontalMovement(1);
			}
		}

		private void OnCollisionEnter(Collision collision)
		{
			if(collision.gameObject.TryGetComponent<ObstacleCubeController>(out ObstacleCubeController cubeController))
			{
				m_UiService.SetGameoverPanelActive(true);
			}
		}

		private void HorizontalMovement(float _horizontalMovement)
		{
			float movement = m_HorizontalInput * m_PlayerSnapping;
			if ((transform.position.x + movement) < -m_Bounds.x || (transform.position.x + movement) > m_Bounds.x)
				return;
			transform.position += new Vector3(m_HorizontalInput * m_PlayerSnapping, 0);
		}
		private void MoveForward()
		{
			if (transform.position.z >= m_Bounds.z)
				return;
			transform.position += new Vector3(0, 0, m_PlayerSpeed * Time.deltaTime);
		}
	}
}
