using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }
    [Header("Audios")]
    [SerializeField]
    private AudioSource PickUpSound;
    [SerializeField]
    private AudioSource BGM;
    [SerializeField]
    private AudioSource Anvil;
    [SerializeField]
    private AudioSource BirdAmbience;
    [SerializeField]
    private AudioSource ButtonSound;
    [SerializeField]
    private AudioSource CatAttacked1;
    [SerializeField]
    private AudioSource CatAttacked2;
    [SerializeField]
    private AudioSource CatCalling1;
    [SerializeField]
    private AudioSource CatCalling2;
    [SerializeField]
    private AudioSource CatScream1;
    [SerializeField]
    private AudioSource CatScream2;
    [SerializeField]
    private AudioSource ConcreteStep1;
    [SerializeField]
    private AudioSource ConcreteStep2;
    [SerializeField]
    private AudioSource ConcreteStep3;
    [SerializeField]
    private AudioSource ConcreteStep4;
    [SerializeField]
    private AudioSource Death;
    [SerializeField]
    private AudioSource DuckQuack;
    [SerializeField]
    private AudioSource GlassBreak;
    [SerializeField]
    private AudioSource GlassFoot1;
    [SerializeField]
    private AudioSource GlassFoot2;
    [SerializeField]
    private AudioSource GlassFoot3;
    [SerializeField]
    private AudioSource NestBreaking;
    [SerializeField]
    private AudioSource PaperPlane;
    [SerializeField]
    private AudioSource RespawnSound;
    [SerializeField]
    private AudioSource TeleportSound;
    [SerializeField]
    private AudioSource WindAmbience;
    [SerializeField]
    private AudioSource TrafficNoise;

    private void Awake()
    {
        if (instance != null)
        {
            //Debug.LogError("Found more than 1 Audio manager in the scene.");
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        PlayBGM();
    }
    private void PlayBGM()
    {
        if (BGM != null)
        {
            BGM.Play();
            BGM.loop = true;
        }
    }

    public void AnvilPlay()
    {
        if (Anvil != null) Anvil.Play();
    }

    public void BirdSoundPlay()
    {
        if (BirdAmbience != null) BirdAmbience.Play();
    }

    public void ButtonSoundPlay()
    {
        if (ButtonSound != null) ButtonSound.Play();
    }

    public void CatAttacked2Play()
    {
        if (CatAttacked2 != null) CatAttacked2.Play();
    }

    public void CatCalling1Play()
    {
        if (CatCalling1 != null) CatCalling1.Play();
    }

    public void CatCalling2Play()
    {
        if (CatCalling2 != null) CatCalling2.Play();
    }

    public void CatAttacked1Play()
    {
        if (CatAttacked1 != null) CatAttacked1.Play();
    }

    public void CatScream1Play()
    {
        if (CatScream1 != null) CatScream1.Play();
    }

    public void CatScream2Play()
    {
        if (CatScream2 != null) CatScream2.Play();
    }

    public void ConcreteStep1Play()
    {
        if (ConcreteStep1 != null) ConcreteStep1.Play();
    }

    public void ConcreteStep2Play()
    {
        if (ConcreteStep2 != null) ConcreteStep2.Play();
    }

    public void ConcreteStep3Play()
    {
        if (ConcreteStep3 != null) ConcreteStep3.Play();
    }

    public void ConcreteStep4Play()
    {
        if (ConcreteStep4 != null) ConcreteStep4.Play();
    }

    public void DeathSoundPlay()
    {
        if (Death != null) Death.Play();
    }

    public void DuckQuackPlay()
    {
        if (DuckQuack != null) DuckQuack.Play();
    }

    public void GlassBreakPlay()
    {
        if (GlassBreak != null) GlassBreak.Play();
    }

    public void GlassFoot1Play()
    {
        if (GlassFoot1 != null) GlassFoot1.Play();
    }

    public void GlassFoot2Play()
    {
        if (GlassFoot2 != null) GlassFoot2.Play();
    }

    public void GlassFoot3Play()
    {
        if (GlassFoot3 != null) GlassFoot3.Play();
    }

    public void NestBreakingPlay()
    {
        if (NestBreaking != null) NestBreaking.Play();
    }

    public void PaperPlanePlay()
    {
        if (PaperPlane != null) PaperPlane.Play();
    }

    public void RespawnSoundPlay()
    {
        if (RespawnSound != null) RespawnSound.Play();
    }

    public void TeleportSoundPlay()
    {
        if (TeleportSound != null) TeleportSound.Play();
    }

    public void WindAmbiencePlay()
    {
        if (WindAmbience != null) WindAmbience.Play();
    }

    public void TrafficNoisePlay()
    {
        if (TrafficNoise != null) TrafficNoise.Play();
    }
}
