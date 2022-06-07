using JetBrains.Annotations;
using UnityEngine;

public class ChooseWindowRow {

	public Sprite Image { get; }
	public string Text { get; }
	public WindowRowType Type { get; }

	public ChooseWindowRow(Sprite image) => (Image, Type) = (image, WindowRowType.Image);
	public ChooseWindowRow(string text, bool title = false) => (Text, Type) = (text, title ? WindowRowType.Title : WindowRowType.Text);
	public ChooseWindowRow(Sprite image, string text) => (Image, Text, Type) = (image, text, WindowRowType.ImageNText);

}

public enum WindowRowType {
	Title,
	Text,
	Image,
	ImageNText
}