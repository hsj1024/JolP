using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

// ����ڿ��� Ȯ�� ���Ǹ� �����ϰ� ������ ó���ϴ� Ŭ����
public class QuestionConfirmController : MonoBehaviour
{
    public static QuestionConfirmController instance; // Ŭ������ �ν��Ͻ��� �������� ����
    public Text QuestionTxt; // Ȯ�� ���� �ؽ�Ʈ�� ǥ���ϴ� UI �ؽ�Ʈ
    public Button YesBtn, NoBtn; // Ȯ�� �� ��� ��ư
    public static bool? isYes = null; // ������� ���� ���θ� �����ϴ� ����
    public TaskCompletionSource<bool> buttonClickedTask; // ��ư Ŭ�� �̺�Ʈ�� �����ϴ� TaskCompletionSource

    // ���� �� ȣ��Ǵ� �Լ�
    public void Start()
    {
        instance = this;
    }

    // Ȯ�� ���� ������ �����ϴ� �Լ�
    public void SetQuestion(string text)
    {
        QuestionTxt.text = text;
        YesBtn.onClick.AddListener(confirmYes);
        NoBtn.onClick.AddListener(confirmNo);
    }

    // Ȯ�� ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    private void confirmYes()
    {
        isYes = true;
        buttonClickedTask.TrySetResult(true);
        FrameManager.instance.CloseQuestionConfirm();
    }

    // ��� ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    private void confirmNo()
    {
        isYes = false;
        buttonClickedTask.TrySetResult(true);
        FrameManager.instance.CloseQuestionConfirm();
    }
}
