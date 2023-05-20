//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Moveit
{
    [Serializable]
    public class MotionSequenceItemMsg : Message
    {
        public const string k_RosMessageName = "moveit_msgs/MotionSequenceItem";
        public override string RosMessageName => k_RosMessageName;

        //  The plan request for this item.
        //  It is the planning request for this segment of the sequence, as if it were a solitary motion.
        public MotionPlanRequestMsg req;
        //  To blend between sequence items, the motion may be smoothed using a circular motion.
        //  The blend radius of the circle between this and the next command, where 0 means no blending.
        public double blend_radius;

        public MotionSequenceItemMsg()
        {
            this.req = new MotionPlanRequestMsg();
            this.blend_radius = 0.0;
        }

        public MotionSequenceItemMsg(MotionPlanRequestMsg req, double blend_radius)
        {
            this.req = req;
            this.blend_radius = blend_radius;
        }

        public static MotionSequenceItemMsg Deserialize(MessageDeserializer deserializer) => new MotionSequenceItemMsg(deserializer);

        private MotionSequenceItemMsg(MessageDeserializer deserializer)
        {
            this.req = MotionPlanRequestMsg.Deserialize(deserializer);
            deserializer.Read(out this.blend_radius);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.req);
            serializer.Write(this.blend_radius);
        }

        public override string ToString()
        {
            return "MotionSequenceItemMsg: " +
            "\nreq: " + req.ToString() +
            "\nblend_radius: " + blend_radius.ToString();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize);
        }
    }
}
