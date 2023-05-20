//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.NiryoOne
{
    [Serializable]
    public class ToolGoal : Message
    {
        public const string k_RosMessageName = "niryo_one_msgs/Tool";
        public override string RosMessageName => k_RosMessageName;

        //  goal
        public ToolCommandMsg cmd;

        public ToolGoal()
        {
            this.cmd = new ToolCommandMsg();
        }

        public ToolGoal(ToolCommandMsg cmd)
        {
            this.cmd = cmd;
        }

        public static ToolGoal Deserialize(MessageDeserializer deserializer) => new ToolGoal(deserializer);

        private ToolGoal(MessageDeserializer deserializer)
        {
            this.cmd = ToolCommandMsg.Deserialize(deserializer);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.cmd);
        }

        public override string ToString()
        {
            return "ToolGoal: " +
            "\ncmd: " + cmd.ToString();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize, MessageSubtopic.Goal);
        }
    }
}