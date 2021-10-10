using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
	//public AudioMixer audio_mixer;

	public bool channel_1;
	public bool channel_2;

	public bool stop;


	public float fadeout_speed = 10.0f;
	public float fadein_speed = 30.0f;

	private AudioSource audio_channel_1;
	private AudioSource audio_channel_2;





	private float audio_channel_1_vol = -80.0f;
	private float audio_channel_2_vol = -80.0f;



	private Object[] AudioArray_channel_1;
	private Object[] AudioArray_channel_2;





	// Use this for initialization
	void Start()
	{

		audio_channel_1 = (AudioSource)gameObject.AddComponent<AudioSource>();
		audio_channel_2 = (AudioSource)gameObject.AddComponent<AudioSource>();



		AudioArray_channel_1 = Resources.LoadAll("1", typeof(AudioClip));
		AudioArray_channel_2 = Resources.LoadAll("2", typeof(AudioClip));



		/*audio_channel_1.outputAudioMixerGroup = audio_mixer.FindMatchingGroups("channel_1")[0];
		audio_channel_2.outputAudioMixerGroup = audio_mixer.FindMatchingGroups("channel_2")[0];*/



		audio_channel_1.clip = AudioArray_channel_1[0] as AudioClip;
		audio_channel_2.clip = AudioArray_channel_2[0] as AudioClip;



		audio_channel_1.loop = true;
		audio_channel_2.loop = true;



		audio_channel_1.Play();
		audio_channel_2.Play();



	}

	// Update is called once per frame
	void Update()
	{
		SetVolumes();
		if (stop)
		{
			StopAllMusic();
		}

	}

	public void StopAllMusic()
	{
		channel_1 = false;
		channel_2 = false;


		if (audio_channel_1_vol < -79.0f)
		{
			audio_channel_1.Stop();
		}
		if (audio_channel_2_vol < -79.0f)
		{
			audio_channel_2.Stop();
		}


	}

	public void SetVolumes()
	{
		/*audio_mixer.SetFloat("channel_1", audio_channel_1_vol);
		audio_mixer.SetFloat("channel_2", audio_channel_2_vol);*/



		if (channel_1)
		{
			if (audio_channel_1_vol < 0.0f)
			{
				audio_channel_1_vol += fadein_speed * Time.deltaTime;
			}
		}
		if (!channel_1)
		{
			if (audio_channel_1_vol > -80.0f)
			{
				audio_channel_1_vol -= fadeout_speed * Time.deltaTime;
			}

		}

		if (channel_2)
		{
			if (audio_channel_2_vol < 0.0f)
			{
				audio_channel_2_vol += fadein_speed * Time.deltaTime;
			}
		}
		if (!channel_2)
		{
			if (audio_channel_2_vol > -80.0f)
			{
				audio_channel_2_vol -= fadeout_speed * Time.deltaTime;
			}

		}


	}

	public void StopMusic()
	{
		stop = true;
	}

	public void PlaySoft()
	{
		channel_1 = true;
		channel_2 = false;

	}

	public void PlayStress()
	{
		channel_1 = true;
		channel_2 = true;
	}
}
