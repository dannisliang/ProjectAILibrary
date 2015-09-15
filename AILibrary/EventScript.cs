using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AILibrary
{
    /// <summary>
    /// 메인 Scene에서 발생하는 Event에 대한 정보를 관리하는 클래스입니다.
    /// </summary>
    public class EventScript
    {
        /// <summary>
        /// EventScript 인스턴스를 초기화합니다.
        /// </summary>
        public EventScript()
        {
            this.DisableEvent();
        }

        /// <summary>
        /// 주어진 XmlFile을 통해 메인에서 발생할 이벤트를 설정합니다.
        /// <param name="eventXmlFileNameToRead">이벤트 실행 시 참조할 Xml 파일입니다. Resources/Scripts 폴더 내에서 참조합니다.</param>
        /// </summary>
        public void SetEvent(string eventXmlFileNameToRead)
        {
            this.IsEventSet = true;
            this.EventXmlFileName = eventXmlFileNameToRead;
        }

        /// <summary>
        /// 설정되어 있는 이벤트를 비활성화합니다.
        /// </summary>
        public void DisableEvent()
        {
            this.IsEventSet = false;
            this.EventXmlFileName = string.Empty;
        }

        /// <summary>
        /// 이벤트가 설정되었는지 여부를 가져옵니다.
        /// </summary>
        public bool IsEventSet
        {
            get; private set;
        }

        /// <summary>
        /// 메인에서 발생시킬 이벤트의 스크립트를 담는 XmlFile의 이름을 가져옵니다.
        /// </summary>
        public string EventXmlFileName
        {
            get; private set;
        }
    }
}
