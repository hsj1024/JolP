using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms;
using Unity.VisualScripting;

public class Tamagotchi : MonoBehaviour
{
    public enum State { EGG, CHILD, TEEN, ADULT, DEAD }
    public State state;
    public float timer;
    public float timeToLive = 259200.0f; 
    public GameObject[] evolutionStages;

    public float money = 0f; // 돈
    public Button sleepButton; // 잠자기 버튼

    public int dayCounter = 1; // 현재 날짜 카운터
    public Text dayCounterText; // 날짜를 표시할 UI 텍스트 (TextMeshProUGUI로 변경 가능)


    public Text hungerText;
    public Text trainingText;
    public Text playfulnessText;
    public Text cleanlinessText;
    public Text timerText;
    public Text socialText; // 사회성을 표시할 UI 텍스트
    public Text moneyText; // 돈을 표시할 UI 텍스트

    // hp 관리 부분 변수
    public int hp = 4; // HP는 4로 시작
    public Sprite[] heartSprites; // 하트 스프라이트 배열
    public Image heartImage; // 하트 이미지를 보여줄 UI 컴포넌트



    void Start()
    {
        EggMonStat.InitializeStat();

        state = State.EGG;
        timer = 0;
        if(evolutionStages != null)
        {
            foreach (GameObject stage in evolutionStages)
            {
                stage.SetActive(false);
            }
            evolutionStages[0].SetActive(true); 
        }
        // 초기 날짜 표시
        UpdateDayCounterUI();
        // 잠자기 버튼 클릭 이벤트에 Sleep 메서드 연결
        sleepButton.onClick.AddListener(Sleep);

    }

    // 날짜 카운터 UI 업데이트
    void UpdateDayCounterUI()
    {
        dayCounterText.text = "DAY " + dayCounter;
    }

    void Update()
    {
        if (state != State.DEAD)
        {
            // 타이머 증가 로직 제거

            DecreaseStatsOverTime();
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        hungerText.text = "먹이기 : " + (int)Mathf.Clamp(EggMonStat.full, 0, 100);
        trainingText.text = "훈련하기 : " + (int)Mathf.Clamp(EggMonStat.intellect, 0, 100);
        playfulnessText.text = "놀아주기 : " + (int)Mathf.Clamp(EggMonStat.playfulness, 0, 100);
        cleanlinessText.text = "씻기기 : " + (int)Mathf.Clamp(EggMonStat.cleanliness, 0, 100);
        socialText.text = "사회성 : " + (int)Mathf.Clamp(EggMonStat.social, 0, 100);
        moneyText.text = "돈 : " + money;


        float remainingTime = timeToLive - timer;
        int remainingHours = Mathf.FloorToInt(remainingTime / 3600);
        int remainingMinutes = Mathf.FloorToInt((remainingTime % 3600) / 60);
        int remainingSeconds = Mathf.FloorToInt(remainingTime % 60);

        timerText.text = string.Format("{0:0}h {1:0}m {2:0}s", remainingHours, remainingMinutes, remainingSeconds);
    }

    // 잠자기 기능을 수행하는 메서드
    public void Sleep()
    {
        // 날짜 카운터 증가
        dayCounter++;

        // 체력을 최대로 회복
        hp = heartSprites.Length - 1;
        UpdateHeartSprite();

        // 날짜 카운터 UI 업데이트
        UpdateDayCounterUI();

        Debug.Log("잠자기 버튼이 눌렸습니다. 다음 날로 넘어갑니다: DAY " + dayCounter);
    }
    public void Feed()
    {
        EggMonStat.IncreaseStat("full", 10f);
        EggMonStat.IncreaseStat("likeability", 1f);
    }

    public void Train()
    {
        EggMonStat.IncreaseStat("intellect", 10f);
        EggMonStat.IncreaseStat("likeability", 1f);
    }

    public void Play()
    {
        EggMonStat.IncreaseStat("playfulness", 10f);
        EggMonStat.IncreaseStat("likeability", 3f);
    }

    public void Clean()
    {
        EggMonStat.IncreaseStat("cleanliness", 10f);
        EggMonStat.IncreaseStat("likeability", 1f);
    }

    public void MeetFriends()
    {
        EggMonStat.IncreaseStat("social", 10f);
        EggMonStat.DecreaseStat("cleanliness", 1f);
    }
    public void Work()
    {
        money += 50f; // 일정 금액을 추가
        EggMonStat.DecreaseStat("full", 40f);
        if (EggMonStat.full <= 0)
        {
            DecreaseHP(); // 배고픔이 0 이하이면 HP 감소
        }
        Debug.Log("돈 : " + money);
    }


    void DecreaseStatsOverTime()
    {
        if (state != State.EGG)
        {
            EggMonStat.DecreaseStat("full", 10f);
            EggMonStat.DecreaseStat("cleanliness", 10f);
            EggMonStat.DecreaseStat("playfulness", 10f);

            // 새로운 HP 감소 조건
            if (EggMonStat.full <= 0 || EggMonStat.cleanliness <= 0)
            {
                DecreaseHP(); // HP 감소 함수 호출
            }
        }


    }

    void UpdateHeartSprite()
    {
        if (hp >= 0 && hp < heartSprites.Length)
        {
            heartImage.sprite = heartSprites[hp]; // 적절한 스프라이트로 업데이트
        }
    }

    public void DecreaseHP()
    {
        if (hp > 0) // HP가 0보다 클 때만 감소
        {
            hp -= 1; // HP를 1 감소
            UpdateHeartSprite(); // 스프라이트 업데이트
        }
    }

    void Evolve()
    {
        switch (state)
        {
            case State.EGG:
                state = State.CHILD;
                UpdateEvolutionStage(1);
                timer = 0;
                break;
            case State.CHILD:
                state = State.TEEN;
                UpdateEvolutionStage(2);
                timer = 0;
                break;
            case State.TEEN:
                state = State.ADULT;
                UpdateEvolutionStage(3);
                timer = 0;
                break;
            case State.ADULT:
                state = State.DEAD;
                Debug.Log("다마고치가 죽었습니다!!");
                break;
        }
    }

    void UpdateEvolutionStage(int index)
    {
        foreach (GameObject stage in evolutionStages)
        {
            stage.SetActive(false);
        }
        evolutionStages[index].SetActive(true);
    }
}
