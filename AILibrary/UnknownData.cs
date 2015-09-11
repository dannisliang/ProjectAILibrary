using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AILibrary
{
    /// <summary>
    /// 미지의 자료에 대한 정보를 담고 있는 클래스입니다.
    /// </summary>
    public class UnknownData : Item
    {
        /// <summary>
        /// 아이템 구성을 위해 필요한 정보를 통해 UnknownData 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="itemID">해당 작업일지의 고유 ID를 가리킵니다.</param>
        /// <param name="name">해당 작업일지의 이름입니다.</param>
        /// <param name="itemSprite">아이템의 이미지를 나타냅니다. 기본 값은 null입니다.</param>
        /// <param name="itemDescription">이 아이템에 대한 설명문을 나타냅니다.</param>
        /// <param name="isGet">획득되었는지에 대한 여부입니다. 기본 값은 False입니다.</param>
        /// <param name="isImported">Import 되었는지에 대한 여부입니다. 기본 값은 False입니다.</param>
        public UnknownData(int itemID, string name, Sprite itemSprite, string itemDescription, bool isGet = false, bool isImported = false)
            : base(itemID, name, itemSprite, itemDescription, isGet, isImported)
        {
        }
    }
}
