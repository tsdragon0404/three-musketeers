using System;
using System.Collections.Generic;

namespace TM.Chat.Models
{
    public class TransferPackage
    {
        public static class DataByteIndex
        {
            public const int Action = 0;
            public const int Data = 4;
        }

        public TransferAction TransferAction { get; set; }
        public object Data { get; set; }

        public TransferPackage(TransferAction transferAction, object data)
        {
            TransferAction = transferAction;
            Data = data;
        }

        public TransferPackage(byte[] data)
        {
            TransferAction = (TransferAction) BitConverter.ToInt32(data, DataByteIndex.Action);

            try
            {
                byte[] dataBytes = new byte[8192];
                Buffer.BlockCopy(data, DataByteIndex.Data, dataBytes, 0, data.Length - DataByteIndex.Data);
                Data = dataBytes.ToObject();
            }
            catch (Exception)
            {
                Data = null;
            }
        }

        public byte[] ToByteArray()
        {
            List<byte> result = new List<byte>();

            result.AddRange(BitConverter.GetBytes((int)TransferAction));
            result.AddRange(Data.ToByteArray());

            return result.ToArray();
        }
    }
}
