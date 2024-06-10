using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }
    public AudioSource BGM;
    public AudioSource Anvil;
    public AudioSource BirdAmbience;
    public AudioSource ButtonSound;
    public AudioSource CatAttacked1;
    public AudioSource CatAttacked2;
    public AudioSource CatCalling1;
    public AudioSource CatCalling2;
    public AudioSource CatScream1;
    public AudioSource CatScream2;
    public AudioSource ConcreteStep1;
    public AudioSource ConcreteStep2;
    public AudioSource ConcreteStep3;
    public AudioSource ConcreteStep4;
    public AudioSource Death;
    public AudioSource DuckQuack;
    public AudioSource GlassBreak;
    public AudioSource GlassFoot1;
    public AudioSource GlassFoot2;
    public AudioSource GlassFoot3;
    public AudioSource NestBreaking;
    public AudioSource PaperPlane;
    public AudioSource RespawnSound;
    public AudioSource TeleportSound;
    public AudioSource WindAmbience;
    public AudioSource TrafficNoise;

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
