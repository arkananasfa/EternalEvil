public class Troll : AbstractCharacter {
    
	private void Start() {
		BaseHP = 200;
		HP = 200;
		Power = 10;
		Speed = 1.5f;
		Target = Player.Instance.transform;
		Controller.Acting();
	}
	
}