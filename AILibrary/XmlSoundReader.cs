using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AILibrary
{
    /// <summary>
    /// 스크립트의 Xml 파일을 읽어 Sound 스크립트와 관련된 항목을 Parsing 해주는 클래스입니다.
    /// </summary>
    public class XmlSoundReader : XmlScriptReader
    {
        /// <summary>
        /// 주어진 정보를 이용하여 XmlSoundReader 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="filePathOrContent">Xml 파일이 있는 경로 혹은 Xml 내용 자체입니다.</param>
        /// <param name="isPath">주어진 문자열이 파일의 경로인지에 대한 여부입니다.</param>
        public XmlSoundReader(string filePathOrContent, bool isPath) : base(filePathOrContent, isPath)
        {
        }

        /// <summary>
        /// 대상 스크립트에서 해당 ID에 해당하는 스크립트에서 사운드가 반복되는 여부를 읽어옵니다.
        /// </summary>
        /// <param name="scriptID">목표 스크립트 ID입니다.</param>
        /// <returns>검색 결과로 나온 결과입니다.</returns>
        public bool GetIsRepeat(int scriptID)
        {
            if (this.IsNeedThisScript(5, scriptID))
            {
                return bool.Parse(base.GetLevelTwoElementValueFromXml("Repeat", scriptID));
            }

            throw new InvalidOperationException("이 스크립트는 사운드 스크립트에 해당하지 않는 스크립트입니다.");
        }

        /// <summary>
        /// 대상 스크립트에서 해당 ID에 해당하는 스크립트에서 사운드 파일을 읽어옵니다.
        /// </summary>
        /// <param name="scriptID">목표 스크립트 ID입니다.</param>
        /// <returns>검색 결과로 나온 사운드 파일입니다.</returns>
        public AudioClip GetSound(int scriptID)
        {
            if (this.IsNeedThisScript(5, scriptID))
            {
                return Resources.Load<AudioClip>("Sounds/" + base.GetLevelTwoElementValueFromXml("Sound", scriptID));
            }

            throw new InvalidOperationException("이 스크립트는 사운드 스크립트에 해당하지 않는 스크립트입니다.");
        }

        /// <summary>
        /// 대상 스크립트에서 정보를 수집하여 SoundScript 인스턴스를 만듭니다.
        /// </summary>
        /// <param name="scriptID">목표 스크립트 ID입니다.</param>
        /// <returns>완성된 SoundScript 인스턴스입니다.</returns>
        public override Script GetScript(int scriptID)
        {
            if (this.IsNeedThisScript(5, scriptID))
            {
                return new SoundScript(this.GetSound(scriptID), this.GetIsRepeat(scriptID));
            }

            throw new InvalidOperationException("이 스크립트는 사운드 스크립트에 해당하지 않는 스크립트입니다.");
        }
    }
}
