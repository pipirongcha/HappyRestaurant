using UnityEngine;

public enum SingletonInitializeTime
{
    None,
    Awake,
    Start
}

public class Singleton<T>: MonoBehaviour where T: MonoBehaviour
{
    public SingletonInitializeTime initializeTime;
    public bool isInit = false;
    [SerializeField] private bool dontDestroy; //인스펙터 작업
    protected static bool isDontDestroy { get; private set; }
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<T>();
                if (instance == null)
                {
                    var obj = new GameObject(typeof(T).Name);
                    instance = obj.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    // 인스턴스 첫 생성에 자동 실행
    // 중복 방지 안해놔서 호출하면 안됨
    public virtual void OnCreateInstance()
    {

    }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            transform.SetParent(null);

            isDontDestroy = dontDestroy;
            if (isDontDestroy) DontDestroyOnLoad(gameObject);

            OnCreateInstance();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        if (initializeTime == SingletonInitializeTime.Awake) Init();
    }

    protected virtual void Start()
    {
        if (initializeTime == SingletonInitializeTime.Start) Init();
    }


    // 사용자 정의 초기화용 메서드
    public void Init()
    {
        if (isInit) return;
        
        isInit = true;
        OnInit();
    }

    protected virtual void OnInit()
    {

    }
    
}