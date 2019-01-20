using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace goSiwonDefine
{
    #region struct
    struct eventInfo {
        public float percent; // 퍼센테이지 -> 작성시 0 <= n < 100 범주에서 작성
        public float satisfaction; // 영향 만족도
        public int gold; // 영향 금액 
        public eventInfo(float percent,float satisfaction,int gold) {
            this.percent = percent;
            this.satisfaction = satisfaction;            
            this.gold = gold;
        }
    }
    #endregion
    #region enum
    public enum roomID {
        none=-1,
        inPrivateSpaceCatergory=0,
        //룸인덱싱을 어디부터??
        room1,
        room2,
        room3,
        room4,
        room5,
        room6,
        room7,
        room8,
        room9,
        room10,        

        inPublicSpaceCatergory = 100,
        kitchen,
        restRoom,
        showerRoom,

        moving
    }
    public enum itemID
    {
        none = -1,

        expendablesCatergory =0,
        detergent,
        noddle,
        rice,
        soap,
        scrubbers,
        tableWare,

        publicsCatergory=1000,
        showerHead,
        toilet,
        riceCooker,
        induction,
        refrigerator,
        purifier,
        boiler,
        dryingRack,
        extinguisher, //소화기
        washer,
        wifi, 
        

        roomsCatergory=2000,
        bed,
        curtain,
        desk,
        tv,
        chair,
        hanger,
        window
    }
    public enum eventID {
        none=-1,
        nonDestroy=0,
        smokeInRoom,
        drunken,
        withFreind,
        riceCake,
        shoeMeTheMoney,
        party,
        noMoney,        

        destoryableEventCatergory=1000,
        thief,
        typhoon,
        kitchenBreak,
        fight,
        publicBreak,
        fire,
        toiletBlock,
        doorBreak,

        max
    }
    public enum jobID {        
        pinky,
        sam,
        noJa,

    }
    #endregion
    #region Interface


    #endregion
    public static class projectPath {
        public static string prefabPath = @"prefab/{0}";
        public static string particlePath = @"particle/{0}";
    }

    public static class Define{

        // x-z평면에 대한 거리 계산 
        public static bool IsInRange(Vector3 pos1, Vector3 pos2, float Range) {
            Vector3 dis = pos2 - pos1;
            return (dis.x * dis.x) + (dis.z * dis.z) < Range * Range;
        }
    }
    public static class ExtensionMethod {
        public static void endIndexing<T>(this List<T> li, int index){
            if (index >= li.Count || index < 0 ) return;
            li.endIndexing(li[index]);
        }
        public static void endIndexing<T>(this List<T> li, T data) {
            if (!li.Contains(data)) return;
            li.Remove(data);
            li.Add(data);
        }
        public static void listShuffle<T>(this List<T> li)
        {
            int n = li.Count-1;
            while (n > 0) {
                int r = Random.Range(0, n);
                T tmp = li[n];
                li[n] = li[r];
                li[r] = tmp;

                n--;
            }
        }
    }
}
