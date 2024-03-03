using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

using Library;
using Library.Sockets;

namespace Test_SocketClient
{
    public class CRobot_YASKAWA : SocketClient, IRobot
    {
        #region 필드

        private readonly object _LockObject = new object();

        private readonly byte[] padding = { 0x00 };

        // ACK by RobotControl, RobotCommand
        private readonly byte[] _ACK = { 0x59, 0x45, 0x52, 0x43, 0x20, 0x00, 0x00, 0x00, 0x03, 0x01, 0x01, 0x00, 0x00, 0x00, 0x00, 0x80, 0x39, 0x39, 0x39, 0x39, 0x39, 0x39, 0x39, 0x39, 0xB4, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

        #endregion

        #region 메서드

        private bool GetLogEnabled_Process()
        {
            bool result = false;
            try
            {
                //result = GlobalVariable.Parameter[(int)e_Parameter.Robot][Const.String.KEY][(int)e_Parameter_Robot.LogEnabled_Process] == e_ComboBox_Use.Use.ToString();

                result = true; // TODO
            }
            catch
            {
            }
            return result;
        }

        private byte[] MakeCommand(e_RobotControl control)
        {
            byte[] result = YaskawaWriteDataHeaderModel.ConstructWriteDataHeader();
            try
            {
                byte[] stream = new byte[] { (byte)control, 0x00, 0x00 };
                byte[] repeat = padding;

                result = result
                .Concat(stream)
                .Concat(repeat)
                .Concat(padding)
                .Concat(padding)
                .ToArray();
            }
            catch (Exception ex)
            {
                LogWrite(MethodBase.GetCurrentMethod().Name, Utility.GetString(ex));
            }
            return result;
        }
        private byte[] MakeCommand(e_RobotCommand command, bool syrupUsed, e_Door door, string productCode, e_ComboBox_Cup cup, bool capUsed, ref byte DATA2, ref byte DATA3)
        {
            byte[] result = YaskawaWriteDataHeaderModel.ConstructWriteDataHeader();
            try
            {
                DATA2 = GetDATA2(command, syrupUsed, door);
                DATA3 = GetDATA3(productCode, cup, capUsed);

                byte[] stream = new byte[] { 0x00, DATA2, DATA3 };
                byte[] repeat = new byte[] { DATA2 };

                result = result
                .Concat(stream)
                .Concat(repeat)
                .Concat(padding)
                .Concat(padding)
                .ToArray();
            }
            catch (Exception ex)
            {
                LogWrite(MethodBase.GetCurrentMethod().Name, Utility.GetString(ex));
            }
            return result;
        }
        private byte GetDATA2(e_RobotCommand command, bool syrupUsed, e_Door door)
        {
            byte result = 0x00;
            try
            {
                switch (command)
                {
                    case e_RobotCommand.Make_Coffee_Start:   result |= 0x01; break;
                    case e_RobotCommand.Ice_Complete:        result |= 0x02; break;
                    case e_RobotCommand.Make_Coffee_Finish:  result |= 0x04; break;
                    case e_RobotCommand.Syrup_Complete:      result |= 0x10; break;


                    case e_RobotCommand.Door:
                        switch (door)
                        {
                            case e_Door.Door_1: result |= 0x40; break;
                            case e_Door.Door_2: result |= 0x80; break;
                            case e_Door.Door_3: result |= 0xC0; break;
                        }
                        break;
                }

                if (syrupUsed)
                {
                    result |= 0x08;
                }
            }
            catch (Exception ex)
            {
                LogWrite(MethodBase.GetCurrentMethod().Name, Utility.GetString(ex));
            }
            return result;
        }
        private byte GetDATA3(string productCode, e_ComboBox_Cup cup, bool capUsed)
        {
            byte result = 0x00;
            try
            {
                string binary = Utility.ConvertDecimalToBinary(Convert.ToInt32(productCode.Substring(0, 2)));
                result = Utility.ConvertBinaryToByte(binary);

                switch (cup)
                {
                    case e_ComboBox_Cup.Paper: result |= 0x20; break;
                    case e_ComboBox_Cup.Trans: result |= 0x40; break;
                }

                if (capUsed)
                {
                    result |= 0x80;
                }
            }
            catch (Exception ex)
            {
                LogWrite(MethodBase.GetCurrentMethod().Name, Utility.GetString(ex));
            }
            return result;
        }

        public bool GetStatus(ref byte[] bytes)
        {
            lock (_LockObject)
            {
                bool result = false;
                try
                {
                    if (SendTo(YaskawaReadDataModels.ConstructReadData(), MethodBase.GetCurrentMethod().Name, GetLogEnabled_Process()))
                    {
                        byte[] ack = null;

                        if (ReceiveFrom(ref ack, MethodBase.GetCurrentMethod().Name, GetLogEnabled_Process()))
                        {
                            if (ack.Length >= 42)
                            {
                                bytes = new byte[3];

                                bytes[0] = ack[36];
                                bytes[1] = ack[37];
                                bytes[2] = ack[38];

                                result = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogWrite(MethodBase.GetCurrentMethod().Name, Utility.GetString(ex));
                }
                return result;
            }
        }

        public bool RobotControl(e_RobotControl control)
        {
            lock (_LockObject)
            {
                bool result = false;
                try
                {
                    if (SendTo(MakeCommand(control), MethodBase.GetCurrentMethod().Name))
                    {
                        byte[] ack = null;

                        if (ReceiveFrom(ref ack, MethodBase.GetCurrentMethod().Name))
                        {
                            result = ack.Length == _ACK.Length;

                            if (result)
                            {
                                for (int i = 0; i < ack.Length; i++)
                                {
                                    result = ack[i] == _ACK[i];

                                    if (result == false)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogWrite(MethodBase.GetCurrentMethod().Name, Utility.GetString(ex));
                }
                return result;
            }
        }

        public bool RobotCommand(e_RobotCommand command, bool syrupUsed, e_Door door, string productCode, e_ComboBox_Cup cup, bool capUsed)
        {
            lock (_LockObject)
            {
                bool result = false;
                try
                {
                    byte DATA2 = byte.MinValue;
                    byte DATA3 = byte.MinValue;

                    if (SendTo(MakeCommand(command, syrupUsed, door, productCode, cup, capUsed, ref DATA2, ref DATA3), MethodBase.GetCurrentMethod().Name))
                    {
                        byte[] ack = null;

                        if (ReceiveFrom(ref ack, MethodBase.GetCurrentMethod().Name))
                        {
                            result = ack.Length == _ACK.Length;

                            if (result)
                            {
                                for (int i = 0; i < ack.Length; i++)
                                {
                                    result = ack[i] == _ACK[i];

                                    if (result == false)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogWrite(MethodBase.GetCurrentMethod().Name, Utility.GetString(ex));
                }
                return result;
            }
        }

        #endregion
    }

    public struct YaskawaCommonDataModel
    {
        public static readonly byte[] YERC = { 0x59, 0x45, 0x52, 0x43 };                                // Byte 0 to 3
        public static readonly byte[] HEADER_PART_SIZE = { 0x20, 0x00 };                                // Byte 4 to 5
        public static readonly byte[] RESERVED_1 = { 0x03 };                                            // Byte 8
        public static readonly byte[] BLOCK_NUMBER = { 0x00, 0x00, 0x00, 0x00 };                        // Byte 12 to 15
        public static readonly byte[] RESERVED_2 = { 0x39, 0x39, 0x39, 0x39, 0x39, 0x39, 0x39, 0x39 };  // Byte 16 to 23
        public static readonly byte[] SERVICE_ANSWER = { 0x00 };                                        // Byte 30
        public static readonly byte[] STATUS = { 0x00 };                                                // Byte 31
    }

    public static class YaskawaReadDataModels
    {
        #region Read Data Fields
        public static byte[] DataPartSize { get; set; } = { 0x04, 0x00 };       // Byte 6 to 7
        public static byte[] ProcessingDivision { get; set; } = { 0x01 };       // Byte 9
        public static byte[] ACK { get; set; } = { 0x00 };                      // Byte 10
        public static byte[] RequestID { get; set; } = { 0x00 };                // Byte 11
        public static byte[] Command { get; set; } = { 0x00, 0x03 };            // Byte 24 to 25
        public static byte[] Instance { get; set; } = { 0x75, 0x0E };           // Byte 26 to 27
        public static byte[] Attribute { get; set; } = { 0x00 };                // Byte 28
        public static byte[] ServiceRequest { get; set; } = { 0x33 };           // Byte 29
        public static byte[] AddedStatusSize { get; set; } = { 0x06 };          // Byte 32
        public static byte[] AddedStatus { get; set; } = { 0x00, 0x00 };        // Byte 33 to 34
        public static byte[] Padding { get; set; } = { 0x00 };                  // Byte 35
        #endregion

        /// <summary>
        /// Constructs Read Data 
        /// </summary>
        /// <returns>Byte array of read data stream</returns>
        public static byte[] ConstructReadData()
        {
            byte[] readData = YaskawaCommonDataModel.YERC
                .Concat(YaskawaCommonDataModel.HEADER_PART_SIZE)
                .Concat(DataPartSize)
                .Concat(YaskawaCommonDataModel.RESERVED_1)
                .Concat(ProcessingDivision)
                .Concat(ACK)
                .Concat(RequestID)
                .Concat(YaskawaCommonDataModel.BLOCK_NUMBER)
                .Concat(YaskawaCommonDataModel.RESERVED_2)
                .Concat(Command)
                .Concat(Instance)
                .Concat(Attribute)
                .Concat(ServiceRequest)
                .Concat(YaskawaCommonDataModel.SERVICE_ANSWER)
                .Concat(YaskawaCommonDataModel.STATUS)
                .Concat(AddedStatusSize)
                .Concat(AddedStatus)
                .Concat(Padding)
                .ToArray();

            return readData;
        }
    }

    public static class YaskawaWriteDataHeaderModel
    {
        #region Write Data Header Fields
        public static byte[] DataPartSize { get; set; } = { 0x0A, 0x00 };       // Byte 6 to 7
        public static byte[] ProcessingDivision { get; set; } = { 0x01 };       // Byte 9
        public static byte[] ACK { get; set; } = { 0x00 };                      // Byte 10
        public static byte[] RequestID { get; set; } = { 0x00 };                // Byte 11
        public static byte[] Command { get; set; } = { 0x00, 0x03 };            // Byte 24 to 25
        public static byte[] Instance { get; set; } = { 0x8D, 0x0A };           // Byte 26 to 27
        public static byte[] Attribute { get; set; } = { 0x00 };                // Byte 28
        public static byte[] ServiceRequest { get; set; } = { 0x34 };           // Byte 29
        public static byte[] AddedStatusSize { get; set; } = { 0x06 };          // Byte 32
        public static byte[] AddedStatus { get; set; } = { 0x00, 0x00 };        // Byte 33 to 34
        public static byte[] Padding { get; set; } = { 0x00 };                  // Byte 35
        #endregion

        /// <summary>
        /// Construct Wriate Data Header According to YASKAWA protocol
        /// </summary>
        /// <returns>Byte array containint the data stream</returns>
        public static byte[] ConstructWriteDataHeader()
        {
            byte[] readData = YaskawaCommonDataModel.YERC
                .Concat(YaskawaCommonDataModel.HEADER_PART_SIZE)
                .Concat(DataPartSize)
                .Concat(YaskawaCommonDataModel.RESERVED_1)
                .Concat(ProcessingDivision)
                .Concat(ACK)
                .Concat(RequestID)
                .Concat(YaskawaCommonDataModel.BLOCK_NUMBER)
                .Concat(YaskawaCommonDataModel.RESERVED_2)
                .Concat(Command)
                .Concat(Instance)
                .Concat(Attribute)
                .Concat(ServiceRequest)
                .Concat(YaskawaCommonDataModel.SERVICE_ANSWER)
                .Concat(YaskawaCommonDataModel.STATUS)
                .Concat(AddedStatusSize)
                .Concat(AddedStatus)
                .Concat(Padding)
                .ToArray();

            return readData;
        }
    }
}
