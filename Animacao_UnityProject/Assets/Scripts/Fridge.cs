namespace Scripts
{
    public class Fridge : Interactable
    {
        public override void Interact()
        {
            GameManager.Instance.AddToMotiveValueByTime(
                GameManager.Instance.Motives[MotiveType.Hunger], 
                50f, 
                5, 
                true);
            
            GameManager.Instance.AddToMotiveValueByTime(
                GameManager.Instance.Motives[MotiveType.Bladder], 
                30f, 
                30, 
                false);
        }
    }
}