namespace Scripts
{
    public class Toilet : Interactable
    {
        public override void Interact()
        {
            GameManager.Instance.AddToMotiveValueByTime(
                GameManager.Instance.Motives[MotiveType.Bladder], 
                100f, 
                5, 
                true);
            
            GameManager.Instance.AddToMotiveValueByTime(
                GameManager.Instance.Motives[MotiveType.Hygiene], 
                40f, 
                15, 
                false);
        }
    }
}