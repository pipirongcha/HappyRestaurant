
using System.Data;
using UnityEngine;

public abstract class CustomerBase<T>: MonoBehaviour where T: MonoBehaviour
{
    private int foodCnt;
    private FOODS food;


    public void OnEnable()
    {
        foodCnt = Random.Range(0, 3);
    }
    private void OrderingFood()
    {
        // 손님이라면? 물을 받았을 때 호출됨
        // 배달부라면? 바로 호출

    }

    private void GetFood()
    {
        // 필요 음식을 덜 받았다면? 그림 내 숫자 또는 그림 자체 Active False 업데이트
        // 필요 음식을 다 받았다면? 배달부는 배달 Anim, 손님은 식사 Anim 시작
    }

    public abstract int PayingFood();
}
