using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;

    private static AudioSource[] sfxSources;
    private static AudioSource musicSource1;
    private static AudioSource musicSource2;

    public AudioMixerGroup masterAudioMixerGroup;
    public AudioMixerGroup musicAudioMixerGroup;
    public AudioMixerGroup sfxAudioMixerGroup;

    private int sfxPointer = 0;

    private void Awake() {

        instance = this;

        //zaten başlatılmış
        if (sfxSources != null) {
            return;
        }

        //sfx başlat
        sfxSources = new AudioSource[16];
        for (var i = 0; i < sfxSources.Length; i++) {

            var sfxGo = new GameObject("SoundFx");
            DontDestroyOnLoad(sfxGo);

            var sfxSource = sfxGo.AddComponent<AudioSource>();
            sfxSource.rolloffMode = AudioRolloffMode.Linear;
            sfxSource.minDistance = 2;
            sfxSource.maxDistance = 12;
            sfxSource.outputAudioMixerGroup = sfxAudioMixerGroup;
            sfxSources[i] = sfxSource;

        }

        //müzik başlat
        var musicGo = new GameObject("Music");
        DontDestroyOnLoad(musicGo);

        musicSource1 = musicGo.AddComponent<AudioSource>();
        musicSource1.loop = true;
        musicSource1.outputAudioMixerGroup = musicAudioMixerGroup;

        musicSource2 = musicGo.AddComponent<AudioSource>();
        musicSource2.loop = true;
        musicSource2.outputAudioMixerGroup = musicAudioMixerGroup;

    }

    private void Start() {
        setMasterVolume(getMasterVolume());
        setMusicVolume(getMusicVolume());
        setSfxVolume(getSfxVolume());
    }

    //volume

    private float calculateDb(float volume) {
        return Mathf.Clamp(Mathf.Log(volume) * 20f, -80f, 0f);
    }

    public void setMasterVolume(float volume) {
        PlayerPrefs.SetFloat("MasterVolume", volume);
        masterAudioMixerGroup.audioMixer.SetFloat("MasterVolume", calculateDb(volume));
    }

    public void setMusicVolume(float volume) {
        PlayerPrefs.SetFloat("MusicVolume", volume);
        musicAudioMixerGroup.audioMixer.SetFloat("MusicVolume", calculateDb(volume));
    }

    public void setSfxVolume(float volume) {
        PlayerPrefs.SetFloat("SfxVolume", volume);
        sfxAudioMixerGroup.audioMixer.SetFloat("SfxVolume", calculateDb(volume));
    }

    public float getMasterVolume() {
        return PlayerPrefs.GetFloat("MasterVolume", 1f);
    }

    public float getMusicVolume() {
        return PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    }

    public float getSfxVolume() {
        return PlayerPrefs.GetFloat("SfxVolume", 1f);
    }

    //play sfx

    public void playSfxByNote(AudioClip clip, float note, Vector3 position = default(Vector3)) {
        note = Mathf.Min(note, 12);
        var scale = Mathf.Pow(2f, 1f / 12f);
        var pitch = Mathf.Pow(scale, note);
        playSfx(clip, position, pitch, pitch);
    }

    public void playSfxRandomPitch(AudioClip clip, Vector3 position = default(Vector3), float minPitch = 0.75f, float maxPitch = 1.25f) {
        playSfx(clip, position);
    }

    public void playSfx(AudioClip clip, Vector3 position = default(Vector3), float minPitch = 1f, float maxPitch = 1f) {
        if (clip) {

            //çal keke
            var sfxSource = sfxSources[sfxPointer];
            if (position == default(Vector3)) {
                sfxSource.spatialBlend = 0f;
            }
            else {
                sfxSource.spatialBlend = 1f;
                sfxSource.transform.position = position;
            }
            sfxSource.pitch = Random.Range(minPitch, maxPitch);
            sfxSource.clip = clip;
            sfxSource.Play();

            //sonraki
            if (++sfxPointer >= sfxSources.Length) {
                sfxPointer = 0;
            }

        }
    }

    //play music

    public void stopMusic() {
        musicSource1.Stop();
        musicSource2.Stop();
    }

    public void playMusic(AudioClip clip) {
        if (musicSource1.clip != clip) {
            StopAllCoroutines();
            StartCoroutine(transition(clip));
        }
    }

    private IEnumerator transition(AudioClip clip) {

        //yeni müziği başlat
        musicSource2.clip = clip;
        musicSource2.Play();

        //geçiş yap
        var duration = 1f;
        var elapsed = 0f;
        var volume = getMusicVolume();
        var volume1 = musicSource1.volume;
        var volume2 = musicSource2.volume;
        while (elapsed <= duration) {
            var t = elapsed / duration;
            elapsed += Time.unscaledDeltaTime;
            musicSource1.volume = Mathf.Lerp(volume1, 0f, t);
            musicSource2.volume = Mathf.Lerp(volume2, volume, t);
            yield return null;
        }

        //tamamla
        var tmp = musicSource1;
        musicSource1 = musicSource2;
        musicSource2 = tmp;
        musicSource2.Stop();

    }

}