using UnityEngine.Events;

public interface ISkill {
	
	UnityEvent OnApply { get; set; }
	UnityEvent OnCancel { get; set; }
	
}