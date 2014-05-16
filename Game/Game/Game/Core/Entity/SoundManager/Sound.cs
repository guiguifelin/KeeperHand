using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class Sound
    {
        //Fields
        private LinkedList<SoundEffect> noise;
        private LinkedList<SoundEffectInstance> instance;
        private LinkedList<Song> music;
        protected int n;
        protected bool mute;
        private float a = 0.0f;
        //Get & Set

        //Constructors
        public Sound()
        {
            this.noise = new LinkedList<SoundEffect>();
            this.instance = new LinkedList<SoundEffectInstance>();
            this.music = new LinkedList<Song>();
        }
        //Methods

        #region Noise
        public int CreateNoise(SoundEffect sound)
        {
            noise.AddLast(sound);
            instance.AddLast(sound.CreateInstance());
            return instance.Count - 1;
        }

        public void InitNoise(int pos, bool loop, float volume)
        {
            SoundEffectInstance i;
            i = instance.ElementAt(pos);
            i.IsLooped = loop;
            i.Volume = volume;
        }

        public void PlayNoise(int pos)
        {
            instance.ElementAt(pos).Play();
        }

        public void PlayAllNoises()
        {
            foreach (SoundEffectInstance sei in instance)
            {
                sei.Play();
            }
        }

        public void PauseNoise()
        {
            foreach (SoundEffectInstance sei in instance)
            {
                sei.Stop();
            }
        }

        public void MuteNoises()
        {
            foreach (SoundEffectInstance sei in instance)
            {
                sei.Volume = 0.0f;
            }
        }

        public void UnmuteNoises()
        {
            foreach (SoundEffectInstance sei in instance)
            {
                sei.Volume = 0.5f;
            }
        }

        public void VolumeDownNoises()
        {
            foreach (SoundEffectInstance sei in instance)
            {
                if (sei.Volume > 0.1f)
                {
                    sei.Volume -= 0.1f;
                }
            }
        }

        public void VolumeUpNoises()
        {
            foreach (SoundEffectInstance sei in instance)
            {
                if (sei.Volume < 0.9f)
                {
                    sei.Volume += 0.1f;
                }
            }
        }

        public void RemoveNoise(int pos)
        {
            instance.Remove(instance.ElementAt(pos));
        }
#endregion Noise

        #region Song

        public void SetSong(float volume, bool loop)
        {
            MediaPlayer.IsRepeating = loop;
            MediaPlayer.Volume = volume;
        }
        public void Next_Song()
        {
            if (n > music.Count - 1)
            {
                n = 0;
            }
            else
            {
                n++;
            }
        }
        public void Previous_Song()
        {
            if (n < 0)
            {
                n = music.Count - 1;
            }
            else
            {
                n--;
            }
        }
        public void InitSong(Song song)
        {
            music.AddLast(song);
        }

        public int AddSong(Song song)
        {
            music.AddLast(song);
            return music.Count - 1;
        }

        public void RemoveSong(int pos)
        {
            music.Remove(music.ElementAt(pos));
        }

        public void PlaySong(int n)
        {
            this.n = n;
            MediaPlayer.Play(music.ElementAt(n));
        }

        public void StopSong()
        {
            MediaPlayer.Stop();
        }

        public void PauseSong()
        {
            MediaPlayer.Pause();
        }

        public void ResumeSong()
        {
            MediaPlayer.Resume();
        }

        public void Volume_Up()
        {
            if (MediaPlayer.Volume != 1.0f)
            {
                MediaPlayer.Volume += 0.01f;
            }
        }

        public void Volume_Down()
        {
            if (MediaPlayer.Volume != 0.0f)
            {
                MediaPlayer.Volume -= 0.01f;
            }
        }
        public float Mute()
        {
            if (MediaPlayer.Volume != 0.0f)
            {
                a = MediaPlayer.Volume;
                MediaPlayer.Volume = 0.0f;
            }
            return a;
        }
        public void Unmute()
        {
            if (MediaPlayer.Volume == 0.0f)
            {
                MediaPlayer.Volume = a;
            }
        }

        #endregion Song
    }
}