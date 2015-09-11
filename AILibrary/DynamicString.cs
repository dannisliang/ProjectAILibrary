using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AILibrary
{
    /// <summary>
    /// 정적인 문자열과 동적인 문자열을 나눠서 관리할 수 있는 클래스입니다.
    /// </summary>
    public class DynamicString
    {
        private StringBuilder dynamicPart;          // 동적인 부분의 문자열을 담는 변수입니다.
        private StringBuilder staticPart;           // 정적인 부분의 문자열을 담는 변수입니다.

        /// <summary>
        /// 초기 정적/동적 문자열을 가지고 DynamicString 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="initialStatic">초기의 정적 문자열입니다.</param>
        /// <param name="initialDynamic">초기의 동적 문자열입니다.</param>
        public DynamicString(string initialStatic = "", string initialDynamic = "")
        {
            this.staticPart = new StringBuilder(initialStatic);
            this.dynamicPart = new StringBuilder(initialDynamic);
        }

        /// <summary>
        /// 현재 동적인 부분의 문자열을 가져옵니다.
        /// </summary>
        public string DynamicPartString
        {
            get { return this.dynamicPart.ToString(); }
        }

        /// <summary>
        /// 현재 정적인 부분의 문자열을 가져옵니다.
        /// </summary>
        public string StaticPartString
        {
            get { return this.staticPart.ToString(); }
        }

        /// <summary>
        /// 현재 정적인 부분의 문자열을 초기화합니다.
        /// </summary>
        public void ClearStaticString()
        {
            this.staticPart = new StringBuilder();
        }

        /// <summary>
        /// 현재 동적인 부분의 문자열을 초기화합니다.
        /// </summary>
        public void ClearDynamicString()
        {
            this.dynamicPart = new StringBuilder();
        }

        /// <summary>
        /// 동적 문자열에 내용을 추가합니다.
        /// </summary>
        /// <param name="toSet">추가하려는 문자열입니다.</param>
        /// <param name="appendNewLine">새로운 줄을 추가할지에 대한 여부입니다. 기본 값은 false입니다.</param>
        public void SetDynamicString(string toSet, bool appendNewLine = false)
        {
            this.ClearDynamicString();

            if (appendNewLine)
            {
                this.dynamicPart.AppendLine(toSet);
            }
            else
            {
                this.dynamicPart.Append(toSet);
            }
        }

        /// <summary>
        /// 정적 문자열에 내용을 추가합니다.
        /// </summary>
        /// <param name="toSet">추가하려는 문자열입니다.</param>
        /// <param name="appendNewLine">새로운 줄을 추가할지에 대한 여부입니다. 기본 값은 false입니다.</param>
        public void SetStaticString(string toSet, bool appendNewLine = false)
        {
            this.ClearStaticString();

            if (appendNewLine)
            {
                this.staticPart.AppendLine(toSet);
            }
            else
            {
                this.staticPart.Append(toSet);
            }
        }

        /// <summary>
        /// 동적 문자열에 내용을 추가합니다.
        /// </summary>
        /// <param name="toAdd">추가하려는 문자열입니다.</param>
        /// <param name="appendNewLine">새로운 줄을 추가할지에 대한 여부입니다. 기본 값은 false입니다.</param>
        public void AddDynamicString(string toAdd, bool appendNewLine = false)
        {
            if (appendNewLine)
            {
                this.dynamicPart.AppendLine(toAdd);
            }
            else
            {
                this.dynamicPart.Append(toAdd);
            }
        }

        /// <summary>
        /// 정적 문자열에 내용을 추가합니다.
        /// </summary>
        /// <param name="toAdd">추가하려는 문자열입니다.</param>
        /// <param name="appendNewLine">새로운 줄을 추가할지에 대한 여부입니다. 기본 값은 false입니다.</param>
        public void AddStaticString(string toAdd, bool appendNewLine = false)
        {
            if (appendNewLine)
            {
                this.staticPart.AppendLine(toAdd);
            }
            else
            {
                this.staticPart.Append(toAdd);
            }
        }
    }
}