using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CommonLibrarySharp.HardWareDog
{
    public unsafe class DogDLl
    {

        public uint DogBytes, DogAddr;
        public byte[] DogData;
        public uint Retcode;

        [DllImport("Win32dll.dll", CharSet = CharSet.Ansi)]
        public static unsafe extern uint DogRead(uint idogBytes, uint idogAddr, byte* pdogData);
        [DllImport("Win32dll.dll", CharSet = CharSet.Ansi)]
        public static unsafe extern uint DogWrite(uint idogBytes, uint idogAddr, byte* pdogData);

        public unsafe DogDLl(ushort num)
        {
            DogBytes = num;
            DogData = new byte[DogBytes];
        }

        public unsafe void ReadDog()
        {
            fixed (byte* pDogData = &DogData[0])
            {
                Retcode = DogRead(DogBytes, DogAddr, pDogData);
            }
        }
        public unsafe void WriteDog()
        {
            fixed (byte* pDogData = &DogData[0])
            {
                Retcode = DogWrite(DogBytes, DogAddr, pDogData);
            }
        }
        public static bool HasDog()
        {
            DogDLl dog = new DogDLl(100);
            try
            {
                dog.DogAddr = 0;
                dog.DogBytes = 0;

                dog.ReadDog();

                if (dog.Retcode == 0)		//Success
                {
 
                    return true;
                }
                else
                {
                    MessageBox.Show(string.Format("Unable to find dog,Error Code:{0}!", dog.Retcode), "未找到加密狗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to find dog :" + ex.Message.ToString(), "未找到加密狗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
