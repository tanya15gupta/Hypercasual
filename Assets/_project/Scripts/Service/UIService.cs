using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hypercasual
{ 
	public class UIService : MonoSingleton<UIService>
	{
		[SerializeField] private GameObject m_GameLostPanel;
		[SerializeField] private GameObject m_GameWonPanel;

		private void Start()
		{
			if(m_GameLostPanel != null && m_GameWonPanel != null)
			{
				SetGameoverPanelActive(false);
				SetGameWonPanelActive(false);
			}
			ContinueGame();
		}

		public void SetGameoverPanelActive(bool _isActive)
		{
			PauseGame();
			m_GameLostPanel.SetActive(_isActive);
		}
		public void SetGameWonPanelActive(bool _isActive)
		{
			PauseGame();
			m_GameWonPanel.SetActive(_isActive);
		}
		public void StartGame()
		{
			SceneManager.LoadScene(1);
		}
		public void PauseGame()
		{
			Time.timeScale = 0.0f;
		}
		public void ContinueGame()
		{
			Time.timeScale = 1.0f;
		}
		public void RestartGame()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
		public void Exit()
		{
			Application.Quit();
		}
	}
}
