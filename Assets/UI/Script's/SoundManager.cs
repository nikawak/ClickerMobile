using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace FWC
{
    public class SoundManager : MonoBehaviour
    {
        //Armazenar o Mixer

        public AudioMixer masterMixer;

        //public AudioSource source_Dialogo; //audio source da música

        private float volume_sfx = 1;
        private float volume_music = 1;

        //Mute

        [SerializeField] Image image_SFX, image_Music; //Armazenar imagem do botão mute da cena

        public Sprite[] sprite_SFX , sprite_Music; //Armazenar sprites "Icon_music On" e "Icon_music Off"

        //Referencia estática deste Script, para que ele possa ser acessado pelos outros scripts

        public static SoundManager Instance;


        //checar se está mutado ou não

        private bool muteSFX, muteMusic;

        //Armazenar áudios como .mp4 .ogg

        public AudioClip[] clip_SFX; //efeitos sonoros
        public AudioClip[] clip_Music; //música

        //Armazenar Audio Sources da cena

        public AudioSource source_SFX; //audio source para efeitos sonoros
        public AudioSource source_Music; //audio source para música


        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {        
            source_Music.volume = volume_music;            
            source_SFX.volume = volume_sfx;            
        }

        public void PlaySFX(AudioClip clip)
        {
            if (!source_SFX.isPlaying)
            {
                source_SFX.clip = clip;
                source_SFX.PlayOneShot(source_SFX.clip);
            }

        }

        public void PlaySFX(int i)
        {  
           source_SFX.clip = clip_SFX[i];
           source_SFX.PlayOneShot(source_SFX.clip);           

        }

        public void PlayMusic(int i)
        {
            source_Music.clip = clip_Music[i];
            source_Music.PlayOneShot(source_Music.clip);
        }
   

        public void MuteMusic()
        {
            muteMusic = !muteMusic;

            if (muteMusic)
            {                
                image_Music.sprite = sprite_Music[1];
                masterMixer.SetFloat("VolumeMusic", -80f);
                return;
            }

            image_Music.sprite = sprite_Music[0];
            masterMixer.SetFloat("VolumeMusic", volume_music);

        }

        public void MuteSFX()
        {
            muteSFX = !muteSFX;

            if (muteSFX)
            {
                image_SFX.sprite = sprite_SFX[1];
                masterMixer.SetFloat("VolumeSFX", -80f);
                return;
            }

            image_SFX.sprite = sprite_SFX[0];
            masterMixer.SetFloat("VolumeSFX", volume_sfx);

        }

        public void ChangeVolumeMusic(float musicVol)
        {
            volume_music = musicVol;

            if (muteMusic) return;

            masterMixer.SetFloat("VolumeMusic", musicVol);
        }

        public void ChangeVolumeSFX(float sfxVol)
        {
            volume_sfx = sfxVol;

            if (muteSFX) return;

            masterMixer.SetFloat("VolumeSFX", sfxVol);
        }



    }

}
