
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CharactersStats : MonoBehaviour
{
    [SerializeField]
    float maxHealth = 100;
   public  float power = 10;
    int killScore = 200;


    public float  currentHealth { get; private set; } 

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void ChangeHealth(float value)
    {
        // currentHealth += value;
        currentHealth = Mathf.Clamp(currentHealth + value, 0, maxHealth);

        Debug.Log("Current Health" + currentHealth + "/" + maxHealth);

        if (transform.CompareTag("Enmy"))
            transform.Find("Canvas").GetChild(1).GetComponent<Image>().fillAmount = currentHealth / maxHealth;

        else if (transform.CompareTag("Player"))
        {
            LevelManager.instance.MainCanvas.Find("PanelStatus").Find("ImageHealthbar").GetComponent<Image>().fillAmount = currentHealth / maxHealth;
            LevelManager.instance.MainCanvas.Find("PanelStatus").Find("TextHealth").GetComponent<TextMeshProUGUI>().text = string.Format("{0:0.##}", (currentHealth / maxHealth) * 100);
        }
            if (currentHealth <= 0)
        {
            Die();
        }

        void Die()
        {
            if (transform.CompareTag("Player"))
            {
                //gameover
            }
            else if (transform.CompareTag("Enmy"))
            {
               LevelManager.instance.score += killScore;
                Destroy(gameObject);

                //Destroy enmy
            }
        }
    }
}
