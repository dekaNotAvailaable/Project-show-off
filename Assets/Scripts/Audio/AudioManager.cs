using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }
    [Header("Sound Effects")]
    [SerializeField] private AudioSource BGM;
    [SerializeField] private AudioSource Anvil;
    [SerializeField] private AudioSource BirdAmbience;
    [SerializeField] private AudioSource ButtonSound;
    [SerializeField] private AudioSource CatAttacked1;
    [SerializeField] private AudioSource CatAttacked2;
    [SerializeField] private AudioSource CatCalling1;
    [SerializeField] private AudioSource CatCalling2;
    [SerializeField] private AudioSource CatScream1;
    [SerializeField] private AudioSource CatScream2;
    [SerializeField] private AudioSource ConcreteStep1;
    [SerializeField] private AudioSource ConcreteStep2;
    [SerializeField] private AudioSource ConcreteStep3;
    [SerializeField] private AudioSource ConcreteStep4;
    [SerializeField] private AudioSource Death;
    [SerializeField] private AudioSource DuckQuack;
    [SerializeField] private AudioSource GlassBreak;
    [SerializeField] private AudioSource GlassFoot1;
    [SerializeField] private AudioSource GlassFoot2;
    [SerializeField] private AudioSource GlassFoot3;
    [SerializeField] private AudioSource NestBreaking;
    [SerializeField] private AudioSource PaperPlane;
    [SerializeField] private AudioSource RespawnSound;
    [SerializeField] private AudioSource TeleportSound;
    [SerializeField] private AudioSource WindAmbience;
    [SerializeField] private AudioSource TrafficNoise;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than 1 Audio manager in the scene.");

        }
        instance = this;
    }
    private void Start()
    {
        PlayBGM();
    }
    private void PlayBGM() { BGM.Play(); BGM.loop = true; }
    public void AnvilPlay() { Anvil.Play(); }
    public void BirdSoundPlay() { BirdAmbience.Play(); }
    public void ButtonSoundPlay() { ButtonSound.Play(); }
    public void CatAttacked2Play() { CatAttacked2.Play(); }
    public void CatCalling1Play() { CatCalling1.Play(); }
    public void CatCalling2Play() { CatCalling2.Play(); }
    public void CatAttacked1Play() { CatAttacked1.Play(); }
    public void CatScream1Play() { CatScream1.Play(); }
    public void CatScream2Play() { CatScream2.Play(); }
    public void ConcreteStep1Play() { ConcreteStep1.Play(); }
    public void ConcreteStep2Play() { ConcreteStep2.Play(); }
    public void ConcreteStep3Play() { ConcreteStep3.Play(); }
    public void ConcreteStep4Play() { ConcreteStep4.Play(); }
    public void DeathSoundPlay() { Death.Play(); }
    public void DuckQuackPlay() { DuckQuack.Play(); }
    public void GlassBreakPlay() { GlassBreak.Play(); }
    public void GlassFoot1Play() { GlassFoot1.Play(); }
    public void GlassFoot2Play() { GlassFoot2.Play(); }
    public void GlassFoot3Play() { GlassFoot3.Play(); }
    public void NestBreakingPlay() { NestBreaking.Play(); }
    public void PaperPlanePlay() { PaperPlane.Play(); }
    public void RespawnSoundPlay() { RespawnSound.Play(); }
    public void TeleportSoundPlay() { TeleportSound.Play(); }
    public void WindAmbiencePlay() { WindAmbience.Play(); }
    public void TrafficNoisePlay() { TrafficNoise.Play(); }
}
