namespace tunagu
{
    internal class RoomAP
    {
        public string RoomName { get; }
        public string APName { get; }

        public RoomAP(string roomName, string APName)
        {
            this.RoomName = roomName;
            this.APName = APName;
        }
    }
}
