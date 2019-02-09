using System;
using StreamLabsDotNet.Client;

namespace StreamLabs_CSharp
{
    class StreamLabs
    {
        private string socketToken = "";
        private Client streamLabsClient;

        public Action<StreamLabs, StreamLabsDotNet.Client.Models.StreamlabsEvent<StreamLabsDotNet.Client.Models.DonationMessage>> OnDonation;

        public StreamLabs(string token)
        {
            socketToken = token;
        }

        public void Connect()
        {
            Console.WriteLine("Connecting to StreamLabs...");

            streamLabsClient = new Client();
            streamLabsClient.Connect(socketToken);

            streamLabsClient.OnConnected += StreamLabsClient_OnConnected;
            streamLabsClient.OnError += StreamLabsClient_OnError;
            streamLabsClient.OnDonation += StreamLabsClient_OnDonation;
            streamLabsClient.OnDisconnected += StreamLabsClient_OnDisconnected;
        }
        public void Disconnect()
        {
            Console.WriteLine("Disconnecting from StreamLabs...");
            streamLabsClient.Disconnect();
        }
        
        private void StreamLabsClient_OnConnected(object sender, bool e)
        {
            Console.WriteLine($"StreamLabs - " + (e ? "Connected!" : "Fail!"));
        }
        private void StreamLabsClient_OnError(object sender, string e)
        {
            Console.WriteLine("StreamLabs - Error!! " + e);
        }
        private void StreamLabsClient_OnDonation(object sender, StreamLabsDotNet.Client.Models.StreamlabsEvent<StreamLabsDotNet.Client.Models.DonationMessage> e)
        {
            Console.WriteLine("StreamLabs - Donation Received!");
            OnDonation(this, e);
        }
        private void StreamLabsClient_OnDisconnected(object sender, bool e)
        {
            Console.WriteLine("StreamLabs - Disconnected!");
        }
    }
}
