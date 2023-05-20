//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Moveit
{
    [Serializable]
    public class GetMotionPlanResponse : Message
    {
        public const string k_RosMessageName = "moveit_msgs/GetMotionPlan";
        public override string RosMessageName => k_RosMessageName;

        public MotionPlanResponseMsg motion_plan_response;

        public GetMotionPlanResponse()
        {
            this.motion_plan_response = new MotionPlanResponseMsg();
        }

        public GetMotionPlanResponse(MotionPlanResponseMsg motion_plan_response)
        {
            this.motion_plan_response = motion_plan_response;
        }

        public static GetMotionPlanResponse Deserialize(MessageDeserializer deserializer) => new GetMotionPlanResponse(deserializer);

        private GetMotionPlanResponse(MessageDeserializer deserializer)
        {
            this.motion_plan_response = MotionPlanResponseMsg.Deserialize(deserializer);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.motion_plan_response);
        }

        public override string ToString()
        {
            return "GetMotionPlanResponse: " +
            "\nmotion_plan_response: " + motion_plan_response.ToString();
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