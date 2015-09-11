using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AILibrary
{
    /// <summary>
    /// 하나의 메시지 Script 정보를 가지고 있는 클래스입니다.
    /// </summary>
    public class MessageScript : Script
    {
        private readonly string defaultCharacter = "アイ";

        /// <summary>
        /// 메시지 Script의 정보를 통해 인스턴스를 초기화합니다. 이 경우 대화 인물의 이름은 アイ로 설정됩니다.
        /// </summary>
        /// <param name="message">인물의 대사입니다.</param>
        /// <param name="image">인물의 이미지입니다.</param>
        public MessageScript(string message, Sprite image)
        {
            base.ScriptCode = (int)ScriptTypeCode.MessageScript;
            base.IsStepScript = true;
            this.Character = this.defaultCharacter;
            this.Message = message;
            this.Image = image;
        }

        /// <summary>
        /// 메시지 Script의 정보를 통해 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="character">대화하는 인물의 이름입니다.</param>
        /// <param name="message">인물의 대사입니다.</param>
        /// <param name="image">인물의 이미지입니다.</param>
        public MessageScript(string character, string message, Sprite image)
        {
            this.Character = character;
            this.Message = message;
            this.Image = image;
        }

        /// <summary>
        /// 현재 인물의 대사를 가져옵니다.
        /// </summary>
        public string Message
        {
            get;
            private set;
        }

        /// <summary>
        /// 현재 인물의 이미지를 가져옵니다.
        /// </summary>
        public Sprite Image
        {
            get;
            private set;
        }

        /// <summary>
        /// 대화하는 인물의 이름을 가져옵니다.
        /// </summary>
        public string Character
        {
            get;
            private set;
        }
    }
}