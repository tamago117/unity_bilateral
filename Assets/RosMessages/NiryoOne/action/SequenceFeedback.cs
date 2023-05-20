//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.NiryoOne
{
    [Serializable]
    public class SequenceFeedback : Message
    {
        public const string k_RosMessageName = "niryo_one_msgs/Sequence";
        public override string RosMessageName => k_RosMessageName;

        //  feedback

        public SequenceFeedback()
        {
        }
        public static SequenceFeedback Deserialize(MessageDeserializer deserializer) => new SequenceFeedback(deserializer);

        private SequenceFeedback(MessageDeserializer deserializer)
        {
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
        }

        public override string ToString()
        {
            return "SequenceFeedback: ";
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize, MessageSubtopic.Feedback);
        }
    }
}
