using UnityEngine;
using UnityEngine.UI;

public class Tamagotchi : MonoBehaviour
{
    public enum State { ALIVE, DEAD }
    public State state;
    public float timer;
    public float timeToLive = 259200.0f; // 72�ð� * 60�� * 60��

    public int hunger = 100;
    public int training = 100;
    public int playfulness = 100;
    public int cleanliness = 100;

    public Text hungerText;
    public Text trainingText;
    public Text playfulnessText;
    public Text cleanlinessText;
    public Text timerText;

    void Start()
    {
        state = State.ALIVE;
        timer = 0;
    }

    void Update()
    {
        if (state == State.ALIVE)
        {
            timer += Time.deltaTime * 2;  // ���⼭ 2�� �ð��� ������ �帣�� �ϴ� ���, ��� ���� ����

            if (timer >= timeToLive)
            {
                state = State.DEAD;
                Debug.Log("�ٸ���ġ�� �� ������ ���Ͽ� �ٸ���ġ�� �׾����ϴ�.. ���� ���� �� �� Ű���ּ��� !!");
            }

            UpdateUI();
        }
    }

    void UpdateUI()
    {
        hungerText.text = "������ : " + hunger;
        trainingText.text = "�Ʒõ� : " + training;
        playfulnessText.text = "�ų��� : " + playfulness;
        cleanlinessText.text = "û�ᵵ : " + cleanliness;

        float remainingTime = timeToLive - timer;
        int remainingHours = Mathf.FloorToInt(remainingTime / 3600);
        int remainingMinutes = Mathf.FloorToInt((remainingTime % 3600) / 60);
        int remainingSeconds = Mathf.FloorToInt(remainingTime % 60);

        timerText.text = string.Format("{0:0}h {1:0}m {2:0}s", remainingHours, remainingMinutes, remainingSeconds);
    }

    public void Feed()
    {
        hunger += 10;
        Debug.Log("�ٸ���ġ �� ���̱� ! �������� ���� : " + hunger);
    }

    public void Train()
    {
        training += 10;
        Debug.Log("�ٸ���ġ �Ʒ��ϱ� ! �Ʒõ��� ���� : " + training);
    }

    public void Play()
    {
        playfulness += 10;
        Debug.Log("�ٸ���ġ ����ֱ� ! �ų����� ���� : " + playfulness);
    }

    public void Clean()
    {
        cleanliness += 10;
        Debug.Log("�ٸ���ġ �ı�� ! û�ᵵ�� ���� : " + cleanliness);
    }
}
