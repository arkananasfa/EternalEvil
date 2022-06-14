using System;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LosePanel : MonoBehaviour {

	[SerializeField] private RoundConfig roundConfig;

	[SerializeField] private GameObject content;
	
	[SerializeField] private Image tryAgainButtonImage;
	[SerializeField] private TextMeshProUGUI finalInfoText;
	[SerializeField] private TextMeshProUGUI tryAgainButtonText;
	[SerializeField] private Image curtains;

	private Image panelItself;

	private void Awake() {
		panelItself = GetComponent<Image>();
	}

	private void OnEnable() {
		GameLoopEvents.OnGameLost += ShowPanel;
	}

	private void OnDisable() {
		GameLoopEvents.OnGameLost -= ShowPanel;
	}

	private void ShowPanel() {
		StartCoroutine(ShowPanelRoutine());
	}

	private IEnumerator ShowPanelRoutine() {
		yield return new WaitForSeconds(1f);
		Color panelColor = Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f);
		Color reverseColor = new Color(1f - panelColor.r, 1f - panelColor.g, 1f - panelColor.b);
		
		panelItself.color = panelColor-new Color(0,0,0,1f);
		curtains.color = panelColor;
		finalInfoText.color = reverseColor;
		tryAgainButtonImage.color = reverseColor;
		tryAgainButtonText.color = panelColor;

		finalInfoText.text = $"{roundConfig.RoundsNumber - 1} rounds beaten";
		
		int fps = 51;
		
		for (int i = 1; i < fps; i++) {
			panelItself.color = new Color(panelColor.r, panelColor.g, panelColor.b, (float)i / fps);
			yield return new WaitForSeconds(0.02f);
		}
		
		content.SetActive(true);
		
		for (int i = 1; i < fps; i++) {
			curtains.color = new Color(panelColor.r, panelColor.g, panelColor.b, 1f- (float)i / fps);
			yield return new WaitForSeconds(0.02f);
		}
		
	}

	public void TryAgain() {
		SceneManager.LoadScene(0);
	}

}