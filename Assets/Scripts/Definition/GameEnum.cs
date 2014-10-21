using UnityEngine;
using System.Collections;

public class GameEnum
{
    public enum State
    {
        Run,
        Warning,
        Error,
    }

    public enum Stage : int
    {
        DataCenter,

        ServerModule,
        Rack,
        Server,
        Switch,

        ACModule,

        PowerModule,
    }

    public enum GuideStage : int
    {
        //container
        SelectContainer = 1,
        ConfirmContainerCreation = 2,

        ClickContainerOptTab = 3,
        SelectOptionContainer = 4,
        ConfirmOptContainerCreation = 5,

        ClickToRoomContentStage = 6,

        //rack
        DragToSetRackQty = 7,
        SelectRack = 8,
        DragRackPos = 9,
        ConfirmRackCreation = 10,

        ClickRoomOptTab = 11,
        SelectAC = 12,
        ConfirmACCreation = 13,

        ClickToRackContentStage = 14,

        //switch & server
        DragToSetSwitchQty = 15,
        SelectSwitch = 16,
        DragSwitchPos = 17,
        ConfirmSwitchCreation = 18,

        ClickServerTab = 19,
        DragToSetServerQty = 20,
        SelectServer = 21,
        DragServerPos = 22,
        ConfirmServerCreation = 23,

        ClickToSwitchContentStage = 24,
        SwipeServerToLink,
        TrainingFinished,
    }

    public enum Category
    {
        None,

        ServerModule,
        OutsideOption,

        Rack,
        InsideOption,

        Switch,
        Server,
        Storage,

        CPU,
        Memory,
        NIC,
    }

    public enum OptionCategory : int
    {
        BatteryCabinet = 0,
        PDFCabinet = 1,
        UPSCabinet = 2,
        PDBCabinet = 3,
        WaterColdedCabinet = 4,
        FireExtinguisher = 5,
        ACModule = 6,
        FingerLocker = 7,
        ControlComputer = 8,
        OutDoorACModule = 9,
        OutDoorPowerModule = 10,
        None = 11,
    }

    public enum DiagramType
    {
        PUE,
        MAP,
        HELP,
        Topology,
        NONE,
    }
}
