using System;
using StreamLabsDotNet.Client.Models;

namespace StreamLabs_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamLabs streamLabs = new StreamLabs("YOUR SOCKET TOKEN!");
            streamLabs.Connect();

            streamLabs.OnDonation += ShowDonation;

            Console.ReadLine();
        }

        private static void ShowDonation(StreamLabs sender, StreamlabsEvent<DonationMessage> donationData)
        {
            for (int i = 0; i < donationData.Message.Length; i++)
            {
                Console.WriteLine($"{donationData.Message[i].From} made a donation of {donationData.Message[i].FormattedAmount}");
            }
        }
    }
}
