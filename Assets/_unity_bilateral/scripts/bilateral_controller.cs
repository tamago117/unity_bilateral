using UnityEngine;
using RosMessageTypes.Std;
using Unity.Robotics.ROSTCPConnector;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;

public class bilateral_controller : MonoBehaviour
{
    [System.Serializable]
    public class ArticulationInfo
    {
        public ArticulationBody articulationBody;
        public string controlTopic;
        public string publishTopic;

        private ROSConnection ros;
        private float stiffness;
        private float damping;
        private float forceLimit;

        public void setConfig(ROSConnection ros, float stiffness, float damping, float forceLimit)
        {
            this.ros = ros;
            this.stiffness = stiffness;
            this.damping = damping;
            this.forceLimit = forceLimit;

            this.ros.RegisterPublisher<Float64Msg>(publishTopic);
        }

        public void Subscribe()
        {
            this.ros.Subscribe<Float64Msg>(controlTopic, UpdateArticulation);
        }

        public void Publish()
        {
            Float64Msg msg = new Float64Msg(articulationBody.jointPosition[0] * Mathf.Rad2Deg);
            this.ros.Publish(publishTopic, msg);
        }

        // ROSからメッセージが来たときの処理
        void UpdateArticulation(Float64Msg message)
        {
            // ROSから受け取った値をラジアンに変換
            float targetAngle = (float)message.data;

            // ArticulationBodyの目標角度を設定
            ArticulationDrive drive = articulationBody.xDrive;
            drive.target = targetAngle;
            drive.stiffness = stiffness;
            drive.damping = damping;
            drive.forceLimit = forceLimit;
            articulationBody.xDrive = drive;
        }
    }

    public ArticulationInfo[] articulationInfos;
    public float stiffness = 10000f;
    public float damping = 0f;
    public float forceLimit = 1000f;

    private ROSConnection ros;

    void Start()
    {
        // ROS接続の設定
        ros = ROSConnection.instance;

        // ROSトピックの購読
        for (int i = 0; i < articulationInfos.Length; i++)
        {
            articulationInfos[i].setConfig(ros, stiffness, damping, forceLimit);
            articulationInfos[i].Subscribe();
        }
    }

    void Update()
    {
        // 各ArticulationBodyの現在の角度をpublish
        for (int i = 0; i < articulationInfos.Length; i++)
        {
            articulationInfos[i].Publish();
        }
    }
}



/*
public class bilateral_controller : MonoBehaviour
{

    public ArticulationBody[] articulationBodies;
    public string[] topicNames = {"/articulation_controller1", "/articulation_controller2", "/articulation_controller3"};
    public string[] publishTopicNames = {"/articulation_angle1", "/articulation_angle2", "/articulation_angle3"};
    public float stiffness = 10000f;
    public float damping = 0f;
    public float forceLimit = 1000f;

    private ROSConnection ros;

    // Start is called before the first frame update
    void Start()
    {
        // ROS接続の設定
        ros = ROSConnection.instance;

        // ROSトピックの購読
        for (int i = 0; i < articulationBodies.Length; i++)
        {
            ros.Subscribe<Float64Msg>(topicNames[i], data => UpdateArticulation(data, i));
            ros.RegisterPublisher<Float64Msg>(publishTopicNames[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 各ArticulationBodyの現在の角度をpublish
        for (int i = 0; i < articulationBodies.Length; i++)
        {
            Float64Msg msg = new Float64Msg(articulationBodies[i].jointPosition[0] * Mathf.Rad2Deg);
            ros.Publish(publishTopicNames[i], msg);
        }
    }

    // ROSからメッセージが来たときの処理
    void UpdateArticulation(Float64Msg message, int index)
    {
        if(index >= articulationBodies.Length){
            Debug.Log("index is out of range" + index + "message: " + message.data);
            return;
        }
        Debug.Log(index + ": " + message.data);
        // ROSから受け取った値をラジアンに変換
        float targetAngle = (float)message.data * Mathf.Deg2Rad;

        // ArticulationBodyの目標角度を設定
        ArticulationDrive drive = articulationBodies[index].xDrive;
        drive.target = targetAngle;
        drive.stiffness = stiffness;
        drive.damping = damping;
        drive.forceLimit = forceLimit;
        articulationBodies[index].xDrive = drive;
    }
}
*/