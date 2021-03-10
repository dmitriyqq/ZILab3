using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZILab3Lib
{
    public class EncodingService
    {
        //public bool ValidateKey(string key)
        //{
        //    return key.All(e => ValidateKeyChar(Convert.ToInt32(e.ToString())));
        //}

        //private byte CyclicBitShift(byte a, byte s) => (byte)((a >> s) | ((a << (8 - s)) & 255));

        //private byte ShiftByte(byte b, int i, byte[] key)
        //{
        //    const byte evenMask = 0b01010101;
        //    const byte oddMask = 0b10101010;
        //    var bEven = b & evenMask;
        //    var bOdd = b & oddMask;
        //    return CyclicBitShift((byte)((bEven << 1) | (bOdd >> 1)), key[i % key.Length]);
        //}

        //private byte UnshiftByte(byte b, int i, byte[] key)
        //{
        //    var unshiftedB = CyclicBitShift(b, (byte)(8 - key[i % key.Length]));

        //    const byte evenMask = 0b01010101;
        //    const byte oddMask = 0b10101010;

        //    var bEven = unshiftedB & evenMask;
        //    var bOdd = unshiftedB & oddMask;

        //    return (byte)((bEven << 1) | (bOdd >> 1));

        private uint CreateInt(byte[] data, int i)
        {
            uint code = 0;
            for (int j = 3; j >= 0; j--)
            {
                if (i + j < data.Length) {
                    code <<= 8;
                    code |= data[i + j];
                }
            }
            return code;
        }

        private byte[] WriteBytes(uint[] ints) {
            var bytes = new List<byte>();

            for (int i = 0; i < ints.Length; i++)
            {
                bytes.Add((byte)ints[i]);
                bytes.Add((byte)(ints[i] >> 8));
                bytes.Add((byte)(ints[i] >> 16));
                bytes.Add((byte)(ints[i] >> 24));
            }

            return bytes.ToArray();
        }


        public byte[] Encode(byte[] data, uint[] key)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            var intData = new List<uint>();
            for (int i = 0; i < data.Length; i+=4)
            {
                intData.Add(CreateInt(data, i));
            }

            while (intData.Count % 4 != 0)
            {
                intData.Add(0);
            }

            var intDataArray = intData.ToArray();
            for(int i = 0; i < intDataArray.Length; i+= 4)
            {
                uint[] block2 = new uint[4] { intDataArray[i], intDataArray[i + 1], intDataArray[i + 2], intDataArray[i + 3] };

                EncodeBlock(block2, key);

                intDataArray[i] = block2[0];
                intDataArray[i + 1] = block2[1];
                intDataArray[i + 2] = block2[2];
                intDataArray[i + 3] = block2[3];
            }

            return WriteBytes(intDataArray);
        }

        private void EncodeBlock(uint[] block, uint[] key)
        {
            for (int i = 0; i < 4; i++)
            {
                block[i] ^= key[(i) % 4];
            }

            for (int j = 1; j <= 6; j++)
            {
                f(block);

                for (int i = 0; i < 4; i++)
                {
                    block[i] = block[i] ^ key[(i + j) % 4];
                }
            }
        }

        private int mod(int x, int m)
        {
            return (x % m + m) % m;
        }

        private void f(uint[] block)
        {
            const uint C = 0x2aaaaaaa;
            const uint C0 = 0x025f1cdb;
            const uint C1 = 2 * C0;
            const uint C2 = C0 << 3;
            const uint C3 = C0 << 7;


            uint[] c = new uint[4] { C0, C1, C2, C3 };

            for (int i = 0; i < 4; i++)
            {
                block[i] = block[i] == uint.MaxValue ? block[i] : (c[i] * block[i]) % uint.MaxValue;
            }

            if ((block[0] & 1) == 1)
            {
                block[0] ^= C;
            }

            if ((block[2] & 1) == 0)
            {
                block[2] ^= C;
            }

            for (int i = 0; i < 4; i++)
            {
                block[i] = (block[mod(i-1, 4)]) ^ ( block[i] ) ^ (block[(i+1) % 4]); 
            }
        }

        public byte[] Decode(byte[] encodedData, uint[] key)
        {
            if (encodedData == null)
            {
                throw new ArgumentNullException(nameof(encodedData));
            }
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }


            var intData = new List<uint>();
            for (int i = 0; i < encodedData.Length; i += 4)
            {
                intData.Add(CreateInt(encodedData, i));
            }

            while (intData.Count % 4 != 0)
            {
                intData.Add(0);
            }

            var intDataArray = intData.ToArray();
            for (int i = 0; i < intDataArray.Length; i += 4)
            {
                uint[] block2 = new uint[4] { intDataArray[i], intDataArray[i + 1], intDataArray[i + 2], intDataArray[i + 3] };

                DecodeBlock(block2, key);

                intDataArray[i] = block2[0];
                intDataArray[i + 1] = block2[1];
                intDataArray[i + 2] = block2[2];
                intDataArray[i + 3] = block2[3];
            }

            return WriteBytes(intDataArray);
        }

        private void DecodeBlock(uint[] block, uint[] key)
        {
            for (int i = 0; i < 4; i++)
            {
                block[i] ^= key[(i + 2) % 4];
            }

            for (int j = 5; j >=0 ; j--)
            {
                fReverse(block);

                for (int i = 0; i < 4; i++)
                {
                    block[i] ^= key[(i + j) % 4];
                }

            }
        }

        private void fReverse(uint[] block)
        {
            const uint C = 0x2aaaaaaa;
            const uint C0 = 0x0dad4694;
            const uint C1 = 0x06d6a34a;
            const uint C2 = 0x81b5a8d2;
            const uint C3 = 0x281b5a8d;

            uint[] c = new uint[4] { C0, C1, C2, C3 };

            for (int i = 0; i < 4; i++)
            {
                block[i] = (block[mod(i - 1, 4)]) ^ (block[i]) ^ (block[(i + 1) % 4]);
            }

            if ((block[0] & 1) == 1)
            {
                block[0] ^= C;
            }

            if ((block[2] & 1) == 0)
            {
                block[2] ^= C;
            }

            for (int i = 0; i < 4; i++)
            {
                block[i] = block[i] == uint.MaxValue ? block[i] : (c[i] * block[i]) % uint.MaxValue;
            }

        }

    }
}

