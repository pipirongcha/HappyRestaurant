
using System.Data;
using UnityEngine;

public abstract class CustomerBase<T>: MonoBehaviour where T: MonoBehaviour
{
    private int foodCnt;
    private FOODS food;
    private int customerTypeLimit; //CustomerType 결정 중에 배달원을 추가 또는 제거할 수 있도록 해주는 필드값
    private CUSTOMERS customerType;
    private int foodCntLimit;
    private float patienceGauge; //손님의 인내심 게이지, 0이 되면 나가버림
    private float patienceDownSpeed;

    public void Start()
    {
        if (GameManager.Instance.isDeliveryWaiting) //@TODO: 의존성 제거 방법 고민해보기
        {
            customerTypeLimit = 3;
        }
        else
        {
            customerTypeLimit = 4;
        }

        customerType = (CUSTOMERS)Random.Range(1, customerTypeLimit);


            switch (customerType)
            {
                case CUSTOMERS.TableCustomer:
                    foodCntLimit = 2;
                    break;
                case CUSTOMERS.TableGlutton:
                    foodCntLimit = 3;
                    break;
                case CUSTOMERS.Delivery:
                    foodCntLimit = 4; //@TODO: 임시값, 배달 랭크에 따라서 오르도록 수정하기
                    break;
            }
        foodCnt = Random.Range(1, foodCntLimit);
        food = (FOODS)Random.Range(1, 7);
    }

    public void OnEnable()
    {
        
    }

    private void WaitingWater()
    {

    }
    private void WaitingFood()
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

    private void Update()
    {
        if (customerType == CUSTOMERS.Delivery) return;

        patienceGauge -= Time.deltaTime * patienceDownSpeed;

        if (patienceGauge <= 0f)
        {
            patienceGauge = 0f;
            TableOut();
        }

        UpdatePatienceUI();
    }

    private void UpdatePatienceUI()
    {
        //@TODO: 손님 인내심 게이지 UI 업데이트
    }

    private void TableOut()
    {
        //@TODO: 손님 화나서 나가는 연출
    }
}
