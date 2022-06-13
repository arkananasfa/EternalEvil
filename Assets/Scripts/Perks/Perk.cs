using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public abstract class Perk : IDescribable {

	private string Name;
	private Sprite Sprite;
	private string Description;
	public Color Color;
	public int Frequency;
	public int MaxUses;
	public int CurrentUses;
	public abstract void Apply();

	public Perk(string name, int frequency, int maxUses, Color color, string description = "") {
		Name = name;
		Frequency = frequency;
		MaxUses = maxUses;
		Color = color;
		Description = description;
		CurrentUses = 0;
		Sprite = Resources.LoadAll<Sprite>("Perks\\Perks").Single(s => s.name == Name);
	}
	
	public List<ChooseWindowRow> GenerateDescribe() {
		var describe = new List<ChooseWindowRow>();
		describe.Add(new ChooseWindowRow(Sprite));
		describe.Add(new ChooseWindowRow(Name, true));
		describe.Add(new ChooseWindowRow($"Chosen before: {CurrentUses} times"));
		describe.Add(new ChooseWindowRow(Description));
		return describe;
	}
}