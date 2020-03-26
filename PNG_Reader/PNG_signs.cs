using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace PNG_Reader
{
    class PNG_signs
    {
        public string PNG_sign = "89-50-4E-47-0D-0A-1A-0A";
        public string[,] signs = new string[21, 2] { { "IHDR", "49-48-44-52" }, { "PLTE", "50-4C-54-45" }, { "IDAT", "49-44-41-54" },
                                                     { "IEND", "49-45-4E-44" }, { "bKGD", "62-4B-47-44" }, { "cHRM", "63-48-52-4D" },
                                                     { "dSIG", "64-53-49-47" }, { "eXIf", "65-58-49-66" }, { "gAMA", "67-41-4D-41" },
                                                     { "hIST", "68-49-53-54" }, { "iCCP", "69-43-43-50" }, { "iTXt", "69-54-58-74" },
                                                     { "pHYs", "70-48-59-73" }, { "sBIT", "73-42-49-54" }, { "sPLT", "73-50-4C-54" },
                                                     { "sRGB", "73-52-47-42" }, { "sTER", "73-54-45-52" }, { "tEXt", "74-45-58-74" },
                                                     { "tIME", "74-49-4D-45" }, { "tRNS", "74-52-4E-53" }, { "zTXt", "7A-54-58-74" } };
        public string IHDR_sign = "49-48-44-52";
        public string PLTE_sign = "50-4C-54-45";
        public string IDAT_sign = "49-44-41-54";
        public string IEND_sign = "49-45-4E-44";
        public string bKGD_sign = "62-4B-47-44";
        public string cHRM_sign = "63-48-52-4D";
        public string dSIG_sign = "64-53-49-47";
        public string eXIf_sign = "65-58-49-66";
        public string gAMA_sign = "67-41-4D-41";
        public string hIST_sign = "68-49-53-54";
        public string iCCP_sign = "69-43-43-50";
        public string iTXt_sign = "69-54-58-74";
        public string pHYs_sign = "70-48-59-73";
        public string sBIT_sign = "73-42-49-54";
        public string sPLT_sign = "73-50-4C-54";
        public string sRGB_sign = "73-52-47-42";
        public string sTER_sign = "73-54-45-52";
        public string tEXt_sign = "74-45-58-74";
        public string tIME_sign = "74-49-4D-45";
        public string tRNS_sign = "74-52-4E-53";
        public string zTXt_sign = "7A-54-58-74";

        public bool IsPNG(BinaryReader Pic)
        {
            if (BitConverter.ToString(Pic.ReadBytes(8)) == PNG_sign)
            {
                Console.WriteLine("Obraz PNG");
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ExploreFile(BinaryReader Pic, Queue<SignInfo> existingSigns)
        {
            byte[] buff = new byte[4];
            string hexBuff = null;
            string hexSign = null;
            string sign_name = null;
            int iterator = 0;

            do
            {
                buff[0] = buff[1];
                buff[1] = buff[2];
                buff[2] = buff[3];
                buff[3] = Pic.ReadByte();
                hexBuff = BitConverter.ToString(buff);

                for (int i = 0; i < 21; i++)
                {
                    if (hexBuff == signs[i, 1])
                    {
                        if (hexSign == null)
                        {
                            hexSign = hexBuff;
                            sign_name = signs[i, 0];
                        }
                        else
                        {
                            SignInfo sign = new SignInfo();
                            sign.Sign = sign_name;
                            sign.hexSign = hexSign;
                            sign.byteLength = iterator-12;
                            existingSigns.Enqueue(sign);
                            hexSign = hexBuff;
                            sign_name = signs[i, 0];
                        }
                        iterator = 0;
                    }
                }

                iterator++;

            } while (!(hexBuff == IEND_sign));
        }

        public int FindSign(BinaryReader Pic, string hexSign)
        {
            byte[] buff = new byte[4];
            buff = Pic.ReadBytes(4);

            while (!(BitConverter.ToString(buff) == IEND_sign))
            {
                if (BitConverter.ToString(buff) == hexSign) return 1;
                buff[0] = buff[1];
                buff[1] = buff[2];
                buff[2] = buff[3];
                buff[3] = Pic.ReadByte();
            }

            return 0;
        }
    }
}
