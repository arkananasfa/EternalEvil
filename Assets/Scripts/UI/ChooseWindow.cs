using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChooseWindow : MonoBehaviour {

	public event Action OnClick;

	[SerializeField] private GameObject TitlePrefab;
	[SerializeField] private GameObject TextPrefab;
	[SerializeField] private GameObject ImagePrefab;
	[SerializeField] private GameObject ImageNTextPrefab;

	[SerializeField] private Transform Content;

	public void Init(IDescribable describable) {
		List<ChooseWindowRow> rows = describable.GenerateDescribe();
		foreach (var row in rows) {
			AddRow(row);
		}
	}

	public void Click() {
		OnClick?.Invoke();
	}
	
	private void AddRow(ChooseWindowRow row) {
		GameObject elem;
		switch(row.Type) {
			case WindowRowType.Title:
				elem = Instantiate(TitlePrefab, Vector3.zero, Quaternion.identity, Content);
				elem.GetComponent<TextMeshProUGUI>().text = row.Text;
				break;
			case WindowRowType.Text:
				elem = Instantiate(TextPrefab, Vector3.zero, Quaternion.identity, Content);
				elem.GetComponent<TextMeshProUGUI>().text = row.Text;
				break;
			case WindowRowType.Image:
				elem = Instantiate(ImagePrefab, Vector3.zero, Quaternion.identity, Content);
				elem = elem.transform.GetChild(0).gameObject;
				elem.GetComponent<Image>().sprite = row.Image;
				break;
			case WindowRowType.ImageNText:
				elem = Instantiate(ImageNTextPrefab, Vector3.zero, Quaternion.identity, Content);
				var elem1 = elem.transform.GetChild(0).gameObject;
				elem1.GetComponent<Image>().sprite = row.Image;
				var elem2 = elem.transform.GetChild(1).gameObject;
				elem2.GetComponent<TextMeshProUGUI>().text = row.Text;
				break;
		}
	}

}