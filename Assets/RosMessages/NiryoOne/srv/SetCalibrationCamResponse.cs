//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.NiryoOne
{
    [Serializable]
    public class SetCalibrationCamResponse : Message
    {
        public const string k_RosMessageName = "niryo_one_msgs/SetCalibrationCam";
        public override string RosMessageName => k_RosMessageName;

        public int status;
        public const int SUCCESSFULLY_SET = 0;
        public const int OVERWRITTEN = 1;
        public const int NOT_SET = -1;

        public SetCalibrationCamResponse()
        {
            this.status = 0;
        }

        public SetCalibrationCamResponse(int status)
        {
            this.status = status;
        }

        public static SetCalibrationCamResponse Deserialize(MessageDeserializer deserializer) => new SetCalibrationCamResponse(deserializer);

        private SetCalibrationCamResponse(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.status);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.status);
        }

        public override string ToString()
        {
            return "SetCalibrationCamResponse: " +
            "\nstatus: " + status.ToString();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize, MessageSubtopic.Response);
        }
    }
}