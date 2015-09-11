using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AILibrary
{
    /// <summary>
    /// 작업 일지에 대한 정보를 담고 있는 클래스입니다.
    /// </summary>
    public class WorkBook : Item
    {
        /// <summary>
        /// 아이템 구성을 위해 필요한 정보를 통해 WorkBook 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="itemID">해당 작업일지의 고유 ID를 가리킵니다.</param>
        /// <param name="name">해당 작업일지의 이름입니다.</param>
        /// <param name="itemSprite">아이템의 이미지를 나타냅니다. 기본 값은 null입니다.</param>
        /// <param name="itemDescription">이 아이템에 대한 설명문을 나타냅니다.</param>
        /// <param name="isGet">획득되었는지에 대한 여부입니다. 기본 값은 False입니다.</param>
        /// <param name="isImported">Import 되었는지에 대한 여부입니다. 기본 값은 False입니다.</param>
        /// <param name="isUserReadInCUI">유저가 CUI 환경에서 작업 일지를 읽었는지에 대한 여부입니다. 기본 값은 False입니다. </param>
        /// <param name="isUserReadInGUI">유저가 GUI 환경에서 작업 일지를 읽었는지에 대한 여부입니다. 기본 값은 False입니다. </param>
        public WorkBook(int itemID, string name, Sprite itemSprite = null, string itemDescription = "", bool isGet = false, bool isImported = false, bool isUserReadInCUI = false, bool isUserReadInGUI = false)
            : base(itemID, name, itemSprite, itemDescription, isGet, isImported)
        {
            this.IsUserReadInCUI = isUserReadInCUI;
            this.IsUserReadInGUI = isUserReadInGUI;
        }

        /// <summary>
        /// 유저가 CUI 환경에서 작업 일지를 읽었는지에 대한 여부를 가져오거나 설정합니다.
        /// </summary>
        public bool IsUserReadInCUI
        {
            get;
            set;
        }

        /// <summary>
        /// 유저가 GUI 환경에서 작업 일지를 읽었는지에 대한 여부를 가져오거나 설정합니다.
        /// </summary>
        public bool IsUserReadInGUI
        {
            get;
            set;
        }
    }
}
