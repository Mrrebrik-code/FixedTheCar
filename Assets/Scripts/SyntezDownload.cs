using FrostweepGames.Plugins.Core;
using FrostweepGames.Plugins.GoogleCloud.TextToSpeech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Itibsoft.TextToSpeech.Syntez
{
	public class SyntezDownload : MonoBehaviour
	{
		public static SyntezDownload Instance;
		private string currentInfo;
		private string currentLang;
		private string content;
		private string languageCode;

		private GCTextToSpeech _gcTextToSpeech;

		private void Awake()
		{
			Instance = this;

		}
		public bool ConnectToGTTS()
		{
			if (_gcTextToSpeech != null)
			{
				return true;
			}
			else
			{
				_gcTextToSpeech = GCTextToSpeech.Instance;
				_gcTextToSpeech.SynthesizeSuccessEvent += _gcTextToSpeech_SynthesizeSuccessEvent;
				return _gcTextToSpeech != null;
			}
			
		}
		public void SynthesizeHandler(string text, string language)
		{
			_gcTextToSpeech.SynthesizeSuccessEvent += _gcTextToSpeech_SynthesizeSuccessEvent;
			_gcTextToSpeech.SynthesizeFailedEvent += _gcTextToSpeech_SynthesizeFailedEvent;
			currentInfo = text;
			currentLang = language;

			content = text;
			Debug.Log(content);
			GetVoicesHandler(language);
			_gcTextToSpeech.Synthesize(text, new VoiceConfig()
			{
				gender = Enumerators.SsmlVoiceGender.MALE,
				languageCode = languageCode,
				name = SetTypeVoice("ru-RU-Wavenet-D")
			});
		}

		private void _gcTextToSpeech_SynthesizeFailedEvent(string data, long requestId)
		{
		}

		private void GetVoicesHandler(string language)
		{
			switch (language)
			{
				case "Russian":
					languageCode = "ru-Ru";
					break;
				case "English":
					languageCode = "en_US";
					break;
				case "Romance":
					languageCode = "ro-RO";
					break;
				case "French":
					languageCode = "fr_FR";
					break;
				case "German":
					languageCode = "de_DE";
					break;
				case "Spanish":
					languageCode = "vi-VN";
					break;
				case "Italian":
					languageCode = "it_IT";
					break;
				case "Finnish":
					languageCode = "fi_FI";
					break;
				case "Japanese":
					languageCode = "ja_JP";
					break;
				case "ChineseTraditional":
					languageCode = "cmn_CN";
					break;
				case "Korean":
					languageCode = "vi-VN";
					break;
			}

		}
		private string SetTypeVoice(string type)
		{
			string typeVoice = languageCode + "-" + "Wavenet" + "-" + type;
			return typeVoice;
		}

		private void _gcTextToSpeech_SynthesizeSuccessEvent(PostSynthesizeResponse response, long requestId)
		{
			ServiceLocator.Get<IMediaManager>().SaveAudioFileAsFile(
				response.audioContent,
				 Application.dataPath + @"/Resources/Syntez/",
				"sound_" + currentInfo + "_" + currentLang,
				Enumerators.AudioEncoding.LINEAR16); ;



			Debug.Log("Download apply: " + "sound_" + currentInfo + "_" + currentLang);
		}
	}

}
