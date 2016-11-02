using GameConsoleClient.Cores;
using System;
using System.Collections.Generic;

namespace GameConsoleClient.Components
{
    public class Tracker : IGameComponent
    {
        public readonly object SyncRoot = new object();
        public List<Player> players;
        public DateTime tmpTime;

        public float[] arr;

        public static string[] nameArr = new string[]
        {
            "So Lan Bi Cham FPS",
            "So Lan Bi Cham Thoi Gian Radar",
            "So Request",
            "So Response",
            "Kich Thuoc Data Gui Di",
            "Kich Thuoc Data Nhan Ve",
            "Kich Thuoc Gui Di Trung Binh",
            "Kich Thuoc Nhan Ve Trung Binh",
            "So Luong Event Nhan Duoc",
            "So Luong Event Trung Binh"
        };

        public enum Param : int
        {
            OutFPS = 0,
            OutTimeRadar = 1,
            AmountRequest = 2,
            AmountResponse = 3,
            SizeDataSent = 4,
            SizeDataRecieved = 5,
            ArrangeSizeDataSent = 6,
            ArrangeSizeDataRecieved = 7,
            AmountEventRadar = 8,
            ArrangeAmountEventRadar = 9
        }

        private long tmpByteOut = 0;
        private long tmpByteIn = 0;

        public Tracker()
        {
            players = new List<Player>();
            tmpTime = DateTime.Now;

            arr = new float[10];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = 0f;
            }
        }

        public void AddPlayer(Player pl)
        {
            lock (SyncRoot)
            {
                players.Add(pl);
            }
        }

        public void Start()
        {

        }

        public void Plus(Param param)
        {
            lock (SyncRoot)
            {
                arr[(int)param]++;
            }
        }

        public void Update()
        {
            lock (SyncRoot)
            {
                if ((DateTime.Now - tmpTime).TotalSeconds > 1)
                {
                    int countInWorld = 0;
                    int countLoging = 0;
                    int countLogined = 0;
                    int countWait = 0;
                    int countDis = 0;
                    int countConnected = 0;

                    foreach (Player pl in players)
                    {
                        if (pl != null)
                        {
                            if (pl.state == Player.State.InWorld)
                            {
                                countInWorld++;
                            }
                            else if (pl.state == Player.State.Logined)
                            {
                                countLogined++;
                            }
                            else if (pl.state == Player.State.Loging)
                            {
                                countLoging++;
                            }
                            else if (pl.state == Player.State.Wait)
                            {
                                countWait++;
                            }
                            else if (pl.state == Player.State.Disconnect)
                            {
                                countDis++;
                            }
                            else if (pl.state == Player.State.Connected)
                            {
                                countConnected++;
                            }

                            if (pl.PlayerPeer != null)
                            {
                                arr[(int)Param.SizeDataSent] += (pl.Peer.BytesIn - tmpByteOut);
                                tmpByteOut = pl.Peer.BytesOut;

                                arr[(int)Param.SizeDataRecieved] += (pl.Peer.BytesIn - tmpByteIn);
                                tmpByteIn = pl.Peer.BytesIn;
                            }
                        }
                    }

                    int countArrange = countLogined + countInWorld + countLoging + countWait + countConnected;

                    arr[(int)Param.ArrangeSizeDataSent] = arr[(int)Param.SizeDataSent] / (float)countArrange;
                    arr[(int)Param.ArrangeSizeDataRecieved] = arr[(int)Param.SizeDataRecieved] / (float)countArrange;
                    arr[(int)Param.ArrangeAmountEventRadar] = arr[(int)Param.AmountEventRadar] / (float)countArrange;

                    Console.WriteLine("======================================");
                    Console.WriteLine("Total Player : " + Program.AmountPeer);
                    Console.WriteLine("State InWorld : " + countInWorld);
                    Console.WriteLine("State Connected : " + countConnected);
                    Console.WriteLine("State Loging : " + countLoging);
                    Console.WriteLine("State Logined : " + countLogined);
                    Console.WriteLine("State Wait : " + countWait);
                    Console.WriteLine("State Dis : " + countDis);
                    Console.WriteLine("--------------------");
                    for (int i = 0; i < arr.Length; i++)
                    {
                        Console.WriteLine(string.Format("{0} : {1}", nameArr[i], arr[i]));
                        arr[i] = 0f;
                    }

                    tmpTime = DateTime.Now;
                }
            }
        }
    }
}
